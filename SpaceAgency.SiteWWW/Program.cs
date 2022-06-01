using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceAgency.Data.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaceAgencyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpaceAgencyContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//START
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//STOP

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
//START
app.UseSession();
//STOP


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
