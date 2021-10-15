using DiscoverAirline.Security.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Domain.ValueObjects
{
    public class Token
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string TokenTypeAccess { get; set; }
        public string TokenCode { get; set; }
        public string TokenRefreshCode { get; set; }
        public DateTime TokenValidTo { get; set; }
        public DateTime TokenValidFrom { get; set; }
        public DateTime TokenRefreshExiration { get; set; }

        public static Token Generate(User user, UserRefreshToken tokenRefresh, string token, DateTime validTo, DateTime validFrom)
        {
            return new Token
            {
                UserId = user.Id,
                UserEmail = user.Email,
                TokenCode = token,
                TokenTypeAccess = "Bearer",
                TokenValidTo = validTo,
                TokenValidFrom = validFrom,
                TokenRefreshCode = tokenRefresh.Token,
                TokenRefreshExiration = tokenRefresh.ExpiryDate
            };
        }
    }
}
