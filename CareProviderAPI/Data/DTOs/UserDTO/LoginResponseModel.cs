﻿namespace CareProviderAPI.Data.DTOs.UserDTO
{
    public class LoginResponseModel
    {
        public string? Email{ get; set; }
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
