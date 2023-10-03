﻿using JwtApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult NewToken()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult NewTokenForAdmin()
        {
            return Ok(new CreateToken().TokenCreateByAdmin());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldin");
        }

        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token başarılı bir şekilde oluşturuldu.");
        }
    }
}
