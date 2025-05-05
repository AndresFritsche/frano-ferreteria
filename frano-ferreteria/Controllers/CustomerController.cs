using frano_ferreteria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace frano_ferreteria.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FranoContext _context;
        public CustomerController(FranoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}
