using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int ClienteId { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public int? PedidoId { get; set; }

    public decimal? Total { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
