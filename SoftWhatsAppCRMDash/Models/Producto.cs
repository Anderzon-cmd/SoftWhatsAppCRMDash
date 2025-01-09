using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string? Oferta { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Imagen { get; set; }

    public int? MarcaId { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<ResenaProducto> ResenaProductos { get; set; } = new List<ResenaProducto>();

    public virtual ICollection<SaleNoteDetail> SaleNoteDetails { get; set; } = new List<SaleNoteDetail>();
}
