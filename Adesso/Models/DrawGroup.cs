using System;
using System.Collections.Generic;

namespace Adesso.Models;

public partial class DrawGroup
{
    public int Id { get; set; }

    public int? DrawId { get; set; }

    public string? GroupId { get; set; }

    public virtual Draw? Draw { get; set; }
}
