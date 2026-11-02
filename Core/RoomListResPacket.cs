using System.Text;

namespace Core
{
    internal class RoomListResPacket : IPacket
    {
        public List<string> RoomNames { get; }

        //서버 -> 클라 방 목록을 전달
        public RoomListResPacket(ICollection<string> roomNames)
        {
            RoomNames = new List<string>(roomNames);
        }

        //클라이언트가 패킷을 받아서 역직렬화 --> 방 이름들을 추출
        public RoomListResPacket(byte[] buffer)
        {
            RoomNames = new List<string>();
            for (int offset = 2; offset < buffer.Length; offset++)
            {
                short roomNameSize = BitConverter.ToInt16(buffer, offset);
                offset += sizeof(short);
                RoomNames.Add(Encoding.UTF8.GetString(buffer, offset, roomNameSize));
            }
        }
        public byte[] Serialize()
        {

            byte[] packetType = BitConverter.GetBytes((short)PacketType.RoomListRes);
            short dataSize = (short)packetType.Length;

            List<byte[]> temp = new List<byte[]>();

            foreach (var item in RoomNames)
            {
                byte[] nameBuff = Encoding.UTF8.GetBytes(item);
                byte[] nameSize = BitConverter.GetBytes((short)nameBuff.Length);
                dataSize += (short)(nameBuff.Length + nameSize.Length);

                temp.Add(nameSize);
                temp.Add(nameBuff);
            }
            byte[] header = BitConverter.GetBytes(dataSize);
            byte[] buffer = new byte[2 + dataSize];

            int offset = 0;
            Array.Copy(header, 0, buffer, offset, header.Length);
            offset += header.Length;
            Array.Copy(packetType, 0, buffer, offset, packetType.Length);
            offset += packetType.Length;

            foreach (var item in temp)
            {
                Array.Copy(item, 0, buffer, offset, item.Length);
                offset += item.Length;
            }

            return buffer;
        }
    }
}
