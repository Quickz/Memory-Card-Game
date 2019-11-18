using Memory_Card_Game.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory_Card_Game.Game
{
    public class CardGame
    {
        public Card[,] cards;

        public CardGame(int cardCountX, int cardCountY)
        {
            cards = new Card[cardCountX, cardCountY];

            for (int i = 0; i < cards.GetLength(0); i++)
            {
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    cards[i, j] = new Card("#" + StringUtility.RandomHexNumber(6));
                }
            }
        }
    }
}
