using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace loginIndian.Classes
{
    internal class GenerateCode
    {
        private static readonly Random random = new Random();

        public static string CreateVerificationCode(int length = 4, VerificationType type = VerificationType.Alphanumeric)
        {
            string allowedChars = "";

            switch (type)
            {
                case VerificationType.Alphanumeric:
                    allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                case VerificationType.Numeric:
                    allowedChars = "0123456789";
                    break;
                case VerificationType.SpecialCharacters:
                    allowedChars = "!@#$%^&*()_+-=[]{}|;':\"\\,./<>?";
                    break;
                default:
                    throw new ArgumentException("Invalid verification type");
            }

            StringBuilder code = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                code.Append(allowedChars[random.Next(allowedChars.Length)]);
            }

            return code.ToString();
        }

        public enum VerificationType
        {
            Alphanumeric,
            Numeric,
            SpecialCharacters
        }
    }
}
