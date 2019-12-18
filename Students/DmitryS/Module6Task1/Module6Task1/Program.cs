using System;
using System.Collections.Generic;

namespace Module6Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> operands = new List<char>();
            List<int> numbers = new List<int>();
            bool con = true;
            char k;
            string expression;
            Calc calculator = new Calc();
            while (con)
            {
                Console.WriteLine("Enter the expression: ");
                expression = "";
                k = Console.ReadKey().KeyChar;
                while (k != '=')
                {
                    expression += k;
                    k = Console.ReadKey().KeyChar;
                }
                try
                {
                    Console.WriteLine(calculator.CalculateExpression(expression));
                }
                catch (IncorrectInputException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Do you want to try again? y/n");
                k = Console.ReadKey().KeyChar;
                if (k == 'n')
                {
                    con = false;
                }
                Console.WriteLine();
            }
        }
    }
}
