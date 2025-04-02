using CareProviderAPI.Models;

namespace CareProviderAPI.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
    }
}
