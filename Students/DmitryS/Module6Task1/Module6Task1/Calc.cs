using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module6Task1
{
    class Calc
    {
        delegate int Calculator(int a, int b, char o);
        public int CalculateExpression(string exp)
        {
            List<int> num = new List<int>();
            List<char> operands = new List<char>();
            string tempNum = "";
            string subString = "";
            bool isNegative = false;
            int counter;
            char tempOp;
            int i = 0;
            
            if (exp[0] == '-')
            {
                i++;
                isNegative = true;
            }
            else if (exp[0] == '(')
            {
                counter = 1;
                do
                {
                    i++;
                    subString += exp[i];
                    if (exp[i] == '(') counter++;
                    if (exp[i] == ')') counter--;

                } while (i < exp.Length && counter > 0);

                if (exp[i] != ')')
                    throw new IncorrectInputException("Incorrect input, try again!");
                subString = subString.Remove(subString.Length - 1, 1);
                num.Add(CalculateExpression(subString));
                subString = "";
                i++;
            }
            else if (!(Char.IsDigit(exp[0])))
                throw new IncorrectInputException("Incorrect input, try again!");

            while (i < exp.Length)
            {
                while (i < exp.Length && Char.IsDigit(exp[i]))
                {
                    tempNum += exp[i];
                    i++;
                }
                if (tempNum != "")
                {
                    checked
                    {

                        if (isNegative)
                        {
                            num.Add(Int32.Parse(tempNum) * (-1));
                            isNegative = false;
                        }
                        else
                            num.Add(Int32.Parse(tempNum));
                    }
                    tempNum = "";
                }
                if (i < exp.Length)
                {
                    tempOp = exp[i];

                    if (tempOp != '-' && tempOp != '+' && tempOp != '*' && tempOp != '/') throw new IncorrectInputException("Incorrect input, try again!");
                    operands.Add(tempOp);
                    i++;
                    if (exp[i] == '(')
                    {
                        counter = 1;
                        do
                        {
                            i++;
                            subString += exp[i];
                            if (exp[i] == '(') counter++;
                            if (exp[i] == ')') counter--;

                        } while (i < exp.Length && counter > 0);

                        if (exp[i] != ')')
                            throw new IncorrectInputException("Incorrect input, try again!");
                        subString = subString.Remove(subString.Length - 1, 1);
                        num.Add(CalculateExpression(subString));
                        subString = "";
                        i++;
                    }
                    else if (i < exp.Length)
                    {
                        if (exp[i] == '-')
                        {
                            if (i != exp.Length - 1)
                            {
                                isNegative = true;
                                i++;
                            }
                            else if (i == exp.Length - 1) throw new IncorrectInputException("Incorrect input, try again!");
                        }
                        else if (exp[i] != '-' && !Char.IsDigit(exp[i]))
                        {
                            throw new IncorrectInputException("Incorrect input, try again!");
                        }
                    }
                }
            }
            return GetResult(num,operands);
        }

        static int GetResult(List<int> num, List<char> operands)
        {
            int j = 0;
            Calculator calcLambda = (a, b, o) =>
            {
                checked
                {
                    switch (o)
                    {
                        case '+': return a + b;
                        case '-': return a - b;
                        case '*': return a * b;
                        case '/': return a / b;
                        default:
                            Console.WriteLine("Incorrect input");
                            throw new IncorrectInputException("Incorrect input, try again!");
                    }
                }
            };

            Expression<Func<int, int, int>> Add = (a, b) => a + b;

            while (j < operands.Count)
            {
                if (operands[j] == '*' || operands[j] == '/')
                {
                    num[j] = calcLambda(num[j], num[j + 1], operands[j]);
                    num.RemoveAt(j + 1);
                    operands.RemoveAt(j);
                    j--;
                }
                j++;
            }
            while (operands.Count > 0)
            {
                num[0] = calcLambda(num[0], num[1], operands[0]);
                num.RemoveAt(1);
                operands.RemoveAt(0);

            }
            return num[0];
        }

        
    }
}
