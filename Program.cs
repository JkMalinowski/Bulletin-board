using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BulletinBoard.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BulletinBoardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BulletinBoardContext") ?? throw new InvalidOperationException("Connection string 'BulletinBoardContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Announcements}/{action=LastTenAnnouncements}");

app.Run();
