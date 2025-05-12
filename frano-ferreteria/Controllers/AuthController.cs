using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using frano_ferreteria.DTO_s;
using frano_ferreteria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace frano_ferreteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new()
        {
            UserName = string.Empty,   
            Password = string.Empty  
        };

        [HttpPost("register")]
        public ActionResult<User> Register(userDTO req)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, req.Password);

            user.UserName = req.UserName;
            user.Password = hashedPassword;   

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(userDTO req)
        {
            if (user.UserName != req.UserName) return BadRequest("Wrong username");

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, req.Password) == PasswordVerificationResult.Failed)
                return BadRequest("Wrong Password");

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims:claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials:creds);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
