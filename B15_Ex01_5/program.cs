// --------------------------------------------------------------------------------------------------------------------
// <copyright file="program.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace B15_Ex01_5
{
    using System;

    public class Program
    {
        public static void Main()
        {
            scanAndPrintNumProperties();
           
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }

        private static void scanAndPrintNumProperties()
        {
            Console.WriteLine("Enter a positive number with length 8");
            string stringNumber = Console.ReadLine();
            int number;
            bool isNumber = int.TryParse(stringNumber, out number);
            while (!isNumber || stringNumber.Length != 8 || number < 0)
            {
                Console.WriteLine("invalid number, try again");
                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }

            // convert char to int
            int firstDigit = stringNumber[0] - '0';
            int numberOfDigitsGreaterThanFirstDigit = 0;
            int numberOfDigitsLowerThanFirstDigit = 0;
            int greatestDigit = firstDigit;
            int smallestDigit = firstDigit;
            for (int i = 1; i < stringNumber.Length; i++)
            {
                int currentDigit = stringNumber[i] - '0';
                if (currentDigit > firstDigit)
                {
                    numberOfDigitsGreaterThanFirstDigit++;
                }

                if (currentDigit < firstDigit)
                {
                    numberOfDigitsLowerThanFirstDigit++;
                }

                if (currentDigit > greatestDigit)
                {
                    greatestDigit = currentDigit;
                }

                if (currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
            }

            string msg = string.Format(
@"The number of digits greater than fisrt digit is : {0} 
The number of digits small than first digit is : {1}
The greatest digit is : {2}
The smallest digit is : {3}", numberOfDigitsGreaterThanFirstDigit, numberOfDigitsLowerThanFirstDigit, greatestDigit, smallestDigit);

            Console.WriteLine(msg);
        }
    }
}
