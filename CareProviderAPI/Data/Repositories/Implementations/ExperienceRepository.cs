
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly CareProviderContext context;

        public ExperienceRepository(CareProviderContext context)
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
