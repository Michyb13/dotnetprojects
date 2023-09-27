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

    public class Create : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Create(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public StudentModel Student { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(Student);
                _dbContext.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}