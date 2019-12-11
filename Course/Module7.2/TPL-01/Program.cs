using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_01
{
    class Program
    {
        const int Delay = 50;
        static void Main(string[] args)
        {
            Console.WriteLine(@"Hello TPL #01!
- 2 kind of task
- 4 exmaple of run task
- use delegates Action/Func (also you can use method directly)
- run tasks with parameters
- run task synchronously
- return task's result
");

            RunTaskWithoutResult();

            Console.WriteLine(Environment.NewLine);

            RunTaskWithResult();
        }

        private static void RunTaskWithoutResult() {
            Console.WriteLine(@"Section: TPL #01.a");

            #region Workers
            Action<object> additionalOutput = (object data) => {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(data ?? '*');
                    Thread.Sleep(Delay);
                }
            };
            Action generalOutput = () => {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(Delay);
                }
            };
            #endregion

            // Cold task (run after create)
            // Step #1  Meet the constructors of the Task, first 4th are more used
            // Step #2  Meet the Task 
            //          class properties (static): CompletedTask, CurrentId, Factory
            //          instance's properties:  CreationOptions, Exception, 
            //                                  IsCompleted, IsCanceled, AsyncState, 
            //                                  IsCompletedSuccessfully, Id, IsFaulted, 
            //                                  Status

            Task task = new Task(additionalOutput, "-");
            task.Start();
            /* task.Start(); - Unhandled exception. System.InvalidOperationException: Start may not be called on a task that was already started. */
            generalOutput();

            // Hot task (create and run), older
            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(additionalOutput, "+");
            generalOutput();

            // Hot task, preferably
            Task.Run(() => additionalOutput("?")); // Task.Run(thread);
            generalOutput();

            // Cold task
            task = new Task(additionalOutput, "*");
            task.RunSynchronously();
            // now generalOutput wait on its queue for print to console
            generalOutput();
        }

        private static void RunTaskWithResult() {
            Console.WriteLine(@"Section: TPL #01.b");
            #region Workers
            Func<object, string> additionalOutput = (object data) => {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(data ?? '*');
                    Thread.Sleep(Delay);
                }
                return data.ToString();
            };
            #endregion

            Task<string> task1 = new Task<string>(additionalOutput, "-");
            task1.Start();
            Console.WriteLine($"\nResult (char) of task #1 - {task1.Result}");
            Thread.Sleep(1000);

            TaskFactory taskFactory = new TaskFactory();
            Task<string> task2 = taskFactory.StartNew<string>(additionalOutput, "+");
            Console.WriteLine($"\nResult (char) of task #2 - {task2.Result}");
            task2.Wait();

            Task<string> task3 = Task.Run(() => additionalOutput("?"));
            Console.WriteLine($"\nResult (char) of task #3 - {task3.Result}");
            task3.Wait();

            Task<string> task4 = new Task<string>(additionalOutput, "*");
            task4.RunSynchronously();
            Console.WriteLine($"\nResult (char) of task #4 - {task4.Result}");
        }
    }
}
