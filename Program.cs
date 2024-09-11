using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;
using SerwisMotoryzacyjny.Infrastructure.Repositories;
using SerwisMotoryzacyjny.Domain.Interfaces;
using System;
using SerwisMotoryzacyjny.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Konfiguracja po³¹czenia do bazy danych logowania
var connectionString = builder.Configuration.GetConnectionString("DBLoginsConnection")
    ?? throw new InvalidOperationException("Connection string 'DBLoginsConnection' not found.");

// Konfiguracja po³¹czenia do bazy danych dla innych modu³ów (np. Parts, Contact, Pricing)
var appConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Konfiguracja kontekstu bazy danych dla logowania
builder.Services.AddDbContext<DBLogins>(options =>
    options.UseSqlServer(connectionString));

// Konfiguracja kontekstu bazy danych dla aplikacji
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(appConnectionString));

// Konfiguracja to¿samoœci (Identity) i dodanie ról
builder.Services.AddDefaultIdentity<SerwisMotoryzacyjnyUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() // Dodajemy wsparcie dla ról
.AddEntityFrameworkStores<DBLogins>();

// Rejestracja repozytoriów w DI
builder.Services.AddScoped<IContactRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.ContactRepository>();
builder.Services.AddScoped<IPartRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.PartRepository>();
builder.Services.AddScoped<IPricingRepository, SerwisMotoryzacyjny.Infrastructure.Repositories.PricingRepository>(); // jeœli masz repozytorium dla cen

// Konfiguracja aplikacji Razor Pages
builder.Services.AddRazorPages();

// Dodanie autoryzacji bazuj¹cej na rolach
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Konfiguracja potoku HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Dodajemy uwierzytelnianie
app.UseAuthorization(); // Dodajemy autoryzacjê

app.MapRazorPages();

app.Run();
