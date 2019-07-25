using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Service;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCoreApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
           
        }
        [HttpPost]
        public IActionResult Insert(User user)
        {
                return Ok();
        }
        public IActionResult GetUser()
        {
            User user = new User() { UserName = "Praksh", Password = "Prakash", Address = new AddressInfo() { City = "New york", Street = "00012AA" } };
            return Ok(user);
        }
    }
}