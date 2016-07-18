using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class SimStatistics
    {
        public static int totalHandCount;
        public static int playerWins;
        public static int pushes;
        public static string nextMove;

        public static void Init()
        {
            totalHandCount = 0;
            playerWins = 0;
            pushes = 0;
            nextMove = "";
        }
  
    }
}
