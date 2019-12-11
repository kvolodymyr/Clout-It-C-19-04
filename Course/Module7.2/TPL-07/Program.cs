using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_07
{
    /*
     Install-Package System.Runtime.CompilerServices.Unsafe -Version 4.7.0
     Install-Package System.Threading.Tasks.Extensions -Version 4.5.3
    */
    class Program
    {
        private static void Main()
        {
            CalculateAndShowAsync(-1).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        private static ValueTask CalculateAndShowAsync(int ceiling)
        {
            if (ceiling < 0)
            {
                //return Task.CompletedTask; 
                return new ValueTask();
            }
            else
            {
                return new ValueTask(Task.Run(() =>
                {
                    Calculator(ceiling);
                }));

                //return Task.Run(() =>
                //    {
                //        Calculator(ceiling);
                //    });
            }
        }

        private static void Calculator(int ceiling)
        {
            int sum = 0;
            for (int i = 0; i < ceiling; i++)
                sum += i;
            Console.WriteLine($"Result - {sum}. Found in task #{Task.CurrentId}, in thread #{Thread.CurrentThread.ManagedThreadId}");
        }


        /*

        private static void Main()
        {
            int res = Sum(5, 3).Result;
            Console.WriteLine(res);

            Console.ReadKey();
        }

        private static ValueTask<int> Sum(int a, int b)
        {
            if (a == 0)
            {
                return new ValueTask<int>(b);
            }
            else if (b == 0)
            {
                return new ValueTask<int>(a);
            }
            else if (a == 0 && b == 0)
            {
                return new ValueTask<int>(0);
            }

            return new ValueTask<int>(Task.Run(() => { return a + b; }));
        }


        private static void Main()
        {
            int salary = 2000;
            ValueTask<double> valueTask = GetIndexing(salary);

            while (!valueTask.IsCompleted)
            {
                Console.Write('*');
                Thread.Sleep(200);
            }

            Task<double> task = valueTask.AsTask();

            task.ContinueWith((t) => Console.WriteLine($"\nRecalculate salary {salary} = {t.Result}%"));

            Console.ReadKey();
        }

        private static ValueTask<double> GetIndexing(int salary)
        {
            Thread.Sleep(500);

            if(salary <= 0)
            {
                return new ValueTask<double>(0);
            }
            else if (salary > 5000)
            {
                return new ValueTask<double>(0);
            }
            else if (salary == 5000)
            {
                return new ValueTask<double>(0.1);
            }
            else
            {
                return new ValueTask<double>(Task.Run(() =>
                {
                    double index = 0.0;
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        index += 0.1;
                    }
                    return index;
                }));
            }
        }
        */
    }
}
