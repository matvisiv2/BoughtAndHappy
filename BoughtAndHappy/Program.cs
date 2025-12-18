using BoughtAndHappy.Data;
using BoughtAndHappy.Data.Seed;
using BoughtAndHappy.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// For currency
var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddDbContext<ApplicationDbContext>((options) =>
{
    switch (configuration["DatabaseProvider"])
    {
        case "Sqlite":
            options.UseSqlite(configuration.GetConnectionString("Sqlite"));
            break;
        case "PostgreSql":
            options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            break;
    }
});

// turn on Session
services.AddDistributedMemoryCache();

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

services.AddHttpContextAccessor();
services.AddScoped<CartService>();

// Add services to the container.
services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DatabaseSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=Index}/{id?}"
);

app.Run();
