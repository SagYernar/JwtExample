using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokensApp.Models;
using TokensApp.Services.Impl;

namespace TokensApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<User> GetAllUsers()
        {
            var result = userService.GetUsers();
            return Ok(result);
        }
    }
}