using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21.Core.Interfaces
{
    public interface IGame
    {
        void StartGame(string[] playerNames);
        string EvaluateHands();
    }
}
