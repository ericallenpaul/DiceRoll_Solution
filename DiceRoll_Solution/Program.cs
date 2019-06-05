using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

            //tell the user what to do
            Console.WriteLine("This program will allow you to roll two dice");
            Console.WriteLine("as many times as you want.");
            Console.WriteLine("Press enter to begin rolling.\n");
            Console.ReadLine();

            //create the string componenets we need to create the die faces
            string top    = "┌───────────┐";
            string zero   = "│           │";
            string one    = "│     ○     │";
            string two    = "│  ○     ○  │";
            string bottom = "└───────────┘";

            //use the componenets to create the die face as a string array
            string[] dieFace1 = { top, zero, zero, one, zero, zero, bottom };
            string[] dieFace2 = { top, zero, zero, two, zero, zero, bottom };
            string[] dieFace3 = { top, zero, one, zero, two, zero, bottom };
            string[] dieFace4 = { top, zero, two, zero, two, zero, bottom };
            string[] dieFace5 = { top, zero, two, one, two, zero, bottom };
            string[] dieFace6 = { top, zero, two, two, two, zero, bottom };

            //assemble the die using a dictionary
            //the integers will become our index
            var die = new Dictionary<int, string[]>
            {
                {1, dieFace1},
                {2, dieFace2},
                {3, dieFace3},
                {4, dieFace4},
                {5, dieFace5},
                {6, dieFace6},
            };

            do
            {
                //let the user know we're rolling the dice
                Console.WriteLine();
                Console.WriteLine("Rolling the dice...");
                Console.WriteLine();

                //play the dice roll sound
                PlayDiceRollSound();

                //the sound file is about 2.5 seconds long so wait to display the dice until the sound plays
                System.Threading.Thread.Sleep(2500);

                //grab two of the dice out of our array using the old method
                int dieOneRoll = RollDie();
                int dieTwoRoll = RollDie();

                //get the die faces
                string[] firstDie = die[dieOneRoll];
                string[] secondDie = die[dieTwoRoll];

                //loop through the die faces
                for (int i = 0; i < 7; i++)
                {
                    //print each face one line at a time
                    Console.WriteLine($"{firstDie[i]}  {secondDie[i]}");
                }

                //write a blank line
                Console.WriteLine();

                //give the user some feed back
                FeedBack(dieOneRoll, dieTwoRoll);

                //give the user some instruction
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

        private static void PlayDiceRollSound()
        {
            Stream str = Properties.Resources.ShakeAndRollDiceSound;
            SoundPlayer sp = new SoundPlayer(str);
            sp.Play();
        }

        private static void FeedBack(int DieOneRoll, int DieTwoRoll)
        {
            if (DieOneRoll == 6 && DieTwoRoll == 6)
            {
                Console.WriteLine("BOXCARS!");
            }
            else if (DieOneRoll == 1 && DieTwoRoll == 1)
            {
                Console.WriteLine("OH NO SNAKE EYES!");
            }
            else if (DieOneRoll == DieTwoRoll)
            {
                Console.WriteLine("DOUBLES SWEET!");
            }
        }

    }
}
