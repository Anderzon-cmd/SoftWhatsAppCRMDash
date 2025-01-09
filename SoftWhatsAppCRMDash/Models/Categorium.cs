using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? PadreId { get; set; }

    public virtual ICollection<Categorium> InversePadre { get; set; } = new List<Categorium>();

    public virtual Categorium? Padre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
