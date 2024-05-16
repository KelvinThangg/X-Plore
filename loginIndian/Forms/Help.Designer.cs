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
            button2 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)picCCCD).BeginInit();
            SuspendLayout();
            // 
            // picCCCD
            // 
            picCCCD.BorderStyle = BorderStyle.FixedSingle;
            picCCCD.Location = new Point(23, 55);
            picCCCD.Name = "picCCCD";
            picCCCD.Size = new Size(385, 198);
            picCCCD.TabIndex = 0;
            picCCCD.TabStop = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(23, 273);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(159, 39);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "Upload Picture";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += PictureBtn_Click;
            // 
            // shortexplainBox
            // 
            shortexplainBox.Location = new Point(188, 290);
            shortexplainBox.Multiline = true;
            shortexplainBox.Name = "shortexplainBox";
            shortexplainBox.Size = new Size(583, 67);
            shortexplainBox.TabIndex = 3;
            // 
            // GenBox
            // 
            GenBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenBox.FormattingEnabled = true;
            GenBox.Items.AddRange(new object[] { "Male", "Female", "Non-binary" });
            GenBox.Location = new Point(523, 110);
            GenBox.Name = "GenBox";
            GenBox.Size = new Size(248, 33);
            GenBox.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 225);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 7;
            label5.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 170);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 8;
            label4.Text = "Gmail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(422, 114);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 9;
            label3.Text = "Gender:";
            // 
            // TelBox
            // 
            TelBox.Location = new Point(523, 222);
            TelBox.Name = "TelBox";
            TelBox.Size = new Size(248, 31);
            TelBox.TabIndex = 4;
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(523, 167);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(248, 31);
            EmailBox.TabIndex = 5;
            // 
            // UserBox
            // 
            UserBox.Location = new Point(523, 55);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(248, 31);
            UserBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(414, 82);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(422, 55);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 9;
            label1.Text = "Username:";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(23, 318);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(159, 39);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += Sendbtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(188, 262);
            label6.Name = "label6";
            label6.Size = new Size(285, 25);
            label6.TabIndex = 7;
            label6.Text = "Short explain about your situation:";
            // 
            // button2
            // 
            button2.Location = new Point(23, 15);
            button2.Name = "button2";
            button2.Size = new Size(150, 34);
            button2.TabIndex = 12;
            button2.Text = "Back to Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(238, 20);
            label7.Name = "label7";
            label7.Size = new Size(166, 25);
            label7.TabIndex = 7;
            label7.Text = "Upload your CCCD:";
            // 
            // Help
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 379);
            Controls.Add(button2);
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
        private Button button2;
        private Label label7;
    }
}