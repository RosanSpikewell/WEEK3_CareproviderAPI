using CareProviderAPI.Data.DTOs.AchievementDTOs;

namespace CareProviderAPI.Services.Interfaces
{
    public interface IAchievementService
    {
        Task<IEnumerable<AchievementDto>> GetByProviderIdAsync(Guid providerId);
        Task AddAsync(AchievementDto achievementDto);
    }
}
