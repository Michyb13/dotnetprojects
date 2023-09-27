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
    public class Edit : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Edit(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public TodoItemModel TodoItem { get; set; }
        [BindProperty]
        public TodoItemModel Updated { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {

            var user = await _userManager.GetUserAsync(User);
            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == id && item.UserId == user.Id);
            if (TodoItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == id && item.UserId == user.Id);
            if (TodoItem == null && !ModelState.IsValid)
            {
                return Page();
            }
            TodoItem.UserId = user.Id;
            TodoItem.Text = Updated.Text;
            _context.Attach(TodoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }

}