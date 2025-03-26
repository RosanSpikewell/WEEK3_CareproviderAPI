namespace CareProviderAPI.Data.DTOs.ExperienceDTOs
{
    public class ExperienceDto
    {
        //public int ID { get; set; }
        public Guid CareProviderId { get; set; }
        public string? HospitalName { get; set; }
        public string? Role { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
