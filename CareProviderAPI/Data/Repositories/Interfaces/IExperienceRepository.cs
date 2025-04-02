
using CareProviderAPI.Models;

namespace CareProviderAPI.Data.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(Experience experience);
    }
}
