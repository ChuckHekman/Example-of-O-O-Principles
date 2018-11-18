using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_of_O_O_Principles
{
    class ContinueLoop
    {
        public static bool Continue()
        {
            Console.WriteLine("\nDo again? y/n");
            string input = Console.ReadLine();
            input = input.ToLower();
            bool doAgain;
            if (input == "y")
            { doAgain = true; }
            else if (input == "n")
            { doAgain = false; }
            else
            {
                // Should never get here, but in case we do...
                Console.WriteLine("\nNot certain what you meant by {0}, so let's try it again.", input);
                // Recursion: running the loop in a method with 2 parts; a step and an end condition.
                doAgain = Continue();
            }
            return doAgain;
        }

    }
}
