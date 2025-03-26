using CareProviderAPI.Data.DTOs.ExperienceDTOs;

namespace CareProviderAPI.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceDto>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(ExperienceDto experienceDto);
    }
}
