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
        private IUserService _userService;
        private IConfiguration _configuration;
        private IUserRoleService _userRoleService;

        public LoginController(IConfiguration configuration, IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _configuration = configuration;
            _userRoleService = userRoleService;
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult response = Unauthorized();
            var data = AuthenticateUser(user);
            if (data != null)
            {
                //find the roles for this user
                List<UserAndRoleModel> roles = _userRoleService.GetRolesByUserId(data.Id);
                List<string> arr_roles = new List<string>();
                foreach (UserAndRoleModel item in roles)
                {
                    arr_roles.Add(item.Role);
                }
                //generate JWT
                string token = GenerateJSONWebToken(data, arr_roles);
                response = Ok(new { token = token,userInfo=new {userName=data.UserName,roles= arr_roles } });
            }
            return response;
        }
        private string GenerateJSONWebToken(User userInfo, List<string> userRoles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = GetValidClaims(userInfo, userRoles);
           
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
            user = _userService.GetUser(data.UserName,data.Password);
            return user;
        }

        private  List<Claim> GetValidClaims(User userInfo, List<string> userRoles)
        {
            List<Claim> claims = new List<Claim>(){
             new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
             new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

             };
            //add roles in the claims
            foreach (string role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}