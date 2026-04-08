// Made by following this https://www.youtube.com/watch?v=YbRe4iIVYJk&t=8245s
using GameStore.Api;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using GameStore.Api.Models;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDb();

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
