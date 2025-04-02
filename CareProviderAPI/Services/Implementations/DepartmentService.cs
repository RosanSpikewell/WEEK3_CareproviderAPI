using AutoMapper;
using CareProviderAPI.Data.DTOs.DepartmentDTOs;
using CareProviderAPI.Data.Repositories.Implementations;
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using CareProviderAPI.Services.Interfaces;

namespace CareProviderAPI.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        public async Task<Department> AddAsync(DepartmentDto departmentDto)
        {
            var department = mapper.Map<Department>(departmentDto);
            await departmentRepository.AddAsync(department);

            return department;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await departmentRepository.GetAllAsync();
            return mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await departmentRepository.GetByIdAsync(id);
            return mapper.Map<DepartmentDto>(department);
        }
    }
}
