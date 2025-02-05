using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class ContextController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        public ContextController(WhatsAppCrmContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var contextResponse = await _context.EnterpriseContexts.FindAsync(1);
            return View(contextResponse);

        }

        [HttpPost]
        public async Task<IActionResult> Update(EnterpriseContext enterpriseContext)
        {
            if (string.IsNullOrEmpty(enterpriseContext.Spromptcontext))
            {
                ModelState.AddModelError("Spromptcontext", "El comportamiento del usuario para el chat es requerido.");
                return View(nameof(Index),enterpriseContext);
            }
            if (string.IsNullOrEmpty(enterpriseContext.Sdata))
            {
                ModelState.AddModelError("Sdata", "La informacion de la empresa es requerido.");
                return View(nameof(Index),enterpriseContext);
            }
            if (ModelState.IsValid)
            {
                _context.Update(enterpriseContext);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            

            return View(nameof(Index),enterpriseContext);
        }

    }
}
