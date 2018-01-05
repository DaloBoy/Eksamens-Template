using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamens_Template
{
    class Program
    {
        private const int PORT = 7070;
        static void Main(string[] args)
        {
            UDPReciever reciever = new UDPReciever(PORT);
            reciever.Start();
            Console.ReadLine();
        }
    }
}
