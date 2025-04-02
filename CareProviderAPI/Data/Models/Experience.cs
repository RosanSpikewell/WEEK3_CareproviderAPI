using System;
using System.Collections.Generic;

namespace CareProviderAPI.Models;

public partial class Experience
{
    public int Id { get; set; }

    public Guid CareProviderId { get; set; }

    public string HospitalName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual CareProvider CareProvider { get; set; } = null!;
}
