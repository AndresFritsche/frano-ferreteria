using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using frano_ferreteria.DTO_s;
using frano_ferreteria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : Controller
    {
        public static User user = new();
        [HttpPost("register")]
        public ActionResult<string> Register(userDTO request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password!);

            user.UserName = request.UserName;
            user.Password = hashedPassword;
            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult<string> LogIn(userDTO request)
        {
            if (user.UserName != request.UserName) return BadRequest("user not found");

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password!, request.Password!) 
                == PasswordVerificationResult.Failed)
            {
                return BadRequest("Wrong Password");
            }
            var token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user) 
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings: Audience"),
                claims: claims,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials: creds

                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
