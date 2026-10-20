# Build ASP.NET Web Apps with Vibe Coding

[![WSQ Course](https://img.shields.io/badge/WSQ-TGS--2023040477-0B5CAB)](https://www.tertiarycourses.com.sg/wsq-build-asp-net-web-apps-with-vibe-coding.html)
[![ASP.NET Core 10](https://img.shields.io/badge/ASP.NET_Core-10.0-512BD4?logo=dotnet)](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0)
[![SQLite](https://img.shields.io/badge/SQLite-EF_Core-003B57?logo=sqlite)](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/)

Courseware and runnable learner Activities for Tertiary Infotech Academy's two-day WSQ course. Learners progressively build **LocalCRM**, a local ASP.NET Core application that combines Razor Pages, a controller API, validation, accessibility, EF Core, SQLite, OpenAPI, integration tests, health checks, and release documentation.

| Course detail | Information |
|---|---|
| Course code | `TGS-2023040477` |
| Programme | WSQ |
| Duration | 2 days · 16 training hours · 2 assessment hours |
| Registration | [View course details and register](https://www.tertiarycourses.com.sg/wsq-build-asp-net-web-apps-with-vibe-coding.html) |
| Funding | Up to 70% course-fee funding for eligible learners or employers. Eligibility and terms apply; funding is currently listed as valid through 3 December 2027. |

## Course overview

- Course code: `TGS-2023040477`
- Duration: 2 days / 16 training hours, followed by 2 hours of assessment
- Technical Skills and Competencies: Software Design (`ICT-DES-3005-1.1`)
- Delivery stack: .NET 10, ASP.NET Core, C#, Razor Pages, MVC controllers, EF Core, SQLite, OpenAPI, and xUnit
- Course page: [Build ASP.NET Web Apps with Vibe Coding](https://www.tertiarycourses.com.sg/wsq-build-asp-net-web-apps-with-vibe-coding.html)

Eligible Singapore Citizens and Permanent Residents may receive SkillsFuture Singapore funding of up to 70%, subject to current eligibility rules and funding terms. Refer to the course page for the latest fees and conditions.

## Learning outcomes

By the end of the course, learners will be able to:

1. Translate user requirements into an ASP.NET Core solution structure and use a controlled AI-assisted coding workflow.
2. Build an accessible Razor Pages interface using semantic HTML, navigation, labels, and keyboard-visible focus.
3. Implement server-side page handlers, dependency injection, model binding, validation, and antiforgery protection.
4. Create interoperable HTTP APIs backed by EF Core SQLite, OpenAPI, and automated integration tests.
5. Prepare an Azure-ready release with configuration boundaries, health checks, smoke evidence, and traceable design documentation.

## Courseware

- [Trainer slides (PPTX)](courseware/WSQ-Master-Trainer-Slides-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.pptx) — 228 visual, mechanism-led slides with five editable charts
- [Trainer slides (PDF)](courseware/WSQ-Master-Trainer-Slides-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.pdf)
- [Learner Guide (PDF)](courseware/LG-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.pdf) — detailed explanations, commands, troubleshooting, and Activity procedures
- [Learner Guide (DOCX)](courseware/LG-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.docx)
- [Lesson Plan (PDF)](courseware/LP-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.pdf)
- [Lesson Plan (DOCX)](courseware/LP-Build-ASP.NET-Web-Apps-with-Vibe-Coding-v6.1.docx)
- [Source map](courseware/SOURCE-MAP.md) and [artifact inventory](courseware/INVENTORY.md)

The slide deck explains concepts visually. Detailed step-by-step procedures are intentionally kept in the Learner Guide and individual Activity guides.

## LocalCRM Activities

Every Activity is self-contained. Each folder contains its own stage-appropriate ASP.NET Core source, fictional JSON/CSV mock data, a detailed README, an Activity PDF, and a local run script.

| Activity | Build increment | Key concepts |
|---:|---|---|
| [1](activities/activity-01-requirements-and-scaffold/README.md) | Requirements and scaffold | solution structure, middleware, Razor Pages syntax |
| [2](activities/activity-02-controlled-vibe-change/README.md) | Controlled vibe-coding change | prompt contract, diff review, health endpoint |
| [3](activities/activity-03-accessible-razor-shell/README.md) | Accessible UI shell | layouts, Tag Helpers, semantic HTML, focus |
| [4](activities/activity-04-accessibility-audit/README.md) | Accessibility evidence | axe checks, keyboard review, remediation |
| [5](activities/activity-05-razor-create-list/README.md) | Contact create/list flow | PageModel, handlers, DI, model binding |
| [6](activities/activity-06-validation-and-antiforgery/README.md) | Secure form handling | DataAnnotations, ModelState, antiforgery |
| [7](activities/activity-07-controller-api/README.md) | Contact CRUD API | controllers, DTOs, status codes, routes |
| [8](activities/activity-08-sqlite-openapi-tests/README.md) | Persistence and contracts | EF Core SQLite, migrations, OpenAPI, xUnit |
| [9](activities/activity-09-production-readiness/README.md) | Release readiness | configuration, health checks, publish, smoke test |
| [10](activities/activity-10-design-documentation/README.md) | Traceable design record | requirements mapping, decisions, verification |

See the [Activities index](activities/README.md) for timing and assessment alignment.

## Run an Activity locally

Install the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0), choose an Activity folder, and run its helper script. For example:

```bash
cd activities/activity-10-design-documentation
./assets/run-local.sh
```

The application starts locally and creates its SQLite database at runtime. Generated databases, build outputs, and secrets are not committed. Activities 8–10 also include integration tests:

```bash
dotnet test src/LocalCRM.Tests/LocalCRM.Tests.csproj
```

## Repository boundaries

This public repository contains learner-safe courseware and Activity source only. Assessment question papers, marking guides, answer keys, source references, QA renders, local environment files, and publication credentials are intentionally excluded.

## Provider

[Tertiary Infotech Academy Pte. Ltd.](https://www.tertiarycourses.com.sg/) · Singapore
