using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class ResenaProducto
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? Calificacion { get; set; }

    public string? Mensaje { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Producto? Producto { get; set; }
}
