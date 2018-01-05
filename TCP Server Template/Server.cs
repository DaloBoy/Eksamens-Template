using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_Template
{
    class Server
    {
        private readonly int PORT;

        public Server()
        {
            
        }

        public Server(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Loopback, PORT);
                listener.Start();
                Console.WriteLine("Echo Server Startet.");
                while (true)
                {
                    Console.WriteLine("venter på client forbindelse");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("accepteret ny client forbindelse");
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    string s = string.Empty;
                    while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                    {
                        Console.WriteLine("Fra Client -> " + s);
                        Console.WriteLine("Fra Server -> " + s);
                        writer.Flush();
                    }
                    reader.Close();
                    writer.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            Console.ReadLine();
        }
    }
}
