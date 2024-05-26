using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Client.CS
{
    public static class Security
    {
        // Encryption logic here
        public static string Encrypt(string input, string key)
        {
            byte[] keyBytes = GetSHA256Hash(key);
            byte[] ivBytes = new byte[16]; // Initialization vector

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] dataBytes = Encoding.UTF8.GetBytes(input);
                        cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        // Decryption logic here
        public static string Decrypt(string cipherText, string key)
        {
            byte[] keyBytes = GetSHA256Hash(key);
            byte[] ivBytes = new byte[16]; // Initialization vector

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    using (var memoryStream = new MemoryStream(cipherBytes))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (var streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Invalid cipher text.");
            }
        }

        // SHA256 hash for key
        private static byte[] GetSHA256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                return sha256.ComputeHash(bytes);
            }
        }
    }
}
