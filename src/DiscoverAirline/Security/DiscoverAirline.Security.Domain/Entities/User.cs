using DiscoverAirline.Core;
using DiscoverAirline.Security.API.Models.Entities.ValueObjects;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DiscoverAirline.Security.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual UserRefreshToken Token { get; set; }

        public Address Address { get; set; }

        public static User ToRegisterFromClass(dynamic userRequest)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(userRequest.Password);
            return new User
            {
                Cpf = userRequest.Cpf,
                Email = userRequest.Email,
                Password = userRequest.Password,
                PasswordHash = System.Convert.ToBase64String(passwordBytes),
                Address = new Address
                {
                    City = userRequest.Address.City,
                    District = userRequest.Address.District,
                    Number = userRequest.Address.Number,
                    State = userRequest.Address.State,
                    Street = userRequest.Address.Street,
                    ZipCode = userRequest.Address.ZipCode
                }
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
            if (!ValidCpf(user.Cpf))
                return false;

            if (!ValidPasswoard(user.Password))
                return false;

            if (!ValidZipCode(user.Address.ZipCode))
                return false;

            return true;
        }

        private static bool ValidCpf(string cpf)
        {
            var hasCpf = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

            return hasCpf.IsMatch(cpf);
        }

        private static bool ValidZipCode(string zipCode)
        {
            var hasZipCode = new Regex(@"^\d{5}-\d{3}$");

            return hasZipCode.IsMatch(zipCode);
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
