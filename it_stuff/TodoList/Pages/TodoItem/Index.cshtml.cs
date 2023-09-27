using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.Models;
using TodoList.Data;


namespace TodoList.Pages.TodoItem
{
    [Authorize(Roles = "Admin, Manager, Subscriber")]
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Index(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<TodoItemModel> TodoItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            TodoItems = await _context.TodoItems.Where(item => item.UserId == user.Id).ToListAsync();
            return Page();
        }


    }
}