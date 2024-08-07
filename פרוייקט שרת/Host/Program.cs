using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

using System.ServiceModel;
namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost Host = new ServiceHost(typeof(Server.Service1));
            Host.Open();

            Console.ReadLine();

        }
    }
}
