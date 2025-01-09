using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Contexto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? ClienteId { get; set; }

    public string? Spromtcontext { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
