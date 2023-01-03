using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebTatilSitesi.Data;
using Microsoft.AspNetCore.Localization;
using System.Reflection;
using WebTatilSitesi.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebTatilSitesi.Areas.Identity;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
IConfiguration Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")//Data Source = TatilSitesiDb
    ));
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;

    //Lockout
    options.Lockout.MaxFailedAccessAttempts= 5;
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers= true;

    //options.User.AllowedUserNameCharacters = "";
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath= "/Account/Logout";
    options.AccessDeniedPath= "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie = new CookieBuilder
    {
        HttpOnly =true,
        Name = ".TarvelSite.Security.Cookie"
    };
});



//builder.Services.AddControllersWithViews()
//                .AddViewLocalization();

//builder.Services.AddLocalization(options =>
//{
//    options.ResourcesPath = "Resources";
//});
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    options.DefaultRequestCulture = new("tr-TR");

//    CultureInfo[] cultures = new CultureInfo[]
//    {
//        new("tr-TR"),
//        new("en-US"),
//        new("fr-FR")
//    };

//    options.SupportedCultures = cultures;
//    options.SupportedUICultures = cultures;
//});

builder.Services.AddSingleton<LanguageService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {

            var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);

            return factory.Create("ShareResource", assemblyName.Name);

        };

    });



builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
            {
                            new CultureInfo("en-US"),
                            new CultureInfo("fr-FR"),
                            new CultureInfo("tr-TR"),
            };



        options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");

        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
        options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Ana}/{action=Index}/{id?}");
//app.MapRazorPages();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
   name: "default",
   pattern: "{controller=Ana}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "adminroles",
      pattern: "admin/role/list",
      defaults: new { Controller = "Admin", Action = "RoleList" }
   );

    endpoints.MapControllerRoute(
      name: "adminrolecreate",
      pattern: "admin/role/create",
      defaults: new { Controller = "Admin", Action = "RoleCreate" }
   );

    endpoints.MapControllerRoute(
      name: "adminroleedit",
      pattern: "admin/role/{id?}",
      defaults: new { Controller = "Admin", Action = "RoleEdit" }
   );

    // endpoints.MapControllerRoute(
    //   name: "adminyorumlistesi",
    //   pattern: "admin/yorumlistesi",
    //   defaults: new { Controller = "Admin", Action = "YorumListesi" }
    //);


});



//var userManager = app.Services.GetService<UserManager<User>>();

//var roleManager = app.Services.GetService<RoleManager<IdentityRole>>();

//SeedIdentity.Seed(userManager,roleManager,Configuration).Wait();

app.Run();


