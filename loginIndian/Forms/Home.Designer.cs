namespace loginIndian.Forms
{
    partial class Home
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
            txtDisplayName = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            NhapPassPn = new Panel();
            label4 = new Label();
            textBox3 = new TextBox();
            panelDoipass = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            button3 = new Button();
            ReEnterPasswordBox = new TextBox();
            PassBox = new TextBox();
            OldpassBox = new TextBox();
            ChangeDisplaynameBtn = new Button();
            label8 = new Label();
            button4 = new Button();
            NhapPassPn.SuspendLayout();
            panelDoipass.SuspendLayout();
            SuspendLayout();
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(98, 64);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(140, 23);
            txtDisplayName.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(98, 229);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(140, 23);
            textBox2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 66);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên hiển thị";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 237);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Mã khóa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 50);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 1;
            label3.Text = "Bảo vệ 2 lớp";
            label3.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(463, 103);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Bật/tắt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(556, 103);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 2;
            button2.Text = "Đổi mật khảu";
            button2.UseVisualStyleBackColor = true;
            // 
            // NhapPassPn
            // 
            NhapPassPn.Controls.Add(label4);
            NhapPassPn.Controls.Add(textBox3);
            NhapPassPn.Location = new Point(479, 145);
            NhapPassPn.Name = "NhapPassPn";
            NhapPassPn.Size = new Size(186, 182);
            NhapPassPn.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 13);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 1;
            label4.Text = "Nhập lại mk";
            label4.Click += label1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 31);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 23);
            textBox3.TabIndex = 0;
            // 
            // panelDoipass
            // 
            panelDoipass.Controls.Add(label7);
            panelDoipass.Controls.Add(label6);
            panelDoipass.Controls.Add(label5);
            panelDoipass.Controls.Add(button3);
            panelDoipass.Controls.Add(ReEnterPasswordBox);
            panelDoipass.Controls.Add(PassBox);
            panelDoipass.Controls.Add(OldpassBox);
            panelDoipass.Location = new Point(479, 145);
            panelDoipass.Name = "panelDoipass";
            panelDoipass.Size = new Size(200, 216);
            panelDoipass.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 121);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 1;
            label7.Text = "Nhập lại";
            label7.Click += label1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 64);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 1;
            label6.Text = "MK mới";
            label6.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 4);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 1;
            label5.Text = "MK cũ";
            label5.Click += label1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(31, 182);
            button3.Name = "button3";
            button3.Size = new Size(126, 23);
            button3.TabIndex = 2;
            button3.Text = "Đổi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ReEnterPasswordBox
            // 
            ReEnterPasswordBox.Location = new Point(17, 139);
            ReEnterPasswordBox.Name = "ReEnterPasswordBox";
            ReEnterPasswordBox.Size = new Size(140, 23);
            ReEnterPasswordBox.TabIndex = 0;
            // 
            // PassBox
            // 
            PassBox.Location = new Point(17, 82);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(140, 23);
            PassBox.TabIndex = 0;
            // 
            // OldpassBox
            // 
            OldpassBox.Location = new Point(17, 22);
            OldpassBox.Name = "OldpassBox";
            OldpassBox.Size = new Size(140, 23);
            OldpassBox.TabIndex = 0;
            // 
            // ChangeDisplaynameBtn
            // 
            ChangeDisplaynameBtn.Location = new Point(80, 103);
            ChangeDisplaynameBtn.Name = "ChangeDisplaynameBtn";
            ChangeDisplaynameBtn.Size = new Size(75, 23);
            ChangeDisplaynameBtn.TabIndex = 2;
            ChangeDisplaynameBtn.Text = "Đổi";
            ChangeDisplaynameBtn.UseVisualStyleBackColor = true;
            ChangeDisplaynameBtn.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 20);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 5;
            label8.Text = "Display name";
            // 
            // button4
            // 
            button4.Location = new Point(98, 262);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Đổi";
            button4.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(label8);
            Controls.Add(panelDoipass);
            Controls.Add(NhapPassPn);
            Controls.Add(button2);
            Controls.Add(ChangeDisplaynameBtn);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(txtDisplayName);
            Name = "Home";
            Text = "Home";
            NhapPassPn.ResumeLayout(false);
            NhapPassPn.PerformLayout();
            panelDoipass.ResumeLayout(false);
            panelDoipass.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplayName;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Panel NhapPassPn;
        private Label label4;
        private TextBox textBox3;
        private Panel panelDoipass;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox ReEnterPasswordBox;
        private TextBox PassBox;
        private TextBox OldpassBox;
        private Button ChangeDisplaynameBtn;
        private Label label8;
        private Button button3;
        private Button button4;
    }
}