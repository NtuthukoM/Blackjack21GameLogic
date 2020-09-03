using BlackJack21.Core.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21.Core.Interfaces
{
    public interface IPlayer
    {
        void DrawCards(Card[] cards);
        void RevealHand(int dealerScore = 0);
    }
}
