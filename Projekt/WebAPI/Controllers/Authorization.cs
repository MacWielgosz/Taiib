using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    public class Authorization : ControllerBase
    {
        WebshopContext webshopContext;

        public Authorization(WebshopContext webshopContext)
        {
            this.webshopContext = webshopContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            if(user== null)
            {
                return BadRequest("Invalid client request");
            }
            User userX = webshopContext.Users.SingleOrDefault(u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password));
            if(userX != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sekret"));
                var singninCredentia = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer : "",
                    audience: "",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: singninCredentia);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok( new {Token =  tokenString});
            }
            else
                return Unauthorized();
               
        }
    }
}
