using System;
using System.Linq.Expressions;

namespace CalculatorLibrary
{
    public static class Operations<T> where T : struct
    {
        public static T Add(T a, T b)
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            var body = Expression.Add(paramA, paramB);

            var add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

            return add(a, b);
        }

        public static T Subtract(T a, T b)
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            var body = Expression.Subtract(paramA, paramB);

            var add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

            return add(a, b);
        }

        public static T Multiply(T a, T b)
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            var body = Expression.Multiply(paramA, paramB);

            var add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

            return add(a, b);
        }

        public static T Divide(T a, T b)
        {
            var paramA = Expression.Parameter(typeof(T), "a");
            var paramB = Expression.Parameter(typeof(T), "b");

            var body = Expression.Divide(paramA, paramB);

            var add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();

            return add(a, b);
        }
    }
}
