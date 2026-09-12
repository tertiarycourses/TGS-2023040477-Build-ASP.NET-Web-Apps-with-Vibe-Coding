# Activity 9: Prepare an Azure-Ready Release

**Course:** Build ASP.NET Web Apps with Vibe Coding (TGS-2023040477)
**Alignment:** LO5 · K5/A5
**Duration:** 60 minutes
**Runnable snapshot:** `src/LocalCRM`

## Goal

Create a production-neutral publish artifact with validated configuration, health endpoints and smoke evidence.

## What you will produce

Release publish directory, health checks, deployment configuration matrix and smoke-test script

## Safety and data boundary

Use only the supplied fictional records in `mock-data/`. Do not paste personal, customer, credential, or production data into an AI tool. Review every generated diff before running it.

## Vibe script

> Prepare LocalCRM for Azure App Service without performing a live deployment. Add validated typed options, /health/live and /health/ready, structured startup logging, and a bash smoke script. Do not add credentials, an Azure resource or a portal-only step.

## Step-by-step

### Step 1 — Define the configuration contract

Add AppOptions with required SupportEmail and public feature flags; bind and ValidateOnStart.

### Step 2 — Add health checks

Map liveness and database readiness separately so operators can distinguish process from dependency health.

### Step 3 — Review production settings

Create docs/deployment-configuration.md naming each key, owner, source and slot-sticky decision. Never place a live value in the table.

### Step 4 — Publish Release

Build an environment-neutral artifact.

```bash
dotnet publish LocalCRM/LocalCRM.csproj -c Release -o publish
```

### Step 5 — Inspect the artifact

Confirm assemblies and static content exist, while source, .git and local database do not.

```bash
find publish -maxdepth 2 -type f | sort
find publish -name '*.db' -o -name '.git'
```

### Step 6 — Run from publish only

Start the compiled DLL on port 8080 with a safe required setting.

```bash
App__SupportEmail=support@example.test ASPNETCORE_URLS=http://localhost:8080 dotnet publish/LocalCRM.dll
```

### Step 7 — Create smoke-test script

Probe liveness, readiness, list and one invalid create. Make the script exit non-zero on a mismatch.

### Step 8 — Capture evidence

Run the smoke script and record build SHA, publish file hash and observed statuses.

```bash
sh activities/activity-09-production-readiness/assets/smoke.sh http://localhost:8080
shasum -a 256 publish/LocalCRM.dll
```

### Step 9 — Model Azure resources

Document resource group, App Service plan, web app, settings, identity, database and monitoring boundaries; do not claim deployment occurred.

## Run the supplied snapshot

The Activity folder already contains a complete stage-appropriate ASP.NET Core project and mock data. From this Activity folder:

```bash
cd src/LocalCRM
dotnet restore
dotnet run --urls http://localhost:5109
```

Open `http://localhost:5109`. For Activities 7–10, also probe `http://localhost:5109/api/contacts`; for Activities 8–10, probe `/openapi/v1.json` and `/health/ready`.

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

1. Explain how the evidence demonstrates LO5 and K5/A5.
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
