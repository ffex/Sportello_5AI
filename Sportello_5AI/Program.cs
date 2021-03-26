using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Sportello_5AI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* configurazione server */
            Socket Server;
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Any;

            // config: devo configurare l'EndPoint
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            Server.Bind(ipep);
            /* fine configurazione server */
        }
    }
}
