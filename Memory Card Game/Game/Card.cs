using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory_Card_Game.Game
{
    public class Card
    {
        public string Color { get; private set; }

        public bool Revealed { get; set; }

        public Card(string color)
        {
            Color = color;
        }
    }
}
