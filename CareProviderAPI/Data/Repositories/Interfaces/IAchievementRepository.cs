

using CareProviderAPI.Models;

namespace CareProviderAPI.Data.Repositories.Interfaces
{
    public interface IAchievementRepository
    {
        Task<IEnumerable<Achievement>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(Achievement achievement);
    }
}
