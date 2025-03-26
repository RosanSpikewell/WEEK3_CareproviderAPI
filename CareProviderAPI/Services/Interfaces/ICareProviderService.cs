using CareProviderAPI.Data.DTOs.CareProviderDTOs;
using CareProviderAPI.Data.Models;

namespace CareProviderAPI.Services.Interfaces
{
    public interface ICareProviderService
    {
        Task<IEnumerable<CareProviderDto>> GetAllAsync();
        Task<CareProviderDto> GetByIdAsync(Guid id);
        Task<IEnumerable<CareProviderDto>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<CareProviderDto>> FilterByExperienceAsync(int years);
        Task<CareProvider> AddAsync(CreateCareProviderDto providerDto);
        Task UpdateAsync(Guid id, UpdateCareProviderDto providerDto);
        Task DeleteAsync(Guid id);
    }
}
