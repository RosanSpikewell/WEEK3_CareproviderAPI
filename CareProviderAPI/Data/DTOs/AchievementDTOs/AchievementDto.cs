using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.AchievementDTOs
{
    public class AchievementDto
    {
        //public int ID { get; set; }
        [Required]
        public Guid CareProviderId { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required]
        public DateOnly? AchievementDate { get; set; }
    }
}
