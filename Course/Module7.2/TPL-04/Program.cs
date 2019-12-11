using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_04
{
    class Program
    {
        private static void Main()
        {
            // Wait(), WaitAll(), WaitAny() - could call deadlock

            Task[] tasks = new Task[] {
                new Task(DoSomething, 1000),
                new Task(DoSomething, 800),
                new Task(DoSomething, 2000),
                new Task(DoSomething, 1000),
                new Task(DoSomething, 3500),
            };

            Console.WriteLine($"main...");
            foreach (Task task in tasks)
                task.Start();

            Console.WriteLine($"main suspended...");
            //foreach (Task task in tasks)
            //    task.Wait();
            //Task.WaitAll(tasks);
            Task.WaitAny(tasks);

            Console.WriteLine($"main continue");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"main({i})");
            }
        }

        private static void DoSomething(object sleepTime)
        {
            Console.WriteLine($"Task #{Task.CurrentId} in thread {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep((int)sleepTime);

            Console.WriteLine($"\t\tTask #{Task.CurrentId} [{Thread.CurrentThread.ManagedThreadId}] completed ");
        }
    }
}
