using System;
using System.Threading;

namespace ThreadTests
{
    public class BackTimer
    {
        public static void RaceStart()
        {
            Console.WriteLine("Race starts after");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"#{i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("GO!");
        }
    }
}
