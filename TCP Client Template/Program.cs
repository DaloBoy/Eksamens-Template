using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_Template
{
    class Program
    {
        private const int PORT = 11111;
        static void Main(string[] args)
        {
            Client client = new Client(PORT);
            client.Start();

            Console.ReadLine();
        }
    }
}
