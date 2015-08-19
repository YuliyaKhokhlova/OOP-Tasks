using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_GettingStarted
{
    class Program
    {
        private const int QuadraticEquationCoefsCount = 3;
        private const int A = 0;
        private const int B = 1;
        private const int C = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Quadratic Equation solver");
            Console.WriteLine("A * x^2 + B * x + C = 0");

            string[] coefNames = { "A", "B", "C" };
            double[] coefs = new double[QuadraticEquationCoefsCount];

            // Read coefs
            for (int i = 0; i < QuadraticEquationCoefsCount; i++)
            {
                bool coefEntered = false;
                do
                {
                    Console.WriteLine("Please, enter coefficient " + coefNames[i]);
                    string input = Console.ReadLine();
                    try
                    {
                        coefs[i] = Convert.ToDouble(input);
                        coefEntered = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        Console.WriteLine("please, enter correct value");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        Console.WriteLine("please, enter correct value");
                    }
                }
                while (!coefEntered);
            }

            // Find roots
            double Discr = coefs[B] * coefs[B] - 4 * coefs[A] * coefs[C];
            if (Discr > 0.0)
            {
                double x1 = (-coefs[B] + Math.Sqrt(Discr)) / (2.0 * coefs[A]);
                double x2 = (-coefs[B] - Math.Sqrt(Discr)) / (2.0 * coefs[A]);
                Console.WriteLine("Equation roots are the following:");
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
            else if (Discr < 0.0)
            {
                Console.WriteLine("Equation doesn't have real roots");
            }
            else
            {
                double x1 = -coefs[B] / (2.0 * coefs[A]);
                Console.WriteLine("Equation root is the following:");
                Console.WriteLine("x1 = " + x1);
            }

        }
    }
}
