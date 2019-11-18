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
            if (cardCountX * cardCountY % 2 != 0)
            {
                throw new InvalidOperationException(
                    "Total card count has to be an even number " +
                    "otherwise there'll be a pair lacking a card");
            }

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
