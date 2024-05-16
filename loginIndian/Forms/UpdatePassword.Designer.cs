namespace loginIndian.Forms
{
    partial class UpdatePassword
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
            UpdateBtn = new Button();
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            ReEnterPasswordBox = new TextBox();
            PassBox = new TextBox();
            UserBox = new TextBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // UpdateBtn
            // 
            UpdateBtn.FlatStyle = FlatStyle.Flat;
            UpdateBtn.Location = new Point(236, 194);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(142, 67);
            UpdateBtn.TabIndex = 10;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 137);
            label6.Name = "label6";
            label6.Size = new Size(162, 25);
            label6.TabIndex = 7;
            label6.Text = "Re-enter Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 93);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 8;
            label2.Text = "New Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 44);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 9;
            label1.Text = "Email:";
            // 
            // ReEnterPasswordBox
            // 
            ReEnterPasswordBox.Location = new Point(236, 137);
            ReEnterPasswordBox.MaxLength = 30;
            ReEnterPasswordBox.Name = "ReEnterPasswordBox";
            ReEnterPasswordBox.Size = new Size(225, 31);
            ReEnterPasswordBox.TabIndex = 4;
            ReEnterPasswordBox.UseSystemPasswordChar = true;
            // 
            // PassBox
            // 
            PassBox.Location = new Point(236, 90);
            PassBox.MaxLength = 30;
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(225, 31);
            PassBox.TabIndex = 5;
            PassBox.UseSystemPasswordChar = true;
            // 
            // UserBox
            // 
            UserBox.Location = new Point(236, 41);
            UserBox.MaxLength = 30;
            UserBox.Name = "UserBox";
            UserBox.ReadOnly = true;
            UserBox.Size = new Size(225, 31);
            UserBox.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(467, 93);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(82, 29);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Show";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // UpdatePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 293);
            Controls.Add(checkBox1);
            Controls.Add(UpdateBtn);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ReEnterPasswordBox);
            Controls.Add(PassBox);
            Controls.Add(UserBox);
            Name = "UpdatePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdatePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button UpdateBtn;
        private Label label6;
        private Label label2;
        private Label label1;
        private TextBox ReEnterPasswordBox;
        private TextBox PassBox;
        private TextBox UserBox;
        private CheckBox checkBox1;
    }
}