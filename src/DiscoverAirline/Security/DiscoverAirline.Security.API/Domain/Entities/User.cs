using DiscoverAirline.Core;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DiscoverAirline.Security.API.Domain
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public virtual List<Role> Roles { get; set; }
        public virtual List<UserToken> Tokens { get; set; } = new List<UserToken>();

        public static User ToRegisterFromClass(dynamic userRequest)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(userRequest.Password);
            return new User
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                PasswordHash = System.Convert.ToBase64String(passwordBytes)
            };
        }
        public static User ToLoginFromClass(dynamic userRequest)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(userRequest.Password);
            return new User
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                PasswordHash = System.Convert.ToBase64String(passwordBytes)
            };
        }

        public static string ToPasswordHash(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(passwordBytes);
        }

        public static string ToPasswordString(string passwordHash)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(passwordHash);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool Valid(User user)
        {
            if (!ValidPasswoard(user.Password))
                return false;

            return true;
        }

        private static bool ValidPasswoard(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            return hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
        }
    }
}
