using System.IdentityModel.Tokens.Jwt;
using AppStoreServerNotificationsV2.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapPost("/sandbox", ([FromBody] ResponseBodyV2 request) =>
{
    var payload = request.Decode();
    return Results.Ok();
});

app.Run();