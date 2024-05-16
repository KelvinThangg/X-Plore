namespace loginIndian.Forms
{
    partial class LoginForm
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
            LoginBtn = new Button();
            BackToRegisterBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            PassBox = new TextBox();
            UserBox = new TextBox();
            showPassBox = new CheckBox();
            forgotPassBtn = new Button();
            checkBox1 = new CheckBox();
            captchaTextBox = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            RefreshBtn = new Button();
            lblCapsLockStatus = new Label();
            signInGGbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoginBtn
            // 
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.Location = new Point(248, 156);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(142, 67);
            LoginBtn.TabIndex = 14;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // BackToRegisterBtn
            // 
            BackToRegisterBtn.FlatStyle = FlatStyle.Flat;
            BackToRegisterBtn.Location = new Point(73, 156);
            BackToRegisterBtn.Name = "BackToRegisterBtn";
            BackToRegisterBtn.Size = new Size(156, 67);
            BackToRegisterBtn.TabIndex = 15;
            BackToRegisterBtn.Text = "Register";
            BackToRegisterBtn.UseVisualStyleBackColor = true;
            BackToRegisterBtn.Click += BackToRegisterBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 81);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 11;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 30);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 12;
            label1.Text = "Username:";
            // 
            // PassBox
            // 
            PassBox.Location = new Point(137, 78);
            PassBox.MaxLength = 30;
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(282, 31);
            PassBox.TabIndex = 6;
            PassBox.UseSystemPasswordChar = true;
            // 
            // UserBox
            // 
            UserBox.Location = new Point(137, 27);
            UserBox.MaxLength = 30;
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(282, 31);
            UserBox.TabIndex = 7;
            UserBox.Leave += UserBox_Leave;
            // 
            // showPassBox
            // 
            showPassBox.AutoSize = true;
            showPassBox.Location = new Point(435, 80);
            showPassBox.Name = "showPassBox";
            showPassBox.Size = new Size(82, 29);
            showPassBox.TabIndex = 16;
            showPassBox.Text = "Show";
            showPassBox.UseVisualStyleBackColor = true;
            showPassBox.CheckedChanged += showPassBox_CheckedChanged;
            // 
            // forgotPassBtn
            // 
            forgotPassBtn.Location = new Point(122, 279);
            forgotPassBtn.Name = "forgotPassBtn";
            forgotPassBtn.Size = new Size(224, 34);
            forgotPassBtn.TabIndex = 17;
            forgotPassBtn.Text = "Forgot your Password!";
            forgotPassBtn.UseVisualStyleBackColor = true;
            forgotPassBtn.Click += forgotPassBtn_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(157, 118);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(204, 29);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Remember Password";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // captchaTextBox
            // 
            captchaTextBox.Location = new Point(461, 279);
            captchaTextBox.MaxLength = 30;
            captchaTextBox.Name = "captchaTextBox";
            captchaTextBox.Size = new Size(200, 31);
            captchaTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(526, 251);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 20;
            label3.Text = "CAPTCHA";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(461, 191);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 50);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // RefreshBtn
            // 
            RefreshBtn.Location = new Point(494, 151);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new Size(146, 34);
            RefreshBtn.TabIndex = 22;
            RefreshBtn.Text = "Renew Captcha";
            RefreshBtn.UseVisualStyleBackColor = true;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // lblCapsLockStatus
            // 
            lblCapsLockStatus.AutoSize = true;
            lblCapsLockStatus.Location = new Point(435, 33);
            lblCapsLockStatus.Name = "lblCapsLockStatus";
            lblCapsLockStatus.Size = new Size(103, 25);
            lblCapsLockStatus.TabIndex = 23;
            lblCapsLockStatus.Text = "Thông báo:";
            lblCapsLockStatus.Visible = false;
            // 
            // signInGGbtn
            // 
            signInGGbtn.Location = new Point(122, 239);
            signInGGbtn.Name = "signInGGbtn";
            signInGGbtn.Size = new Size(225, 34);
            signInGGbtn.TabIndex = 24;
            signInGGbtn.Text = "Sign-In with Google";
            signInGGbtn.UseVisualStyleBackColor = true;
            signInGGbtn.Click += signInGGbtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 344);
            Controls.Add(signInGGbtn);
            Controls.Add(lblCapsLockStatus);
            Controls.Add(RefreshBtn);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(forgotPassBtn);
            Controls.Add(showPassBox);
            Controls.Add(LoginBtn);
            Controls.Add(BackToRegisterBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(captchaTextBox);
            Controls.Add(PassBox);
            Controls.Add(UserBox);
            KeyPreview = true;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            KeyDown += LoginForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginBtn;
        private Button BackToRegisterBtn;
        private Label label2;
        private Label label1;
        private TextBox PassBox;
        private TextBox UserBox;
        private CheckBox showPassBox;
        private Button forgotPassBtn;
        private CheckBox checkBox1;
        private TextBox captchaTextBox;
        private Label label3;
        private PictureBox pictureBox1;
        private Button RefreshBtn;
        private Label lblCapsLockStatus;
        private Button signInGGbtn;
    }
}