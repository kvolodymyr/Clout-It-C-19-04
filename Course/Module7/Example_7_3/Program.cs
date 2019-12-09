using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example_7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowThreadPool();
        }

        private static void ShowThreadPool() {
            WaitCallback clb = new WaitCallback(DispatcherState);
            ThreadPool.QueueUserWorkItem(clb, "Start");
            ThreadPool.QueueUserWorkItem(clb, "Sleep");
            ThreadPool.QueueUserWorkItem(clb, "Interrupt");
            ThreadPool.QueueUserWorkItem(clb, "Join");
        }

        private static void DispatcherState(object state) {
            Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId} = {state}");
        }

    }
}
