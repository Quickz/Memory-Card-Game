using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory_Card_Game.Game
{
    public class CardGame
    {
        public Card[,] cards;
        private Random random = new Random();

        public CardGame(int cardCountX, int cardCountY)
        {
            cards = new Card[cardCountX, cardCountY];

            for (int i = 0; i < cards.GetLength(0); i++)
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    cards[i, j] = new Card("#" + RandomHexNumber(6));
                }
            }
        }

        public string RandomHexNumber(int digits)
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
