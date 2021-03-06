﻿using System;
using System.Security.Cryptography;
using System.Linq;

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

    // source: https://www.owasp.org/index.php/Using_Rfc2898DeriveBytes_for_PBKDF2
    public class PasswordHashWithPBKDF2 {
        private static int iterationCount = 20000;
        
        public static byte[] generateSalt() {
            // source: http://geekswithblogs.net/Nettuce/archive/2012/06/14/salt-and-hash-a-password-in.net.aspx
            byte[] saltBytes = new byte[32];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            return saltBytes;
        }

        // methods with password and salt as strings
        public static string hashPasswordAsString(string password) {
            // Generate the hash, with an automatic 32 byte salt
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32, iterationCount);
            byte[] hash = rfc2898DeriveBytes.GetBytes(20);
            // Return the hash
            return Convert.ToBase64String(hash);
        }

        public static string hashPasswordAsString(string password, byte[] salt) {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterationCount);
            byte[] hash = rfc2898DeriveBytes.GetBytes(20);
            // Return the salt and the hash
            //return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
            return Convert.ToBase64String(hash);
        }

        // TODO: consider using System.Security.SecureString
        public static bool compareWithStoredPassword(string password, string storedHash, byte[] salt) {
            return hashPasswordAsString(password, salt).Equals(storedHash);
        }

        // methods with password and salt as bytes
        public static byte[] hashPassword(string password) {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32, iterationCount);
            return rfc2898DeriveBytes.GetBytes(20);
        }

        public static byte[] hashPassword(string password, byte[] salt) {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterationCount);
            return rfc2898DeriveBytes.GetBytes(20);
        }

        public static bool compareWithStoredPassword(string password, byte[] storedHash, byte[] salt) {
            return hashPassword(password, salt).SequenceEqual(storedHash);
        }
    }
}