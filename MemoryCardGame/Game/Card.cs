using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCardGame.Game
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

        public string Text { get; private set; }

        public double Opacity
        {
            get
            {
                if (Enabled)
                {
                    return 1f;
                }
                return 0.5f;
            }
        }

        public bool Revealed { get; set; }
        public bool Enabled { get; set; } = true;

        private const string HiddenStateColor = "#c3c3c3";
        private readonly string revealedStateColor;

        public Card(string color, string text)
        {
            revealedStateColor = color;
            Text = text;
        }
        
        public void Click()
        {
            if (!Enabled)
            {
                return;
            }
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
