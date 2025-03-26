using CareProviderAPI.Data.Models;

namespace CareProviderAPI.Data.Repositories.Interfaces
{
    public interface ICareProviderRepository
    {
        Task<IEnumerable<CareProvider>> GetAllAsync();
        Task<CareProvider?> GetByIdAsync(Guid id);
        Task<IEnumerable<CareProvider>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<CareProvider>> FilterByExperienceAsync(int years);
        Task<CareProvider> AddAsync(CareProvider provider);
        Task UpdateAsync(CareProvider provider);
        Task DeleteAsync(Guid id);
    }
}
