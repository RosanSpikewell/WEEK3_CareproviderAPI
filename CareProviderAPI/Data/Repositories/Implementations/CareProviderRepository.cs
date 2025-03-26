using CareProviderAPI.Data.Context;
using CareProviderAPI.Data.Models;
using CareProviderAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class CareProviderRepository : ICareProviderRepository
    {
        private readonly CareproviderContext context;

        public CareProviderRepository(CareproviderContext context)
        {
            this.context = context;
        }
        public async Task<CareProvider> AddAsync(CareProvider provider)
        {
            context.CareProviders.Add(provider);
            await context.SaveChangesAsync();
            return provider;
        }

        public async Task DeleteAsync(Guid id)
        {
            var provider = await context.CareProviders.FindAsync(id);
            if (provider != null)
            {
                provider.IsActive = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CareProvider>> FilterByExperienceAsync(int years)
        {
            return await context.CareProviders
                .Where(p => p.YearsOfExperience >= years)
                .Include(p => p.Department)
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .ToListAsync();
        }

        public async Task<IEnumerable<CareProvider>> GetAllAsync()
        {
            return await context.CareProviders
                .Include(p => p.Department)
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .ToListAsync();
        }

        public async Task<IEnumerable<CareProvider>> GetByDepartmentAsync(int departmentId)
        {
            return await context.CareProviders
                .Where(p => p.DepartmentId == departmentId)
                .Include(p => p.Department)
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .ToListAsync();
        }

        public async Task<CareProvider?> GetByIdAsync(Guid id)
        {
            return await context.CareProviders
                .Include(p => p.Department)
                .Include(p => p.Achievements)
                .Include(p => p.Experiences)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(CareProvider provider)
        {
            context.CareProviders.Update(provider);
            await context.SaveChangesAsync();
        }
    }
}
