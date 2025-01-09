using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string? NumeroOrden { get; set; }

    public string Departamento { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal? Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal CosteTotal { get; set; }

    public int? EntregaId { get; set; }

    public string Estado { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Entrega? Entrega { get; set; }
}
