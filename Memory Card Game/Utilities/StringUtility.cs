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
    }
}
