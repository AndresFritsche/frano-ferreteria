using frano_ferreteria.DTO_s;
using frano_ferreteria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public static User user = new();
        [HttpPost("register")]
        public async Task<ActionResult<List<User>>> Register(userDTO request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.UserName = request.UserName;
            user.Password = hashedPassword;
            return Ok(user);
        }
    }
}
