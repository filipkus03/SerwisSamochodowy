using SerwisSamochodowy.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); // Dodaj, jeœli u¿ywasz HttpClient do komunikacji z mikroserwisami
builder.Services.AddHttpClient<MicroservicesController>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5003"); // Ustaw bazowy adres, jeœli to potrzebne
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
