using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
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
    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        return games.Find(game => game.ID == id);
    }
    public void Create(Game game)
    {
        game.ID = games.Max(game => game.ID) + 1;
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.ID == updatedGame.ID);
        games[index] = updatedGame;
    }
    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.ID == id);
        games.RemoveAt(index);
    }

    public Game? get(int id)
    {
        throw new NotImplementedException();
    }

    public void update(Game updatedGame)
    {
        throw new NotImplementedException();
    }
}