using MediEval.Data;
using MediEval.Data.Cart;
using MediEval.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediEval.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using MediEval.Hubs;
using MediEval.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});


//Services Configurations 
builder.Services.AddScoped<IPharmacyServices, PharmacyService>();
builder.Services.AddScoped<IPharmacyBrandService, PharmacyBrandService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddSingleton(builder.Configuration.GetSection("MailJet").Get<MailJetOptions>());
builder.Services.AddScoped<IEmailSender, MailJetEMailSender>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//Authentication and Authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireLowercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    opt.Lockout.MaxFailedAccessAttempts = 3;
});
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = "2744944232306568";
    options.AppSecret = "994ef342ceca047aa6220f83b2137294";
});
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();



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


//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});




//app.MapControllerRoute(
//    name: "default",
//    pattern: "{area}{controller=Home}/{action=Index}/{id?}");


//app.MapAreaControllerRoute(

//    name: "admin",
//          areaName: "Admin",
//          pattern: "Admin/{controller=User}/{action=Index}/{id?}"

//    );

//app.MapRazorPages();
app.MapHub<UserHub>("/hubs/userCount");
app.MapHub<NotificationHub>("/hubs/notification");
//app.MapHub<BasicChatHub>("/hubs/basicchat");
app.MapHub<ChatHub>("/hubs/chat");




//Seed Database 
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
