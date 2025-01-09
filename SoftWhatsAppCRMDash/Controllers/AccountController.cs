using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftWhatsAppCRMDash.ViewModels;

namespace SoftWhatsAppCRMDash.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;   
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(); ;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl ?? "/");
                }

                ModelState.AddModelError(string.Empty, "Credenciales invalidas.");
                return View(model);
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error en el servidor.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
            
        }


    }
}
