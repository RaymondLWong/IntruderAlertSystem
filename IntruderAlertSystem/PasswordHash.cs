using System;
using System.Security.Cryptography;
using BCrypt.Net;
using static System.Security.Cryptography.Rfc2898DeriveBytes;

namespace IntruderAlertSystem {
    // source: https://cmatskas.com/a-simple-net-password-hashing-implementation-using-bcrypt/
    public class PasswordHashWithBCrypt {
        private static string GetRandomSalt() {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string correctHash) {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }

    public class PasswordHashWithPBKDF2 {
        // source: https://www.owasp.org/index.php/Using_Rfc2898DeriveBytes_for_PBKDF2
        public static string hashPassword(string password) {
            // Generate the hash, with an automatic 32 byte salt
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32);
            rfc2898DeriveBytes.IterationCount = 20000;
            byte[] hash = rfc2898DeriveBytes.GetBytes(20);
            byte[] salt = rfc2898DeriveBytes.Salt;
            // Return the salt and the hash
            return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
        }

        // TODO: consider using System.Security.SecureString
        public static bool compareWithStoredPassword(string password, string storedHash) {
            return hashPassword(password).Equals(storedHash);
        }
    }
}