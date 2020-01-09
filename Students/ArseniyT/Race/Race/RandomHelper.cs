using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class RandomHelper
    {
        static public int GetAverageSpeed()
        {
            Thread.Sleep(100);
            Random rand = new Random();
            if (rand.Next(0, 100) < 75)
            {
                return rand.Next(250, 260);
            }
            else return rand.Next(260, 270);
        }

        static public int GetRandomSpeed()
        {
            Random rand = new Random();
            int randomValue = rand.Next(0, 100);
            if (randomValue < 80)
            {
                return rand.Next(250, 320);
            }
            else if (randomValue < 90)
            {
                return rand.Next(320, 360);
            }
            else return rand.Next(360, 370);
        }
    }
}
