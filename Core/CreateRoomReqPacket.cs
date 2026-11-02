using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CreateRoomReqPacket : IPacket
    {
        //방 이름
        public string RoomName { get; private set; }

        //클라 -> 서버
        public CreateRoomReqPacket(string roomName)
        {
            RoomName = roomName;
        }

        public CreateRoomReqPacket(byte[] buffer)
        {
            //헤더를 제외한 나머지 databuffer
            int offset = 2;
            short rNSize = BitConverter.ToInt16(buffer, offset);
            offset += sizeof(short);
            RoomName = Encoding.UTF8.GetString(buffer, offset, rNSize);
        }

        //직렬화
        public byte[] Serialize()
        {
            byte[] packetType = BitConverter.GetBytes((short)PacketType.CreateRoomReq);
            byte[] roomName = Encoding.UTF8.GetBytes(RoomName);
            byte[] rNSize = BitConverter.GetBytes((short)roomName.Length);

            short dataSize = (short)(packetType.Length + roomName.Length + rNSize.Length);
            byte[] header = BitConverter.GetBytes(dataSize);

            byte[] buffer = new byte[2 + dataSize];

            int offset = 0;
            Array.Copy(header, 0, buffer, offset, header.Length);
            offset += header.Length;
            Array.Copy(packetType, 0, buffer, offset, packetType.Length);
            offset += packetType.Length;
            Array.Copy(rNSize, 0, buffer, offset, rNSize.Length);
            offset += rNSize.Length;
            Array.Copy(roomName, 0, buffer, offset, roomName.Length);
            offset += roomName.Length;

            return buffer;
        }
    }
}
