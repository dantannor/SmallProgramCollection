// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex01_3
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter size");
            constructHourGlass(scanHourGlassSize());
            Console.WriteLine();
            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
        }

        /*
        * Scan and validate correct height number from user
        */
        private static int scanHourGlassSize()
        {
            int inputNum = 0;
            bool v_goodInput = false;
            bool v_firstTry = true;

            // Check input
            while (!v_goodInput)
            {
                if (!v_firstTry)
                {
                    Console.WriteLine("Invalid number, please re-enter:");
                }

                string inputString = Console.ReadLine();

                // Check that input parsed well to int, it's positive and exactly 3 digits
                v_goodInput = int.TryParse(inputString, out inputNum);
                v_goodInput &= (inputString != null) && !(inputNum < 0);
                v_firstTry = false;
            }

            return inputNum;
        }

        /*
        * Constructs hour glass based on user input height
        */
        private static void constructHourGlass(int i_hourGlassHeight)
        {
            bool v_increaseStars = false;

            // Make the height odd.
            if (i_hourGlassHeight % 2 == 0)
            {
                i_hourGlassHeight++;
            }

            int[] starNumArr = new int[i_hourGlassHeight];
            int starNum = i_hourGlassHeight;

            // Insert number of stars per line in an array
            for (int i = 0; i < starNumArr.Length; i++)
            {
                if (i == 0)
                {
                    starNumArr[0] = starNum;
                }
                else
                {
                    // Once we reach the middle of the hourglass,
                    // we start adding back the number of stars to widen the lines
                    v_increaseStars |= starNum == 1;

                    if (v_increaseStars)
                    {
                        starNumArr[i] = starNum += 2;
                    }
                    else
                    {
                        starNumArr[i] = starNum -= 2;
                    }
                }
            }

            // Draw
            for (int i = 0; i < starNumArr.Length; i++)
            {
                // Add the correct number of spaces for each line
                for (int j = 0; j < (i_hourGlassHeight - starNumArr[i]) / 2; j++)
                {
                    Console.Write(" ");
                }

                // The stars
                for (int j = 0; j < starNumArr[i]; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
