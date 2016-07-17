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
        List<Hand> handsList = new List<Hand>();
        int dealerUpCard;
        int dealerDownCard;
        Hand dealerHand;

        int playerCardOne;
        int playerCardTwo;
        Hand playerHand;

        int numOfSims;
        int extraHands;


        public Simulator(int dealerUpCard, int playerCardOne, int playerCardTwo, int numOfSims)
        {
            deck = new Deck();
            this.dealerUpCard = dealerUpCard;
            this.playerCardOne = playerCardOne;
            this.playerCardTwo = playerCardTwo;
            this.numOfSims = numOfSims;
        }

        public void BeginSim()
        {
            for (int i = 0; i < numOfSims; i++)
            {
                handsList.Clear();
                InitDealerHand();
                InitPlayerHand();
                RunSim();
            }
        }

        private void InitDealerHand()
        {
            dealerDownCard = deck.getCard();
            dealerHand = new Hand(dealerUpCard, dealerDownCard, HandOwner.DEALER);
            handsList.Add(dealerHand);
        }

        private void InitPlayerHand()
        {
            if ((playerCardOne == 11 && playerCardTwo != 11) ||
                (playerCardOne != 11 && playerCardTwo == 11))
            {
                if (playerCardOne + playerCardTwo >= 18)
                {
                    playerHand = new Hand(playerCardOne, playerCardTwo, HandOwner.PLAYER);
                }
                else
                {
                    playerCardOne = playerCardOne == 11 ? playerCardOne = 1 : playerCardOne;
                    playerCardTwo = playerCardTwo == 11 ? playerCardTwo = 1 : playerCardTwo;
                    playerHand = new Hand(playerCardOne, playerCardTwo, HandOwner.PLAYER);
                }
            }
            else
            {
                playerHand = new Hand(playerCardOne, playerCardTwo, HandOwner.PLAYER);
            }

            handsList.Add(playerHand);
        }

        private void RunSim()
        {
            CheckDealerBlackjack();
            CheckPlayerBlackjack();

            if (!dealerHand.IsBlackjack)
            {
                PlayerDecision();
                DealerDecision();
            }
            else
            {
                RoundOver();
            }

            RoundOver();

        }

        private void CheckDealerBlackjack()
        {
            if (dealerHand.HandValue == 21)
            {
                dealerHand.IsBlackjack = true;
            }
        }

        private void CheckPlayerBlackjack()
        {
            if (playerHand.HandValue == 21)
            {
                playerHand.IsBlackjack = true;
            }
        }

        private void PlayerDecision()
        {
            bool shouldHit = false;
            bool shouldStay = false;
            bool shouldSplit = false;
            bool shouldDoubleDown = false;
            bool canProceed = true;

            shouldSplit = ShouldSplitHand();
            shouldDoubleDown = ShouldDoubleDown();

            if (shouldSplit)
            {
                SplitHand();
                canProceed = false;
            }
            else if (shouldDoubleDown)
            {
                DoubleDown(ref playerHand);
                canProceed = false;
            }


            if (canProceed && dealerUpCard >= 7)
            {
                while (playerHand.HandValue <= 16 &&
                    playerHand.HandStatusString.Equals(HandStatus.LIVE) &&
                    !playerHand.IsStay)
                {
                    Hit(ref playerHand);
                }
                canProceed = false;
            }

            if (canProceed && dealerUpCard <= 6 && playerHand.HandValue <= 9)
            {
                while (playerHand.HandValue <= 11 && !playerHand.IsStay)
                {
                    Hit(ref playerHand);
                }
                canProceed = false;
            }

            if (canProceed)
            {
                playerHand.IsStay = true;
            }


        }

        private void DealerDecision()
        {
            while (dealerHand.HandValue <= 16 &&
                playerHand.HandStatusString == HandStatus.LIVE &&
                !dealerHand.IsStay)
            {
                Hit(ref dealerHand);
            }
        }

        private bool ShouldSplitHand()
        {
            bool shouldSplit = false;

            if (playerCardOne == playerCardTwo)
            {
                switch (playerCardOne)
                {
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        shouldSplit = true;
                        break;
                    case 9:
                        break;
                    case 10:
                        shouldSplit = false;
                        break;
                    case 11:
                        shouldSplit = true;
                        break;
                }
            }

            return shouldSplit;
        }

        private bool ShouldDoubleDown()
        {
            bool shouldDoubleDown = false;

            if ((playerHand.HandValue == 11 ||
                playerHand.HandValue == 10) &&
                (playerHand.HandValue > dealerUpCard))
            {
                shouldDoubleDown = true;
            }
            else if (playerHand.HandValue == 9 &&
                dealerUpCard <= 6 && dealerUpCard >= 3)
            {
                shouldDoubleDown = true;
            }

            return shouldDoubleDown;
        }

        private void Hit(ref Hand hand)
        {
            int newCard = deck.getCard();

            if (newCard == 11)
            {
                newCard = newCard + hand.HandValue > 21 ? 1 : 11;
            }

            hand.HandValue = newCard;

            if (hand.HandValue > 21)
            {
                hand.HandStatusString = HandStatus.BUSTED;
                hand.IsStay = true;
            }
            else if (hand.HandValue >= 17)
            {
                hand.IsStay = true;
            }
        }



        private void DoubleDown(ref Hand hand)
        {
            Hit(ref hand);
            hand.IsStay = true;
        }

        private void SplitHand()
        {

        }

        private void RoundOver()
        {
            foreach (Hand hand in handsList)
            {
                // check live hands for values and winners
                // then send to stat class for accumulation.
                if (hand.HandOwnerString.Equals(HandOwner.PLAYER))
                {
                    if (hand.HandValue > dealerHand.HandValue)
                    {
                        SimStatistics.playerWins++;
                    }
                    else if (hand.HandValue == dealerHand.HandValue)
                    {
                        SimStatistics.pushes++;
                    }
                    SimStatistics.totalHandCount = numOfSims + extraHands;
                }
            }
        }
    }

}