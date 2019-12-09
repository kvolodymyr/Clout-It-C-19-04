using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_1
{
    // https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=netframework-4.8
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId}");
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;
            foreach (ProcessThread thread in currentThreads) {
                Console.WriteLine($"thread {thread.Id}");
            }
            FirstThread();
            Console.ReadLine();
        }

        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding 
        // the rest of its time slice each time, and then ends.
        public static void ThreadProc() {
            for (int i = 1; i < 10; i++) {
                // A thread ID. The value of the read-only ManagedThreadId property is assigned 
                // by the runtime and uniquely identifies a thread within its process.
                // Note
                // An operating - system ThreadId has no fixed relationship to a managed thread, 
                // because an unmanaged host can control the relationship between managed and 
                // unmanaged threads.Specifically, a sophisticated host can use the CLR Hosting 
                // API to schedule many managed threads against the same operating system thread, 
                // or to move a managed thread between different operating system threads.
                Console.WriteLine($"Counter: {i}, thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            }
        }

        public static void FirstThread() {
            // The constructor for the Thread class requires a ThreadStart 
            // delegate that represents the method to be executed on the 
            // thread.  C# simplifies the creation of this delegate.
            ThreadStart starter = new ThreadStart(ThreadProc);
            Thread thread1 = new Thread(starter);
            Thread thread2 = new Thread(starter);

            // Start ThreadProc.  Note that on a uniprocessor, the new 
            // thread does not get any processor time until the main thread 
            // is preempted or yields.  Uncomment the Thread.Sleep that 
            // follows t.Start() to see the difference.
            // Remark: When a process starts, the common language runtime automatically 
            // creates a single foreground thread to execute application code. Along with 
            // this main foreground thread, a process can create one or more threads to execute 
            // a portion of the program code associated with the process. These threads can execute 
            // either in the foreground or in the background. In addition, you can use the ThreadPool 
            // class to execute code on worker threads that are managed by the common language runtime.
            thread1.Start();
            thread2.Start();

            Thread.Sleep(1000);

            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;
            foreach (ProcessThread thread in currentThreads)
            {
                Console.WriteLine($"thread {thread.Id}");
            }

            thread1.Join();
            thread2.Join();
        }
    }
}
