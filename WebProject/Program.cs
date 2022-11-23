using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebProject.DAL;
using WebProject.Data;
using WebProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<AnimalContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<AnimalContext>();
var app = builder.Build();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
    var userMngr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleMngr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    var adminRole = new IdentityRole("Admin");
    if (!ctx.Roles.Any())
    {
        // Create role
        roleMngr.CreateAsync(adminRole).GetAwaiter().GetResult();
    }

    if (!ctx.Users.Any(u => u.UserName == "Admin"))
    {
        var adminUser = new IdentityUser
        {
            UserName = "Admin",
        };
        var result = userMngr.CreateAsync(adminUser, "123456aA").GetAwaiter().GetResult();
        // add role to user
        userMngr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
    }
}
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

