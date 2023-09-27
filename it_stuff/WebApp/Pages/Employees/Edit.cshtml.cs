using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WebApp.Pages.Employees
{
    public class Edit : PageModel
    {
        
        private readonly EmployeeDbContext _context;

        public Edit(EmployeeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        
                public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _context.Employees.Find(id);

            if (Employee == null)
            {
               
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            if (!EmployeeExists(Employee.Id))
                {
                    
                    return NotFound();
                }else
                {
                _context.SaveChanges();
                return RedirectToPage("Index");
                }
                
            
            

             
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}