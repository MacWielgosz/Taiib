using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly WebshopContext _webshopContext;
        private readonly string _secretKey = "bardzoseketrynykodktorymusibycwtajemnicy";

        public AuthorizationController(WebshopContext webshopContext)
        {
            _webshopContext = webshopContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            if (user == null)
            {
                return Unauthorized();
            }

            User userX = _webshopContext.Users.SingleOrDefault(u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password));

            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, userX.Type == TypUser.Admin ? "admin":"Casual"),
                new(ClaimTypes.PrimarySid, userX.ID.ToString()),
            };
            if (userX != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7154", // Adres serwera API
                    audience: "https://localhost:4200", // Adres frontendowego klienta
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
