
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Repositories.Repositories.BaseRepo;
using Stripe;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using YazRehProje.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
#region Session
//builder.Services.AddSession(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//}); 
#endregion
builder.Services.AddInfrastructure();
#region Authorization
//builder.Services.AddAuthorization(options =>
//{
//    //options.AddPolicy("AdminPolicy", policy =>
//    //{
//    //    policy.RequireRole("Admin");
//    //});
//}); 
#endregion
builder.Services.ConfigureIdentity();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
//builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddScoped<Randevu>();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));



//builder.Services.AddHangfire(configuration => configuration
//            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//            .UseSimpleAssemblyNameTypeSerializer()
//            .UseRecommendedSerializerSettings()
//            .UseSqlServerStorage(builder.Configuration.GetConnectionString("SqlCon"))); // MS SQL Server veritabaný kullanýlýyor


var app = builder.Build();

/*app.ConfigureExceptionHandler();*///BU KOD OLUCAK MI BELLÝ DEÐÝL OLMAZSA LOGGER EKLEMEK LAZIM UNUTMA 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithRedirects("/Error/ErrorPage?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseNotyf();
app.UseRouting();
//app.UseSession();

var turkishCulture = new CultureInfo("tr-TR");

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(turkishCulture),
    SupportedCultures = new[] { turkishCulture },
    SupportedUICultures = new[] { turkishCulture }
};

app.UseRequestLocalization(localizationOptions);
app.UseResponseCaching();





//app.MapAreaControllerRoute(
//            name: "areas",
//            areaName: "User",
//            pattern: "User/{controller=User}/{action=Anasayfa}/{id?}");

//app.MapAreaControllerRoute(
//            name: "areas",
//            areaName: "Admin",
//            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "areas",
//    areaName: "Employee",
//    pattern: "Employee/{controller=Home}/{action=Index}/{id?}"
//    );

app.UseAuthentication();
app.UseAuthorization();
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    //'APPUSER' rolünün varlýðýný kontrol edin ve oluþturun
//    if (!roleManager.RoleExistsAsync("User").Result)
//    {
//        var role = new IdentityRole("User");
//        roleManager.CreateAsync(role).Wait();
//    }
//    if (!roleManager.RoleExistsAsync("Employee").Result)
//    {
//        var role = new IdentityRole("Employee");
//        roleManager.CreateAsync(role).Wait();
//    }
//    if (!roleManager.RoleExistsAsync("Admin").Result)
//    {
//        var role = new IdentityRole("Admin");
//        roleManager.CreateAsync(role).Wait();
//    }
//}
app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=account}/{action=login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Yaz}/{action=Anasayfa}/{id?}");


//app.ConfigureAndCheckMigration();
app.ConfigureDefaultAdminUser();

app.Run();
