// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex01_4
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 10 letters or 10 digits:");
            scanInputAndPrint();
            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
        }

        /*
        * Scan, validate and print
        */
        private static void scanInputAndPrint()
        {
            bool v_firstTry = true;
            string inputString = "invalid";

            // Check input
            while (true)
            {
                switch (checkInputType(inputString))
                {
                    case "invalid":
                        if (!v_firstTry)
                        {
                            Console.WriteLine("Invalid input, please re-enter:");
                        }

                        inputString = Console.ReadLine();
                        checkInputType(inputString);

                        // Else, re-loop
                        v_firstTry = false;
                        break;
                    case "numeric":
                        writeNumericProperties(inputString);
                        return;
                    case "string":
                        writeStringProperties(inputString);
                        return;
                }
            }
        }

        /*
         * Write the output string properties
         */
        private static void writeStringProperties(string io_inputString)
        {
            int upperCount = io_inputString.Count(char.IsUpper);
            string palindromeString = checkPalindromeString(io_inputString.ToLower().ToCharArray());

            Console.WriteLine("The word {0} a palindrome and the number of upper case letters is {1}.", palindromeString, upperCount);
        }

        /*
         * Write the output numeric properties
         */
        private static void writeNumericProperties(string io_inputString)
        {
            string palindromeString = checkPalindromeString(io_inputString.ToCharArray());
            int sum = sumArray(io_inputString);

            Console.WriteLine(@"The number {0} a palindrome and the sum of its digits is {1}.", palindromeString, sum);
        }

        /*
         * Sums the array numbers
         */
        private static int sumArray(string io_inputString)
        {
            int sum = 0;
            int digit;

            for (int i = 0; i < io_inputString.Length; i++)
            {
                int.TryParse(io_inputString[i].ToString(), out digit);
                sum += digit;
            }

            return sum;
        }

        /*
         * Return is or isn't based on if it's a palindrome
         */
        private static string checkPalindromeString(char[] i_charArr)
        {
            bool v_palindrome = true;

            for (int i = 0; i < i_charArr.Length / 2; i++)
            {
                v_palindrome = i_charArr[i].Equals(i_charArr[i_charArr.Length - i - 1]);
                if (!v_palindrome)
                {
                    break;
                }
            }

            if (v_palindrome)
            {
                return "is";
            }

            return "isn't";
        }

        private static string checkInputType(string io_inputString)
        {
            int inputNum = 0;
            bool v_validNumericInput = false;
            bool v_validStringInput = false;

            // Check if it's a 10 digit number
            v_validNumericInput = int.TryParse(io_inputString, out inputNum);
            v_validNumericInput &= (io_inputString != null) && !(io_inputString.Length != 10 || inputNum < 0);

            if (!v_validNumericInput)
            {
                v_validStringInput = (io_inputString != null) && (io_inputString.Length == 10) &&
                                     io_inputString.All(char.IsLetter);
            }

            if (v_validNumericInput)
            {
                return "numeric";
            }

            if (v_validStringInput)
            {
                return "string";
            }

            return "invalid";
        }
    }
}
