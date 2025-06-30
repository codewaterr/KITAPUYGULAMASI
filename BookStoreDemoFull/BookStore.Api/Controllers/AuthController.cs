using Microsoft.AspNetCore.Mvc;
using BookStore.Api.DTOs;
using BookStore.Api.Data;
using BookStore.Api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly BookStoreContext _ctx;
    private readonly IConfiguration _config;

    public AuthController(BookStoreContext ctx, IConfiguration config)
    {
        _ctx = ctx;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        if (await _ctx.Users.AnyAsync(u => u.Username == dto.Username))
            return BadRequest("Username already exists");

        var user = new Models.Entities.User
        {
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserRegisterDto dto)
    {
        var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Username == dto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized();

        var token = JwtHelper.GenerateToken(user.Username, _config);
        return Ok(new { token });
    }
}