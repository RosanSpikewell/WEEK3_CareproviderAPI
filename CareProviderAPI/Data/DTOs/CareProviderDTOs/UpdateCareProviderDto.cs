using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.CareProviderDTOs
{
    public class UpdateCareProviderDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Contact Info is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? ContactInfo { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be a positive number.")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Years of Experience is required.")]
        [Range(0, 100, ErrorMessage = "Years of Experience must be between 0 and 50.")]
        public int YearsOfExperience { get; set; }

        public bool IsActive { get; set; }
    }
}
