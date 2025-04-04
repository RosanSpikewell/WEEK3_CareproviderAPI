﻿using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.UserDTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
