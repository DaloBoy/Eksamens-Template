using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Udp_Sender_Template
{
    class UDPSender
    {
        private readonly int PORT;

        public UDPSender(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            // Eksempel med class library
            //Car bil = new Car("Tesla", "red", "EL23400");


            //Objektet til tekst
            //var biltekst = bil.ToString();
            var tekst = "Hej";

            //Sender
            byte[] buffer = Encoding.ASCII.GetBytes(tekst /*biltekst*/);

            UdpClient udp = new UdpClient();

            IPEndPoint OtherEP = new IPEndPoint(IPAddress.Broadcast, PORT);
            udp.Send(buffer, buffer.Length, OtherEP);

            IPEndPoint ReceiverEp = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiverbuffer = udp.Receive(ref ReceiverEp);
            Console.WriteLine($"længde af modtaget udp datagram = {receiverbuffer.Length}");
            String incomingStr = Encoding.ASCII.GetString(receiverbuffer);
            Console.WriteLine(incomingStr);
        }
    }
}
