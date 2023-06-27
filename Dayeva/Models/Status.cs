using System;
using System.Collections.Generic;

namespace Dayeva.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProductAuction> ProductAuctions { get; set; } = new List<ProductAuction>();
}
