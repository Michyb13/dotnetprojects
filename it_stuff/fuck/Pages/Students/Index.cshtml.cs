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

    public class Index : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public Index(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentModel> Students { get; set; }

        public void OnGet()
        {
            Students = _dbContext.Students.ToList();
        }
    }
}