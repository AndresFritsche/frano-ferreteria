using frano_ferreteria.DTO_s;
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

        //Get all items
        [HttpGet("/api/item")]
        public async Task<ActionResult<List<Item>>> GetItems()
        {

            var item = await _context.Items.ToListAsync();

            if (item is null) return NotFound();
            
            return Ok(item);
        }


        //Get item by ID
        [HttpGet("/api/item/{id}")]
        public async Task<ActionResult<List<Item>>> GetItemById(int id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);

            if (item is null) return NotFound();

            return Ok(item);
        }


        //Create Item
        [HttpPost("/api/item/create")]
        public async Task<ActionResult<List<Item>>> CreateItem(ItemDTO itemDTO)
        {
            var newItem = new Item
            {
                Name = itemDTO.Name,
                Descrition = itemDTO.Descrition,
                UnitPrice = itemDTO.UnitPrice,
                Stock = itemDTO.Stock
            };

            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            return Created();
        }

        //Update Customer
        [HttpPut("/api/item/update/{id}")]

        public async Task<ActionResult<List<Item>>> UpdateList(int id, ItemDTO itemDTO)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item is null) return NotFound();

            item.Name = itemDTO.Name;
            item.Descrition = itemDTO.Descrition;
            item.Stock = itemDTO.Stock;
            item.UnitPrice = itemDTO.UnitPrice;

            _context.Items.Update(item);
            await _context.SaveChangesAsync();

            return Ok("Item Updated");
        }


        //Delete Customer
        [HttpDelete]

        public async Task<ActionResult<List<Item>>> DeleteItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item is null) return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok("The item is succesfully deleted");
        }
    }
}
