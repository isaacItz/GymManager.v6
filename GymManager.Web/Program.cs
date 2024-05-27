using Microsoft.AspNetCore.Identity;
using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.EquipmentTypes;
using GymManager.ApplicationServices.MemberShips;
using GymManager.ApplicationServices.MemberMemberships;
using GymManager.ApplicationServices.Navigation;
using GymManager.DataAccess.Repositories;
using GymManager.Core.Entities;
using System.Globalization;
using Serilog;
using GymManager.DataAccess;
using Microsoft.EntityFrameworkCore;

//CultureInfo culture;
//culture = CultureInfo.CreateSpecificCulture("ex-MX");
//Thread.CurrentThread.CurrentUICulture = culture;
//Thread.CurrentThread.CurrentCulture = culture;
//CultureInfo.DefaultThreadCurrentCulture = culture;
//CultureInfo.DefaultThreadCurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("home");

builder.Services.AddDbContext<GymManagerContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true
).AddEntityFrameworkStores<GymManagerContext>();
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
});
builder.Services.ConfigureApplicationCookie(options =>
    options.LoginPath = "/Account/LogIn"
);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IMembersAppService, MembersAppService>();
builder.Services.AddTransient<IMemberShipsAppService, MemberShipsAppService>();
builder.Services.AddTransient<IMemberMembershipsAppService, MemberMembershipsAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IEquipmentTypesAppService, EquipmentTypesAppService>();
builder.Services.AddTransient<IRepository<int, Member>, MembersRepository>();
builder.Services.AddTransient<MemberMembershipsRepository>();
builder.Services.AddTransient<IRepository<int, Membership>, MembershipsRepository>();
builder.Services.AddTransient<IRepository<int, EquipmentType>, Repository<int, EquipmentType>>();
var app = builder.Build();

var defaultCulture = "es-MX";
var ci = new CultureInfo(defaultCulture);

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    }
});
app.MapControllerRoute("default", "{controller=Members}/{action=Index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.Run();