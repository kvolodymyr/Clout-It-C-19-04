using System;

namespace Formula1
{
    internal class CarInfo
    {
        public string TeamName { get; set; }
        public int AvgSpeed { get; set; }
        public int Distance { get; set; }
        public Random Rnd { get; set; }

        public CarInfo(string name, Random rnd)
        {
            TeamName = name;
            Distance = 0;
            Rnd = rnd;

            if (rnd.Next(0, 100) >= 76)
                AvgSpeed = rnd.Next(261, 270);
            else
                AvgSpeed = rnd.Next(250, 260);
        }
    }
}
