using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;

public static class Security
{
    // Cố định IV
    private static byte[] fixedIV = new byte[16] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10 };

    // Encryption logic here
    public static string Encrypt(string input, string key)
    {
        byte[] keyBytes = GetSHA256Hash(key);

        using (var aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = fixedIV; // Sử dụng IV cố định

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

        try
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = fixedIV; // Sử dụng IV cố định

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
            return GenerateRandomString(16);
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
    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
