using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module6Task2
{
    class Car
    {
        static object locker = new object();
        public int TimeToAverageSpeed { get; }
        public double AverageSpeed { get;}
        public double MaxSpeed { get;}
        public double Distance { get; set; }
        public double CurrentSpeed { get; set; }
        public double TargetDistance { get; set; }
        public string Team { get;}
        public int Time { get; set; }
        public ManualResetEvent ManualResetEvent { get; set; }
        public Car(string team, Random rnd, int target)
        {
            Team = team;
            Time = 0;
            TargetDistance = target;
            TimeToAverageSpeed = rnd.Next(3, 5);
            CurrentSpeed = 0;
            Distance = 0;
            MaxSpeed = 103.5; //372.6/3.6 (m/s)
            int probability = rnd.Next(1, 100);
            if(probability<76)
            {
                AverageSpeed = rnd.Next(250, 260)/3.6;
            }
            else
            {
                AverageSpeed = rnd.Next(261, 270)/3.6;
            }
            
        }
        public void Start(Random rnd)
        {
            int probability=-1;
            for (int i = 0; i < TimeToAverageSpeed; i++)
            {
                CurrentSpeed += AverageSpeed / TimeToAverageSpeed;
                Distance += CurrentSpeed;
                lock (locker)
                {
                    Console.WriteLine(this.ToString());
                }
                Thread.Sleep(1000);
                Time++;
            }
            while(Distance<TargetDistance)
            {
                probability = rnd.Next(1, 100);
                if (probability < 81)
                {
                    CurrentSpeed = rnd.Next(250,320);
                }
                else if(probability<100)
                {
                    CurrentSpeed = rnd.Next(320, 360);
                }
                else
                {
                    CurrentSpeed = rnd.Next(360, 370);
                }
                Distance += CurrentSpeed;
                lock (locker)
                {
                    Console.WriteLine(this.ToString());
                }
                Thread.Sleep(1000);
                Time++;
            }
        }
        public override string ToString()
        {
            return $"Team: {Team}, Current speed = {(int)(CurrentSpeed*100)/100.0}, Current Distance = {(int)(Distance * 100) / 100.0}";
        }
    }
}
