using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models.Request;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services.Abastractions
{
    public interface IUserService
    {
        Task<Notification> CreateAsync(UserRegisterRequest model);
    }
}
