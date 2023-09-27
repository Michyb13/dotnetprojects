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

namespace TodoList.Pages.Manager
{
    [Authorize(Roles = "Admin, Manager")]
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public Index(ILogger<Index> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        public List<User> Users { get; set; }
        public class User
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }

        }

        public IActionResult OnGet()
        {
            Users = new List<User>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                Users.Add(new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email

                });
            }
            return Page();
        }
    }
}