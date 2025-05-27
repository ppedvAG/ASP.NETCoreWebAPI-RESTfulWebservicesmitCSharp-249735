using Microsoft.AspNetCore.Identity;

namespace BusinessModel.Contracts
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}