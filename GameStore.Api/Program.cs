using GameStore.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<GameDto> games = [
  new(
    1,
    "Street Fighter II",
    "Fighting",
    19.99m,
    new DateOnly(1992, 7, 15)
  ),
  new(
    2,
    "The Legend of Zelda: Ocarina of Time",
    "Action-Adventure",
    59.99m,
    new DateOnly(1998, 11, 21)
  ),
  new(
    3,
    "Minecraft",
    "Sandbox",
    26.95m,
    new DateOnly(2011, 11, 18)
  ),
  new(
    4,
    "The Witcher 3: Wild Hunt",
    "Action RPG",
    39.99m,
    new DateOnly(2015, 5, 19)
  )
];

//GET /games
app.MapGet("/games", () => games);

app.Run();
