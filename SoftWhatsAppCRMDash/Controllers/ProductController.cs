using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;
using SoftWhatsAppCRMDash.ViewModels;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class ProductController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        public ProductController(WhatsAppCrmContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = new List<ProductVM>();
            try
            {
                products = await _context.Productos.Include(x => x.Categoria).Include(x=>x.Marca).OrderBy(x=>x.Id).Select(x=>new ProductVM { 
                    Fecha = x.Fecha,
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Stock = x.Stock,
                    Oferta = x.Oferta,
                    Imagen = x.Imagen,
                    Categoria = x.Categoria,
                    Marca = x.Marca

                }).ToListAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                // Handle exception here
            }
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = new List<Categorium>();
            try
            {
                categories = await _context.Categoria.ToListAsync();
                return View(categories);
            }
            catch (Exception ex)
            {
                // Handle exception here
            }
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Productos.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception ex)
            {
                // Handle exception here
            }
            return View(product);
        }
    }
}
