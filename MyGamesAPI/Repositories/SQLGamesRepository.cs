using Microsoft.EntityFrameworkCore;
using MyGamesAPI.Data;
using MyGamesAPI.Models.Domain;

namespace MyGamesAPI.Repositories
{
    public class SQLGamesRepository : IGameRepository
    {
        private readonly MyGamesApiDbContext _dbContext;
        public SQLGamesRepository(MyGamesApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();

            return game;
        }

        public async Task<Game?> DeleteAsync(Guid id)
        {
            var existingGame = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGame == null)
            {
                return null;
            }

            _dbContext.Remove(existingGame);
            await _dbContext.SaveChangesAsync();

            return existingGame;
        }

        public async Task<List<Game>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var games = _dbContext.Games.Include("Studio").Include("Difficulty").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            { 
                games = games.Where(x => x.Type.Contains(filterQuery));
            }

            return await games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Games.Include("Studio").Include("Difficulty").FirstOrDefaultAsync(x =>x.Id == id); 
        }

        public async Task<Game?> UpdateAsync(Guid id, Game game)
        {
            var existingGame = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGame == null)
            {
                return null;
            }

            //update values
            existingGame.Name = game.Name;
            existingGame.Type = game.Type;
            existingGame.Description = game.Description;
            existingGame.Price= game.Price;
            existingGame.ImageURL= game.ImageURL;
            existingGame.DifficultyId= game.DifficultyId;
            existingGame.StudioId= game.StudioId;

            await _dbContext.SaveChangesAsync();

            return existingGame;
            
        }
    }
}

