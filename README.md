# Premier Property Hub (.NET 10)

Web app for real estate teams to share **WhatsApp links** with clients. Each link opens a property page with photos, details, and a booking/application form. Admins manage properties and review submitted appointments.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (Production) PostgreSQL on [Render](https://render.com)

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
| Production  | PostgreSQL | Environment variable `DATABASE_URL` from Render    |

## EF Core migrations

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Deploy on Render

### 1. PostgreSQL

1. [dashboard.render.com](https://dashboard.render.com) → **+ New** → **PostgreSQL**
2. Same region as the web service (e.g. **Oregon**)
3. Use a **paid** plan (Basic) so the database does not expire
4. Wait until status is **Available**

### 2. Web Service

1. **+ New** → **Web Service** → connect GitHub repo `premier-property-hub`
2. **Root Directory:** leave empty if repo root is the app, or set the folder that contains the `Dockerfile`
3. **Runtime:** Docker
4. **Instance type:** Starter or higher (not Free, if you need always-on)

### 3. Link database

1. Open the web service → **Environment**
2. Remove any old `DATABASE_URL` variable
3. **Add Environment Variable** → **Add from database**
4. Select your Postgres service → **Internal Database URL**
5. **Save Changes**

Optional env vars (Render sets `PORT` automatically):

| Variable | Value |
|----------|--------|
| `ASPNETCORE_ENVIRONMENT` | `Production` |

### 4. Deploy

**Manual Deploy** → **Deploy latest commit**

In **Logs** you should see:

```
Database target: PostgreSQL host=...; database=...
Database initialized successfully.
```

Your site URL: `https://premier-property-hub.onrender.com` (or your custom domain).

### Custom domain (Render Pro)

1. Web service → **Settings** → **Custom Domains**
2. Add your domain and configure DNS as Render instructs

### Disconnect other hosts

If you previously connected this repo to **Railway**, **Firebase**, or other platforms, disable auto-deploy there so only Render deploys on push to `master`.

## Project structure

```
Models/                     # Property, Photo, Appointment entities
Data/AppDbContext.cs        # EF Core
Data/DbSeeder.cs            # Sample data
Pages/Property/             # Public property page + thank-you
Pages/Admin/                # Property CRUD + appointments
Services/SlugHelper.cs      # URL slug generation
```
