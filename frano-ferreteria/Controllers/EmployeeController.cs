using frano_ferreteria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 


namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly FranoContext _context;

        public EmployeeController(FranoContext context)
        {
            _context = context;
        }

        [HttpGet("/api/employee")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("/api/employee/{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id) 
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            if(employee is null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }
        [HttpPost("/api/employee")]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Created();
        }

    }
}
