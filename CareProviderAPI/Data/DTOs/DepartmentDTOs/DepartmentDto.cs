using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.DepartmentDTOs
{
    public class DepartmentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }
    }
}
