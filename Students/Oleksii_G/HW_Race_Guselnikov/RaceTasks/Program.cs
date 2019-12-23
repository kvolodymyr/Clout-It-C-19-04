using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThreadTests;

namespace RaceTasks
{
    class Program
    {

        static int averageSpeed;
        static double startAcceliration;
        static double sectionAcceliration;
        static double distanceToFinish;

        static List<BolidTaskVersion> list = new List<BolidTaskVersion> {
               new BolidTaskVersion { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Ferrari" },
               new BolidTaskVersion { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "McLaren" },
               new BolidTaskVersion { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Fiat" },
               new BolidTaskVersion { CarPower = 700, MaxSpeed = 372, TankVolume = 60, TeamName = "Reno" },
            };

        static void Main(string[] args)
        {
            Task[] tasks = new Task[list.Count];
            BackTimerTaskVersion.RaceStart();
            for (int i = 0; i < list.Count; i++)         
            {
                tasks[i] = new Task(()=>Race(list[i]));
                tasks[i].Start();
                Thread.Sleep(500);
            }
            Task.WaitAll(tasks);
            Console.WriteLine("\nRace is completed");
            Console.WriteLine("Race statistics:\n");
            foreach (var item in list)
            {
                Console.WriteLine("Team is {3} Max speed is {0} km/h, Min speed is {1} km/h, Race time is {2} sec", item.MaxRaceSpeed, item.MinSpeed, item.RaceTime, item.TeamName);
            }
            Console.ReadLine();
        }

        public static void Race(BolidTaskVersion bolid)
        {
            Console.WriteLine("Team name {0}, Max speed {1} km/h, Power {2} h.p., Tank volume {3}", bolid.TeamName, bolid.MaxSpeed, bolid.CarPower, bolid.TankVolume);
            DistanceMonitoringTaskVersion distanceMonitoring = new DistanceMonitoringTaskVersion();
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
        }
    }
}
