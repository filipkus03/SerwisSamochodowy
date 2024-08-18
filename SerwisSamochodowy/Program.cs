using SerwisSamochodowy.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerwisSamochodowy.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBContextLoginConnection") ?? throw new InvalidOperationException("Connection string 'DBContextLoginConnection' not found.");

builder.Services.AddDbContext<DBContextLogin>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SerwisSamochodowyUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DBContextLogin>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); // Dodaj, je�li u�ywasz HttpClient do komunikacji z mikroserwisami
builder.Services.AddHttpClient<MicroservicesController>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5003"); // Ustaw bazowy adres, je�li to potrzebne
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.Run();
