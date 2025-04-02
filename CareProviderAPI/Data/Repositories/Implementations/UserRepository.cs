using CareProviderAPI.Data.Repositories.Interfaces;
using CareProviderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CareProviderAPI.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CareProviderContext context;

        public UserRepository(CareProviderContext context)
        {
            this.context = context;
        }
        public async Task AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

        }

        public async  Task<User> GetUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
