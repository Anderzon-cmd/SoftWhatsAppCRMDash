using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.ViewModels;


namespace SoftWhatsAppCRMDash.Controllers
{
    public class UserController:Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           List<UserVM> users = new List<UserVM>();
           var usersDb = await _userManager.Users.ToListAsync();
            users=usersDb.Select(u=>new UserVM
            {
                Id=u.Id,
                Email=u.Email,
                UserName=u.UserName
            }).ToList();
           return View(users);
        }

        
    }
}
