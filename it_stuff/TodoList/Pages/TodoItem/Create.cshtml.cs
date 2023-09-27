using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using TodoList.Models;
using TodoList.Data;


namespace TodoList.Pages.TodoItem
{
    [Authorize(Roles = "Admin, Manager, Subscriber")]
    public class Create : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public Create(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public TodoItemModel TodoItem { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (TodoItem.Text != null)
            {
                var user = await _userManager.GetUserAsync(User);
                TodoItem.UserId = user.Id;
                _context.TodoItems.Add(TodoItem);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }

            return Page();

        }
    }
}