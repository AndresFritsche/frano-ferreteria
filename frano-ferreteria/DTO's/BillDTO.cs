using System.ComponentModel.DataAnnotations.Schema;

namespace frano_ferreteria.DTO_s
{

    public class BillDTO
    {
        public int CustomerId { get; set; }
        [ForeignKey("Id")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string? PaymentMethod { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }

}
