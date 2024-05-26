using System;
using System.Collections.Generic;

namespace Adesso.Models;

public partial class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }
}
