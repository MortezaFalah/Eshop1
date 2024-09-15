using Application.Eshop.Statics;
using Infra.Data.Eshop.Context;
using Infra.IOC.Eshop.Container;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Config Service

builder.Services.RegisterServices();

#endregion

#region GetSectionofAppsettingSms

builder.Configuration.GetSection("MeliPayamSms").Get<MeliPayamStatics>();

#endregion

#region Connection String
string Connectionstring = builder.Configuration.GetConnectionString("MyEshopconnectionstring");
builder.Services.AddDbContext<EshopContext>(option =>
option.UseSqlServer(Connectionstring));

#endregion

#region HtmlEncoder
builder.Services.AddSingleton<HtmlEncoder>(
  HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                            UnicodeRanges.Arabic }));

#endregion


#region Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Login";
        option.LogoutPath = "/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(10);
    });



#endregion

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute

    (
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



