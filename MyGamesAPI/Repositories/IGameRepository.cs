using MyGamesAPI.Models.Domain;

namespace MyGamesAPI.Repositories
{
    public interface IGameRepository
    {
        Task <List<Game>> GetAllAsync(string? filterOn = null, string? filterQuery = null);

        Task <Game?> GetByIdAsync (Guid id);

        Task<Game> CreateAsync(Game game);

        Task<Game?> UpdateAsync(Guid id ,Game game);

        Task<Game?> DeleteAsync(Guid id);
    }
}
