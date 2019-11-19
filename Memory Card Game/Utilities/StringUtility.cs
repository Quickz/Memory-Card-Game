using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory_Card_Game.Utilities
{
    public static class StringUtility
    {
        private static Random random = new Random();

        public static string RandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);

            string result = string
                .Concat(buffer.Select(x => x.ToString("X2"))
                .ToArray());

            if (digits % 2 == 0)
            {
                return result;
            }

            return result + random.Next(16).ToString("X");
        }

        public static string RandomHexColor(
            byte minRed = 0,
            byte maxRed = 255,
            byte minGreen = 0,
            byte maxGreen = 255,
            byte minBlue = 0,
            byte maxBlue = 255)
        {
            byte[] buffer = new byte[3];

            buffer[0] = (byte)random.Next(minRed, maxRed);
            buffer[1] = (byte)random.Next(minGreen, maxGreen);
            buffer[2] = (byte)random.Next(minBlue, maxBlue);

            string result = string.Concat(buffer
                .Select(x => x.ToString("X2"))
                .ToArray());

            return "#" + result;
        }
    }
}
