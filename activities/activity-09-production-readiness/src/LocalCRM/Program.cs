using LocalCRM.Data; using LocalCRM.Models; using LocalCRM.Services; using Microsoft.EntityFrameworkCore;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); builder.Services.AddControllers(); builder.Services.AddOpenApi();
builder.Services.AddDbContext<CrmDbContext>(o=>o.UseSqlite(builder.Configuration.GetConnectionString("LocalCRM")));
builder.Services.AddScoped<IContactStore,SqliteContactStore>(); builder.Services.AddHealthChecks(); builder.Services.AddOptions<LocalCRM.Options.AppOptions>().BindConfiguration("App").ValidateDataAnnotations().ValidateOnStart();
var app=builder.Build();
using(var scope=app.Services.CreateScope()){var db=scope.ServiceProvider.GetRequiredService<CrmDbContext>();db.Database.Migrate();if(!db.Contacts.Any()){db.Contacts.AddRange(new Contact{Name="Aisha Rahman",Email="aisha@example.test",Stage="Lead"},new Contact{Name="Benjamin Tan",Email="benjamin@example.test",Stage="Qualified"},new Contact{Name="Chen Mei",Email="mei@example.test",Stage="Customer"});db.SaveChanges();}}
app.UseStaticFiles(); app.MapRazorPages(); app.MapControllers();
if(app.Environment.IsDevelopment()) app.MapOpenApi();
app.MapGet("/health/ready",async (CrmDbContext db,CancellationToken ct)=>await db.Database.CanConnectAsync(ct)?Results.Ok(new{status="ready",database="sqlite"}):Results.StatusCode(503)); app.MapGet("/health/live",()=>Results.Ok(new{status="ok"})); app.Run();
public partial class Program { }
