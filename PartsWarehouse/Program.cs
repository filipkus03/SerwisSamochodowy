using Microsoft.EntityFrameworkCore;
using PartsWarehouse.Infrastructure;
using PartsWarehouse.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext and repository services to the container
builder.Services.AddDbContext<PartsWarehouseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPartRepository, PartRepository>();

// Configure HttpClient if needed for communication with other services
// builder.Services.AddHttpClient("OtherServiceClient", client =>
// {
//     client.BaseAddress = new Uri("http://localhost:5003"); // Example URL
// });

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

app.Run();
