using System;
using System.Collections.Generic;

namespace Adesso.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
