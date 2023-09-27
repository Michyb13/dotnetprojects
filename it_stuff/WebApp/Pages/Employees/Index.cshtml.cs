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
    public class Index : PageModel
    {
        private readonly EmployeeDbContext _context;

        public Index(EmployeeDbContext context)
        {
            _context = context;
        }
        public List<Employee> Data {get; set;}

        public void OnGet()
        {
            Data = _context.Employees.ToList();
        }
    }
}