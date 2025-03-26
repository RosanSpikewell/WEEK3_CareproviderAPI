namespace CareProviderAPI.Data.DTOs.CareProviderDTOs
{
    public class UpdateCareProviderDto
    {
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public int DepartmentID { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsActive { get; set; } 
    }
}
