using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_06
{
    /*
       "Continuation" of asynchronous task
        callback method (callback method)
        ContinueWith () method - add continuation
        ContinueWith () - returns a new instance of the class
    */
    class Program
    {
        private static void Main()
        {
            Task task = new Task(new Action<object>(OperationAsync), "Hello world");
            Task continuation = task.ContinueWith(Continuation);

            Console.WriteLine($"Status - {continuation.Status}");

            task.Start();

            Console.ReadKey();
        }

        private static void OperationAsync(object arg)
        {
            Console.WriteLine();
            Console.WriteLine($"Task #{Task.CurrentId} starts in thread {Thread.CurrentThread.ManagedThreadId}.");
            Console.WriteLine($"Argument value - {arg.ToString()}");
            Console.WriteLine($"Task #{Task.CurrentId} finished in thread  {Thread.CurrentThread.ManagedThreadId}.");
        }

        private static void Continuation(Task task)
        {
            Console.WriteLine();
            Console.Write($"Continuation #{Task.CurrentId} starts in thread {Thread.CurrentThread.ManagedThreadId}. ");
            Console.WriteLine($"AsyncState - {task.AsyncState}");
            Console.WriteLine($"Done");
        }

        /*

               private static void Main()
                {
                    int a = 2, b = 3;
                    Task<int> task = Task.Run<int>(() => Calc(a, b));

                    task.ContinueWith(Continuation);

                    //task.ContinueWith((t) =>
                    //{
                    //    Console.WriteLine($"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
                    //    Console.WriteLine($"Operation result - {t.Result}");
                    //});

                    Console.ReadKey();
                }

                private static int Calc(int a, int b)
                {
                    Console.WriteLine($"Task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
                    return a + b;
                }

                private static void Continuation(Task<int> t)
                {
                    Console.WriteLine($"\nContinuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
                    Console.WriteLine($"Result - {t.Result}");
                }





private static void Main()
        {
            Task<int> task = Task.Run<int>(new Func<int>(GetValue));
            //Task<int> c1 = task.ContinueWith<int>(Increment);
            //Task<int> c2 = c1.ContinueWith<int>(Increment);
            //Task<int> c3 = c2.ContinueWith<int>(Increment);
            //Task<int> c4 = c3.ContinueWith<int>(Increment);
            //Task<int> c5 = c4.ContinueWith<int>(Increment);
            //c5.ContinueWith(ShowRes);

            task.ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(Increment)
                .ContinueWith(ShowRes);

            Console.WriteLine("done...");
            Console.ReadKey();
        }

        private static int GetValue()
        {
            return 10;
        }

        private static int Increment(Task<int> t)
        {
            Console.WriteLine($"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            int result = t.Result + 1;
            return result;
        }

        private static void ShowRes(Task<int> t)
        {
            Console.WriteLine($"Continuation task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            Console.WriteLine($"Result - {t.Result}");
        }



private static Random random = new Random();

        private static void Main()
        {
            //TaskFactory taskFactory = Task.Factory;
            TaskFactory taskFactory = new TaskFactory();

            Task<double> t1 = taskFactory.StartNew(() => { return Calculate(1); });
            Task<double> t2 = taskFactory.StartNew(() => { return Calculate(2); });
            Task<double> t3 = taskFactory.StartNew(() => { return Calculate(3); });
            Task<double> t4 = taskFactory.StartNew(() => { return Calculate(4); });
            Task<double> t5 = taskFactory.StartNew(() => { return Calculate(5); });

            taskFactory.ContinueWhenAll(
                new Task[] { t1, t2, t3, t4, t5 },
                completedTasks => {
                    double sum = 0;

                    foreach (Task<double> item in completedTasks)
                    {
                        sum += item.Result;
                    }

                    Console.WriteLine($"Результат - {sum:N}");
                }
            );
            Console.ReadKey();
        }

        private static double Calculate(int x)
        {
            double res = 0.0;

            for (int i = 0; i < 10; i++)
            {
                res += (i * random.Next(1, x) / (x * 2) * x);
            }

            return res;
        }


        private static void Main()
        {
            Task task = Task.Run(() => Method());
            // by default is TaskContinuationOptions.None :
            //task.ContinueWith((t) => Continuation());

            // configure continuation :
            //task.ContinueWith((t) => Continuation(t), TaskContinuationOptions.ExecuteSynchronously);
            task.ContinueWith((t) => Continuation(t), TaskContinuationOptions.RunContinuationsAsynchronously);
            // check another continuation options

            Console.ReadKey();
        }

        private static void Method()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Task #{Task.CurrentId} finsihed at thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));
        }

        private static void Continuation(Task task)
        {
            Console.WriteLine($"Continuation Task Id - {Task.CurrentId}. Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine();
        }

        */
    }
}
