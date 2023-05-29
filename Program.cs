using System.Configuration;
using Diplom_back.Database;
using Microsoft.EntityFrameworkCore;
using Diplom_back.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Diplom_backContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
