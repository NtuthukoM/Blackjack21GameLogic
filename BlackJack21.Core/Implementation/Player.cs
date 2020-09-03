using BlackJack21.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21.Core.Implementation
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Result { get; set; }
        public Card[] Hand { get; set; }


        public void DrawCards(Card[] cards)
        {
            Hand = cards;
            Result = string.Empty;
            Score = 0;
        }

        public void RevealHand(int dealerScore = 0)
        {
            if(Hand == null)
            {
                throw new ApplicationException("Cards not dealt.");
            }
            foreach (Card card in Hand)
            {
                Score += card.Value;
            }
            //0 is passed if player is the actual dealer
            if(dealerScore > 0)
            {
                if(Score < 21 && Hand.Length == 5)
                {
                    Result = "Beats the dealer";
                }
                else if(Score >= dealerScore && Score <= 21)
                {
                    Result = "Beats the dealer";
                }
                else
                {
                    Result = "Loses";
                }
            }

        }

        public override string ToString()
        {
            string display = "";
            display += string.Format("Player name: {0}\n", Name);   
            if(Hand != null)
            {
                display += "\t\t--- Hand --\n";
                foreach(Card card in Hand)
                {
                    display += string.Format("{0}, ", card.Name);
                }
                display += "\t\t-----------\n";

                display += string.Format("Player score: {0}\n", Score);
                if (!string.IsNullOrEmpty(Result))
                {
                    display += string.Format("Player result: {0}\n", Result);
                }
            }
            return display;
        }
    }
}
