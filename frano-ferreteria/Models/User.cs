using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frano_ferreteria.Models
{
    public class User
    {

        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
