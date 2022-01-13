using DiscoverAirline.Security.API.Rules.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Rules.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<UsuarioToken> GenerateTokenAsync(IdentityUser user, IList<string> roles, ICollection<Claim> claims);

        public Task<string> GetRefreshTokenByToken(string userRefresh);
    }
}
