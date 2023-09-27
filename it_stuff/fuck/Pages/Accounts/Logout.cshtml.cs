using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace fuck.Pages.Accounts
{
    public class Logout : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public Logout(SignInManager<IdentityUser> signInManager)
        {

            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}