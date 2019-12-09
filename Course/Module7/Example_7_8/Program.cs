using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loop");
            for (int i = 0; i <= 8; i++) {
                Console.WriteLine($"i = {i}, Thread.CurrentThread.ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            }
            Console.WriteLine("Parallel.For");
            Parallel.For(0, 8, i => {
                Console.WriteLine($"i = {i}, Thread.CurrentThread.ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            });
        }
    }
}
