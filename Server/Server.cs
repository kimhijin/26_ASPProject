
using Core;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class Server
    {
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //딕셔너리(Room)
        //Room
        public ConcurrentDictionary<string, Room> Rooms { get; } = new();
        public Server(string ip, int port, int backlog)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(backlog);
        }

        public async Task StartAsync()
        {
            while (true)
            {
                try
                {
                    Socket clientSocket = await serverSocket.AcceptAsync();
                    Console.WriteLine(clientSocket.RemoteEndPoint);
                    //send, recv
                    _ = Task.Run(() => RunAsync(clientSocket));
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private async Task RunAsync(object? sender)
        {
            Socket clientSocket = (Socket)sender!;
            byte[] headerBuffer = new byte[2];

            string id = "";
            string nickName = "";
            string roomName = "";
            while (true)
            {
                int n1 = await clientSocket.ReceiveAsync(headerBuffer, SocketFlags.None);
                if (n1 < 1)
                {
                    Console.WriteLine("Client Disconnect");
                    clientSocket.Close();
                    break;
                }
                else if (n1 == 1)
                {
                    await clientSocket.ReceiveAsync(new ArraySegment<byte>(headerBuffer, 1, 1), SocketFlags.None);
                }

                short dataSize = BitConverter.ToInt16(headerBuffer);
                byte[] dataBuffer = new byte[dataSize];

                int totalRecv = 0;
                while (totalRecv < dataSize)
                {
                    int n2 = await clientSocket.ReceiveAsync(new ArraySegment<byte>(dataBuffer, totalRecv, dataSize - totalRecv), SocketFlags.None);
                    totalRecv += n2;
                }

                PacketType packetType = (PacketType)BitConverter.ToInt16(dataBuffer);
                switch (packetType)
                {
                    case PacketType.LoginReq:
                        LoginReqPacket reqPacket = new LoginReqPacket(dataBuffer);
                        Console.WriteLine($"ID: {reqPacket.Id} NickName: {reqPacket.Nickname}");

                        LoginResPacket resPacket = new LoginResPacket(200);
                        await clientSocket.SendAsync(resPacket.Serialize(), SocketFlags.None);
                        break;
                    case PacketType.CreateRoomReq:
                        CreateRoomReqPacket packet = new CreateRoomReqPacket(dataBuffer);
                        Room room = new Room();
                        if (Rooms.TryAdd(packet.RoomName, room))
                        {
                            roomName = packet.RoomName;
                            //방을 만든 사람을 추가
                            room.Users.TryAdd(id, nickName);
                            Console.WriteLine($"Created Room: {roomName}");

                            //응답
                            CreateRoomResPacket roomResPacket = new CreateRoomResPacket(200);
                            await clientSocket.SendAsync(roomResPacket.Serialize(), SocketFlags.None);
                        }
                        else
                            Console.WriteLine("Room Create Failed");
                        break;
                    case PacketType.CreateRoomRes:
                        break;
                    case PacketType.RoomListReq:
                        //키(방 이름)를 가져올 수 있다
                        RoomListResPacket roomListPacket = new RoomListResPacket(Rooms.Keys);
                        await clientSocket.SendAsync(roomListPacket.Serialize(), SocketFlags.None);
                        break;
                    case PacketType.RoomListRes:
                        break;
                    case PacketType.EnterRoomReq:
                        break;
                    case PacketType.EnterRoomRes:
                        break;
                    case PacketType.UserEnter:
                        break;
                    case PacketType.UserLeft:
                        break;
                    case PacketType.Chat:
                        break;
                }
            }
        }
    }
}
