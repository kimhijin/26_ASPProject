using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RoomListReqPacket : IPacket
    {
        public byte[] Serialize()
        {
            byte[] packetType = BitConverter.GetBytes((short)PacketType.RoomListReq);

            short dataSize = (short)(packetType.Length);
            byte[] header = BitConverter.GetBytes(dataSize);

            byte[] buffer = new byte[2 + dataSize];

            int offset = 0;
            Array.Copy(header, 0, buffer, offset, header.Length);
            offset += header.Length;
            Array.Copy(packetType, 0, buffer, offset, packetType.Length);

            return buffer;
        }
    }
}
