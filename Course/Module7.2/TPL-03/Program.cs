using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_03
{
    class Program
    {
        const int Delay = 1000;

        private static void Main()
        {
            Action worker = () => Thread.Sleep(Delay);

            Task task = new Task(worker); // Task task = new Task(new Action(<<static void SomeMethod()>>));

            Console.WriteLine($"{task.Status}");

            task.Start();

            Console.WriteLine($"{task.Status}");
            Thread.Sleep(Delay);

            Console.WriteLine($"{task.Status}");
            Thread.Sleep(Delay * 2);

            Console.WriteLine($"{task.Status}");
        }
    }
}
