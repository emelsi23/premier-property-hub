# Premier Property Hub (.NET 10)

Web app for real estate teams to share **WhatsApp links** with clients. Each link opens a property page with photos, details, and a booking/application form. Admins manage properties and review submitted appointments.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (Optional) Docker for container deployment
- (Production) PostgreSQL — Railway, Render, Azure, etc.

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

## Deploy on Railway (recommended to get started)

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

## Deploy on Render

1. New **Web Service** from GitHub.
2. **Root Directory:** `ApartamentosRenta`
3. **Runtime:** Docker (uses the included Dockerfile) or Native .NET.
4. Add PostgreSQL and link `DATABASE_URL`.

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
