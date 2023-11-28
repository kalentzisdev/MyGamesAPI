using MyGamesAPI.Models.Domain;

namespace MyGamesAPI.Repositories
{
    public interface IStudioRepository
    {

        Task<List<Studio>> GetAllAsync();

        Task<Studio?> GetByIdAsync(Guid id);

        Task<Studio> CreateAsync(Studio studio);

        Task<Studio?> UpdateAsync(Guid id, Studio studio);

        Task<Studio?> DeleteAsync(Guid id);

        
    }
}
