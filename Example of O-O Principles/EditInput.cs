using System;

namespace Example_of_O_O_Principles
{
    class EditInput
    {
        public static int IsDigit(string input)
        {
            char[] charArray = input.ToCharArray();
            int x;
            try
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (!(char.IsDigit(charArray[i])))
                    {
                        throw new Exception("Entry must be an integer.");
                    }
                }
                return int.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return x = IsDigit(Console.ReadLine());
            }
        }

        public static int DigitInRange(string input, int y)
        {
            int x;
            try
            {
                x = IsDigit(input);
                if (x <= y && x > 0)
                {
                    return x;
                }
                else
                {
                    throw new Exception($"Your input {x} is not within the range of {y}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                x = DigitInRange(Console.ReadLine(), y);
                return x;
            }
        }

        public static int DigitInRange(string input, int min, int max)
        {
            int x;
            try
            {
                x = IsDigit(input);
                if (x >= min && x <= max)
                {
                    return x;
                }
                else
                {
                    throw new Exception($"Your input {x} is not within the range of {min} to {max}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                x = DigitInRange(Console.ReadLine(), min, max);
                return x;
            }
        }
    }
}
