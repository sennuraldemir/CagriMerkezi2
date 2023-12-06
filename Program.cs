

using CagriMerkezi2.Models;
using CagriMerkezi2.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UygulamaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<UygulamaDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IBirimRepository, BirimRepository>();

builder.Services.AddScoped<IDepartmanRepository, DepartmanRepository>();

builder.Services.AddScoped<ISikayetRepository, SikayetRepository>();

builder.Services.AddScoped<ICalisanRepository, CalisanRepository>();

builder.Services.AddScoped<ICagriMerkeziRepository, CagriMerkeziRepository>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
