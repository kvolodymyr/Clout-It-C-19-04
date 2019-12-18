using System;
using System.Linq.Expressions;

namespace ExpressionTreeCalculator
{
    public static class Operations
    {
        public static double Add(double a, double b)
        {
            var param1 = Expression.Parameter(typeof(double), "a");
            var param2 = Expression.Parameter(typeof(double), "b");

            var func = Expression.Add(param1, param2);
            var result = Expression.Lambda<Func<double, double, double>>(func, param1, param2).Compile();

            return result(a,b);
        }

        public static double Substract(double a, double b)
        {
            var param1 = Expression.Parameter(typeof(double), "a");
            var param2 = Expression.Parameter(typeof(double), "b");

            var func = Expression.Subtract(param1, param2);
            var result = Expression.Lambda<Func<double, double, double>>(func, param1, param2).Compile();

            return result(a,b);
        }

        public static double Multiply(double a, double b)
        {
            var param1 = Expression.Parameter(typeof(double), "a");
            var param2 = Expression.Parameter(typeof(double), "b");

            var func = Expression.Multiply(param1, param2);
            var result = Expression.Lambda<Func<double, double, double>>(func, param1, param2).Compile();

            return result(a,b);
        }

        public static double Divide(double a, double b)
        {
            var param1 = Expression.Parameter(typeof(double), "a");
            var param2 = Expression.Parameter(typeof(double), "b");

            var func = Expression.Subtract(param1, param2);
            var result = Expression.Lambda<Func<double, double, double>>(func, param1, param2).Compile();

            return result(a,b);
        }
    }
}
