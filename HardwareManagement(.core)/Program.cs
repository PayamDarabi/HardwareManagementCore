using HardwareManagement_.core_.Models.Entity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddSession();
builder.Services.AddMemoryCache();
//builder.Services.AddDbContext<HardwareManagement_.core_.Models.Entity.HardwaremanagementContext>();



var connectionString = builder.Configuration.GetConnectionString("Data Source=.;Initial Catalog='Hardware management';Persist Security Info=True;User ID=sa;Password=saMaster1819!@;Trusted_Connection=false;TrustServerCertificate=True;timeout=100;Integrated Security=false;");
builder.Services.AddDbContext<HardwaremanagementContext>(options =>
    options.UseSqlServer("Data Source=.;Initial Catalog='Hardware management';Persist Security Info=True;User ID=sa;Password=saMaster1819!@;Trusted_Connection=false;TrustServerCertificate=True;timeout=100;Integrated Security=false;"));
//builder.Services.Configure<RazorViewEngineOptions>(o =>
//{
//    o.ViewLocationFormats.Clear();
//    o.ViewLocationFormats.Add("Views/{1}/{0}" + RazorViewEngine.ViewExtension);
//});
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}/{id?}");

app.Run();
