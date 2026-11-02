using Core;

namespace Client
{
    public partial class RoomList : Form
    {
        public RoomList()
        {
            InitializeComponent();
            Singleton.Instance.CreateRoomResponsed += CreateRoomResponsd;
            Singleton.Instance.RoomListResponsed += RoomListResponsed;

            FormClosing += (s, e) =>
            {
                Singleton.Instance.CreateRoomResponsed -= CreateRoomResponsd;
                Singleton.Instance.RoomListResponsed -= RoomListResponsed;
            };
            //활성화 때마다(처음 보여질때, 다른 창 보고 있다가 이창으로 돌아왔을 때
            Activated += (s, e) =>
            {
                btn_refresh_Click(null, EventArgs.Empty);
            };
        }

        private void RoomListResponsed(object? sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RoomListResponsed(sender, e)));
                return;
            }

            RoomListResPacket packet = (RoomListResPacket)sender;
            foreach (var item in packet.RoomNames)
            {
                listBox_roomList.Items.Add(item);
            }
        }

        private async void btn_createRoom_Click(object sender, EventArgs e)
        {
            string roomName = tbx_roomName.Text;
            if (string.IsNullOrEmpty(roomName))
            {
                MessageBox.Show("방 이름을 입력하세요");
                return;
            }
            //패킷 생성 --> 서버에 전송
            CreateRoomReqPacket packet = new CreateRoomReqPacket(roomName);
            await Singleton.Instance.Socket.SendAsync(packet.Serialize(), System.Net.Sockets.SocketFlags.None);
        }
        private void CreateRoomResponsd(object? sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => CreateRoomResponsd(sender, e)));
                return;
            }
            CreateRoomResPacket packet = (CreateRoomResPacket)sender;
            if (packet.Code == 200)
            {
                //방 생성 성공
                IAsyncResult ar = null;
                ar = BeginInvoke(() =>
                {
                    listBox_roomList.Items.Add(tbx_roomName.Text);
                    ChatRoom chatRoom = new ChatRoom();
                    chatRoom.Show();
                    EndInvoke(ar);
                });

            }
            else
            {

            }
        }

        private async void btn_refresh_Click(object sender, EventArgs e)
        {
            listBox_roomList.Items.Clear();
            RoomListReqPacket packet = new RoomListReqPacket();
            await Singleton.Instance.Socket.SendAsync(packet.Serialize(), System.Net.Sockets.SocketFlags.None);
        }
    }
}
