using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StartClient();
        }

        public static void StartClient()
        {
            TcpClient socket = new TcpClient("192.168.3.2", 7000);

            while (true)
            {
                Stream ns = socket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string message = Console.ReadLine();
                sw.WriteLine(message);
                string line = sr.ReadLine();

                Console.WriteLine(line);
            }
            
        }
    }
}
