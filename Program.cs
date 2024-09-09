using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerwisMotoryzacyjny.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracja po³¹czenia do bazy danych
var connectionString = builder.Configuration.GetConnectionString("DBLoginsConnection")
    ?? throw new InvalidOperationException("Connection string 'DBLoginsConnection' not found.");

// Konfiguracja kontekstu bazy danych
builder.Services.AddDbContext<DBLogins>(options =>
    options.UseSqlServer(connectionString));

// Konfiguracja to¿samoœci (Identity) i dodanie ról
builder.Services.AddDefaultIdentity<SerwisMotoryzacyjnyUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() // Dodajemy wsparcie dla ról
.AddEntityFrameworkStores<DBLogins>();

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
