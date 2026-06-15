# Premier Property Hub (.NET 10)

Web app for real estate teams to share **WhatsApp links** with clients. Each link opens a property page with photos, details, and a booking/application form. Admins manage properties and review submitted appointments.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (Optional) Docker for container deployment
- (Production) PostgreSQL — Neon, Supabase, Railway, etc.

## Run locally

```bash
cd ApartamentosRenta
dotnet run
```

Open the URL shown in the console (e.g. `https://localhost:7004`).

- **Property page:** `/property/{slug}` — public client-facing page
- **Admin:** `/Admin` — create, edit, delete properties; view appointments

The first run creates `apartamentos.db` (SQLite) and loads sample data.

## Database

| Environment | Engine     | Configuration                                      |
|-------------|------------|----------------------------------------------------|
| Development | SQLite     | `ConnectionStrings:DefaultConnection` in appsettings |
| Production  | PostgreSQL | Environment variable `DATABASE_URL`                |

Typical `DATABASE_URL` format:

```
postgresql://user:password@host:5432/dbname
```

## EF Core migrations

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Docker deployment

```bash
cd ApartamentosRenta
docker build -t premier-property-hub .
docker run -p 8080:8080 -e DATABASE_URL="postgresql://..." premier-property-hub
```

## Deploy on Firebase + Cloud Run (recommended)

Firebase **Hosting** gives you a fast public URL on Google's CDN. Your .NET app runs in **Cloud Run** (Docker). PostgreSQL stays external (e.g. [Neon](https://neon.tech) free tier — database does not sleep).

> **Important:** Firebase Hosting alone cannot run ASP.NET. The setup below uses Hosting → Cloud Run. Cloud Run free tier can have a **cold start** (~5–15 s) after idle time, similar to Render. The CDN edge is always on; the server wakes on first request. True 24/7 with zero cold start requires a paid min-instances setting on Cloud Run.

### One-time setup

1. Create a [Firebase project](https://console.firebase.google.com) (enable **Blaze** billing — pay-as-you-go, usually $0 within free quotas).
2. Enable APIs: Cloud Run, Artifact Registry, Firebase Hosting.
3. Create a free PostgreSQL database at [Neon](https://neon.tech) and copy the connection string.
4. Copy `.firebaserc.example` → `.firebaserc` and replace `TU-PROYECTO-FIREBASE` with your project id.
5. Create a [Google Cloud service account](https://console.cloud.google.com/iam-admin/serviceaccounts) with roles:
   - Cloud Run Admin
   - Artifact Registry Writer
   - Service Account User
   - Firebase Hosting Admin  
   Download the JSON key.

### GitHub Actions (auto deploy on push to `master`)

Add these repository secrets:

| Secret | Value |
|--------|--------|
| `GCP_PROJECT_ID` | Firebase / GCP project id |
| `GCP_SA_KEY` | Service account JSON (full file) |
| `DATABASE_URL` | `postgresql://...` from Neon |

Push to `master` — workflow builds Docker, deploys Cloud Run, then Firebase Hosting.

### Manual deploy (Windows)

```powershell
cd ApartamentosRenta
$env:GCP_PROJECT_ID = "tu-proyecto-firebase"
$env:DATABASE_URL = "postgresql://user:pass@host/db?sslmode=require"
.\scripts\deploy-firebase.ps1
```

Your site URL will appear in Firebase Console → Hosting (e.g. `https://tu-proyecto.web.app`).

Property page example: `https://tu-proyecto.web.app/property/7025-agate-trail-inver-grove-heights-mn`

## Deploy on Railway

1. Push this repo to GitHub.
2. In [railway.app](https://railway.app), create a project → **Deploy from GitHub**.
3. Add a **PostgreSQL** service.
4. In the web service, configure:
   - **Root directory:** `ApartamentosRenta`
   - **Variable:** `DATABASE_URL` = reference to the PostgreSQL URL
   - **Variable:** `PORT` = `8080` (Railway injects this automatically)
5. Railway detects .NET and deploys. The app applies migrations on startup.

## Deploy on Azure App Service

1. Create App Service with **.NET 10** runtime.
2. Create Azure Database for PostgreSQL.
3. In **Configuration → Connection strings**, add `DATABASE_URL` or use Application Settings.
4. Publish:

```bash
dotnet publish -c Release
# Upload the publish folder with Azure CLI, VS, or GitHub Actions
```

## Project structure

```
Models/                     # Property, Photo, Appointment entities
Data/AppDbContext.cs        # EF Core
Data/DbSeeder.cs            # Sample data
Pages/Property/             # Public property page + thank-you
Pages/Admin/                # Property CRUD + appointments
Services/SlugHelper.cs      # URL slug generation
```

## Suggested next steps

- Add authentication to `/Admin` (ASP.NET Core Identity)
- Upload images to Azure Blob / S3 instead of external URLs
- Contact notifications via email (SendGrid, Resend)
- Custom domain and HTTPS on your hosting provider
