using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_5
{
    class Program
    {
        static AutoResetEvent syncEvent;

        static void Main(string[] args)
        {
            // Example a
            // lock (ThreadLock) {
            //    Console.WriteLine($"Thread.CurrentThread.Name {Thread.CurrentThread.Name} in DispatcherMessage()");
            //    // emulate long work
            //    Console.WriteLine("Random Morse code");
            //    for (int i = 0; i < 35; i++) {
            //        Random rnd = new Random();
            //        int j = rnd.Next(0, 36);
            //        Thread.Sleep(10 * j);
            //        Console.WriteLine($"{Morse_code[j]}");
            //    }
            //}

            // Example b
            //Monitor.Enter(MonitorLocker);
            //try
            //{
            //    Console.WriteLine($"Thread.CurrentThread.Name {Thread.CurrentThread.Name} in DispatcherMessage()");
            //    // emulate long work
            //    Console.WriteLine("Random Morse code");
            //    for (int i = 0; i < 35; i++)
            //    {
            //        Random rnd = new Random();
            //        int j = rnd.Next(0, 36);
            //        Thread.Sleep(10 * j);
            //        Console.WriteLine($"{Morse_code[j]}");
            //    }
            //}
            //finally {
            //    Monitor.Exit(MonitorLocker);
            //}


        }

        static void SomethingDo() {
            Console.WriteLine("Worker thread waits on event...");
            syncEvent.WaitOne();
            Console.WriteLine("Worker thread reactivated");
        }

        static void SyncEvent() {
            syncEvent = new AutoResetEvent(false);
            Console.WriteLine("Main thread starts worker thread...");
            Thread thread = new Thread(SomethingDo);
            thread.Start();
            Console.WriteLine("Main thread sleeps for 3 sedonds...");
            Thread.Sleep(3000);
            Console.WriteLine("Main thread signals worker thread...");
            syncEvent.Set();
        }
    }
}
