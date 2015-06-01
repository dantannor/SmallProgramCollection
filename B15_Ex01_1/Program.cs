// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex01_1
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            receiveInputAndCountSeries();

            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }

        private static void receiveInputAndCountSeries()
        {
            StringBuilder binaryNumbers = new StringBuilder(string.Empty);
            int numberOfAscendingSeries = 0;
            int numberOfDescendingSeries = 0;
            int numberOfDigitsInBinaryNumbers = 0;
            int sumOfNumbers = 0;

            // Check input
            Console.WriteLine("Please enter 5 numbers with 3 digits each:");
            for (int i = 1; i < 6; i++)
            {
                string stringNum = Console.ReadLine();
                int num;
                bool res = int.TryParse(stringNum, out num);

                // check the number of digits
                if (res == false || stringNum.Length != 3 || num <= 0)
                {
                    Console.WriteLine("The input you entered is invalid. please try again.");
                    i--;
                }
                else
                {
                    string binaryNumber = toBinary(num);
                    numberOfDigitsInBinaryNumbers += binaryNumber.Length;
                    sumOfNumbers += num;
                    binaryNumbers.Append(binaryNumber + " ");

                    // Count series type (ascending/decending)
                    if (ascendingSeries(stringNum))
                    {
                        numberOfAscendingSeries++;
                    }
                    else
                    {
                        if (descendingSeries(stringNum))
                        {
                            numberOfDescendingSeries++;
                        }
                    }
                }
            }

            double avaregeNumberOfDigits = (double)numberOfDigitsInBinaryNumbers / 5;
            double avaregeNumbers = (double)sumOfNumbers / 5;
            string msg = string.Format(
@"The binary numbers are : {0} . 
There are {1} numers which are an ascending series and {2} which are descending .
The avarege number of digits int the binary numer is : {3}
The general average of the inserted numbers is : {4}",
                                                     binaryNumbers,
                                                     numberOfAscendingSeries,
                                                     numberOfDescendingSeries,
                                                     avaregeNumberOfDigits,
                                                     avaregeNumbers);

            Console.WriteLine(msg);
        }

        /**
         * Check if series ascends
         */
        private static bool ascendingSeries(string io_stringNum)
        {
            int currenDigit = io_stringNum[0];
            for (int i = 1; i < io_stringNum.Length; i++)
            {
                if (io_stringNum[i] <= currenDigit)
                {
                    return false;
                }
                else
                {
                    currenDigit = io_stringNum[i];
                }
            }

            return true;
        }

        /**
         * Check if series descends
         */
        private static bool descendingSeries(string io_stringNum)
        {
            int currenDigit = io_stringNum[0];
            for (int i = 1; i < io_stringNum.Length; i++)
            {
                if (io_stringNum[i] >= currenDigit)
                {
                    return false;
                }
                else
                {
                    currenDigit = io_stringNum[i];
                }
            }

            return true;
        }

        /*
         * Convert decimal to binary
         */
        private static string toBinary(int io_num)
        {
            string binaryNumber = string.Empty;
            int num = io_num;
            int remainder;
            while (num != 0)
            {
                num = Math.DivRem(num, 2, out remainder);
                binaryNumber = remainder + binaryNumber;
            }

            return binaryNumber;
        }
    }
}
