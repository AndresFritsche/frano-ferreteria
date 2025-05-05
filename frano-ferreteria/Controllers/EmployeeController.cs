using frano_ferreteria.Models;
using frano_ferreteria.DTO_s;
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
        //Get All Employees
        [HttpGet("/api/employee")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }


        //Get Employees by Id
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


        //Create employee
        [HttpPost("/api/employee/create")]
        public async Task<ActionResult<List<EmployeeDTO>>> AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                Name = employeeDTO.Name,
                LastName = employeeDTO.LastName,
                Age = employeeDTO.Age,
                HiringDate = employeeDTO.HiringDate
            };
                
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Created();
        }


        //Update employee
        [HttpPut("/api/employee/update/{id}")]
        public async Task<ActionResult<List<EmployeeDTO>>> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var updatedEmployee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);

            if (updatedEmployee is null)
            {
                return NotFound("Employee not found");
            }
            updatedEmployee.Name = employeeDTO.Name;
            updatedEmployee.LastName = employeeDTO.LastName;
            updatedEmployee.Age = employeeDTO.Age;
            updatedEmployee.HiringDate = employeeDTO.HiringDate;

            await _context.SaveChangesAsync();

            return Ok(employeeDTO);
        }
        //Delete employee
        [HttpDelete("/api/employee/delete/{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if(employee is null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok("delete succesfully");
        }
    }
}
