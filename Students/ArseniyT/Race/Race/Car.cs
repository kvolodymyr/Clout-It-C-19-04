using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class Car
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public string Pilot { get; set; }
        public int AverageSpeed { get; set; }
        public double Distance { get; set; }

        public double totalDistance;

        public Car(int id, string team, string pilot)
        {
            Id = id;
            Team = team;
            Pilot = pilot;
            AverageSpeed = RandomHelper.GetAverageSpeed();
            Distance = 0;
        }

        public void Move(object state)
        {
            bool IsStart = (bool)state;
            if (IsStart)
            {
                Thread.Sleep(1000);
                Distance += (double)AverageSpeed / 3600;
            }
            else
            {
                Thread.Sleep(1000);
                Distance += (double)RandomHelper.GetRandomSpeed() / 3600; ;
            }
        }

        public void Start()
        {
            while (Distance < totalDistance)
            {
                Move(false);
                PrintDistance(totalDistance);
            }
        }

        public void PrintDistance(double totalDistance)
        {
            Console.WriteLine($"Team: {Team}, Pilot: {Pilot}, Сurrent distance: {Distance}, Remaining distance: {totalDistance - Distance}");
        }

        public override string ToString()
        {
            return $"Number: {Id}\nTeam: {Team}\nPilot: {Pilot}\nAverage speed: {AverageSpeed}";
        }
    }
}
