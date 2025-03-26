using CareProviderAPI.Data.Context;
using CareProviderAPI.Data.Models;
using CareProviderAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CareproviderContext context;

        public ExperienceRepository(CareproviderContext context)
        {
            this.context = context;
        }
        public async  Task AddAsync(Experience experience)
        {
            await context.Experiences.AddAsync(experience);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Experience>> GetByProviderIdAsync(Guid providerId)
        {
            return await context.Experiences
                .Where(e => e.CareProviderId == providerId)
                .ToListAsync();
        }
    }
}
