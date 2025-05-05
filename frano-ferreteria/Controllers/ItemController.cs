using frano_ferreteria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly FranoContext _context;
        public ItemController(FranoContext context)
        {
            _context = context;
        }
        [HttpGet("/api/item")]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var employees = await _context.Items.ToListAsync();
            return Ok(employees);
        }
    }
}
