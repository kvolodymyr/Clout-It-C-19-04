using System;
using System.Collections.Generic;
using System.Threading;

namespace Formula1
{
    internal class Race
    {
        private const int Lap = 3340;
        private static readonly object Locker = new object();
        static ManualResetEvent sync_event = new ManualResetEvent(false);

        public static void BeforeTheRace(List<object> listOfTeams)
        {
            Console.WriteLine("=================BEFORE RACE=================");

            foreach (var team in listOfTeams)
            {
                ThreadPool.QueueUserWorkItem(StartTheRace, team);
            }

            Thread.Sleep(10000);     //This is necessary for my home computer(2 cores 4 threads).

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
        }

        public static void StartTheRace(object info)
        {
            var carInfo = (CarInfo)info;

            SayHelloBeforeRace(carInfo);

            sync_event.WaitOne();

            var a = carInfo.AvgSpeed / 4 / 5;   //car acceleration
            carInfo.Distance += a * 25;
            while (carInfo.Distance < Lap)
            {
                Thread.Sleep(1000);

                var random = carInfo.Rnd.Next(0, 100);
                int speed;

                if (random >= 100)
                    speed = carInfo.Rnd.Next(360, 370) / 4;
                else if (random >= 81)
                    speed = carInfo.Rnd.Next(320, 360) / 4;
                else
                    speed = carInfo.Rnd.Next(250, 320) / 4;

                carInfo.Distance += speed;

                PrintState(speed, carInfo);
            }

            Console.WriteLine($"\n===================={carInfo.TeamName} has finished race====================\n"); //replace later with events
        }

        private static void SayHelloBeforeRace(CarInfo carInfo)
        {
            lock (Locker)
            {
                Console.WriteLine($"Team: {carInfo.TeamName}");
                Console.WriteLine($"Avg Speed: {carInfo.AvgSpeed}");
                Console.WriteLine();
            }
        }

        private static void PrintState(int speed, CarInfo carInfo)
        {
            var percent = carInfo.Distance * 30 / Lap;
            Console.WriteLine("\n" + $"Team:{carInfo.TeamName}; " +
                              $"Speed is {speed} m/s; " +
                              $"Distance is {carInfo.Distance} m." +
                              "\t" + new string('#', percent) +
                              new string('-', (30 - percent % 31)));

        }

    }
}
