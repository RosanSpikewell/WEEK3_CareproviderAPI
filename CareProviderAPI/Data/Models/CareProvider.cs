using System;
using System.Collections.Generic;

namespace CareProviderAPI.Models;

public partial class CareProvider
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public int DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public int? YearsOfExperience { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
