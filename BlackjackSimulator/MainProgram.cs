using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class MainProgram
    {
        static int dealerUpCard = 0;
        static int playerCardOne = 0;
        static int playerCardTwo = 0;
        static int numOfSims = 1000;

        static void Main(string[] args)
        {
            PrintHeader();
            GetDealerUpCard();
            GetPlayerCardOne();
            GetPlayerCardTwo();
            GetHandSimulationCount();
            RunSim();
        }

        static void PrintHeader()
        {
            Console.WriteLine("Welcome to the Blackjack Hand Simulator");
            Console.WriteLine("You will enter the Dealer's Up Card and your individual starting cards, then how many hand simulations you want to run.\n");
        }

        static void GetDealerUpCard()
        {
            int result;

            Console.WriteLine("Please enter the Dealer's Up Card");

            if (Int32.TryParse(Console.ReadLine(), out result) && result <= 11 && result >= 1)
            {
                dealerUpCard = result;
            }
            else
            {
                Console.WriteLine("Bad number entered for Dealer Up Card, try again.");
                GetDealerUpCard();
            }
        }

        static void GetPlayerCardOne()
        {
            int result;

            Console.WriteLine("Please enter the Player's First Card");

            if (Int32.TryParse(Console.ReadLine(), out result) && result <= 11 && result >= 1)
            {
                playerCardOne = result;
            }
            else
            {
                Console.WriteLine("Bad number entered for Player's First Card, try again.");
                GetPlayerCardOne();
            }
        }

        static void GetPlayerCardTwo()
        {
            int result;

            Console.WriteLine("Please enter the Player's Second Card.");

            if (Int32.TryParse(Console.ReadLine(), out result) && result <= 11 && result >= 1)
            {
                playerCardTwo = result;
            }
            else
            {
                Console.WriteLine("Bad number entered for Player's Second Card, try again.");
                GetPlayerCardTwo();
            }
        }

        static void GetHandSimulationCount()
        {
            int result;

            Console.WriteLine("Please enter the number of simulations to run.");

            if (Int32.TryParse(Console.ReadLine(), out result) && result >= 1)
            {
                numOfSims = result;
            }
            else
            {
                Console.WriteLine("Bad number entered for number of simulations, try again.");
                GetHandSimulationCount();
            }
        }

        static void RunSim()
        {
            Console.WriteLine("Running Simulation...");
            Console.WriteLine("...");
            Simulator sim = new Simulator(dealerUpCard, playerCardOne, playerCardTwo, numOfSims);
            sim.BeginSim();
            Console.WriteLine(SimStatistics.playerWins);
            Console.WriteLine(SimStatistics.totalHandCount);
            Console.ReadKey();
        }
    }
}
