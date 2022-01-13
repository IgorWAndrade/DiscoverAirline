using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Rules.ViewModels;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Rules.Services.Interfaces
{
    public interface IUserService
    {
        Task<Notification> RegisterAsync(UsuarioRegistro userRequest);
        Task<Notification> LoginAsync(UsuarioLogin userRequest);
        Task<Notification> LogoutAsync(string email);
        Task<Notification> LoginRefreshAsync(string refreshToken);
    }
}
