using System;
using System.Collections.Generic;

namespace Formula1
{
    internal class Program
    {

        private static void Main()
        {
            var rnd = new Random();

            var listOfTeams = new List<object>
            {
                new CarInfo("Red Bull", rnd),
                new CarInfo("Brawn GP", rnd),
                new CarInfo("McLaren", rnd),
                new CarInfo("Mercedes", rnd),
                new CarInfo("Renault", rnd),
                new CarInfo("Williams", rnd),
                new CarInfo("BMW team", rnd),
                new CarInfo("Ferrari", rnd)
            };

            Race.BeforeTheRace(listOfTeams);

            Console.ReadLine();
        }
    }
}
