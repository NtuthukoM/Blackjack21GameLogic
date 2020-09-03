///<summary>
// Blackjack21 game logic
// usage: - create a new instance of 'Game' class
//        - call the 'StartGame' method passing in a list of player names
//        - call the 'EvaluateHands' method to get the results of the game.
///</summary>
using BlackJack21.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21.Core.Implementation
{
    public class Game : IGame
    {
        public Card[] Deck { get; set; }
        public Player[] Players { get; set; }
        public Player Dealer { get; set; }

        public Game()
        {
            Dealer = new Player() { Name = "Dealer" };
        }

        private void LoadCards()
        {
            string[] cardTypes = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            string[] royals = new string[] { "Jack", "Queen", "King" };
            int cardIndex = -1;
            Deck = new Card[52];
            foreach (string cardType in cardTypes)
            {
                //1 - 10
                for (int i = 1; i < 11; i++)
                {
                    cardIndex++;
                    Deck[cardIndex] = new Card()
                    {
                        Name = string.Format("{0} of {1}", i, cardType),
                        Value = i
                    };
                }
                //Royal cards:
                foreach (string royal in royals)
                {
                    cardIndex++;
                    Deck[cardIndex] = new Card()
                    {
                        Name = string.Format("{0} of {1}", royal, cardType),
                        Value = 10
                    };
                }
            }
        }

        /// <summary>
        /// Evaluates all the players' hands and displays the result in a string
        /// </summary>
        /// <returns></returns>
        public string EvaluateHands()
        {
            string scoreBoard = "";
            Dealer.RevealHand();
            scoreBoard += Dealer.ToString();
            scoreBoard += "\n\n";
            foreach(var player in Players)
            {
                player.RevealHand(Dealer.Score);
                scoreBoard += player.ToString();
                scoreBoard += "\n\n";
            }
            return scoreBoard;
        }

        private Card[] GetCards(int total)
        {
            Random random = new Random();
            Card[] cards = new Card[total];
            for (int i = 0; i< total; i++)
            {
                Card card;
                do
                {
                    // index to draw card from deck randomly
                    int idx = random.Next(0, 51);
                    card = Deck[idx];
                    if (card != null)
                    {
                        Deck[idx] = null;
                    }
                } while (card == null);
                cards[i] = card;
            }
            return cards;
        }

        public void StartGame(string[] playerNames)
        {
            LoadCards();
            Random random = new Random();

            // Set Dealer hand:
            Card[] cards = GetCards(2);
            Dealer.DrawCards(cards);

            // Set players hands:
            Players = new Player[playerNames.Length];
            for(int i = 0; i < playerNames.Length; i++)
            {
                Players[i] = new Player();
                Players[i].Name = playerNames[i];
                
                //assign cards:
                int cardsInHand = random.Next(3, 5);
                cards = GetCards(cardsInHand);
                Players[i].DrawCards(cards);
            }

        }
    }
}
