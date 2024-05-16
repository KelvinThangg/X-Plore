namespace loginIndian.Forms
{
    partial class RegisterForm
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
            UserBox = new TextBox();
            label1 = new Label();
            PassBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            EmailBox = new TextBox();
            label4 = new Label();
            TelBox = new TextBox();
            label5 = new Label();
            GenBox = new ComboBox();
            BackToLoginBtn = new Button();
            RegBtn = new Button();
            ReEnterPasswordBox = new TextBox();
            label6 = new Label();
            showPassBox = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label7 = new Label();
            displayNameBox = new TextBox();
            SuspendLayout();
            // 
            // UserBox
            // 
            UserBox.Location = new Point(153, 79);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(282, 31);
            UserBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 82);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // PassBox
            // 
            PassBox.Location = new Point(153, 131);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(282, 31);
            PassBox.TabIndex = 0;
            PassBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 134);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 230);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 1;
            label3.Text = "Gender:";
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(153, 280);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(282, 31);
            EmailBox.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 283);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 1;
            label4.Text = "Gmail:";
            // 
            // TelBox
            // 
            TelBox.Location = new Point(153, 328);
            TelBox.Name = "TelBox";
            TelBox.Size = new Size(282, 31);
            TelBox.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 331);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 1;
            label5.Text = "Phone:";
            // 
            // GenBox
            // 
            GenBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenBox.FormattingEnabled = true;
            GenBox.Items.AddRange(new object[] { "Male", "Female", "Non-binary" });
            GenBox.Location = new Point(153, 227);
            GenBox.Name = "GenBox";
            GenBox.Size = new Size(282, 33);
            GenBox.TabIndex = 2;
            // 
            // BackToLoginBtn
            // 
            BackToLoginBtn.FlatStyle = FlatStyle.Flat;
            BackToLoginBtn.Location = new Point(118, 387);
            BackToLoginBtn.Name = "BackToLoginBtn";
            BackToLoginBtn.Size = new Size(142, 67);
            BackToLoginBtn.TabIndex = 3;
            BackToLoginBtn.Text = "Back to Login";
            BackToLoginBtn.UseVisualStyleBackColor = true;
            BackToLoginBtn.Click += BackToLoginBtn_Click;
            // 
            // RegBtn
            // 
            RegBtn.FlatStyle = FlatStyle.Flat;
            RegBtn.Location = new Point(279, 387);
            RegBtn.Name = "RegBtn";
            RegBtn.Size = new Size(142, 67);
            RegBtn.TabIndex = 3;
            RegBtn.Text = "Register";
            RegBtn.UseVisualStyleBackColor = true;
            RegBtn.Click += RegBtn_Click;
            // 
            // ReEnterPasswordBox
            // 
            ReEnterPasswordBox.Location = new Point(210, 178);
            ReEnterPasswordBox.Name = "ReEnterPasswordBox";
            ReEnterPasswordBox.Size = new Size(225, 31);
            ReEnterPasswordBox.TabIndex = 0;
            ReEnterPasswordBox.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 181);
            label6.Name = "label6";
            label6.Size = new Size(162, 25);
            label6.TabIndex = 1;
            label6.Text = "Re-enter Password:";
            // 
            // showPassBox
            // 
            showPassBox.AutoSize = true;
            showPassBox.Location = new Point(452, 133);
            showPassBox.Name = "showPassBox";
            showPassBox.Size = new Size(82, 29);
            showPassBox.TabIndex = 4;
            showPassBox.Text = "Show";
            showPassBox.UseVisualStyleBackColor = true;
            showPassBox.CheckedChanged += showPassBox_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(452, 267);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Auto Fill (Tester)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(452, 307);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 7;
            button2.Text = "Auto Fill (Admin)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(452, 227);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 8;
            button3.Text = "Google";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 35);
            label7.Name = "label7";
            label7.Size = new Size(123, 25);
            label7.TabIndex = 9;
            label7.Text = "Display name:";
            // 
            // displayNameBox
            // 
            displayNameBox.Location = new Point(181, 29);
            displayNameBox.Name = "displayNameBox";
            displayNameBox.Size = new Size(254, 31);
            displayNameBox.TabIndex = 10;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 483);
            Controls.Add(displayNameBox);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(showPassBox);
            Controls.Add(RegBtn);
            Controls.Add(BackToLoginBtn);
            Controls.Add(GenBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TelBox);
            Controls.Add(EmailBox);
            Controls.Add(ReEnterPasswordBox);
            Controls.Add(PassBox);
            Controls.Add(UserBox);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserBox;
        private Label label1;
        private TextBox PassBox;
        private Label label2;
        private Label label3;
        private TextBox EmailBox;
        private Label label4;
        private TextBox TelBox;
        private Label label5;
        private ComboBox GenBox;
        private Button BackToLoginBtn;
        private Button RegBtn;
        private TextBox ReEnterPasswordBox;
        private Label label6;
        private CheckBox showPassBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label7;
        private TextBox displayNameBox;
    }
}