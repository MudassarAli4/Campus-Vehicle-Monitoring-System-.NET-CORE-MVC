using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class Vehicle
{
    public int Vid { get; set; }

    public string Vname { get; set; } = null!;

    public string Vtype { get; set; } = null!;

    public string Vplate { get; set; } = null!;

    public string Vowner { get; set; } = null!;

    public virtual ICollection<InOut> InOuts { get; set; } = new List<InOut>();
}
