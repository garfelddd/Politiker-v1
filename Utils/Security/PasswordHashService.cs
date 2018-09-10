using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Utils.Security
{
    public class PasswordHashService
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int IterationsCount = 5000;

        public static string GenerateSalt(int saltByteSize = SaltByteSize)
        {
            using (RNGCryptoServiceProvider cryptoService = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[saltByteSize];
                cryptoService.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public static string GenerateHash(string password, string salt)
        {
            if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException("Password is empty");
            }
            using (Rfc2898DeriveBytes hashService = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt)))
            {
                hashService.IterationCount = IterationsCount;
                return Convert.ToBase64String(hashService.GetBytes(HashByteSize));
            }
        }

        public static bool CompareHashes(string value, string hash, string salt)
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(hash) && string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException("Password is empty");
            }
            return hash == GenerateHash(value, salt);
        }
    }
}
