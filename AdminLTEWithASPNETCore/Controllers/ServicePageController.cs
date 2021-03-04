using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers
{
    public class ServicePageController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public ServicePageController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Lockscreen()
        {
            ViewBag.Reason = "lockscreen";
            return View();
        }

        public async Task<IActionResult> LockscreenCheck(string password)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(password))
            {
                var result = await _signInManager.PasswordSignInAsync(User.Identity?.Name, password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return LocalRedirectPermanent("/Home");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = "/Home" });
                }
                else
                {
                    return LocalRedirectPermanent("/ServicePage/Lockscreen");
                }
            }

            return LocalRedirectPermanent("/ServicePage/Lockscreen");
        }
    }
}