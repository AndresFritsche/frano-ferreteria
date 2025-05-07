using frano_ferreteria.DTO_s;
using frano_ferreteria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillController : ControllerBase
    {
        private readonly FranoContext _context;

        public BillController(FranoContext context)
        {
            _context = context;
        }

        //Get all bills

        [HttpGet("/api/bill")]
        public async Task<ActionResult<List<Bill>>> GetBills()
        {
            var bills = await _context.Bills.ToListAsync();
            return Ok(bills);
        }

        //Get bill by id
        
        [HttpGet("/api/bill/{id}")]
        public async Task<ActionResult<List<Bill>>> GetBillsById(int id)
        {
            var bills = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);
            if (bills is null)
            {
                return NotFound();
            }

            return Ok(bills);
        }

        //Create Bill

        [HttpPost("/api/bill/create/")]

        public async Task<ActionResult<Bill>> CreateBill(Bill billDTO)
        {
            if (billDTO == null)
                return BadRequest("Invalid bill.");



            var createBill = new Bill
            {
                CustomerId = billDTO.CustomerId,
                UnitPrice = billDTO.UnitPrice,
                Quantity = billDTO.Quantity,
                Total = billDTO.UnitPrice * billDTO.Quantity,
                PaymentMethod = billDTO.PaymentMethod,
                PurchaseDate = billDTO.PurchaseDate,
            };

            _context.Bills.Add(createBill);
            await _context.SaveChangesAsync();


            return Created();
        }

        //Update Bill

        [HttpPut("/api/bill/update/{id}")]
        public async Task<ActionResult<Bill>> UpdateBill(int id, BillDTO billDTO)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);

            if (bill is null) return NotFound();

            bill.Quantity = billDTO.Quantity;
            bill.UnitPrice = billDTO.UnitPrice;
            bill.PaymentMethod = billDTO.PaymentMethod;
            bill.Total = billDTO.UnitPrice * billDTO.Quantity;


            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();

            return Ok(bill);
        }

        //Delete bill

        [HttpDelete("/api/delete/{id}")]
        public async Task<ActionResult<List<Bill>>> DeleteBill(int id)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);

            if (bill is null) return NotFound();
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return Ok($"bill with Id: {id} removed" );
        }
    }
}
