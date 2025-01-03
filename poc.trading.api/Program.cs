using Microsoft.Extensions.Options;
using poc.trading.api.Repositpory;
using poc.trading.api.Repositpory.Interface;
using poc.trading.api.Services;
using poc.trading.api.Services.Interfaces;
using poc.trading.db.Middleware;
using poc.trading.sdk.Authentication;
using poc.trading.sdk.ExceptionHandler;
using poc.trading.signalr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        //builder.WithOrigins(@"http://localhost:5500").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        builder.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddJwtAuthentication(builder.Configuration);

// Sql Connection
var connectionString = builder.Configuration.GetConnectionString("MysqlConnection") ?? "";
builder.Services.AddSqlConnector(connectionString);

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IWatchlistService, WatchlistService>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.SetupSignalR();
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHsts();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseJwtAuthentication();
app.MapControllers();
app.UseSingalR();
app.MapHealthChecks("/health");
app.Run();