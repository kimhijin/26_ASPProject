namespace Client
{
    partial class ChatRoom
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
            listBox_msg = new ListBox();
            btn_send = new Button();
            listBox_user = new ListBox();
            tbx_msg = new TextBox();
            SuspendLayout();
            // 
            // listBox_msg
            // 
            listBox_msg.FormattingEnabled = true;
            listBox_msg.Location = new Point(12, 12);
            listBox_msg.Name = "listBox_msg";
            listBox_msg.Size = new Size(207, 379);
            listBox_msg.TabIndex = 0;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(228, 406);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(95, 32);
            btn_send.TabIndex = 1;
            btn_send.Text = "전송하기";
            btn_send.UseVisualStyleBackColor = true;
            // 
            // listBox_user
            // 
            listBox_user.FormattingEnabled = true;
            listBox_user.Location = new Point(231, 12);
            listBox_user.Name = "listBox_user";
            listBox_user.Size = new Size(125, 124);
            listBox_user.TabIndex = 2;
            // 
            // tbx_msg
            // 
            tbx_msg.Location = new Point(12, 412);
            tbx_msg.Name = "tbx_msg";
            tbx_msg.Size = new Size(207, 23);
            tbx_msg.TabIndex = 3;
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 450);
            Controls.Add(tbx_msg);
            Controls.Add(listBox_user);
            Controls.Add(btn_send);
            Controls.Add(listBox_msg);
            Name = "ChatRoom";
            Text = "ChatRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox_msg;
        private Button btn_send;
        private ListBox listBox_user;
        private TextBox tbx_msg;
    }
}