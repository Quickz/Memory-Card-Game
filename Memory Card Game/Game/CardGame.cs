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
            IEnumerator<string> cardColors = CardColors();

            for (int y = 0; y < cards.GetLength(1); y++)
            {
                for (int x = 0; x < cards.GetLength(0); x++)
                {
                    cardColors.MoveNext();
                    cards[x, y] = new Card(cardColors.Current);
                }
            }
        }

        /// <summary>
        ///  Returns a color in form of a hexademical string.
        ///  Returns each random value twice.
        /// </summary>
        private IEnumerator<string> CardColors()
        {
            while (true)
            {
                string color = "#" + StringUtility.RandomHexNumber(6);
                yield return color;
                yield return color;
            }
        }
    }
}
