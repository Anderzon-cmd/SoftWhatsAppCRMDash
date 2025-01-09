using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class ClientController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        public ClientController(WhatsAppCrmContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> clients = new List<Cliente>();
            try
            {
                clients = await _context.Clientes.Select(client => new Cliente
                {
                    Id = client.Id,
                    Nombre = client.Nombre,
                    Numero = client.Numero.Substring(client.Numero.Length - 8),
                    Photo = client.Photo,

                }).ToListAsync();
                return View(clients);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return View(clients);
            }

        }
    }
}
