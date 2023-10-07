using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiHack_RitehKromanjonci.Data;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "LoginCookie";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // editat koliko dugo treba trajati
            options.LoginPath = "/"; // Redirect to this path if authentication fails
        });

builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://your-api-base-url.com/") // Replace with your API base URL
    };
    return httpClient;
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Retrieve the ServerBaseUrl from an environment variable
string serverBaseUrl = Environment.GetEnvironmentVariable("ServerBaseUrl");

if (!string.IsNullOrEmpty(serverBaseUrl))
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(serverBaseUrl) });
}
else
{
    // Handle the case where the configuration value is missing or empty
    // You can log an error or take appropriate action here
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCookiePolicy(cookiePolicyOptions);
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
