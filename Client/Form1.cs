using Core;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Singleton.Instance.LoginResponsed += LoginResponsed;
            FormClosing += (s, e) =>
            {
                Singleton.Instance.LoginResponsed -= LoginResponsed;
            };
        }
        private async void btn_login_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbx_id.Text) || string.IsNullOrEmpty(tbx_name.Text))
            {
                MessageBox.Show("입력하세요");
                return;
            }

            await Singleton.Instance.ConnectAsync();

            //LoginReqPacket 생성
            LoginReqPacket packet = new LoginReqPacket(tbx_id.Text, tbx_name.Text);
            //send
      

            await Singleton.Instance.Socket.SendAsync(packet.Serialize(), SocketFlags.None);


            //윈폼 비동기 처리
            IAsyncResult ar = null;
            ar = BeginInvoke(() =>
            {
                RoomList roomList = new RoomList();
                roomList.ShowDialog();
                EndInvoke(ar);
            });

            //로그인 응답을 받으면 RoomList폼을 띄어야함
        }

        private void LoginResponsed(object? sender, EventArgs e)
        {
            LoginResPacket packet = (LoginResPacket)sender;
            if(packet.Code == 200)
            {
                Singleton.Instance.Id = tbx_id.Text;
                Singleton.Instance.Nickname = tbx_name.Text;
            }
            else
            {
                MessageBox.Show("로그인 거부");
                //Both, Send, Recv
                Singleton.Instance.Socket.Shutdown(System.Net.Sockets.SocketShutdown.Send);
            }
        }
    }
}
