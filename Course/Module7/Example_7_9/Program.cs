using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mylist = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                mylist.Add($"{DateTime.Now.ToShortTimeString()} {i}");
            }
            Parallel.ForEach(mylist, (text) => Console.WriteLine(text));

            Console.WriteLine("Parallel.Foreach");
            long total1 = 0;
            Parallel.ForEach<string, long>(mylist, () => { return total1; }, (j, loop, subtotal) => {
                Console.WriteLine(j);
                return ++subtotal;
            },
            (finalResult) => Interlocked.Add(ref total1, finalResult));
            Console.WriteLine($"the total count from Parallel.ForEach is {total1:N0}");

            Parallel.Invoke(() => Console.WriteLine("Hello Dude"), () => Console.WriteLine("Hi!"));

        }
    }
}
