using GameStore.Api;
using GameStore.Api.Dtos;

const string GetGameEndpointName = "GetGame";
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


//GET /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
  .WithName(GetGameEndpointName);

//PUT /games/1
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
  var index = games.FindIndex(game => game.Id == id);

  games[index] = new GameDto(
    id,
    updatedGame.Name,
    updatedGame.Genre,
    updatedGame.Price,
    updatedGame.ReleaseDate
  );

  return Results.NoContent();
});







//POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
  GameDto game = new(
  games.Count + 1,
  newGame.Name,
  newGame.Genre,
  newGame.Price,
  newGame.ReleaseDate
  );
  games.Add(game);

  return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

});


//DELETE /games/1
app.MapDelete("/games/{id}", (int id) =>
{
  games.RemoveAll(game => game.Id == id);
  return Results.NoContent();
});
app.Run();
