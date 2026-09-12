# Source Map

Course: Build ASP.NET Web Apps with Vibe Coding · TGS-2023040477 · v6.1

## Authority order

1. Course application and current same-course TMS assessment/plan for identity, TSC, LO/K/A and duration.
2. Current Microsoft Learn ASP.NET Core 10 documentation for technical mechanics.
3. Legacy v6.0 trainer deck as the coverage floor, modernised where technology or admin wording changed.
4. Supplied secondary tutorials for supplementary topic discovery only; legacy ASP/Web Forms material is never represented as ASP.NET Core.

## Local authorities

- `reference/WSQ - Master Trainer Slides - Build .ASP.NET Web Apps with Vibe Coding.pptx` — 114-slide legacy v6.0 coverage floor.
- `../course_application/CP_TIPL_ASPNET_v2.1.docx` — approved 2-day/16-hour curriculum and five LO/K/A pairs.
- `reference/tms/assessment-original/` — five WA items K1–K5 and five PP tasks A1–A5, each assessment mode 1 hour.
- `reference/tms/courseware-original/` — current same-course LG, LP, FG and courseware mapping downloaded from Drive.

## Online sources

- [Microsoft Learn — ASP.NET Core 10.0 documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0) — Primary current authority for ASP.NET Core architecture, APIs, hosting, security and deployment.
- [Microsoft Learn — ASP.NET tutorials](https://learn.microsoft.com/en-us/aspnet/tutorials) — Legacy ASP.NET 4.x tutorial index; used only to mark the legacy boundary.
- [Microsoft Learn — ASP.NET Web Forms videos](https://learn.microsoft.com/en-us/aspnet/web-forms/videos/) — Legacy Web Forms lifecycle/control reference; explicitly separated from ASP.NET Core.
- [TutorialsPoint — ASP.NET Tutorial](https://www.tutorialspoint.com/asp.net/index.htm) — Supplementary legacy topic inventory: lifecycle, controls, state, data access and deployment.
- [GeeksforGeeks — ASP.NET Tutorial](https://www.geeksforgeeks.org/c-sharp/asp-net-tutorial/) — Supplementary beginner examples and classic-versus-Core setup comparison.
- [W3Schools — ASP and ASP.NET Tutorials](https://www.w3schools.com/asp/) — Supplementary technology-family distinction; Classic ASP and Web Forms are not ASP.NET Core.
- [Guru99 — ASP.NET Tutorial](https://www.guru99.com/asp-net-tutorial.html) — Supplementary legacy overview; source returned HTTP 403 during the 12 Sep 2026 review, so no unsupported detail was imported.
- [Tpoint Tech — ASP.NET Tutorial](https://www.tpointtech.com/asp-net-tutorial) — Supplementary classic ASP.NET topic index; used only where consistent with Microsoft documentation.

## Legacy-to-current separation

| Supplied legacy topic | Current treatment in v6.1 |
|---|---|
| Classic ASP / `.asp` / VBScript | Historical boundary only; not a current course implementation path. |
| ASP.NET Web Forms / `.aspx` / page lifecycle | Historical comparison only; Web Forms is not part of ASP.NET Core. |
| ASP.NET MVC 5 / System.Web | Distinguished from ASP.NET Core MVC/Razor Pages. |
| ASP.NET Core | Primary course implementation stack, pinned to the .NET 10 documentation view. |
| Visual Studio-only Azure publish | Reframed as a platform-neutral publish artifact plus an Azure App Service design; no live deployment is claimed. |

## Artifact alignment

- Deck: 228 slides; Topic ranges and Activity starts are recorded in `build/slide_map.json`.
- Learner Guide: same five topics plus all detailed Activity steps.
- Lesson Plan: reads the built deck slide map; all teaching rows and Activities cite actual slide ranges.
- Activities: ten numbered self-contained LocalCRM snapshots with identical fictional mock-data schema.
- Assessment traceability: LO1/K1/A1 through LO5/K5/A5 preserved for the assessment-generation workflow.
