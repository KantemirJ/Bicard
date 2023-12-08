using Microsoft.AspNetCore.Identity;

namespace Bicard.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAccessToken(IdentityUser user);
    }
}
