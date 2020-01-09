using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car(1, "Ferarri", "Mihcael Johnson"),
                new Car(2, "Renault", "Alex Stone"),
                new Car(3, "BMW", "Paul Fuks"),
                new Car(4, "Ferarri", "Andrey  Sobolev"),
                new Car(5, "Honda", "Kim Song"),
            };

            Race race = new Race("Hell Race", "France", "Paris", 3.5, cars);
            race.StartRace();
            
        }
    }
}
