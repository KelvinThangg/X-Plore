namespace loginIndian.Forms
{
    partial class Help
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
            picCCCD = new PictureBox();
            btnUpload = new Button();
            shortexplainBox = new TextBox();
            GenBox = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            TelBox = new TextBox();
            EmailBox = new TextBox();
            UserBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnSend = new Button();
            label6 = new Label();
            backtologinBtn = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)picCCCD).BeginInit();
            SuspendLayout();
            // 
            // picCCCD
            // 
            picCCCD.BorderStyle = BorderStyle.FixedSingle;
            picCCCD.Location = new Point(16, 33);
            picCCCD.Margin = new Padding(2, 2, 2, 2);
            picCCCD.Name = "picCCCD";
            picCCCD.Size = new Size(270, 120);
            picCCCD.TabIndex = 0;
            picCCCD.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(16, 164);
            btnUpload.Margin = new Padding(2, 2, 2, 2);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(111, 23);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "Upload Picture";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += PictureBtn_Click;
            // 
            // shortexplainBox
            // 
            shortexplainBox.ForeColor = SystemColors.Info;
            shortexplainBox.Location = new Point(132, 174);
            shortexplainBox.Margin = new Padding(2, 2, 2, 2);
            shortexplainBox.Multiline = true;
            shortexplainBox.Name = "shortexplainBox";
            shortexplainBox.Size = new Size(409, 42);
            shortexplainBox.TabIndex = 3;
            shortexplainBox.Text = "Miêu tả ngắn gọn tình trạng của bạn";
            // 
            // GenBox
            // 
            GenBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenBox.FormattingEnabled = true;
            GenBox.Items.AddRange(new object[] { "Male", "Female", "Non-binary" });
            GenBox.Location = new Point(366, 66);
            GenBox.Margin = new Padding(2, 2, 2, 2);
            GenBox.Name = "GenBox";
            GenBox.Size = new Size(175, 23);
            GenBox.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(295, 135);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 7;
            label5.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(295, 102);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 8;
            label4.Text = "Gmail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 68);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 9;
            label3.Text = "Gender:";
            // 
            // TelBox
            // 
            TelBox.Location = new Point(366, 133);
            TelBox.Margin = new Padding(2, 2, 2, 2);
            TelBox.Name = "TelBox";
            TelBox.Size = new Size(175, 23);
            TelBox.TabIndex = 4;
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(366, 100);
            EmailBox.Margin = new Padding(2, 2, 2, 2);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(175, 23);
            EmailBox.TabIndex = 5;
            // 
            // UserBox
            // 
            UserBox.Location = new Point(366, 33);
            UserBox.Margin = new Padding(2, 2, 2, 2);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(175, 23);
            UserBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 49);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 33);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 9;
            label1.Text = "Username:";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(16, 191);
            btnSend.Margin = new Padding(2, 2, 2, 2);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(111, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += Sendbtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(132, 157);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(189, 15);
            label6.TabIndex = 7;
            label6.Text = "Short explain about your situation:";
            // 
            // backtologinBtn
            // 
            backtologinBtn.Location = new Point(16, 9);
            backtologinBtn.Margin = new Padding(2, 2, 2, 2);
            backtologinBtn.Name = "backtologinBtn";
            backtologinBtn.Size = new Size(105, 20);
            backtologinBtn.TabIndex = 12;
            backtologinBtn.Text = "Back to Login";
            backtologinBtn.UseVisualStyleBackColor = true;
            backtologinBtn.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(167, 12);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(110, 15);
            label7.TabIndex = 7;
            label7.Text = "Upload your CCCD:";
            // 
            // Help
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 227);
            Controls.Add(backtologinBtn);
            Controls.Add(GenBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TelBox);
            Controls.Add(EmailBox);
            Controls.Add(UserBox);
            Controls.Add(shortexplainBox);
            Controls.Add(btnSend);
            Controls.Add(btnUpload);
            Controls.Add(picCCCD);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Help";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Help";
            ((System.ComponentModel.ISupportInitialize)picCCCD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private TextBox shortexplainBox;
        private ComboBox GenBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox TelBox;
        private TextBox EmailBox;
        private TextBox UserBox;
        private Label label2;
        private Label label1;
        private Button btnSend;
        private Label label6;
        private PictureBox picCCCD;
        private Button btnUpload;
        private Button backtologinBtn;
        private Label label7;
    }
}