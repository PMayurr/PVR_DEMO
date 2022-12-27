using System.Collections.Generic;
using System.Threading.Tasks;

using PVR.Models;
using PVR.Service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PVR.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LoginService _loginService;

        public UsersController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<Users> CreateUser(Users user)
        {
            await _loginService.CreateUser(user);
            return user;
        }

    }
}
