using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Employees
{
    public class Create : PageModel
    {
        private readonly EmployeeDbContext _context;

        public Create(EmployeeDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Employee newEmployee {get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }else{
                return Page();
            }
        }
    }
}