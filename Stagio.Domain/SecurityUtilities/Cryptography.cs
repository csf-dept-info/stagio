using System;
using System.Security.Cryptography;

namespace Stagio.Domain.SecurityUtilities
{
    public static class Cryptography
    {
        public static string Encrypt(string stringToEncrypt)
        {
            var passBytes = new PasswordDeriveBytes(stringToEncrypt, null);
            var key = passBytes.CryptDeriveKey("RC2", "SHA1", 128, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });

            return BitConverter.ToString(key);
        }
    }
}
