using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Service;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AngularCoreApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult response = Unauthorized();
            var data = AuthenticateUser(user);
            if (data != null)
            {
                //generate JWT
                string token = GenerateJSONWebToken(data);
                response = Ok(new { token = token });
            }
            return response;
        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var claims = new[] {
             new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
             new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User data)
        {
            User user = null;

            if (data.UserName == "Admin")
            {
                return new User() { UserName = "Admin", Password = "Admin", Email = "admin@gmail.com" };
            }
            return user;
        }


    }
}