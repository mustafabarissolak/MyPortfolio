using MyPortfolio.Application;
using MyPortfolio.Persistance;
using MyPortfolio.Persistance.SeedAdmin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllersWithViews();

var app = builder.Build();

await IdentitySeed.SeedAsync(app.Services);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
