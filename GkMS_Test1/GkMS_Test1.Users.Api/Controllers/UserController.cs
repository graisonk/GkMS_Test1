using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.Users.Application.Interfaces;
using GkMS_Test1.Users.Application.Models;
using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GkMS_Test1.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetUsers());
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<UserVM> Get(int id)
        {
            return Ok(_userService.GetUser(id));
        }

        [HttpPut("{id}")]
        public void PutUser(int id, UserVM user)
        {
            _userService.ModUser(id, user);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.DelUser(id);
        }

        [HttpPost]
        public void PostUser([FromBody] UserVM user)
        {
            _userService.AddUser(user);
        }

        [HttpPost("{id:int}")]
        public IActionResult Post(int id, [FromBody] UPrinterDto uPrinterDto)
        {
            _userService.AssignPrinter(uPrinterDto);
            return Ok(uPrinterDto);
        }
        
        [HttpPost("{uname}")]
        public IActionResult UpdateProfile(string uname, [FromBody] User profile)
        {
            _userService.UpdProfile(profile);
            return Ok(profile);
        }
    }
}
