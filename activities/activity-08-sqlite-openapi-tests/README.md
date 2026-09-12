# Activity 8: Prove Persistence and Interoperability

**Course:** Build ASP.NET Web Apps with Vibe Coding (TGS-2023040477)
**Alignment:** LO4 · K4/A4
**Duration:** 70 minutes
**Runnable snapshot:** `src/LocalCRM`

## Goal

Replace volatile state with EF Core SQLite, publish an OpenAPI contract and verify components through integration tests.

## What you will produce

SQLite migration, persistent CRUD path, openapi.json and HTTP integration tests

## Safety and data boundary

Use only the supplied fictional records in `mock-data/`. Do not paste personal, customer, credential, or production data into an AI tool. Review every generated diff before running it.

## Vibe script

> Replace InMemoryContactStore with EF Core SQLite behind IContactStore. Add a migration, async cancellation-aware queries, OpenAPI in Development, and WebApplicationFactory tests for 201, 400 and 404. Preserve existing page and API contracts.

## Step-by-step

### Step 1 — Add reviewed packages

Pin compatible .NET 10 package versions rather than accepting an AI-chosen floating version.

```bash
dotnet add LocalCRM package Microsoft.EntityFrameworkCore.Sqlite --version 10.0.12
dotnet add LocalCRM package Microsoft.EntityFrameworkCore.Design --version 10.0.12
dotnet add LocalCRM package Microsoft.AspNetCore.OpenApi --version 10.0.12
```

### Step 2 — Create CrmDbContext

Define ContactEntity with database key and bounded required columns.

### Step 3 — Configure connection

Keep only the local non-secret SQLite path in Development settings.

Create or update `LocalCRM/appsettings.Development.json excerpt`:

```text
{ "ConnectionStrings": { "LocalCRM": "Data Source=localcrm.db" } }
```

### Step 4 — Register EF Core

Use AddDbContext and a scoped SqliteContactStore.

### Step 5 — Create/apply migration

Install or invoke dotnet-ef, inspect generated migration, then apply it.

```bash
dotnet tool install --global dotnet-ef --version 10.0.12
dotnet ef migrations add InitialCreate --project LocalCRM
dotnet ef database update --project LocalCRM
```

### Step 6 — Enable OpenAPI

Register AddOpenApi and map it only in Development.

### Step 7 — Capture the contract

Run the app and save the generated document.

```bash
curl -fsS http://localhost:5050/openapi/v1.json -o evidence/openapi-v1.json
```

**Expected evidence:** Valid JSON with /api/contacts operations and DTO schemas.

### Step 8 — Add integration test project

Create xUnit project, reference LocalCRM and add Microsoft.AspNetCore.Mvc.Testing.

### Step 9 — Test public HTTP behaviour

Use WebApplicationFactory with an isolated SQLite database. Assert status, Location, media type and ProblemDetails shape.

### Step 10 — Verify persistence

Create through API, restart the app and GET the same id.

**Expected evidence:** The row remains after restart and both UI/API read the same store.

## Run the supplied snapshot

The Activity folder already contains a complete stage-appropriate ASP.NET Core project and mock data. From this Activity folder:

```bash
cd src/LocalCRM
dotnet restore
dotnet run --urls http://localhost:5108
```

Open `http://localhost:5108`. For Activities 7–10, also probe `http://localhost:5108/api/contacts`; for Activities 8–10, probe `/openapi/v1.json` and `/health/ready`.

## Run the supplied integration tests

From this Activity folder:

```bash
dotnet test src/LocalCRM.Tests/LocalCRM.Tests.csproj
```

Expected evidence: three tests pass for readiness, JSON collection output and invalid-input ProblemDetails.

## Acceptance checklist

- [ ] The project targets `net10.0` and restores without an unreviewed package.
- [ ] The app starts from this Activity folder without relying on another Activity.
- [ ] The supplied mock contacts are fictional and load as described.
- [ ] Positive and negative paths match the expected status or UI state.
- [ ] The diff contains only intended files and no secret.

## Troubleshooting

- `NETSDK1045`: install a .NET 10 SDK or select the installed 10.0 feature band in `global.json`.
- Address already in use: stop the previous Activity process or use `--urls http://localhost:PORT` with a free port.
- HTTP 404: compare the exact route, method, route constraint and Activity stage.
- HTTP 400/415: inspect ProblemDetails and confirm JSON shape plus `Content-Type: application/json`.
- SQLite failure (Activities 8–10): remove only the local training `localcrm.db`, then restart so the snapshot recreates mock data.

## Reflection and evidence record

1. Explain how the evidence demonstrates LO4 and K4/A4.
2. Name one AI suggestion you rejected or changed and why.
3. Identify one negative path you tested and the observable result.
4. State the next improvement you would make without widening the approved scope.

| Evidence item | Record the path, command result or observation |
|---|---|
| Build or test result |  |
| Runtime URL and HTTP status |  |
| Positive-path evidence |  |
| Negative-path evidence |  |
| Reviewed AI change or rejection |  |
| Commit or evidence reference |  |
