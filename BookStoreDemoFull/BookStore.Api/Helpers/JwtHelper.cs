using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Api.Helpers;

public static class JwtHelper
{
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration config)
    {
        var jwt = config.GetSection("JwtSettings");
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwt["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwt["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Secret"]!)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    }

    public static string GenerateToken(string username, IConfiguration config)
    {
        var jwt = config.GetSection("JwtSettings");
        var claims = new[] { new System.Security.Claims.Claim("username", username) };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);
        return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
    }
}