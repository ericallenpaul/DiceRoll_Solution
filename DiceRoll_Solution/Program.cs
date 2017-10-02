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
            //set the output encoding
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("This program will allow you to roll two dice");
            Console.WriteLine("as many times as you want.");
            Console.WriteLine("Press enter twice to begin rolling.\n");
            Console.ReadLine();

            var die = new Dictionary<int, string>
            {
                { 1, "┌─────────┐\n│         │\n│    ○    │\n│         │\n└─────────┘" },
                { 2, "┌─────────┐\n│         │\n│  ○   ○  │\n│         │\n└─────────┘" },
                { 3, "┌─────────┐\n│    ○    │\n│  ○   ○  │\n│         │\n└─────────┘" },
                { 4, "┌─────────┐\n│  ○   ○  │\n│         │\n│  ○   ○  │\n└─────────┘" },
                { 5, "┌─────────┐\n│  ○   ○  │\n│    ○    │\n│  ○   ○  │\n└─────────┘" },
                { 6, "┌─────────┐\n│  ○   ○  │\n│  ○   ○  │\n│  ○   ○  │\n└─────────┘" },
            };

            do
            {
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
