using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Entrega
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public decimal? Precio { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
