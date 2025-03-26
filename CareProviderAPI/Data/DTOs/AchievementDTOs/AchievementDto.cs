namespace CareProviderAPI.Data.DTOs.AchievementDTOs
{
    public class AchievementDto
    {
        //public int ID { get; set; }
        public Guid CareProviderId { get; set; }
        public string? Description { get; set; }
        public DateOnly? AchievementDate { get; set; }
    }
}
