using System;
using System.Collections.Generic;

namespace CareProviderAPI.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CareProvider> CareProviders { get; set; } = new List<CareProvider>();
}
