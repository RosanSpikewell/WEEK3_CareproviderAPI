using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CareProviderContext context;

        public DepartmentRepository(CareProviderContext context)
        {
            this.context = context;
        }
        public async Task<Department> AddAsync(Department department)
        {
            context.Departments.Add(department);
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await context.Departments.FindAsync(id);
        }
    }
}
