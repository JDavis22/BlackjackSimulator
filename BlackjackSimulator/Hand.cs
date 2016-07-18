using BlackjackSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class Hand
    {
        private int cardOne;
        private int cardTwo;
        private int handValue;
        private string handStatus;
        private string handOwner;
        private bool isDoubleDown;
        private bool isStay;
        private bool isBlackjack;

        public Hand(int cardOne, int cardTwo, string handOwner)
        {
            this.cardOne = cardOne;
            this.cardTwo = cardTwo;
            this.handOwner = handOwner;
            handValue = cardOne + cardTwo;
            handStatus = HandStatus.LIVE;
            isStay = false;
            isBlackjack = false;
            isDoubleDown = false;
        }

        public int CardOne
        {
            get
            {
                return cardOne;
            }
            set
            {
                cardOne = value;
            }
        }

        public int CardTwo
        {
            get
            {
                return cardTwo;
            }
            set
            {
                cardTwo = value;
            }
        }

        public string HandStatusString
        {
            get
            {
                return handStatus;
            }
            set
            {
                handStatus = value;
            }
        }

        public bool IsStay { get; set; }

        public bool IsBlackjack { get; set; }

        public string HandOwnerString
        {
            get
            {
                return handOwner;
            }
            set
            {
                handOwner = value;
            }
        }

        public int HandValue
        {
            get
            {
                return handValue;
            }
            set
            {
                handValue += value;
            }
        }

        public bool IsDoubleDown
        {
            get
            {
                return isDoubleDown;
            }
            set
            {
                isDoubleDown = value;
            }
        }
    }
}
