using System;
using System.Threading;

namespace Formula1
{
    internal class Program
    {
        private const int Lap = 3340;
        static readonly object Locker = new object();
        static ManualResetEvent sync_event = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("=================BEFORE RACE=================");

            object team1Info = new CarInfo("Red Bull");
            object team2Info = new CarInfo("Brawn GP");
            object team3Info = new CarInfo("McLaren");
            object team4Info = new CarInfo("Mercedes");
            object team5Info = new CarInfo("Renault");
            object team6Info = new CarInfo("Williams");
            object team7Info = new CarInfo("BMW team");
            object team8Info = new CarInfo("Ferrari");

            ThreadPool.QueueUserWorkItem(Race, team1Info);
            ThreadPool.QueueUserWorkItem(Race, team2Info);
            ThreadPool.QueueUserWorkItem(Race, team3Info);
            ThreadPool.QueueUserWorkItem(Race, team4Info);
            ThreadPool.QueueUserWorkItem(Race, team5Info);
            ThreadPool.QueueUserWorkItem(Race, team6Info);
            ThreadPool.QueueUserWorkItem(Race, team7Info);
            ThreadPool.QueueUserWorkItem(Race, team8Info);

            Thread.Sleep(6000);


            lock (Locker)
            {
                Console.WriteLine("====================RACE====================");
                Console.WriteLine(3);
                Thread.Sleep(1000);
                Console.WriteLine(2);
                Thread.Sleep(1000);
                Console.WriteLine(1);
                Thread.Sleep(1000);
                Console.WriteLine("GO");
            }

            sync_event.Set();

            Console.ReadLine();
        }

        static void Race(object info)
        {
            CarInfo inf = (CarInfo)info;
            lock (Locker)
            {
                Console.WriteLine($"Team: {inf.TeamName}");
                Console.WriteLine($"Avg Speed: {inf.AvgSpeed}");
                Console.WriteLine();
            }

            sync_event.WaitOne();

            Random rnd = new Random();

            int a = inf.AvgSpeed / 4 / 5;
            inf.Distance += a * 25;
            while (inf.Distance < Lap)
            {
                Thread.Sleep(1000);

                int random = (rnd.Next(0, 100) + Thread.CurrentThread.ManagedThreadId * 13) % 100; // flow identifier is used to make the Random() work more correctly
                int speed;

                if (random >= 100)
                {
                    speed = (rnd.Next(360, 370) + Thread.CurrentThread.ManagedThreadId * 13) / 4;
                }
                else if (random >= 81)
                {
                    speed = (rnd.Next(320, 360) + Thread.CurrentThread.ManagedThreadId * 13) / 4;

                }
                else
                {
                    speed = (rnd.Next(250, 320) + Thread.CurrentThread.ManagedThreadId * 13) / 4;
                }

                inf.Distance += speed;
                var percent = inf.Distance * 30 / Lap;

                Console.WriteLine($"Team:{inf.TeamName}; Speed is {speed} m/s; Distance is {inf.Distance} m." + "\t" + new string('#', percent) + new string('-', (30 - percent % 31)));
            }

            Console.WriteLine($"\n=================================={inf.TeamName} has finished race==================================\n");
        }
    }

    class CarInfo
    {
        Random rnd = new Random();
        public string TeamName { get; set; }
        public int AvgSpeed { get; set; }
        public int Distance { get; set; }

        public CarInfo(string name)
        {
            TeamName = name;
            Distance = 0;

            if ((rnd.Next(rnd.Next(0, 100) + Thread.CurrentThread.ManagedThreadId * 20) % 100) >= 76)
                AvgSpeed = rnd.Next(261, 270);
            else
                AvgSpeed = rnd.Next(250, 260);
        }
    }
}
