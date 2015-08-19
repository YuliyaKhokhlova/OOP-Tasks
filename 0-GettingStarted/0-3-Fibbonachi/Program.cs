using System;
using System.Collections;

namespace _0_3_Fibbonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            fibNumbers.Add(1, 1);
            fibNumbers.Add(2, 1);

            Console.WriteLine("Enter the number of Fibbonachi row you wanna get:");
            int N = -1;
            do
            {
                string input = Console.ReadLine();
                try
                {
                    N = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine("You made mistake: " + e.Message);
                    Console.WriteLine("Try one more time...");
                }
            }
            while (N < 0);

            Console.WriteLine("It's " + Fibbonachi(N));
        }

        private static Hashtable fibNumbers = new Hashtable();
        private static int Fibbonachi(int n)
        {
            if (1 == n)
            {
                return (int)fibNumbers[1];
            }

            if (2 == n)
            {
                return (int)fibNumbers[2];
            }

            if (!fibNumbers.ContainsKey(n))
            {
                int x1 = Fibbonachi(n - 2);
                int x2 = Fibbonachi(n - 1);
                fibNumbers.Add(n, x1 + x2);
            }

            return (int)fibNumbers[n];
        }
    }
}
