using System.Text.RegularExpressions;
using GameStore.Api.Entities;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    static List<Game> games = new()
{
    new Game(){
        ID = 1,
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = "https://placehold.co/100"

    },

    new Game(){
        ID = 2,
        Name = "Final Fantasy XIV",
        Genre = "RolePlaying",
        Price = 49.99M,
        ReleaseDate = new DateTime(2001,2,1),
        ImageUri = "https://placehold.co/100"
    },

    new Game(){
        ID = 3,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 59.99M,
        ReleaseDate = new DateTime(2022,2,1),
        ImageUri = "https://placehold.co/100"

    }
};
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
               .WithParameterValidation();

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.ID == id);

            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game);
        }
        ).WithName(GetGameEndPointName);

        group.MapPost("/", (Game game) =>
        {
            game.ID = games.Max(game => game.ID) + 1;
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.ID }, game);
        }
        );


        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = games.Find(game => game.ID == id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            return Results.NoContent();

        }
        );

        group.MapDelete("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.ID == id);

            if (game is not null)
            {
                games.Remove(game);
            }
            return Results.NoContent();

        });
        return group;
    }

}