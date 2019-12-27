using System;

namespace ThreadTests
{
    class Bolid
    {
        public string TeamName { get; set; }
        public int CarPower { get; set; }
        public int MaxSpeed { get; set; }
        public int MaxRaceSpeed { get; set; }
        public int MinSpeed { get; set; }
        public double RaceTime { get; set; }
        public int TankVolume { get; set; }

        public System.Threading.ManualResetEvent ManualResetEvent { get; set; }

        public int GetAverageSpeed()
        {
            Random random = new Random();
            var probability = random.Next(0, 100);
            int speed;
            if (probability <= 75)
            {
                speed = random.Next(250, 260);
                MaxRaceSpeed = speed;
                return speed;
            }
            else
            {
                speed = random.Next(261, 270);
                MaxRaceSpeed = speed;
                return speed;
            }
        }

        public int GetMaxSectionSpeed()
        {
            Random random = new Random();
            var probability = random.Next(0, 100);
            int speed;
            if (probability >= 0 && probability <= 80)
            {
                speed = random.Next(250, 320);
                if (MaxRaceSpeed > speed)
                {
                    MinSpeed = speed;
                }
                else
                {
                    MinSpeed = MaxRaceSpeed;
                    MaxRaceSpeed = speed;
                }
                return speed;
            }
            else if (probability >= 81 && probability <= 99)
            {
                speed = random.Next(321, 360);
                if (MaxRaceSpeed > speed)
                {
                    MinSpeed = speed;
                }
                else
                {
                    MinSpeed = MaxRaceSpeed;
                    MaxRaceSpeed = speed;
                }
                return speed;
            }
            else
            {
                speed = random.Next(361, 370);
                if (MaxRaceSpeed > speed)
                {
                    MinSpeed = speed;
                }
                else
                {
                    MinSpeed = MaxRaceSpeed;
                    MaxRaceSpeed = speed;
                }

                return speed;
            }
        }

        public double StartAcceleration(int averageSpeed)
        {
            double reachedTime = 5.0;
            double acceleration = (averageSpeed * 0.28) / reachedTime;
            return acceleration;
        }

        public double SectionAcceleration(int averageSpeed)
        {
            double reachedTime = 1.0;
            double acceleration = (averageSpeed * 0.28) / reachedTime;
            return acceleration;
        }
    }
}
