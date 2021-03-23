using System;
using System.Security.Cryptography;

namespace SlackClone.Auth.Core.Models
{
    public class UserCredentials
    {
        public string Email { get; }
        public string Hash { get; }
        public string Salt { get; }

        public UserCredentials(
            string email,
            string password)
        {
            Email = email;

            Salt = GenerateSalt();
            Hash = ComputeHash(password, Salt);
        }

        public UserCredentials(
            string email,
            string salt,
            string hash)
        {
            Email = email;
            Salt = salt;
            Hash = hash;
        }

        private static string GenerateSalt()
        {
            byte[] salt = new byte[192 / 8];

            using var gen = RandomNumberGenerator.Create();
            gen.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        private static string ComputeHash(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using var gen = new Rfc2898DeriveBytes(password, saltBytes);
            byte[] hashBytes = gen.GetBytes(192 / 8);

            return Convert.ToBase64String(hashBytes);
        }

        public bool IsMatchingPassword(string password)
        {
            return ComputeHash(password, Salt) == Hash;
        }
    }
}
