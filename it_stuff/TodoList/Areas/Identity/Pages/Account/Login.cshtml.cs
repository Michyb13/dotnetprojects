using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TodoList.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }


        [BindProperty]
        public LoginViewModel Input { get; set; }

        public class LoginViewModel
        {

            [Required]

            public string UsernameOrEmail { get; set; }


            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }



        public async Task<IActionResult> OnPostAsync()
        {


            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(Input.UsernameOrEmail) ?? await _userManager.FindByEmailAsync(Input.UsernameOrEmail);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User doesn't exist.");
                }
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect Password.");
                }
                else
                {

                    await _signInManager.SignInAsync(user, isPersistent: Input.RememberMe);
                    return RedirectToPage("/Index");
                }
            }


            return Page();
        }
    }
}
