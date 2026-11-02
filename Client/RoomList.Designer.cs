namespace Client
{
    partial class RoomList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbx_roomName = new TextBox();
            btn_createRoom = new Button();
            btn_refresh = new Button();
            btn_entrance = new Button();
            listBox_roomList = new ListBox();
            SuspendLayout();
            // 
            // tbx_roomName
            // 
            tbx_roomName.Location = new Point(201, 88);
            tbx_roomName.Name = "tbx_roomName";
            tbx_roomName.Size = new Size(134, 23);
            tbx_roomName.TabIndex = 9;
            // 
            // btn_createRoom
            // 
            btn_createRoom.Location = new Point(201, 141);
            btn_createRoom.Name = "btn_createRoom";
            btn_createRoom.Size = new Size(116, 47);
            btn_createRoom.TabIndex = 8;
            btn_createRoom.Text = "방 만들기";
            btn_createRoom.UseVisualStyleBackColor = true;
            btn_createRoom.Click += btn_createRoom_Click;
            // 
            // btn_refresh
            // 
            btn_refresh.Location = new Point(201, 12);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(116, 47);
            btn_refresh.TabIndex = 7;
            btn_refresh.Text = "새로고침";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // btn_entrance
            // 
            btn_entrance.Location = new Point(12, 376);
            btn_entrance.Name = "btn_entrance";
            btn_entrance.Size = new Size(172, 62);
            btn_entrance.TabIndex = 6;
            btn_entrance.Text = "입장하기";
            btn_entrance.UseVisualStyleBackColor = true;
            // 
            // listBox_roomList
            // 
            listBox_roomList.FormattingEnabled = true;
            listBox_roomList.Location = new Point(12, 12);
            listBox_roomList.Name = "listBox_roomList";
            listBox_roomList.Size = new Size(172, 349);
            listBox_roomList.TabIndex = 5;
            // 
            // RoomList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 450);
            Controls.Add(tbx_roomName);
            Controls.Add(btn_createRoom);
            Controls.Add(btn_refresh);
            Controls.Add(btn_entrance);
            Controls.Add(listBox_roomList);
            Name = "RoomList";
            Text = "방 목록";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_roomName;
        private Button btn_createRoom;
        private Button btn_refresh;
        private Button btn_entrance;
        private ListBox listBox_roomList;
    }
}