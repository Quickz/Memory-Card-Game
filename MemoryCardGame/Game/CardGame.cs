﻿using MemoryCardGame.Utilities;
using MemoryCardGame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCardGame.Game
{
    public class CardGame
    {
        public bool won { get; private set; }
        public Card[,] cards;

        private List<Card> selectedCards = new List<Card>();

        public CardGame(int cardCountX, int cardCountY)
        {
            if (cardCountX * cardCountY % 2 != 0)
            {
                throw new InvalidOperationException(
                    "Total card count has to be an even number " +
                    "otherwise there'll be a pair lacking a card");
            }

            cards = new Card[cardCountX, cardCountY];
            StartNewSession();
        }

        public void StartNewSession()
        {
            selectedCards.Clear();
            won = false;
            IEnumerator<string> cardColors = CardColors();
            IEnumerator<int> cardNumbers = CardNumbers();

            for (int y = 0; y < cards.GetLength(1); y++)
            {
                for (int x = 0; x < cards.GetLength(0); x++)
                {
                    cardColors.MoveNext();
                    cardNumbers.MoveNext();

                    cards[x, y] = new Card(
                        cardColors.Current,
                        cardNumbers.Current.ToString());

                    cards[x, y].Clicked += OnCardClicked;
                }
            }

            cards.Shuffle();
        }

        private void OnCardClicked(object sender, Card card)
        {
            if (card.Revealed || won)
            {
                return;
            }

            if (selectedCards.Count >= 2)
            {
                if (AllSelectedCardsAreSameColor())
                {
                    foreach (Card selectedCard in selectedCards)
                    {
                        selectedCard.Enabled = false;
                    }
                }
                else
                {
                    foreach (Card selectedCard in selectedCards)
                    {
                        selectedCard.Revealed = false;
                    }
                }
                
                selectedCards.Clear();
            }

            card.Revealed = true;
            selectedCards.Add(card);

            if (AllCardsAreRevealed())
            {
                won = true;
            }
        }

        private bool AllSelectedCardsAreSameColor()
        {
            for (int i = 1; i < selectedCards.Count; i++)
            {
                if (!selectedCards[0].Matches(selectedCards[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///  Returns a color in form of a hexademical string.
        ///  Returns each random value twice.
        /// </summary>
        private IEnumerator<string> CardColors()
        {
            while (true)
            {
                string color = StringUtility.RandomHexColor(0, 125, 0, 125, 0, 125);
                yield return color;
                yield return color;
            }
        }

        private IEnumerator<int> CardNumbers()
        {
            for (int i = 1; true; i++)
            {
                yield return i;
                yield return i;
            }
        }

        private bool AllCardsAreRevealed()
        {
            for (int y = 0; y < cards.GetLength(1); y++)
            {
                for (int x = 0; x < cards.GetLength(0); x++)
                {
                    if (!cards[x, y].Revealed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
