using CareProviderAPI.Data.DTOs.DepartmentDTOs;
using CareProviderAPI.Data.Models;

namespace CareProviderAPI.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> GetByIdAsync(int id);
        Task<Department> AddAsync(DepartmentDto departmentDto);
    }
}
