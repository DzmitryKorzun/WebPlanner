using Microsoft.EntityFrameworkCore;
using WebPlanner.DAL;
using WebPlanner.DAL.Interfaces;
using WebPlanner.DAL.Repositories;
using WebPlanner.Service.Interfaces;
using WebPlanner.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connection, serverVersion));
builder.Services.AddScoped<IItemGroupRepository, ItemGroupRepository>();
builder.Services.AddScoped<IItemGroupServiñe, ItemGroupServiñe>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "HomeController",
            pattern: "{controller=Home}/{action=Index}");
});
app.Run();
