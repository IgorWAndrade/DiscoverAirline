using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.ValueObjects;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<Token> GenerateTokenAsync(User user);

        public Task<int> GetRefreshTokenByToken(string userRefresh);
    }
}
