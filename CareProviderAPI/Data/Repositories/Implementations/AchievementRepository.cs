
using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly CareProviderContext context;

        public AchievementRepository(CareProviderContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Achievement achievement)
        {
            await context.Achievements.AddAsync(achievement);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Achievement>> GetByProviderIdAsync(Guid providerId)
        {
            return await context.Achievements
                 .Where(a => a.CareProviderId == providerId)
                 .ToListAsync();
        }
    }
}
