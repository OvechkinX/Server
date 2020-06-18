using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;
using Backend.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Backend.Services;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly ApiContext _context;
       // private readonly AuthService _authService;


        public AuthController(IAuthRepository repo, IConfiguration config, ApiContext context/*, AuthService authService*/)
        {
            _repo = repo;
            _config = config;
            _context = context;
           // _authService = authService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Admins.ToListAsync();
            return new JsonResult(users);
        }

        [Authorize(Roles = Role.Loader)]
        [HttpGet("GetAll2")]
        public async Task<IActionResult> GetAll2()
        {
            var users = await _context.Loaders.ToListAsync();
            return new JsonResult(users);
        }

        [Authorize(Roles = Role.Transport)]
        [HttpGet("GetAll3")]
        public async Task<IActionResult> GetAll3()
        {
            var users = await _context.Transports.ToListAsync();
            return new JsonResult(users);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.userExists(userForRegisterDto.Username))
                return BadRequest("Username already exists!");

            /*switch (userForRegisterDto.Role)
            {
                case "Admin":
                    var userToCreate = new Admin
                    {
                        Username = userForRegisterDto.Username,
                        Role = userForRegisterDto.Role,
                        FirstName = userForRegisterDto.FirstName,
                        LastName = userForRegisterDto.LastName,
                        Email = userForRegisterDto.Email
                    };
                    break;
            }*/

            await _repo.Register(userForRegisterDto);

            return StatusCode(201);

            
            /*
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authService.userExists(userForRegisterDto.Username))
                return BadRequest("Username already exists!");

            await _authService.Register(userForRegisterDto);

            return StatusCode(201);
            */

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim(ClaimTypes.Role, userFromRepo.Role),
                new Claim(ClaimTypes.GivenName, userFromRepo.FirstName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                expireDate = tokenDescriptor.Expires,
                role = userFromRepo.Role
            });
        }

    }
}
