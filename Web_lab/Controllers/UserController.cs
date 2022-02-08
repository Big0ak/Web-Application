using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_lab.Models;
using Web_lab.Services;

namespace Web_lab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listUser = _userService.GetAll();
            return Ok(listUser);
        }

        [HttpGet]
        public IActionResult GetById(Guid id = default)
        {
            if (id == Guid.Empty) return BadRequest();
            var User = _userService.GetById(id);
            return Ok(User);
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            var isSuccess = _userService.Save(user);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult Edit(User user)
        {
            var isSuccess = _userService.Edit(user);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var isSuccess = _userService.Delete(id);
            return Ok(isSuccess);
        }
    }
}
