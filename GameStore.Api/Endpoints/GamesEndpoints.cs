using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";
  private static readonly List<GameDto> games = [
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
  public static void MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/games").WithTags("Games");
    //GET /games
    group.MapGet("/", () => games);


    //GET /games/1
    group.MapGet("/{id}", (int id) =>
    {
      var game = games.Find(game => game.Id == id);

      return game is null ? Results.NotFound() : Results.Ok(game);
    })
      .WithName(GetGameEndpointName);


    //POST /games
    group.MapPost("/", (CreateGameDto newGame) =>
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


    //PUT /games/1
    group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
    {
      var index = games.FindIndex(game => game.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
      );

      return Results.NoContent();
    });

    //DELETE /games/1
    group.MapDelete("/{id}", (int id) =>
    {
      games.RemoveAll(game => game.Id == id);
      return Results.NoContent();
    });
  }
}
