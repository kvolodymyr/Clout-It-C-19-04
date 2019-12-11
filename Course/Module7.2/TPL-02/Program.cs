using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_02
{
    class Program
    {
        const int Delay = 50;

        static void Main(string[] args)
        {
            Console.WriteLine(@"Hello TPL #02!
- how to affect on task (configure)
- some thread constants
");
            // Task.CurrentId is nullable because it can be called out of task's context and in that case it null
            Console.WriteLine($"Main Task Id: {Task.CurrentId ?? -1}");
            Console.WriteLine($"Main Thread Id : {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));

            // Task creation options
            Task task = new Task(new Action(DoSomething), TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning);
            //TaskCreationOptions
            //      None - Specifies that the default behavior should be used.
            //      PreferFairness 
            //      LongRunning 
            //      AttachedToParent 
            //      DenyChildAttach 
            //      HideScheduler 
            //      RunContinuationsAsynchronously 

            task.Start(); // Запуск задачи
            task.Wait();

            // uncomment and check the task id
            //Parallel.For(0, 2, (int i) => Task.Run(new Action(DoSomething)));
            //Thread.Sleep(5000);
            //Parallel.For(0, 10, (int i) => Task.Run(new Action(DoSomething)));

            Thread.Sleep(Delay); // Даем поработать методу DoSomething

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"...main...");
                Thread.Sleep(Delay);
            }

            Console.ReadKey();
        }

        private static void DoSomething()
        {
            // Task.CurrentId is unique identifier od the task
            // Task.CurrentId is nullable because it can be called out of task's context and in that case it null
            Console.WriteLine($"DoSomething Task Id: {Task.CurrentId}");
            // ThreadId is not equal Task Id this is different things
            Console.WriteLine($"DoSomething Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', Delay));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\tdo something #{Task.CurrentId}");
                Thread.Sleep(Delay);
            }

            Console.WriteLine($"Thread finsihed: {Thread.CurrentThread.ManagedThreadId}.");
        }
    }
}
