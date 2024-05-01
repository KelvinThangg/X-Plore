﻿namespace loginIndian.Forms
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
            SuspendLayout();
            // 
            // LoginBtn
            // 
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.Location = new Point(407, 198);
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
            BackToRegisterBtn.Location = new Point(213, 198);
            BackToRegisterBtn.Name = "BackToRegisterBtn";
            BackToRegisterBtn.Size = new Size(175, 67);
            BackToRegisterBtn.TabIndex = 15;
            BackToRegisterBtn.Text = "Back to Register";
            BackToRegisterBtn.UseVisualStyleBackColor = true;
            BackToRegisterBtn.Click += BackToRegisterBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 132);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 11;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 81);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 12;
            label1.Text = "Username:";
            // 
            // PassBox
            // 
            PassBox.Location = new Point(296, 129);
            PassBox.Name = "PassBox";
            PassBox.PasswordChar = '*';
            PassBox.Size = new Size(282, 31);
            PassBox.TabIndex = 6;
            PassBox.UseSystemPasswordChar = true;
            // 
            // UserBox
            // 
            UserBox.Location = new Point(296, 78);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(282, 31);
            UserBox.TabIndex = 7;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginBtn);
            Controls.Add(BackToRegisterBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PassBox);
            Controls.Add(UserBox);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
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
    }
}