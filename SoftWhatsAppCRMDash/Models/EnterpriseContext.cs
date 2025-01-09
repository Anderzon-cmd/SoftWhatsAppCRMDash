using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class EnterpriseContext
{
    public int Nid { get; set; }

    public string Sdata { get; set; } = null!;

    public string Spromptcontext { get; set; } = null!;
}
