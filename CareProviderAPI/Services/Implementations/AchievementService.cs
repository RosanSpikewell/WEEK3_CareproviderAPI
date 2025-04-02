using AutoMapper;
using CareProviderAPI.Data.DTOs.AchievementDTOs;
using CareProviderAPI.Data.Repositories.Implementations;
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using CareProviderAPI.Services.Interfaces;

namespace CareProviderAPI.Services.Implementations
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository achievementRepository;
        private readonly IMapper mapper;

        public AchievementService(IAchievementRepository achievementRepository,IMapper mapper)
        {
            this.achievementRepository = achievementRepository;
            this.mapper = mapper;
        }
        public async Task AddAsync(AchievementDto achievementDto)
        {
            var achievement = mapper.Map<Achievement>(achievementDto);
            await achievementRepository.AddAsync(achievement);
        }

        public async Task<IEnumerable<AchievementDto>> GetByProviderIdAsync(Guid providerId)
        {
            var achievements = await achievementRepository.GetByProviderIdAsync(providerId);
            return mapper.Map<IEnumerable<AchievementDto>>(achievements);
        }
    }
}
