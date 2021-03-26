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
            int port = 23000;

            // config: devo configurare l'EndPoint
            IPEndPoint ipep = new IPEndPoint(ipaddr, port);

            Server.Bind(ipep);// La assegno al server
            Server.Listen(5);

            /* fine configurazione server */

            /* In attesa di client che si connettono */

            Socket client = Server.Accept();//Server si blocca
            Console.WriteLine("Il Client è connesso!");


            /* Fine in attesa di client che si connettono */
            /* Saluto il client*/

            string Saluto = "Ciao Client!";

            byte[] buff = new byte[128];

            //ho bisogno di convertire da stringa a byte[]
            buff = Encoding.ASCII.GetBytes(Saluto);

            client.Send(buff);
            /* fine saluto il client*/
            while (true)
            {
                /* Attendo messaggio dal Client */
                byte[] buff2 = new byte[128];
                string messaggio = "";
                int recvBytes = 0;

                recvBytes = client.Receive(buff2);

                messaggio = Encoding.ASCII.GetString(buff2, 0, recvBytes);

                Console.WriteLine("Client dice: " + messaggio);

                /* fine attendo messagio dal Client */

                /* Rispondo al client */
                string risposta = "Non ho capito";
                if (messaggio == "temp")
                {
                    risposta = "25 C";
                }

                byte[] buff3 = new byte[128];

                //ho bisogno di convertire da stringa a byte[]
                buff3 = Encoding.ASCII.GetBytes(risposta);

                client.Send(buff3);

                /* fine rispondo al client */
            }
            
        }
    }
}
