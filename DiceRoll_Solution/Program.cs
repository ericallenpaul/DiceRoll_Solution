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
            Console.WriteLine("Press enter to begin rolling.\n");
            Console.ReadLine();

            //draw the dice using text
            var die = new Dictionary<int, string>
            {
                { 1, "[     ]\n[  o  ]\n[     ]" },
                { 2, "[     ]\n[ o o ]\n[     ]" },
                { 3, "[  o  ]\n[ o o ]\n[     ]" },
                { 4, "[ o o ]\n[     ]\n[ o o ]" },
                { 5, "[ o o ]\n[  o  ]\n[ o o ]" },
                { 6, "[ o o ]\n[ o o ]\n[ o o ]" },
            };

            do
            {
                //use a little LINQ magic to get two random dice
                //sort the dictionary in random order and take the top two items
                var shuffled = die.OrderBy(x => Guid.NewGuid()).Take(2);
                foreach (KeyValuePair<int, string> i in shuffled)
                {
                    Console.WriteLine(i.Value);
                    Console.WriteLine();
                }
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
