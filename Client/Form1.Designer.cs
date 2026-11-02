namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label3 = new Label();
            tbx_id = new TextBox();
            tbx_name = new TextBox();
            btn_login = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 22);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 58);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 1;
            label3.Text = "닉네임";
            // 
            // tbx_id
            // 
            tbx_id.Location = new Point(89, 22);
            tbx_id.Name = "tbx_id";
            tbx_id.Size = new Size(100, 23);
            tbx_id.TabIndex = 2;
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(89, 54);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(100, 23);
            tbx_name.TabIndex = 3;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(131, 116);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(58, 23);
            btn_login.TabIndex = 4;
            btn_login.Text = "로그인";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(206, 175);
            Controls.Add(btn_login);
            Controls.Add(tbx_name);
            Controls.Add(tbx_id);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbx_id;
        private TextBox tbx_name;
        private Button btn_login;
    }
}
