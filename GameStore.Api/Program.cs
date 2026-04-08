// Made by following this https://www.youtube.com/watch?v=YbRe4iIVYJk&t=8245s
using GameStore.Api;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
