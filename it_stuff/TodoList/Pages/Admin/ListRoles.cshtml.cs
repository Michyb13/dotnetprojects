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
    public class ListRoles : PageModel
    {
        private readonly ILogger<ListRoles> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ListRoles(ILogger<ListRoles> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }
        public RolesViewModel RolesModel { get; set; }
        public class RolesViewModel
        {
            public List<IdentityRole> AllRoles { get; set; }
        }

        public IActionResult OnGet()
        {

            RolesModel = new RolesViewModel
            {
                AllRoles = _roleManager.Roles.ToList()
            };

            return Page();
        }
    }
}