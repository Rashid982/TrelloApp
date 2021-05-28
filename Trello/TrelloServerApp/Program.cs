using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Trello.Model;

namespace TrelloServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listener
            TcpListener server = new TcpListener(IPAddress.Any, 5001);
            server.Start();
            Console.WriteLine("Server is running...");
           
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected !");
                Task.Run(() =>
                {
                    using (var reader = new StreamReader(client.GetStream()))
                    {                        
                        var jsonMessage = JsonConvert.DeserializeObject<Board>(reader.ReadToEnd());
                        
                        //Sender
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5002);
                        TcpClient senderClient = new TcpClient();
                        senderClient.Connect(endPoint);

                        var jsonMessages = JsonConvert.SerializeObject(jsonMessage);

                        using (var writer = new StreamWriter(senderClient.GetStream()))
                        {
                            writer.WriteLine(jsonMessages);
                            writer.Flush();
                        }
                        Console.WriteLine("The message was sent to client !");
                    }
                });
            }
            
        }
    }
}
