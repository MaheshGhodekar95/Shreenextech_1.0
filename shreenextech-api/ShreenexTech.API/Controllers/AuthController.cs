using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Application.Common.Authentication;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("User already exists");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
