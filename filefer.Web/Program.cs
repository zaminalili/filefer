using filefer.Data.Context;
using filefer.Data.Extensions;
using filefer.Entity.Entites;
using filefer.Service.AutoKey;
using filefer.Service.Helpers;
using filefer.Service.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.LoadDataLayerExtensions(builder.Configuration);

builder.Services.AddIdentity<AppUser, AppRole>()
                                                .AddRoleManager<RoleManager<AppRole>>()
                                                .AddEntityFrameworkStores<AppDbContext>()
                                                .AddDefaultTokenProviders();

builder.Services.AddScoped<IAutoKey, AutoKey>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileHelper, FileHerper>();

builder.Services.AddSession();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Auth/Login");
    config.LogoutPath = new PathString("/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "Filefer",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };

    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromHours(12);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
