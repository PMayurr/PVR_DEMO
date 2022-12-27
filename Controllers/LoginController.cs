using System.Collections.Generic;
using System.Threading.Tasks;

using PVR.Models;
using PVR.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVR.Controllers
{
    [Route("/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        public class LoginDto{
            public string Email {get; set;}
            public string Password { get; set; }

        }
        private readonly LoginService _loginService;
        


        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        //[Route("Token")]
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> GetToken(LoginDto loginDto)
        {
            var token = await _loginService.GetToken(loginDto.Email, loginDto.Password);
            if(string.IsNullOrEmpty(token)){
            return BadRequest(new
            {
                Status = 400,
                Message = "Login Failed"
            });
            }
            return Ok( new {
                Status = 200,
                Token = token
            });
        }
    }
}
