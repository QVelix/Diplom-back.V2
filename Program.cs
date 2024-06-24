using System.Configuration;
using Diplom_back.Database;
using Microsoft.EntityFrameworkCore;
using Diplom_back.Models;
using MySqlConnector;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using System.Web.Http.Cors;

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// var cors = new EnableCorsAttribute("*","*","*");

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>{
//     options.AddPolicy(name: MyAllowSpecificOrigins, policy=>{
//         policy.WithOrigins("*");
//     });
// });

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Diplom_backContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")
    )
);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
