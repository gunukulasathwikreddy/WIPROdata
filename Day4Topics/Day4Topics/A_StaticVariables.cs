using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    class CricketScore
    {
        public static int score;
        public void Increment(int x)
        {
           score += x;
        }

    }
    internal class A_StaticVariables
    {
        static void Main(string[] args)
        {
            CricketScore Batsman1 = new CricketScore();
            CricketScore Batsman2 = new CricketScore();
            CricketScore Batsman3 = new CricketScore();

            Batsman1.Increment(159);
            Batsman2.Increment(81);
            Batsman3.Increment(107);

            Console.WriteLine("The Circket Score is : " + CricketScore.score);
            
        }
    }
}
