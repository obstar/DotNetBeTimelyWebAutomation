using System;
using System.IO;
using System.Text;

namespace DotNetBeTimelyWebAutomation.Tests.Support
{
    public class FormDataGenerator
    {
        private static readonly Random Rnd = new();

        public string SomeNewGuid()
        {
            return Guid.NewGuid()
                       .ToString("N");
        }

        public string SomeNewGuid(int charactersNumberToRemove)
        {
            return Guid.NewGuid()
                       .ToString("N")
                       .Remove(0, charactersNumberToRemove);
        }

        public string SomeText(int characterCount,
                               bool intOnly = false)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!?_+=";
            if (intOnly)
                characters = "0123456789";
            var sb = new StringBuilder();
            for (var i = 0; i < characterCount; i++)
                sb.Append(characters[Rnd.Next(characters.Length)]);

            return sb.ToString();
        }

        public string SomeAlphanumericText(int characterCount)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

            var sb = new StringBuilder();
            for (var i = 0; i < characterCount; i++)
                sb.Append(characters[Rnd.Next(characters.Length)]);

            return sb.ToString();
        }

        public string SomeTextStartingWith(string prefix,
                                           int characterCount)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

            var sb = new StringBuilder();
            sb.Append(prefix);
            for (var i = 0; i < characterCount - prefix.Length; i++)
                sb.Append(characters[Rnd.Next(characters.Length)]);

            return sb.ToString();
        }

        public string AnAlphaCode(int characterCount)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var sb = new StringBuilder();
            for (var i = 0; i < characterCount; i++)
                sb.Append(characters[Rnd.Next(characters.Length)]);

            return sb.ToString();
        }

        public string AnAlphaNumericCode(int characterCount)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var sb = new StringBuilder();
            for (var i = 0; i < characterCount; i++)
                sb.Append(characters[Rnd.Next(characters.Length)]);

            return sb.ToString();
        }

        public string OneRandomCharFromString(string characters)
        {
            var index = Rnd.Next(characters.Length);
            return characters[index]
                .ToString();
        }

        public bool ABoolean()
        {
            return Rnd.NextDouble() >= 0.5;
        }

        public int SomeNumber(int minNumber,
                              int maxNumber)
        {
            return Rnd.Next(minNumber, maxNumber);
        }

        public decimal SomeDecimal(
            int minNumber,
            int maxNumber,
            int decimals = 2)
        {
            if (maxNumber <= minNumber) throw new InvalidDataException($"minNumber: {minNumber} should be less than maxNumber: {maxNumber}. Review your parameters");

            var divisor = 1;
            for (var i = 0; i < decimals; i++) divisor = divisor * 10;

            var decimalPart = (decimal) SomeNumber(0, divisor - 1) / divisor;
            var value = SomeNumber(minNumber, maxNumber) + decimalPart;
            return decimal.Round(value, decimals, MidpointRounding.AwayFromZero);
        }

        public decimal SomePercent(int min = 0,
                                   int max = 100)
        {
            var ret = Rnd.Next(0, 100 * max);
            return ret / 100m;
        }

        public static string Base64EncodeCredentials(string email,
                                                     string password)
        {
            var userCredentialsBase64Encoded = Encoding.UTF8.GetBytes($"{email}:{password}");
            return Convert.ToBase64String(userCredentialsBase64Encoded);
        }
    }
}