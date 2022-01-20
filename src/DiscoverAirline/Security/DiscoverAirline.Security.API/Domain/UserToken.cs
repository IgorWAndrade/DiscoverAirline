﻿using DiscoverAirline.Core;
using System;
using System.Linq;

namespace DiscoverAirline.Security.API.Domain
{
    public class UserToken : BaseEntity
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual User User { get; set; }

        public static string GenerateToken()
        {
            return RandomString(25) + Guid.NewGuid();
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
