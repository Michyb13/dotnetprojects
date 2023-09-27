using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using TodoList.Models;
using TodoList.Data;

namespace TodoList.Pages.TodoItem
{
    [Authorize(Roles = "Admin, Manager, Subscriber")]
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Delete(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public TodoItemModel TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (TodoItem != null)
            {
                _context.TodoItems.Remove(TodoItem);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}