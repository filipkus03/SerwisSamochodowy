using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;
using SerwisMotoryzacyjny.Infrastructure.Repositories;
using SerwisMotoryzacyjny.Domain.Interfaces;
using ContactRepo = SerwisMotoryzacyjny.Infrastructure.Repositories.ContactRepository;
using IContactRepo = SerwisMotoryzacyjny.Domain.Interfaces.IContactRepository;

using System;
using SerwisMotoryzacyjny.Infrastructure.Data;
using Microsoft.Build.Framework;
using SerwisMotoryzacyjny.Domain.Entities;
using System.Diagnostics;
using System.Configuration;
Debug.WriteLine("dupa");

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DBConnection")
    ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

var appConnectionString = builder.Configuration.GetConnectionString("DBConnection")
    ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

builder.Services.AddDbContext<DBLogins>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IContactRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.ContactRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(appConnectionString));

builder.Services.AddDefaultIdentity<SerwisMotoryzacyjnyUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() 
.AddEntityFrameworkStores<DBLogins>();

builder.Services.AddScoped<IContactRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.ContactRepository>();
builder.Services.AddScoped<IPartRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.PartRepository>();
builder.Services.AddScoped<IPricingRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.PricingRepository>(); 
builder.Services.AddScoped<IPartRepository, PartRepository>();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapRazorPages();

app.Run();
