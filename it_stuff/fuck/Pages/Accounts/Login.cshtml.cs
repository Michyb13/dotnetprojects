using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using fuck.Models;

namespace fuck.Pages.Accounts
{

    public class Login : PageModel

    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public Login(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            Model = new LoginViewModel();

        }

        [BindProperty]
        public LoginViewModel Model { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Model.Username, Model.Password, Model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return Page();
        }
    }
}