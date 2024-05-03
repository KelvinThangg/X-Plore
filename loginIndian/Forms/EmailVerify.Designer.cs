namespace loginIndian.Forms
{
    partial class EmailVerify
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            confirmBtn = new Button();
            codeBox = new TextBox();
            timvcode = new System.Windows.Forms.Timer(components);
            txtGmail = new Label();
            mailBox = new TextBox();
            sendBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 108);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 0;
            label1.Text = "Verification Code";
            // 
            // confirmBtn
            // 
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(317, 189);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(112, 34);
            confirmBtn.TabIndex = 1;
            confirmBtn.Text = "&Confirm";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // codeBox
            // 
            codeBox.Enabled = false;
            codeBox.Location = new Point(216, 105);
            codeBox.MaxLength = 4;
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(213, 31);
            codeBox.TabIndex = 2;
            // 
            // timvcode
            // 
            timvcode.Enabled = true;
            timvcode.Interval = 1000;
            timvcode.Tick += timvcode_Tick;
            // 
            // txtGmail
            // 
            txtGmail.AutoSize = true;
            txtGmail.Location = new Point(153, 41);
            txtGmail.Name = "txtGmail";
            txtGmail.Size = new Size(57, 25);
            txtGmail.TabIndex = 0;
            txtGmail.Text = "Gmail";
            // 
            // mailBox
            // 
            mailBox.Location = new Point(216, 38);
            mailBox.MaxLength = 100;
            mailBox.Name = "mailBox";
            mailBox.Size = new Size(213, 31);
            mailBox.TabIndex = 2;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(199, 189);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(112, 34);
            sendBtn.TabIndex = 3;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // EmailVerify
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendBtn);
            Controls.Add(mailBox);
            Controls.Add(codeBox);
            Controls.Add(txtGmail);
            Controls.Add(confirmBtn);
            Controls.Add(label1);
            Name = "EmailVerify";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmailVerify";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button confirmBtn;
        private TextBox codeBox;
        private System.Windows.Forms.Timer timvcode;
        private Label txtGmail;
        private TextBox mailBox;
        private Button sendBtn;
    }
}