using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using fuck.Data;
using fuck.Models;

namespace fuck.Pages.Students
{

    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public Delete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public StudentModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _dbContext.Students.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var studentToDelete = await _dbContext.Students.FindAsync(Student.Id);
            if (studentToDelete != null)
            {
                _dbContext.Students.Remove(studentToDelete);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}