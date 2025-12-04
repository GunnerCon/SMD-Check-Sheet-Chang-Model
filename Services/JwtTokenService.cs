using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtTokenService()
    {
        _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "mysupersecurekeywith32characters!!";
        _issuer = "SMDCheckSheet";
        _audience = "SMDCheckSheetClient";

        // Kiểm tra độ dài key để tránh lỗi runtime
        if (_key.Length < 32)
            throw new Exception("JWT_KEY must be at least 32 characters long for HS256.");
    }

    public (string token, DateTime expiresAt) GenerateToken(int userId, string username, string role, int expiryMinutes = 120)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("uid", userId.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(expiryMinutes);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
