using FastFup_Prove_Eksamen_1;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPServer
{
    static class Program
    {

        static void Main(string[] args)
        {
            //Opret server
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //Opret adresse eller port
            TcpListener serverSocket = new TcpListener(ip, 7000);
            //starter Server listener
            serverSocket.Start();
            Console.WriteLine("Server Started");

            //While loekke der holder serveren koerende, og ventende paa clienter
            while (true)
            {
                //threading der tillader flere clienter at forbinde
                Task.Run(() =>
                {
                    //Venter på client forbindelse
                    TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Client Connected");
                    //kalder metoden DoClient ved forbindelses oprettelse
                    DoClient(connectionSocket);

                });

            }

        }
        //TCP client til modsvar fra server til client
        public static void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string message = sr.ReadLine();

            while (message != null && message != "")
            {
                //Laver clientens besked om til et array
                string[] messageArray = message.Split(' ');

                //opdeler kommando og parametre
                string param = message.Substring(message.IndexOf(' ') + 1);
                string command = messageArray[0];

                switch (command)
                {
                    case "Gennemsnit":
                        string[] par = param.Split(' ');
                        sw.WriteLine("Gennemsnits braendstofsforbruget:" + TransportCalc.Average(int.Parse(par[0]), double.Parse(par[1])));

                        break;
                    case "TotalKm":

                        sw.WriteLine("Summen af km koert:" + TransportCalc.Total(param));

                        break;

                    default:

                        sw.WriteLine("Ugyldig kommando");
                        break;
                }
                message = sr.ReadLine();
            }
            ns.Close();
            socket.Close();
        }
    }
}
