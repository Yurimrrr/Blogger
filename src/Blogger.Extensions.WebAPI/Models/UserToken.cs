using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace Blogger.Extensions.WebAPI.Models;

public class UserToken
{
    private readonly IHttpContextAccessor _accessor;
    
    public UserToken(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public static UserInfo? Info(string token)
    {
        if (string.IsNullOrEmpty(token)) return UserInfo.Empty;
        
        var handler = new JwtSecurityTokenHandler();
        var readed = handler.ReadJwtToken(token);

        var id = readed.Claims.FirstOrDefault(a => a.Type == JwtRegisteredClaimNames.Jti)?.Value ?? "";
        var email = readed.Claims.FirstOrDefault(a => a.Type == JwtRegisteredClaimNames.UniqueName)?.Value ?? "";
        var name = readed.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value ?? "";

        var user = new UserInfo(id, name, email);
        
        return user;
    }
}