using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        
        public CategoryController(WhatsAppCrmContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = new List<Categorium>();
            try
            {

                categories = await _context.Categoria.OrderBy(x=>x.Id).ToListAsync();
                return View(categories);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return View(categories);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categorium category)
        {
            try
            {
                _context.Categoria.Add(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle exception here
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Categorium category)
        {
            try
            {
                Categorium dbCategory = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);
                if (dbCategory == null)
                {
                    return NotFound();
                }

                dbCategory.Nombre = category.Nombre;
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorEdit"] = "Ups no se pudo editar.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Categorium dbCategory = await _context.Categoria.FirstOrDefaultAsync(x => x.Id == id);
                if (dbCategory == null)
                {
                    return NotFound();
                }

                _context.Categoria.Remove(dbCategory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorDelete"] = "Ups no se pudo eliminar";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = new List<Categorium>();
            try
            {
                categories = await _context.Categoria.ToListAsync();
                return Ok(new { Ok = true, Data = categories, Message = "Ok", Error = new { Code = 1, Description = "" } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Ok = false, Data = categories, Message = "Error Interno", Error = new { Code = 2, Description = "Servidor" } });
            }
        }
    }
}
