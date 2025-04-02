using CareProviderAPI.Data.DTOs.AchievementDTOs;
using CareProviderAPI.Data.DTOs.ExperienceDTOs;
using System.ComponentModel.DataAnnotations;

namespace CareProviderAPI.Data.DTOs.CareProviderDTOs
{
    public class CareProviderDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ContactInfo { get; set; }

        public int DepartmentId { get; set; }

        public bool? IsActive { get; set; }

        public int? YearsOfExperience { get; set; }
        public List<AchievementDto> Achievements { get; set; } = new List<AchievementDto>();
        public List<ExperienceDto> Experiences { get; set; } = new List<ExperienceDto>();
    }
}
