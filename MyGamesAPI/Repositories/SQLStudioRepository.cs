using Microsoft.EntityFrameworkCore;
using MyGamesAPI.Data;
using MyGamesAPI.Models.Domain;

namespace MyGamesAPI.Repositories
{
    public class SQLStudioRepository : IStudioRepository
    {
        private readonly MyGamesApiDbContext _dbContext;
        public SQLStudioRepository(MyGamesApiDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<Studio> CreateAsync(Studio studio)
        {
           await _dbContext.Studios.AddAsync(studio);
           await _dbContext.SaveChangesAsync();

           return studio;
        }

        public async Task<Studio?> DeleteAsync(Guid id)
        {
            var existingStudio = await _dbContext.Studios.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudio == null)
            {
                return null;
            }
            _dbContext.Studios.Remove(existingStudio);
            await _dbContext.SaveChangesAsync();

            return existingStudio;

        }

        public async Task<List<Studio>> GetAllAsync()
        {
            return await _dbContext.Studios.ToListAsync();
        }

        public async Task<Studio?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Studios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Studio?> UpdateAsync(Guid id, Studio studio)
        {
            var existingStudio = await _dbContext.Studios.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudio == null)
            {
                return null;
            }

            existingStudio.Name = studio.Name;
            existingStudio.Country= studio.Country;

            await _dbContext.SaveChangesAsync();

            return existingStudio;
        }
    }
}
