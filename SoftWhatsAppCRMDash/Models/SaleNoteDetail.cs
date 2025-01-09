using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class SaleNoteDetail
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal SubTotal { get; set; }

    public int SaleNoteId { get; set; }

    public int ProductId { get; set; }

    public virtual Producto Product { get; set; } = null!;

    public virtual SaleNote SaleNote { get; set; } = null!;
}
