using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokensApp.Models.ViewModels;
using TokensApp.Services.Impl;

namespace TokensApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserViewModel> Authenticate([FromBody] UserViewModel userViewModel)
        {
            var userResult = userService.Authenticate(userViewModel);

            if(userResult == null)
                return BadRequest(new { message = "Неверный логин или пароль" });

            return Ok(userResult);
        }

    }
}