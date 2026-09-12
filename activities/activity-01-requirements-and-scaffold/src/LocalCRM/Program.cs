var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => Results.Content("""
<!doctype html><html lang="en"><head><meta charset="utf-8"><title>LocalCRM</title></head>
<body><main><h1>LocalCRM</h1><p>Verified ASP.NET Core CRM scaffold — Activity 1.</p></main></body></html>
""", "text/html"));
app.Run();
