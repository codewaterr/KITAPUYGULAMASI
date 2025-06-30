namespace BookStore.Api.DTOs;

public class UserRegisterDto
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}