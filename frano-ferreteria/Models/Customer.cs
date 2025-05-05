using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frano_ferreteria.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public  string? Name { get; set; }
        public  string? Email { get; set; }   
        public  string? Phone { get; set; }   
        public string? Address { get; set; }  

        public List<Bill> Bills { get; set; } = new List<Bill>();
    }
}
