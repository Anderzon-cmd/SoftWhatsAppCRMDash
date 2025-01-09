using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class SaleNote
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Mount { get; set; }

    public int State { get; set; }

    public string? PayCode { get; set; }

    public int ClientId { get; set; }

    public virtual Cliente Client { get; set; } = null!;

    public virtual ICollection<SaleNoteDetail> SaleNoteDetails { get; set; } = new List<SaleNoteDetail>();
}
