

using System.IdentityModel.Tokens.Jwt;

public class TokenService
{
    private readonly IConfiguration _config;
    public TokenService (IConfiguration config)
    {
        config = _config;
    }
    public string GenerateToken(ApplicationUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        claims.AddRange(roles.Select(r=> new Claim(ClaimTypes.Role, r)));

        var key = new SymmetricSecurityKey(Encoding.UFT8.GetBytes(_config["Jwt:Key"]));

        var creds = new SigningCredentials(key, SecrurityAlgorithms.HmacSha257)

        var token = new JwtSecurityToken(issuer : _config["Jwt issuer"],
        audience: _config["Jwt: Audience"],
        claim: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}