using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.ViewModels
{
    public class SaleNoteVM
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Mount { get; set; }
        public string? PayCode { get; set; }
        public string StateColor { get; set; }
        public string StateName { get; set; }
        public virtual Cliente Client { get; set; } = null!;
    }
}
