﻿using System;
using System.Collections.Generic;

namespace Dayeva.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<PersonalDatum> PersonalData { get; set; } = new List<PersonalDatum>();

    public virtual Role Role { get; set; } = null!;
}
