
using poc.trading.api.Repositpory;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services;
using poc.trading.api.Services.Interfaces;
using poc.trading.db.Middleware;
using poc.trading.signalr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Sql Connection
var connectionString = builder.Configuration.GetConnectionString("MysqlConnection") ?? "";
builder.Services.AddSqlConnector(connectionString);

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();

builder.Services.SetupSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.UseSingalR();

app.Run();