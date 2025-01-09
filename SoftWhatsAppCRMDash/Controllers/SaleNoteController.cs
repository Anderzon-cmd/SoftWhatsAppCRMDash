using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.ViewModels;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class SaleNoteController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        private readonly ILogger<SaleNoteController> _logger;
        public SaleNoteController(WhatsAppCrmContext context, ILogger<SaleNoteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<SaleNoteVM> saleNotes = new List<SaleNoteVM>();
            try
            {
                var saleNotesDb = await _context.SaleNotes.Include(saleNote=>saleNote.Client).OrderByDescending(x=>x.Date).ToListAsync();
                saleNotes=saleNotesDb.Select(saleNotesDb=>new SaleNoteVM
                {
                    Id=saleNotesDb.Id,
                    Client=saleNotesDb.Client,
                    Date=saleNotesDb.Date,
                    Mount=saleNotesDb.Mount,
                    PayCode=saleNotesDb.PayCode,
                    StateName=GetStateName((SaleNoteState)saleNotesDb.State),
                    StateColor=GetStateColor((SaleNoteState)saleNotesDb.State)
                }).ToList();
                return View(saleNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las notas de venta");
                // Handle exception here
                
                return View(saleNotes);
            }
        }

        public enum SaleNoteState
        {
            Unpaid = 0,
            Paid = 1
        }

        private string GetStateName(SaleNoteState state)
        {
            switch (state)
            {
                case SaleNoteState.Unpaid:
                    return "No pagado";
                case SaleNoteState.Paid:
                    return "Pagado";
                default:
                    return "Sin confirmar";
            }
        }

        private string GetStateColor(SaleNoteState state)
        {
            switch (state)
            {
                case SaleNoteState.Unpaid:
                    return "bg-red-500";
                case SaleNoteState.Paid:
                    return "bg-green-500";
                    
                default:
                    return "bg-yellow-500";
            }
        }
    }
}
