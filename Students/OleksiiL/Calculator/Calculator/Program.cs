using System;
using CalculatorLibrary;

namespace Calculator
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                try
                {
                    var input = InputHandler.ReadInput(false, out var inlineResults);
                    InputHandler.ParseInput(input, inlineResults, out var numbers, out var operators);
                    var answer = InputHandler.Count(numbers, operators);
                    Console.WriteLine(answer);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
