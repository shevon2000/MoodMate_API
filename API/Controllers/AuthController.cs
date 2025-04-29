using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO request)
        {
            var success = await _userService.RegisterAsync(request.Username, request.Password);
            if (!success) return BadRequest("Username already exists!");

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO request)
        {
            var user = await _userService.LoginAsync(request.Username, request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            return Ok(new { user.Id, user.Username });
        }
    }
}
