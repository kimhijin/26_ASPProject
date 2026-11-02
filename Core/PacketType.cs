using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum PacketType
    {
        LoginReq,
        LoginRes,

        CreateRoomReq,
        CreateRoomRes,

        RoomListReq,
        RoomListRes,

        EnterRoomReq,
        EnterRoomRes,
        UserEnter,
        UserLeft,

        Chat
    }
}
