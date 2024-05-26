using System;
using System.Collections.Generic;

namespace Adesso.Models;

public partial class Draw
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<DrawGroup> DrawGroups { get; set; } = new List<DrawGroup>();
}
