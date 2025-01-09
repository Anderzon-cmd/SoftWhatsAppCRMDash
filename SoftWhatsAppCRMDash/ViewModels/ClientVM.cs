namespace SoftWhatsAppCRMDash.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; }

        public string Numero { get; set; } = null!;

        public string? Nombre { get; set; }

        public string? Photo { get; set; }
        public string StateName { get; set;}
        public string StateColor { get;set; }
        public int StateUpdate { get; set; }
    }
}
