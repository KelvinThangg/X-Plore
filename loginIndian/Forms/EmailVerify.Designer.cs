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
            label1 = new Label();
            confirmBtn = new Button();
            codeBox = new TextBox();
            sendBtn = new Button();
            NotifcationTxT = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 126);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 0;
            label1.Text = "Verification Code";
            // 
            // confirmBtn
            // 
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(318, 188);
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
            codeBox.Location = new Point(217, 123);
            codeBox.MaxLength = 4;
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(213, 31);
            codeBox.TabIndex = 2;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(200, 188);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(112, 34);
            sendBtn.TabIndex = 3;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // NotifcationTxT
            // 
            NotifcationTxT.AutoSize = true;
            NotifcationTxT.Location = new Point(272, 20);
            NotifcationTxT.Name = "NotifcationTxT";
            NotifcationTxT.Size = new Size(99, 25);
            NotifcationTxT.TabIndex = 4;
            NotifcationTxT.Text = "Thông báo";
            NotifcationTxT.TextAlign = ContentAlignment.TopCenter;
            // 
            // EmailVerify
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NotifcationTxT);
            Controls.Add(sendBtn);
            Controls.Add(codeBox);
            Controls.Add(confirmBtn);
            Controls.Add(label1);
            Name = "EmailVerify";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmailVerify";
            FormClosed += EmailVerify_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button confirmBtn;
        private TextBox codeBox;
        private Button sendBtn;
        private Label NotifcationTxT;
    }
}