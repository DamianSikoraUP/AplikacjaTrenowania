using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AplikacjaTrenowania.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = false;
}) 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LogoutPath = "/Account/Logout";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roleExists = await roleManager.RoleExistsAsync("Admin");
    if (!roleExists)
    {
        var role = new IdentityRole("Admin");
        await roleManager.CreateAsync(role);
    }

    var user = await userManager.FindByEmailAsync("admin@admin.com");
    if (user == null)
    {
        user = new ApplicationUser { FirstName = "Marcin", LastName = "Tomczyk", UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true};
        await userManager.CreateAsync(user, "zaq1@WSX");
    }

    if (!await userManager.IsInRoleAsync(user, "Admin"))
    {
        await userManager.AddToRoleAsync(user, "Admin");
    }

    var otherUser = await userManager.FindByEmailAsync("user@user.com");
    if (otherUser == null)
    {
        otherUser = new ApplicationUser { FirstName = "Kacper", LastName = "Nowak", UserName = "user@user.com", Email = "user@user.com", EmailConfirmed = true};
        await userManager.CreateAsync(otherUser, "zaq1@WSX");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
