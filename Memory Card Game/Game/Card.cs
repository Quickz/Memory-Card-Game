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
                return hiddenStateColor;
            }
        }

        public bool Revealed { get; set; }

        private readonly string revealedStateColor;
        private const string hiddenStateColor = "#c3c3c3";

        public Card(string color)
        {
            revealedStateColor = color;
        }

        public void Click()
        {
            Clicked?.Invoke(this, this);
        }
    }
}
