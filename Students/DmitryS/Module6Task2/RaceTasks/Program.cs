using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            List<Car> cars = new List<Car> {
                new Car("Red Bull", rnd, 3340),
                new Car("Brawn GP", rnd, 3340),
                new Car("McLaren", rnd, 3340),
                new Car("Mercedes", rnd, 3340),
                new Car("Renault", rnd, 3340),
                new Car("Williams", rnd, 3340),
                new Car("BMW", rnd, 3340),
                new Car("Ferrari", rnd, 3340),
            };
            Console.WriteLine("Race starts after");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"{i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Go");
            Console.Clear();
            Task[] tasks = new Task[cars.Count];
            for (int i = 0; i < cars.Count; i++)
            {
                tasks[i] = new Task(() => Race(cars[i]));
                tasks[i].Start();
                Thread.Sleep(500);
            }
            Task.WaitAll(tasks);
            Console.Clear();
            Console.WriteLine("Race is done.\nCar stats:\n");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Team} cleared race in {item.Time} seconds with end distance of {(int)(item.Distance * 100) / 100.0} and end speed of {(int)(item.CurrentSpeed * 100) / 100.0}\n");
            }
            Console.ReadLine();
        }

        public static void Race(object c)
        {
            Car car = (Car)c;
            var rnd = new Random();
            car.Start(rnd);
            car.ManualResetEvent.Set();
        }
    }
}
