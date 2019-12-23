using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork_10_Guselnikov
{
    class Program
    {
        private static readonly Regex operandRegex = new Regex(@"^(\d+(,\d|\.\d|\d*)\d*)$", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex operatorRegex = new Regex(@"^[\+\-\*\/]$", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        static void Main(string[] args)
        {
            var data = SetData();
            switch (data.operation)
            {
                case ("+"):
                    Console.WriteLine("Sum is " + Operations.Sum(data.firstOperand, data.secondOperand));
                    break;
                case ("-"):
                    Console.WriteLine("Subtraction is " + Operations.Subtraction(data.firstOperand, data.secondOperand));
                    break;
                case ("*"):
                    Console.WriteLine("Multiplication is " + Operations.Multiplication(data.firstOperand, data.secondOperand));
                    break;
                case ("/"):
                    Console.WriteLine("Division is " + Operations.Division(data.firstOperand, data.secondOperand));
                    break;
                default:
                    break;
            }

            /*  Console.WriteLine("Enter operation symbol");
              var operation = Console.Read();
              Operations
              Console.WriteLine("Enter second operand");
              var y = Console.Read();
              Console.WriteLine("Sum is " + Operations.Sum(x, y));
              Console.WriteLine("Substraction is " + Operations.Subtraction(x, y));
              Console.WriteLine("Dividing is " + Operations.Division(x, y));
              Console.WriteLine("Multiply is " + Operations.Multiplication(x, y));*/
            Console.Read();
        }

        

         static (double firstOperand, double secondOperand, string operation) SetData()
            {
            Console.WriteLine("Enter first operand");
            var firstOperandRead = Console.ReadLine();
            Console.WriteLine("Enter second operand");
            var seconfOperandRead = Console.ReadLine();
            if (!operandRegex.IsMatch(firstOperandRead) || !operandRegex.IsMatch(seconfOperandRead))
            {
                Console.WriteLine("data should be digits");
                SetData();
            }
            if(firstOperandRead.Contains(","))
            {
                firstOperandRead = firstOperandRead.Replace(',', '.');
            }
            else if(seconfOperandRead.Contains(","))
            {
                seconfOperandRead = seconfOperandRead.Replace(',', '.');
            }
            var firstOperand = Double.Parse(firstOperandRead);
            var secondOperand = Double.Parse(seconfOperandRead); 
            Console.WriteLine("Enter operation");
            var operation = Console.ReadLine();
            // check regex
            if (!operatorRegex.IsMatch(operation))
            {
                Console.WriteLine("Enter valid operator");
                operation = SetData(firstOperand, secondOperand);
            }
            return (firstOperand, secondOperand, operation);
        }

        static string SetData(double firstOperand, double secondOperand)
        {
            Console.WriteLine("Enter operation");
            var operation = Console.ReadLine();
            // check regex
            if (!operatorRegex.IsMatch(operation))
            {
                Console.WriteLine("Enter valid operator");
                operation = SetData(firstOperand, secondOperand);
            }           
            return  operation;
        }
    }
}
