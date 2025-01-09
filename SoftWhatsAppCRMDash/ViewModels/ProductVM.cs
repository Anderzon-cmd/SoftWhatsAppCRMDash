using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string? Oferta { get; set; }

        public DateOnly Fecha { get; set; }

        public string? Imagen { get; set; }
        public virtual Categorium Categoria { get; set; } = null!;

        public virtual Marca? Marca { get; set; }
    }
}
