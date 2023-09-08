using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCKnockout.DAL;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddDbContext<PeopleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=People}/{action=Index}/{id?}");

app.Run();
