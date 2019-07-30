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
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Insert(User user)
        {
                return Ok();
        }
        public IActionResult GetUser()
        {
            User user = new User() { UserName = "Praksh", Password = "Prakash"};
            return Ok(user);
        }
    }
}