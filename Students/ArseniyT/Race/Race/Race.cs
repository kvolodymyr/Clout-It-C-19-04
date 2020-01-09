using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class Race
    {
        public string RaceName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public readonly double totalDistance;
        public List<Car> Cars { get; set; }
        public List<Task> Tasks = new List<Task>();

        public Race(string name, string country, string city, double totalDistance, List<Car> cars)
        {
            Cars = cars;
            this.totalDistance = totalDistance;
            RaceName = name;
            Country = country;
            City = city;

            foreach (var car in Cars)
            {
                car.totalDistance = totalDistance;
            }
        }

        private void Welcom()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Welcom to the {RaceName} race!!!\nCountry: {Country}\nCity: {City}\nTotalDistance: {totalDistance}");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        private void ShowCars()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Participants");
            foreach (var car in Cars)
            {
                Console.WriteLine("________________________");
                Console.WriteLine(car);
                Console.WriteLine("________________________\n");
            }
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        private void Countdown()
        {
            Console.WriteLine("Press any button to start race.");
            Console.ReadKey();
            Console.Clear();
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============\n\nReady!\n\n=============");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============\n\nStady!\n\n=============");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=============\n\nGo!\n\n=============");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Go()
        {
            foreach (var car in Cars)
            {
                Task task = new Task(car.Start);
                Tasks.Add(task);

                task.Start();
            }
            Task.WaitAll(Tasks.ToArray());

        }

        public void StartRace()
        {
            //Welcom();
            //ShowCars();
            //Countdown();
            Go();
        }
    }
}
