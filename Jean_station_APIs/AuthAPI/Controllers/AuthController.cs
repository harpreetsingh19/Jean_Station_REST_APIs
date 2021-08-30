using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Newtonsoft.Json;
using Service;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                return Created("Registered Successfully", service.RegisterUser(user));
                //service.RegisterUser(user);
                //return StatusCode(201,"Registered Successfully");
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate([FromBody] User user)
        {
            bool _user = service.LoginUser(user);
            if (_user)
                return Ok(GetToken(user.UserId));
            else
                return Unauthorized("Invalid user id or password");
        }
        [HttpPost]
        [Route("addactiveuser")]
        public void AddActiveUser([FromBody] Activeuser activeuser)
        {
            service.AddActiveUser(activeuser);
        }

        [HttpGet]
        [Route("lastuser")]
        public Activeuser LastUser()
        {
            return service.LastUser();
        }
        [HttpDelete("{id}")]
        [Route("deleteactiveuser")]
        public void DeleteActiveUser(int id)
        {
            service.DeleteActiveUser(id);
        }
        private string GetToken(string userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_auth_jwt_to_secure_microservice"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthenticationServer",
                audience: "AuthClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(response);
        }
    }
}
