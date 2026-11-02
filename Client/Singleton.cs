using Core;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client
{
    //클라이언트의 네트워크 상태를 중앙에서 관리 NetworkManager
    //소켓 연결을 하나만 유지
    public class Singleton
    {
        public string Id { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public Socket Socket { get; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public event EventHandler<EventArgs> LoginResponsed;
        public event EventHandler<EventArgs> CreateRoomResponsed;

        private static Singleton? instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton() { 

        }

        public async Task ConnectAsync()
        {
            //Socket --> Connect
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20000);
            await Socket.ConnectAsync(endPoint);

            _ = Task.Run(() => RecvAssync(Socket));
        }

        public async void RecvAssync(object? sender)
        {
            Socket socket = (Socket)sender!;
            byte[] headerBuffer = new byte[2];

            while (true)
            {
                int n1 = await socket.ReceiveAsync(headerBuffer, SocketFlags.None);
                if (n1 < 1)
                {
                    Console.WriteLine("Client Disconnect");
                    socket.Close();
                    break;
                }
                else if (n1 == 1)
                {
                    await socket.ReceiveAsync(new ArraySegment<byte>(headerBuffer, 1, 1), SocketFlags.None);
                }

                short dataSize = BitConverter.ToInt16(headerBuffer);
                byte[] dataBuffer = new byte[dataSize];

                int totalRecv = 0;
                while (totalRecv < dataSize)
                {
                    int n2 = await socket.ReceiveAsync(new ArraySegment<byte>(dataBuffer, totalRecv, dataSize - totalRecv), SocketFlags.None);
                    totalRecv += n2;
                }

                PacketType packetType = (PacketType)BitConverter.ToInt16(dataBuffer);
                switch (packetType)
                {
                    case PacketType.LoginRes:
                        LoginResPacket packet = new LoginResPacket(dataBuffer);
                        LoginResponsed?.Invoke(packet, EventArgs.Empty);
                        break;
                    case PacketType.CreateRoomRes:
                        CreateRoomResPacket resPacket = new CreateRoomResPacket(dataBuffer);
                        CreateRoomResponsed?.Invoke(resPacket, EventArgs.Empty);
                        break;
                    case PacketType.RoomListReq:
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
