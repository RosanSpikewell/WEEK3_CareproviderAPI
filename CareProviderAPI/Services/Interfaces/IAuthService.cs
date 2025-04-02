using CareProviderAPI.Data.DTOs.UserDTO;

namespace CareProviderAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDTO registerDTO);
        Task<LoginResponseModel> ValidateUser(LoginDTO loginDTO);
    }
}
