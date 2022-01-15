using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Application.ViewModels;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Notification> RegisterAsync(UsuarioRegistro userRequest);
        Task<Notification> LoginAsync(UsuarioLogin userRequest);
        Task<Notification> LogoutAsync(string email);
        Task<Notification> LoginRefreshAsync(string refreshToken);
    }
}
