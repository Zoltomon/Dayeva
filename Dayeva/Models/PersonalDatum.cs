using System;
using System.Collections.Generic;

namespace Dayeva.Models;

public partial class PersonalDatum
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronomic { get; set; }

    public int? UserId { get; set; }

    public string? NumberPassport { get; set; }

    public string? SeriesPassport { get; set; }

    public virtual ICollection<ProductAuction> ProductAuctions { get; set; } = new List<ProductAuction>();

    public virtual User? User { get; set; }
}
