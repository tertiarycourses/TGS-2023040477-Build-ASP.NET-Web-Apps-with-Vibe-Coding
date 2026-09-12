# Activity 4: Audit Accessibility with axe and Manual Evidence

**Course:** Build ASP.NET Web Apps with Vibe Coding (TGS-2023040477)
**Alignment:** LO2 · K2/A2
**Duration:** 45 minutes
**Runnable snapshot:** `src/LocalCRM`

## Goal

Create a repeatable automated-plus-manual accessibility gate for the running Razor Pages UI.

## What you will produce

axe JSON evidence, a manual keyboard checklist and a reviewed remediation diff

## Safety and data boundary

Use only the supplied fictional records in `mock-data/`. Do not paste personal, customer, credential, or production data into an AI tool. Review every generated diff before running it.

## Vibe script

> Review the supplied axe findings and the Razor markup. Propose the smallest semantic fix for each confirmed violation. Do not suppress rules. State which outcomes still require manual keyboard or screen-reader checks.

## Step-by-step

### Step 1 — Install the audit runner

Use a project-local npm package so the audit version is recorded.

```bash
mkdir -p tools/a11y && cd tools/a11y
npm init -y
npm install --save-dev @axe-core/cli
```

### Step 2 — Start LocalCRM

Keep the application running at the stable Activity URL.

```bash
dotnet run --project LocalCRM --urls http://localhost:5050
```

### Step 3 — Run axe

From the repository root, scan the Contacts page and save JSON output.

```bash
mkdir -p evidence
npx axe http://localhost:5050/Contacts --save evidence/activity-04-axe.json
```

### Step 4 — Inspect violations

For every violation, open the exact node and confirm it is a real problem before changing code.

### Step 5 — Use the remediation prompt

Provide only the confirmed violation IDs, HTML snippet and allowed files. Reject rule disabling.

### Step 6 — Review and apply

Apply the smallest semantic change. Use native labels/buttons before ARIA and inspect git diff.

### Step 7 — Retest

Run the same URL and save the fixed report separately.

```bash
npx axe http://localhost:5050/Contacts --save evidence/activity-04-axe-fixed.json
```

**Expected evidence:** No critical or serious automated violations.

### Step 8 — Complete manual checks

Record keyboard order, visible focus, heading structure, zoom at 200%, and whether link purpose is clear.

### Step 9 — Commit evidence

Commit reviewed source and non-sensitive evidence only.

```bash
git diff --check
git add LocalCRM evidence/activity-04-axe*.json evidence/activity-04-manual.md
git commit -m 'fix: meet accessible UI gate'
```

## Run the supplied snapshot

The Activity folder already contains a complete stage-appropriate ASP.NET Core project and mock data. From this Activity folder:

```bash
cd src/LocalCRM
dotnet restore
dotnet run --urls http://localhost:5104
```

Open `http://localhost:5104`. For Activities 7–10, also probe `http://localhost:5104/api/contacts`; for Activities 8–10, probe `/openapi/v1.json` and `/health/ready`.

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

1. Explain how the evidence demonstrates LO2 and K2/A2.
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
