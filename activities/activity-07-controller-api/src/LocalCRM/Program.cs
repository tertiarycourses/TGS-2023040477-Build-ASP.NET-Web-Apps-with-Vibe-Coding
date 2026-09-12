using LocalCRM.Services;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); builder.Services.AddControllers();
builder.Services.AddSingleton<IContactStore,InMemoryContactStore>();
var app=builder.Build(); app.UseStaticFiles(); app.MapRazorPages(); app.MapControllers();
app.MapGet("/health",()=>Results.Ok(new{status="ok",service="LocalCRM"})); app.Run();
