using System;
using System.Collections.Generic;

namespace CareProviderAPI.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public Guid CareProviderId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? AchievementDate { get; set; }

    public virtual CareProvider CareProvider { get; set; } = null!;
}
