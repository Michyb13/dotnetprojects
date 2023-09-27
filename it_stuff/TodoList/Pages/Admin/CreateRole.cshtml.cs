using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateRole : PageModel
    {
        private readonly ILogger<CreateRole> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRole(ILogger<CreateRole> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        [BindProperty]
        public RoleViewModel model { get; set; }

        public class RoleViewModel
        {
            [Required]
            public string RoleName { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole { Name = model.RoleName };
                var result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToPage("./ListRoles");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return Page();
        }
    }
}