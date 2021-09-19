﻿using DiscoverAirline.Security.API.Models.Response;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.API.Services
{
    public interface ITokenService
    {
        Task<UserDefaultResponse> GenerateTokenAsync(string email);
    }
}
