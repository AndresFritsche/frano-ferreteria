using frano_ferreteria.DTO_s;
using frano_ferreteria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Client;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly FranoContext _context;
        public CustomerController(FranoContext context)
        {
            _context = context;
        }
        [HttpGet("/api/customer")]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
        [HttpGet("/api/customer/{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost("/api/customer/create")]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO is null)
            {
                return BadRequest();
            }
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Created();
        }
        [HttpPut("/api/customer/update/{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if(customer is null)
            {
                return NotFound();
            }


            customer.Name = customerDTO.Name;
            customer.Email = customerDTO.Email;
            customer.Phone = customerDTO.Phone;
            customer.Address = customerDTO.Address;


            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpDelete("api/customer/delete/{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if(customer is null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok("Delete succesfully");
        }
    }
}
