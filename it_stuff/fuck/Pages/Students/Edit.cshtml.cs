using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using fuck.Data;
using fuck.Models;

namespace fuck.Pages.Students
{

    public class Edit : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public Edit(ApplicationDbContext dbContext)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Attach(Student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}