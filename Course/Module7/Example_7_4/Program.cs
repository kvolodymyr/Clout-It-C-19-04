using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBack WorkThread = new MessageBack();
            WorkThread.Message = "Are you present?";
            new Thread(WorkThread.Replay).Start();

            Console.WriteLine("Press any key");
            Console.ReadLine();
            Console.WriteLine(WorkThread.Answer);
        }
    }


    public class MessageBack {
        public string Message { get; set; }
        public string Answer { get; set; }

        public void Replay() {
            Console.WriteLine($"Worker thread. Message field: {Message}");
            Answer = "Yes!";
        }
    }
}
