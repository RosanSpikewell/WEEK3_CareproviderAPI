using AutoMapper;
using CareProviderAPI.Data.DTOs.CareProviderDTOs;
using CareProviderAPI.Data.Repositories.Implementations;
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using CareProviderAPI.Services.Interfaces;

namespace CareProviderAPI.Services.Implementations
{
    public class CareProviderService : ICareProviderService
    {
        private readonly ICareProviderRepository careProviderRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public CareProviderService(ICareProviderRepository careProviderRepository,IDepartmentRepository departmentRepository,IMapper mapper)
        {
            this.careProviderRepository = careProviderRepository;
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public IDepartmentRepository DepartmentRepository { get; }

        public async  Task<CareProvider> AddAsync(CreateCareProviderDto providerDto)
        {
            var provider = mapper.Map<CareProvider>(providerDto);
            return await careProviderRepository.AddAsync(provider);
        }

        public async Task DeleteAsync(Guid id)
        {
            await careProviderRepository.DeleteAsync(id);
        }

        public async  Task<IEnumerable<CareProviderDto>> FilterByExperienceAsync(int years)
        {
            var providers = await careProviderRepository.FilterByExperienceAsync(years);
            return mapper.Map<IEnumerable<CareProviderDto>>(providers);
        }

        public async Task<IEnumerable<CareProviderDto>> GetAllAsync()
        {
            var providers = await careProviderRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CareProviderDto>>(providers);
        }

        public async Task<IEnumerable<CareProviderDto>> GetByDepartmentAsync(int departmentId)
        {
            var providers = await careProviderRepository.GetByDepartmentAsync(departmentId);
            return mapper.Map<IEnumerable<CareProviderDto>>(providers);
        }

        public async  Task<CareProviderDto> GetByIdAsync(Guid id)
        {
            var provider = await careProviderRepository.GetByIdAsync(id);
            return mapper.Map<CareProviderDto>(provider);
        }

        public async Task UpdateAsync(Guid id, UpdateCareProviderDto providerDto)
        {
            var provider = await careProviderRepository.GetByIdAsync(id);
            if (provider == null) return;

            mapper.Map(providerDto, provider);
            await careProviderRepository.UpdateAsync(provider);
        }
    }
}
