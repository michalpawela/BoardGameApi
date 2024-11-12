using BoardGame_REST_API;
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.Services;
using BoardGame_REST_API.Services.Interfaces;
using BoardGame_REST_API.Services.Seeders;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
IServiceCollection serviceCollection = builder.Services.AddDbContext<BoardGameDbContext>();
builder.Services.AddScoped<GameSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IGameService, GameService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. aka Middleware
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<GameSeeder>();

seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
