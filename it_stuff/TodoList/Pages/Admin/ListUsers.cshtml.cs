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
    public class ListUsers : PageModel
    {
        private readonly ILogger<ListUsers> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public ListUsers(ILogger<ListUsers> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public List<UserWithRoles> UsersWithRoles { get; set; }

        public class UserWithRoles
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public IList<string> Roles { get; set; }
        }

        public IActionResult OnGet()
        {
            UsersWithRoles = new List<UserWithRoles>();
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                UsersWithRoles.Add(new UserWithRoles
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles
                });
            }
            return Page();
        }
    }
}