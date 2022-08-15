using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace POI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICurrentUser _currentUser;

        public AuthController(IConfiguration config,
            ICurrentUser currentUser)
        {
            _config = config;
            _currentUser = currentUser;
        }

        [HttpGet]
        public string Authenticate([FromQuery] LogInDTO logInDTO)
        {
            return GenerateToken(logInDTO);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok(new
            {
                _currentUser.UserId,
                _currentUser.FullName,
            });
        }

        private string GenerateToken(LogInDTO logInDTO)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, logInDTO.name),
                new Claim(ClaimTypes.NameIdentifier, logInDTO.id.ToString()),
            };

            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_config.GetValue<string>("Key")));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(365), 
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
