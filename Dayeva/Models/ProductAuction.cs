using System;
using System.Collections.Generic;

namespace Dayeva.Models;

public partial class ProductAuction
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PriceStart { get; set; }

    public string? PriceEnd { get; set; }

    public int? StatusId { get; set; }

    public int? PersonalDataId { get; set; }

    public virtual PersonalDatum? PersonalData { get; set; }

    public virtual Status? Status { get; set; }
}
