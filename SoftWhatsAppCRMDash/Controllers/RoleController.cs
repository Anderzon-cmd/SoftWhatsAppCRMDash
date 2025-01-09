using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.ViewModels;

namespace SoftWhatsAppCRMDash.Controllers
{
    public class RoleController:Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<RoleVM> roles=new List<RoleVM>();
            var rolesDb=await _roleManager.Roles.ToListAsync();   
            roles=rolesDb.Select(x=>new RoleVM() { Id = x.Id, Name = x.Name }).ToList();
            return View(roles);
        }
    }
}
