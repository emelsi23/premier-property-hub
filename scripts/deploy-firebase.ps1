# Manual deploy: Cloud Run + Firebase Hosting
# Prerequisites: gcloud CLI, firebase CLI, Docker, Blaze plan on Firebase
#
# Usage:
#   $env:GCP_PROJECT_ID = "tu-proyecto"
#   $env:DATABASE_URL = "postgresql://..."
#   .\scripts\deploy-firebase.ps1

$ErrorActionPreference = "Stop"

$ProjectId = $env:GCP_PROJECT_ID
$DatabaseUrl = $env:DATABASE_URL
$Region = "us-central1"
$Service = "premier-property-hub"
$Repository = "premier-property-hub"

if ([string]::IsNullOrWhiteSpace($ProjectId)) {
    throw "Set GCP_PROJECT_ID to your Firebase / Google Cloud project id."
}

if ([string]::IsNullOrWhiteSpace($DatabaseUrl)) {
    throw "Set DATABASE_URL to your PostgreSQL connection string (Neon, Supabase, etc.)."
}

gcloud config set project $ProjectId

gcloud services enable run.googleapis.com artifactregistry.googleapis.com cloudbuild.googleapis.com firebasehosting.googleapis.com

gcloud artifacts repositories describe $Repository --location=$Region 2>$null
if ($LASTEXITCODE -ne 0) {
    gcloud artifacts repositories create $Repository `
        --repository-format=docker `
        --location=$Region `
        --description="Premier Property Hub"
}

$Image = "$Region-docker.pkg.dev/$ProjectId/$Repository/app:latest"

gcloud auth configure-docker "$Region-docker.pkg.dev" --quiet

docker build -t $Image .
docker push $Image

gcloud run deploy $Service `
    --image $Image `
    --region $Region `
    --platform managed `
    --allow-unauthenticated `
    --port 8080 `
    --memory 512Mi `
    --cpu 1 `
    --max-instances 3 `
    --set-env-vars "ASPNETCORE_ENVIRONMENT=Production,DATABASE_URL=$DatabaseUrl"

if (-not (Test-Path ".firebaserc")) {
    Copy-Item ".firebaserc.example" ".firebaserc"
    (Get-Content ".firebaserc") -replace "TU-PROYECTO-FIREBASE", $ProjectId | Set-Content ".firebaserc"
}

firebase deploy --only hosting --project $ProjectId

Write-Host ""
Write-Host "Done. Open your Firebase Hosting URL from:"
Write-Host "https://console.firebase.google.com/project/$ProjectId/hosting"
