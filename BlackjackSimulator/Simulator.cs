using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class Simulator
    {
        Deck deck;

        int dealerUpCard;
        int dealerDownCard;
        int dealerHand = 0;

        int playerCardOne;
        int playerCardTwo;
        int playerHand = 0;


        public Simulator(int dealerUpCard, int playerCardOne, int playerCardTwo)
        {
            deck = new Deck();
            this.dealerUpCard = dealerUpCard;
            this.playerCardOne = playerCardOne;
            this.playerCardTwo = playerCardTwo;
        }

        public void BeginSim()
        {  
            InitDealerHand();
            InitPlayerHand();
        }

        private void InitDealerHand()
        {
            dealerDownCard = deck.getCard();
            dealerHand = dealerUpCard + dealerDownCard;
        }

        private void InitPlayerHand()
        {
            if ((playerCardOne == 11 && playerCardTwo != 11) ||
                (playerCardOne != 11 && playerCardTwo == 11))
            {
                if(playerCardOne + playerCardTwo >= 18)
                {
                    playerHand = playerCardOne + playerCardTwo;
                }
                else
                {
                    playerCardOne = playerCardOne == 11 ? playerCardOne = 1 : playerCardOne;
                    playerCardTwo = playerCardTwo == 11 ? playerCardTwo = 1 : playerCardTwo;
                    playerHand = playerCardOne + playerCardTwo;
                }
                
            }
        }
    }
}
