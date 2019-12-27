using System;

namespace ThreadTests
{
    public class DistanceMonitoring
    {
        public int FullDistance { get; } = 1340;

        public double PrintCoverDistance(double acceliration, double coveredDistance)
        {
            double distance = (acceliration / 2) + coveredDistance;
            double quantityOfPrintedSymbols = Math.Round((distance * 0.03), 5);
            for (int i = 0; i < quantityOfPrintedSymbols; i++)
            { Console.Write("*"); }
            Console.WriteLine();
            if (distance <= FullDistance)
            {
                return distance;
            }
            else
            {
                Console.WriteLine("Bolid completed race");
                return distance;
            }
        }
        public double PrintFirstCoveredDistance(double acceliration)
        {
            double distance = (acceliration * Math.Pow(5, 2) / 2);
            double quantityOfPrintedSymbols = Math.Round((distance * 0.03), 5);
            Console.Write("{0} m ", distance);
            for (int i = 0; i < quantityOfPrintedSymbols; i++)
            { Console.Write("*"); }
            Console.WriteLine();
            return distance;
        }
    }
}
