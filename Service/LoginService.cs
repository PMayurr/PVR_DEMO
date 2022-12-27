using System.Collections.Generic;
using PVR.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PVR.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace PVR.Service
{
    public class LoginService
    {
        
        private readonly DatabaseContext _dbContext;
        public IConfiguration _configuration;
        public LoginService(IConfiguration config, DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _configuration = config;
        }
        public async Task CreateUser(Users user){
            user.Role = "User";
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<string> GetToken(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = await _dbContext.Users.Where(a => a.Email == email && a.Password == password).FirstOrDefaultAsync();
                        if (user != null)
                        {
                            //create claims details based on the user information
                            var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                new Claim("UserId", user.Id.ToString()),
                                new Claim("DisplayName", user.Name),
                                new Claim("Email", user.Email),
                                new Claim("Role", user.Role)
                            };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                            var token = new JwtSecurityToken(
                                _configuration["Jwt:Issuer"],
                                _configuration["Jwt:Audience"],
                                claims,
                                expires: DateTime.UtcNow.AddMinutes(20),
                                signingCredentials: signIn);

                            return new JwtSecurityTokenHandler().WriteToken(token);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
        }
      
    }
}