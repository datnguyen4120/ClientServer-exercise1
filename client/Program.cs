using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client.Connect(ipServer);
            string clientSend = "CYKA BLYAT";
            byte[] Send = Encoding.ASCII.GetBytes(clientSend);
            client.Send(Send);
            byte[] Receive = new byte[1024 * 60];
            int receive = client.Receive(Receive);
            string clientReceive = Encoding.ASCII.GetString(Receive, 0, receive);
            StreamWriter sw = new StreamWriter("..//..//TextFileClient.txt");
            sw.Write(clientReceive);
            sw.Close();
        }
    }
}
