using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LoginReqPacket : IPacket
    {
        public string Id { get; private set; }
        public string Nickname { get; private set; }

        //1.클라이언트 --> 서버 데이터를 보낼 때
        public LoginReqPacket(string id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        //2. 서버가 클라이언트의 패킷을 받아서 역질렬화
        public LoginReqPacket(byte[] buffer)
        {
            int offset = 2;
            short idSize = BitConverter.ToInt16(buffer, offset);
            offset += sizeof(short);
            Id = Encoding.UTF8.GetString(buffer, offset, idSize);
            offset += idSize;

            short nickSize = BitConverter.ToInt16(buffer, offset);
            offset += sizeof(short);
            Nickname = Encoding.UTF8.GetString(buffer, offset, nickSize);
        }

        public byte[] Serialize()
        {
            byte[] packetType = BitConverter.GetBytes((short)PacketType.LoginReq);
            byte[] id = Encoding.UTF8.GetBytes(Id);
            byte[] idSize = BitConverter.GetBytes((short)id.Length);
            byte[] nickName = Encoding.UTF8.GetBytes(Nickname);
            byte[] nickSize = BitConverter.GetBytes((short)nickName.Length);

            short dataSize = (short)(packetType.Length + id.Length + idSize.Length + nickName.Length + nickSize.Length);
            byte[] header = BitConverter.GetBytes(dataSize);

            byte[] buffer = new byte[2+dataSize];

            int offset = 0;
            Array.Copy(header, 0, buffer, offset, header.Length);
            offset += header.Length;
            Array.Copy(packetType, 0, buffer, offset, packetType.Length);
            offset += packetType.Length;
            Array.Copy(idSize, 0, buffer, offset, idSize.Length);
            offset += idSize.Length;
            Array.Copy(id, 0, buffer, offset, id.Length);
            offset += id.Length;
            Array.Copy(nickSize, 0, buffer, offset, nickSize.Length);
            offset += nickSize.Length;
            Array.Copy(nickName, 0, buffer, offset, nickName.Length);

            return buffer;
        }
    }
}
