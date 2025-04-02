using AutoMapper;
using CareProviderAPI.Data.DTOs.ExperienceDTOs;
using CareProviderAPI.Data.Repositories.Implementations;
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using CareProviderAPI.Services.Interfaces;

namespace CareProviderAPI.Services.Implementations
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly IMapper mapper;

        public ExperienceService(IExperienceRepository experienceRepository,IMapper mapper)
        {
            this.experienceRepository = experienceRepository;
            this.mapper = mapper;
        }
        public async  Task AddAsync(ExperienceDto experienceDto)
        {
            var experience = mapper.Map<Experience>(experienceDto);
            await experienceRepository.AddAsync(experience);
        }

        public async Task<IEnumerable<ExperienceDto>> GetByProviderIdAsync(Guid providerId)
        {
            var experiences = await experienceRepository.GetByProviderIdAsync(providerId);
            return mapper.Map<IEnumerable<ExperienceDto>>(experiences);
        }
    }
}
