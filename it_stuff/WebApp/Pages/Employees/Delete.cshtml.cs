using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace WebApp.Pages.Employees
{
    public class Delete : PageModel
    {
        private readonly EmployeeDbContext _context;
        public Delete(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}