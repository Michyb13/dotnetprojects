using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using webapi1.Models;
using webapi1.Data;

namespace webapi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "Employee doesn't exist" });
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel newEmployee)
        {

            _dbContext.Employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.Id }, newEmployee);



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id, EmployeeModel updated)
        {
            var existing = await _dbContext.Employees.FindAsync(id);
            if (existing == null)
            {
                return BadRequest(new { message = "Employee to edit doesn't exist" });
            }
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            existing.Address = updated.Address;
            existing.PhoneNo = updated.PhoneNo;

            _dbContext.Entry(existing).State = EntityState.Modified;

            if (!EmployeeExists(id))
            {
                return NotFound(new { message = "Employee to edit doesn't exist" });
            }
            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "Employee doesn't exist" });
            }
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _dbContext.Employees.Any(e => e.Id == id);
        }
    }
}