using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_2
{
    class Program
    {
        private static Thread mother;
        private static Thread son;


        static void Main(string[] args)
        {
            Interrupt();
        }

        public static void Interrupt() {
            mother = new Thread(new ThreadStart(MotherSleep));
            son = new Thread(new ThreadStart(ChildWoke));

            mother.Start();
            son.Start();
            mother.Join();
            son.Join();

            Console.WriteLine("Exiting Interrupt");
            Console.ReadLine();
        }

        private static void MotherSleep() {
            for (int i = 0; i < 50; i++) {
                Console.WriteLine("m");
                if (i % 10 == 0 && i != 0) {
                    try
                    {
                        Console.WriteLine($"Mother counter control: {i}, thread: {Thread.CurrentThread.ManagedThreadId} Mother still sleep");
                        Thread.Sleep(2000);
                    }
                    catch (ThreadInterruptedException) {
                        Console.WriteLine("Mother catch ThreadInterruptedException. Get up!");
                        Console.WriteLine("Ok");
                    }
                }
            }
        }

        private static void ChildWoke()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("c");
                if (mother.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine($"Child check Mother. ThreadState == ThreadState.WaitSleepJoin. Interrupting mother");
                    mother.Interrupt();
                }
            }
        }

    }
}
