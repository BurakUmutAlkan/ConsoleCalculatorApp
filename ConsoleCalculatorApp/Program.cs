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
            Console.WriteLine(
                "WELCOME TO THE CALCULATOR APP\n------------------------------------------------------------------------------------------\nThis app acts like a calculator, only difference being developed on a console application.\n\n"
                );

        OperatorInput:

            Console.WriteLine(
                "You can select any operator from the operators listed below:\n\nA for Addition\nS for Substraction\nM for Multiplication\nD for Division\nC to Close the application\n"
                );
            Console.Write("Please enter the desired operation: ");

            List<char> operationsList = CreateAndReturnOperationsList();

            char operation = ReturnOperationValue();

            if (!operationsList.Contains(operation))
            {
                PrintMessage("opc2");
                goto OperatorInput;
            }
            else if (operation == 'c')
            {
                PrintMessage("exit");
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();

            FirstNumber:

                Console.Write("Please enter the first number: ");

                double numberOne = ReturnDoubleNumberValue();

                if (numberOne.Equals(double.NaN))
                {
                    goto FirstNumber;
                }

                Console.Clear();

            SecondNumber:

                Console.Write("Please enter the second number: ");

                double numberTwo = ReturnDoubleNumberValue();

                if (numberTwo.Equals(double.NaN))
                {
                    goto SecondNumber;
                }
                else if (operation == 'd' && numberTwo == 0d)
                {
                    PrintMessage("d0");
                    goto SecondNumber;
                }
                else if (operation == 'm' && numberOne == 0d && numberTwo == 0d)
                {
                    PrintMessage("m00");
                    goto SecondNumber;
                }
                else
                {
                    PrintResult(operation, numberOne, numberTwo);
                }

                Console.ReadKey();
                Console.Clear();
                goto OperatorInput;
            }
        }

        #region Methods

        private static List<char> CreateAndReturnOperationsList()
        {
            return new List<char> { 'a', 's', 'm', 'd', 'c' };
        }

        private static char ReturnOperationValue()
        {
            char operation;

            try
            {
                operation = Convert.ToChar(Console.ReadLine().Trim().ToLower());
            }
            catch
            {
                PrintMessage("opc");
                return ' ';
            }

            return operation;
        }

        private static double ReturnResultValue(char operation, double numberOne, double numberTwo)
        {
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

            return result;
        }

        private static double ReturnDoubleNumberValue()
        {
            double number;

            try
            {
                number = Convert.ToDouble(Console.ReadLine().Trim());
            }
            catch
            {
                PrintMessage("dNaN");
                return double.NaN;
            }

            return number;
        }

        private static void PrintResult(char operation, double numberOne, double numberTwo)
        {
            Console.Clear();

            double result = ReturnResultValue(operation, numberOne, numberTwo);

            Console.WriteLine("Result: " + result);
        }

        private static void PrintMessage(string messageCode)
        {
            if (messageCode == "opc")
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid input. Please try again.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (messageCode == "opc2")
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid operation. Please try again.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (messageCode == "exit")
            {
                Console.Clear();
                Console.WriteLine("Bye bye...");
                Console.WriteLine("Press enter to close the application...");
                Console.ReadKey();
            }
            else if (messageCode == "dNaN")
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid value. Please try again.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (messageCode == "d0")
            {
                Console.Clear();
                Console.WriteLine("The dividend cannot be zero. Please try another value.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (messageCode == "m00")
            {
                Console.Clear();
                Console.WriteLine("Zero cannot multiply by zero. Please try another value.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #endregion
    }
}
