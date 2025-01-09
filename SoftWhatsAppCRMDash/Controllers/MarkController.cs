using Microsoft.AspNetCore.Mvc;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class MarkController : Controller
    {
        private readonly WhatsAppCrmContext _context;

        public MarkController(WhatsAppCrmContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Marca> marks = new List<Marca>();
            try
            {
                marks = _context.Marcas.ToList();
                return View(marks);
            }
            catch (Exception ex)
            {

                // Handle exception here
                return View(marks);
            }
        }
    }
}