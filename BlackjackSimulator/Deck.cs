using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class Deck
    {
        private const int shoeSize = 312;
        private int[] shoeArray;
        private List<int> shoeList = new List<int>();

        public Deck()
        {
            InitDeck();
        }

        private void InitDeck()
        {
            shoeList = new List<int>();
            shoeList.Clear();

            shoeArray = new int[shoeSize];
            shoeArray.Initialize();

            int pos = 0;

            // normal cards
            for (int i = 2; i <= 9; i++)
            {
                for(int t = 0; t < 24; t++)
                {
                    shoeArray.SetValue(i, pos);
                    pos++;
                }
            }

            // tens
            for(int i = 0; i < 96; i++)
            {
                shoeArray.SetValue(10, pos);
                pos++;
            }

            // aces
            for (int i = 0; i < 24; i++)
            {
                shoeArray.SetValue(11, pos);
                pos++;
            }

            shoeList = shoeArray.ToList<int>();
        }

        public int getCard()
        {
            int randomPos = 0;
            int cardValue = 0;
            Random random = new Random();
            randomPos = random.Next(0, shoeList.Count);

            cardValue = shoeList[randomPos];
            shoeList.RemoveAt(randomPos);

            if(shoeList.Count <= 30)
            {
                InitDeck();
            }

            return cardValue;
        }


    }
}
