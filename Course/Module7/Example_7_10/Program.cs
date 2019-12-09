using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_7_10
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[100];
            string FName = "hello";
            FileStream FStream = new FileStream(FName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            IAsyncResult result = FStream.BeginRead(buffer, 0, buffer.Length, null, null);
            int numBytes = FStream.EndRead(result);
            FStream.Close();
            Console.WriteLine($"Read {numBytes} bytes");
            Console.WriteLine(BitConverter.ToString(buffer));
        }
    }
}
