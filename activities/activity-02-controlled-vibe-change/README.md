# Activity 2: Run a Controlled Vibe-Coding Change

**Course:** Build ASP.NET Web Apps with Vibe Coding (TGS-2023040477)
**Alignment:** LO1 · K1/A1
**Duration:** 45 minutes
**Runnable snapshot:** `src/LocalCRM`

## Goal

Add a health endpoint through a specify–generate–inspect–verify loop without accepting unrelated AI edits.

## What you will produce

a reviewed /health endpoint, build evidence and a decision log

## Safety and data boundary

Use only the supplied fictional records in `mock-data/`. Do not paste personal, customer, credential, or production data into an AI tool. Review every generated diff before running it.

## Vibe script

> Modify LocalCRM/Program.cs only. Add GET /health returning HTTP 200 JSON { status: 'ok', service: 'LocalCRM' }. Do not add packages or reorder existing middleware. Explain the exact diff and provide curl acceptance evidence.

## Step-by-step

### Step 1 — Confirm the baseline

Work from the Activity 1 commit and make sure the tree is clean.

```bash
git status --short
dotnet build LocalCRM/LocalCRM.csproj
```

### Step 2 — Submit the constrained prompt

Use the provided prompt with your approved coding assistant. Reject any response that adds packages or edits more than Program.cs.

### Step 3 — Apply the smallest patch

Place the endpoint after app.UseAuthorization() and before app.MapRazorPages().

Create or update `Program.cs excerpt`:

```csharp
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    service = "LocalCRM"
}));

app.MapRazorPages();
```

### Step 4 — Inspect scope

Confirm exactly one source file changed and no package reference was added.

```bash
git diff --stat
git diff -- LocalCRM/Program.cs
git diff -- LocalCRM/LocalCRM.csproj
```

### Step 5 — Build and run

Compile and start the application on the known URL.

```bash
dotnet build LocalCRM/LocalCRM.csproj
dotnet run --project LocalCRM --urls http://localhost:5050
```

### Step 6 — Capture positive evidence

Probe headers and JSON from another terminal.

```bash
curl -i http://localhost:5050/health
```

**Expected evidence:** HTTP 200, application/json, status=ok and service=LocalCRM.

### Step 7 — Capture negative evidence

Probe a misspelled path to prove routing distinguishes unmatched endpoints.

```bash
curl -i http://localhost:5050/healthz
```

**Expected evidence:** HTTP 404.

### Step 8 — Record the decision

Create evidence/activity-02.md with prompt, reviewed files, commands and observed status codes; then commit.

```bash
mkdir -p evidence
git add LocalCRM/Program.cs evidence/activity-02.md
git commit -m 'feat: add verified health endpoint'
```

## Run the supplied snapshot

The Activity folder already contains a complete stage-appropriate ASP.NET Core project and mock data. From this Activity folder:

```bash
cd src/LocalCRM
dotnet restore
dotnet run --urls http://localhost:5102
```

Open `http://localhost:5102`. For Activities 7–10, also probe `http://localhost:5102/api/contacts`; for Activities 8–10, probe `/openapi/v1.json` and `/health/ready`.

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

1. Explain how the evidence demonstrates LO1 and K1/A1.
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
