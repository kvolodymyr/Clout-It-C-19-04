using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_05
{
    class Program
    {
        const int Indent = 100;

        #region helpder
        public enum Operation
        {
            ADD,
            SUB,
            DIV,
            MUL
        }

        public struct Expression
        {
            public Operation Operation;
            public int X;
            public int Y;
            public Expression(Operation op, int x, int y) {
                this.Operation = op;
                this.X = x;
                this.Y = y;
            }
        }

        private static int Calculate(object arg)
        {
            Expression expression = (Expression)arg;
            if (expression.Operation == Operation.MUL)
                return expression.X * expression.Y;
            else if (expression.Operation == Operation.DIV)
                return expression.X / expression.Y;
            else if (expression.Operation == Operation.SUB)
                return expression.X - expression.Y;
            else
                return expression.X + expression.Y;
        }
        #endregion


        private static void Main()
        {
            int x = 2, y = 3;

            Expression expression = new Expression(Operation.ADD, 2, 3);

            Task<int> task = new Task<int>(Calculate, expression);
            task.Start();

            Console.WriteLine($"SUM: {task.Result}");
            Console.WriteLine(new string('-', Indent));

            // Review way how to set parameters to delegate 
            // Functional Oriented Programming, Closure
            Task<int> lambda = new Task<int>(() => Sum(x, 5));
            lambda.Start();

            Console.WriteLine($"SUM: {lambda.Result}");
            Console.WriteLine(new string('-', Indent));

            Task<int> taskRun = Task<int>.Run<int>(() =>
            {
                int x1 = 5;
                int y1 = 5;
                return Sum(x1, x1) + Sum(x, y);
            });

            Console.WriteLine($"Sum: {taskRun.Result}");

            // many parameters
            Task.Run(() => Log(1, 0.1, "string", new object(), expression, new Program(), taskRun));
            Console.ReadKey();
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }

        private static void Log(int i, double d, string str, object o, Expression expression, Program program, dynamic _dynamic)
        {
            Console.WriteLine("..........................................................................");
            Console.WriteLine($"Param integer: {i}");
            Console.WriteLine($"Param double: {d}");
            Console.WriteLine($"Param string: {str}");
            Console.WriteLine($"Param object: {o}");
            Console.WriteLine($"Param expression: {expression.X} {expression.Y}");
            Console.WriteLine();
            Console.WriteLine($"Param expression: {program.GetType().Name}");
            Console.WriteLine($"Param expression: {_dynamic}");
            Console.WriteLine("..........................................................................");
        }
    }
}
