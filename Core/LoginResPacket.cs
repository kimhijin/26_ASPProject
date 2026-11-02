
namespace Core
{
    public class LoginResPacket : IPacket
    {
        //헤더 + 패킷타입 + 응답코
        public int Code { get; private set; }
        
        //서버 -> 클라이언트
        public LoginResPacket(int code)
        {
            Code = code;
        }

        public LoginResPacket(byte[] buffer)
        {
            Code = BitConverter.ToInt16(buffer, 2);
        }

        public byte[] Serialize()
        {
            byte[] packetType = BitConverter.GetBytes((short)PacketType.LoginRes);
            byte[] code = BitConverter.GetBytes(Code);

            short dataSize = (short)(packetType.Length + code.Length);
            byte[] header = BitConverter.GetBytes(dataSize);

            byte[] buffer = new byte[2 + dataSize];

            int offset = 0;

            Array.Copy(header, 0, buffer, offset, header.Length);
            offset += header.Length;
            Array.Copy(packetType, 0, buffer, offset, packetType.Length);
            offset += packetType.Length;
            Array.Copy(code, 0, buffer, offset, code.Length);

            return buffer;
        }
    }
}
