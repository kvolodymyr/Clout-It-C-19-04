using System;
using System.Threading;
using ThreadTests;
using System.Collections.Generic;

namespace HelloApp
{
    class Program
    {
        static int averageSpeed;
        static double startAcceliration;
        static double sectionAcceliration;
        static double distanceToFinish;

        static List<Bolid> list = new List<Bolid> {
               new Bolid { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Ferrari" },
               new Bolid { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "McLaren" },
               new Bolid { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Fiat" },
               new Bolid { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Reno" },
            };

        static void Main(string[] args)
        {
            var completedRaces = new ManualResetEvent[list.Count];
            BackTimer.RaceStart();
            var manualResetEvents = new ManualResetEvent[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                list[i].ManualResetEvent = new ManualResetEvent(false);
                manualResetEvents[i] = list[i].ManualResetEvent;
                ThreadPool.QueueUserWorkItem(Race, list[i]);
            }
            WaitHandle.WaitAll(manualResetEvents);
            Console.WriteLine("\nRace is completed");
            Console.WriteLine("Race statistics:\n");
            foreach (var item in list)
            {
                Console.WriteLine("Max speed is {0} km/h, Min speed is {1} km/h, Race time is {2} sec", item.MaxRaceSpeed, item.MinSpeed, item.RaceTime);
            }
            Console.ReadLine();
        }

        public static void Race(object x)
        {
            Bolid bolid = (Bolid)x;
            Console.WriteLine("Team name {0}, Max speed {1} km/h, Power {2} h.p., Tank volume {3}", bolid.TeamName, bolid.MaxSpeed, bolid.CarPower, bolid.TankVolume);
            DistanceMonitoring distanceMonitoring = new DistanceMonitoring();
            averageSpeed = bolid.GetAverageSpeed();
            bolid.RaceTime = 5;
            startAcceliration = bolid.StartAcceleration(averageSpeed);
            Console.Write("First start {0}, {1} m/s^2 ", bolid.TeamName, startAcceliration);
            distanceToFinish = distanceMonitoring.PrintFirstCoveredDistance(startAcceliration);
            while (distanceToFinish <= distanceMonitoring.FullDistance)
            {
                bolid.RaceTime++;
                Console.WriteLine("");
                Thread.Sleep(1000);
                averageSpeed = bolid.GetMaxSectionSpeed();
                sectionAcceliration = bolid.SectionAcceleration(averageSpeed);
                Console.Write("{0}, {1} m/s^2, {2} m ", bolid.TeamName, sectionAcceliration, distanceToFinish);
                distanceToFinish = distanceMonitoring.PrintCoverDistance(sectionAcceliration, distanceToFinish);
            }
            bolid.ManualResetEvent.Set();
        }
    }
}