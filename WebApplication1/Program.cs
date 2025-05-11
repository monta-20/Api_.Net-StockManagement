
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Repository; // Assurez-vous que ce namespace est correct
var builder = WebApplication.CreateBuilder(args);

// Lire la chaîne de connexion depuis appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Enregistrer le DbContext avec SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers(); // for add Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Repository Pattern , DI
builder.Services.AddScoped<IStockRepository , StockRepository>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
