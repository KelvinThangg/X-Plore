using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SimpleServerCS
{
    class SimpleServer
    {
        int pport;
        TcpListener _tcpListener;
        static List<Client> clients = new List<Client>();

        public SimpleServer(string ipAddress, int port)
        {
            pport = port;
            IPAddress ip = IPAddress.Parse(ipAddress);
            _tcpListener = new TcpListener(ip, port);
        }

        public void Start()
        {
            _tcpListener.Start();
            Console.WriteLine("The server is listening on port : " + Convert.ToString(pport));
            while (true)
            {
                Socket socket = _tcpListener.AcceptSocket();
                Client client = new Client(socket);
                clients.Add(client);
                client.Start();
            }
            
        }

        public void Stop()
        {
            foreach (Client c in clients)
            {
                c.Stop();
            }

            _tcpListener.Stop();
        }

        public static void SocketMethod(Client fromClient)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Socket socket = fromClient.Socket;
                NetworkStream stream = fromClient.Stream;
                BinaryReader reader = fromClient.Reader;
                fromClient.SendText(fromClient, "Successfully Connected");
                int noOfIncomingBytes;
                while ((noOfIncomingBytes = reader.ReadInt32()) != 0)
                {
                    byte[] bytes = reader.ReadBytes(noOfIncomingBytes);
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    Packet packet = formatter.Deserialize(memoryStream) as Packet;
                    switch (packet.type)
                    {
                        case PacketType.NICKNAME:
                            string nickName = ((NickNamePacket)packet).nickName;
                            fromClient.SetNickName(nickName);
                            break;
                        case PacketType.CHATMESSAGE:
                            string message = ((ChatMessagePacket)packet).message;
                            Console.WriteLine("[" + fromClient.NickName + "] " + message);
                            foreach (Client c in clients)
                            {
                                c.SendText(fromClient, message);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
            finally
            {
                fromClient.Stop();
            }
        }
    }
}
