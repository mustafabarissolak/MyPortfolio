using Microsoft.AspNetCore.Identity;
using MyPortfolio.Application;
using MyPortfolio.Infrastructure;
using MyPortfolio.Infrastructure.Storages.Local;
using MyPortfolio.MVC;
using MyPortfolio.Persistance;
using MyPortfolio.Persistance.SeedAdmin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthenticationServices();

var app = builder.Build();

await IdentitySeed.SeedAsync(app.Services);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); 
app.MapStaticAssets();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
