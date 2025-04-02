using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.CareProviderDTOs
{
    public class CreateCareProviderDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? ContactInfo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be greater than 0.")]
        public int DepartmentID { get; set; }

        [Range(0, 50, ErrorMessage = "Years of experience must be between 0 and 50.")]
        public int YearsOfExperience { get; set; }
    }
}
