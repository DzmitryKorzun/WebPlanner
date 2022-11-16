using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebPlanner.DAL;
using WebPlanner.DAL.Interfaces;
using WebPlanner.DAL.Repositories;
using WebPlanner.Service.Interfaces;
using WebPlanner.Service.Services;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddRazorPages();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connection,serverVersion));
builder.Services.AddScoped<IItemGroupRepository, ItemGroupRepository>();
builder.Services.AddScoped<IItemGroupServiñe, ItemGroupServiñe>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "HomeController",
            pattern: "{controller=Home}/{action=Index}");
});
app.Run();
