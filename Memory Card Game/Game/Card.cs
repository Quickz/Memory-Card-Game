using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory_Card_Game.Game
{
    public class Card
    {
        public event EventHandler<Card> Clicked;

        public string Color
        {
            get
            {
                if (Revealed)
                {
                    return revealedStateColor;
                }
                return HiddenStateColor;
            }
        }

        public bool Revealed { get; set; }

        private const string HiddenStateColor = "#c3c3c3";
        private readonly string revealedStateColor;

        public Card(string color)
        {
            revealedStateColor = color;
        }
        
        public void Click()
        {
            Clicked?.Invoke(this, this);
        }

        /// <summary>
        ///  Returns true if both cards have the same
        ///  reveal state color.
        /// </summary>
        public bool Matches(Card card)
        {
            return revealedStateColor == card.revealedStateColor;
        }
    }
}
