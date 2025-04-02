using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.ExperienceDTOs
{
    public class ExperienceDto
    {
        //public int ID { get; set; }
        [Required]
        public Guid CareProviderId { get; set; }


        [Required(ErrorMessage = "Hospital Name is required.")]
        [StringLength(100, ErrorMessage = "Hospital Name cannot exceed 100 characters.")]
        public string? HospitalName { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        [StringLength(50, ErrorMessage = "Role cannot exceed 50 characters.")]
        public string? Role { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
