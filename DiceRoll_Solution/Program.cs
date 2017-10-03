using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will allow you to roll two dice");
            Console.WriteLine("as many times as you want.");
            Console.WriteLine("Press enter twice to begin rolling.\n");
            Console.ReadLine();

            do
            {
                Console.WriteLine("Dice 1 rolled: {0}", RollDie());
                Console.WriteLine("Dice 2 rolled: {0}", RollDie());
                Console.WriteLine("Press enter to roll again or type q for quit");

            } while (Console.ReadLine() != "q");
        }

        private static int RollDie()
        {
            //set up a return value
            int returnValue = 0;

            //seed the random function to ensure randomness
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            //populate the returnvalue
            returnValue = rnd.Next(1, 7);

            //return the new random integer value
            return returnValue;
        }

    }
}
