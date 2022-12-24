using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE CALCULATOR APP");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("This app acts like a calculator, only difference being developed on a console application.");
            Console.WriteLine();

        OperatorInput:

            Console.WriteLine("You can select any operator from the operators listed below:");
            Console.WriteLine("A for Addition");
            Console.WriteLine("S for Substraction");
            Console.WriteLine("M for Multiplication");
            Console.WriteLine("D for Division");
            Console.WriteLine("C to Close the application");
            Console.Write("Please enter the desired operation: ");

            List<char> operationsList = new List<char>();
            operationsList.Add('a');
            operationsList.Add('s');
            operationsList.Add('m');
            operationsList.Add('d');
            operationsList.Add('c');

            char operation;

            try
            {
                operation = Convert.ToChar(Console.ReadLine().Trim().ToLower());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid input. Please try again.");
                Console.ReadKey();
                Console.Clear();
                goto OperatorInput;
            }

            if (!operationsList.Contains(operation))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid operation. Please try again.");
                Console.ReadKey();
                Console.Clear();
                goto OperatorInput;
            }
            else if (operation == 'c')
            {
                Console.Clear();
                Console.WriteLine("Bye bye...");
                Console.WriteLine("Press enter to close the application...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();

            FirstNumber:

                Console.Write("Please enter the first number: ");

                double numberOne;

                try
                {
                    numberOne = Convert.ToDouble(Console.ReadLine().Trim());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid value. Please try again.");
                    Console.ReadKey();
                    Console.Clear();
                    goto FirstNumber;
                }

                Console.Clear();

            SecondNumber:

                Console.Write("Please enter the second number: ");

                double numberTwo;

                try
                {
                    numberTwo = Convert.ToDouble(Console.ReadLine().Trim());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid value. Please try again.");
                    Console.ReadKey();
                    Console.Clear();
                    goto SecondNumber;
                }

                if (operation == 'd' && numberTwo == 0d)
                {
                    Console.Clear();
                    Console.WriteLine("The dividend cannot be zero. Please try another value.");
                    Console.ReadKey();
                    Console.Clear();
                    goto SecondNumber;
                }
                else if (operation == 'm' && numberOne == 0d && numberTwo == 0d)
                {
                    Console.Clear();
                    Console.WriteLine("Zero cannot multiply by zero. Please try another value.");
                    Console.ReadKey();
                    Console.Clear();
                    goto SecondNumber;
                }
                else
                {
                    Console.Clear();

                    double result = 0d;

                    switch (operation)
                    {
                        case 'a':
                            result = numberOne + numberTwo;
                            break;
                        case 's':
                            result = numberOne - numberTwo;
                            break;
                        case 'm':
                            result = numberOne * numberTwo;
                            break;
                        case 'd':
                            result = numberOne / numberTwo;
                            break;
                    }

                    Console.WriteLine("Result: " + result);
                }

                Console.ReadKey();
                Console.Clear();
                goto OperatorInput;
            }
        }
    }
}
