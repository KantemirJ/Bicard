using Bicard.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bicard.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAccessToken(User user);
    }
}
