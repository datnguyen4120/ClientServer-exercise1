using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 1234);
            server.Bind(ip);
            StreamReader sr = new StreamReader("..//..//TextFileServer.txt");
            string readFile = sr.ReadToEnd();
            sr.Close();
            server.Listen(4);
            Socket client = server.Accept();
            byte[] Receive = new byte[1024 * 60];
            int receive = client.Receive(Receive);
            string serverReceive = Encoding.ASCII.GetString(Receive, 0, receive);
            Console.WriteLine("Client send: " + serverReceive);
            byte[] Send = Encoding.ASCII.GetBytes(readFile);
            client.Send(Send);

        }
    }
}
