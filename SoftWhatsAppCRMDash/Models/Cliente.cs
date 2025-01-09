using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public string? Nombre { get; set; }

    public int WhatsappId { get; set; }

    public string? Photo { get; set; }
    public int StateChat { get; set; } = 2;

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Contexto> Contextos { get; set; } = new List<Contexto>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<ResenaProducto> ResenaProductos { get; set; } = new List<ResenaProducto>();

    public virtual ICollection<SaleNote> SaleNotes { get; set; } = new List<SaleNote>();
}
