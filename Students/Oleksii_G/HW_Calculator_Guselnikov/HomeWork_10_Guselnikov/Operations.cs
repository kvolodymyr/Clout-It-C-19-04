using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_Guselnikov
{
    class Operations
    { 

        public static T Sum<T>( T x, T y) 
        {
            ParameterExpression firstParameter = Expression.Parameter(typeof(T), "x");
            ParameterExpression secondParameter = Expression.Parameter(typeof(T), "y");
            BinaryExpression sum = Expression.Add(firstParameter, secondParameter);
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(sum, firstParameter, secondParameter).Compile();
            return add(x, y);
        }

        public static T Subtraction<T>(T x, T y)
        {
            ParameterExpression firstParameter = Expression.Parameter(typeof(T), "x");
            ParameterExpression secondParameter = Expression.Parameter(typeof(T), "y");
            BinaryExpression substraction = Expression.Subtract(firstParameter, secondParameter);
            Func<T, T, T> substract = Expression.Lambda<Func<T, T, T>>(substraction, firstParameter, secondParameter).Compile();
            return substract(x, y);
        }

        public static T Division<T>(T x, T y)
        {
            ParameterExpression firstParameter = Expression.Parameter(typeof(T), "x");
            ParameterExpression secondParameter = Expression.Parameter(typeof(T), "y");
            BinaryExpression division = Expression.Divide(firstParameter, secondParameter);
            Func<T, T, T> divide = Expression.Lambda<Func<T, T, T>>(division, firstParameter, secondParameter).Compile();
            return divide(x, y);
        }

        public static T Multiplication<T>(T x, T y)
        {
            ParameterExpression firstParameter = Expression.Parameter(typeof(T), "x");
            ParameterExpression secondParameter = Expression.Parameter(typeof(T), "y");
            BinaryExpression multiplication = Expression.Multiply(firstParameter, secondParameter);
            Func<T, T, T> multiply= Expression.Lambda<Func<T, T, T>>(multiplication, firstParameter, secondParameter).Compile();
            return multiply(x, y);
        }
    }    
}
