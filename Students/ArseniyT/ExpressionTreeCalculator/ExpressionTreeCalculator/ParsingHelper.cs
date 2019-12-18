using System;

namespace ExpressionTreeCalculator
{
    public delegate double CalculatorDelegate(double a, double b, string op);
    public class ParsingHelper
    {
        static CalculatorDelegate del = Calculator;
        //This method parses an input string.
        public static string[] MyParse(string s)
        {
            string temp = "";
            string[] arr = new string[100];
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]) || s[i] == ',' || (s[i] == '-' && i == 0)
                    || (i != 0 && (s[i] == '-') && (s[i - 1] == '-' || s[i - 1] == '+'
                    || s[i - 1] == '/' || s[i - 1] == '*')) || s[i] == '(' || s[i]==')')
                {
                    temp += s[i];
                }
                else if ((s[i] == '+' || s[i] == '-' || s[i] == '/' || s[i] == '*')
                    && char.IsDigit(s[i - 1]))
                {
                    arr[count] = temp;
                    temp = "";
                    count++;
                    arr[count] = s[i].ToString();
                    count++;
                }
                else throw new ArgumentException("Input Error! Please, try again.");

                if (i == s.Length - 1)
                {
                    arr[count] = temp;
                    count++;
                }

            }

            string[] arr1 = new string[count];

            for (int i = 0; i < count; i++)
            {
                arr1[i] = arr[i];
            }

            return arr1;
        }

        static string[] Converter(string[] arr, CalculatorDelegate d)
        {
            int i = 1;
            string newstr = "";
            while (i < arr.Length)
            {
                if(arr[i] == "(")
                {
                    string[] tempArr = new string[100];
                    var j = i;
                    var count = 0;
                    while (arr[j] != ")")
                    {
                        tempArr[count] = arr[j];
                    }
                    var tempStr = "";
                    var tempArr1 =  Converter(tempArr, d);
                    foreach(var s in tempArr1)
                    {
                        tempStr += s;
                    }
                    newstr += tempStr;
                }
                if (arr[i] == "+" || arr[i] == "-")
                {
                    newstr += arr[i - 1] + arr[i];
                    i += 2;
                }
                else if (arr[i] == "*" || arr[i] == "/")
                {
                    double temp = Convert.ToDouble(arr[i - 1]);
                    while (true)
                    {
                        temp = d(temp, Convert.ToDouble(arr[i + 1]), arr[i]);
                        if (i + 2 < arr.Length && (arr[i + 2] == "*" || arr[i + 2] == "/"))
                        {
                            i = i + 2;
                        }
                        else break;
                    }
                    newstr += temp;
                    if (i + 2 < arr.Length)
                    {
                        newstr += arr[i + 2];
                        i += 4;
                    }
                    else break;

                }
            }

            if (arr[arr.Length - 2] == "+" || arr[arr.Length - 2] == "-")
                newstr += arr[arr.Length - 1];

            return MyParse(newstr);
        }


        //This method executes operations.
        static double Calculator(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return Operations.Add(a, b);
                case "-": return Operations.Substract(a, b);
                case "*": return Operations.Multiply(a, b);
                case "/":
                    if (b == 0) throw new DivideByZeroException("You can't divide by zero!");
                    return Operations.Divide(a, b);
                default: throw new ArgumentException("Input Error! Please, try again.");
            }
        }

        //This method executes calculations.
        public static double Calculate(string s)
        {
            CalculatorDelegate d = Calculator;
            if (s.Length < 3)
            {
                throw new ArgumentException("Input Error! Please, try again.");
            }

            string[] arr = ParsingHelper.MyParse(s);
            arr = Converter(arr, d);
            int i = 1;
            double res = Convert.ToDouble(arr[0]);

            while (i < arr.Length)
            {
                res = d(res, Convert.ToDouble(arr[i + 1]), arr[i]);
                i += 2;
            }

            return res;
        }

    }
}
