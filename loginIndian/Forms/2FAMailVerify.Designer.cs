namespace loginIndian.Forms
{
    partial class _2FAMailVerify
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
            label1.Location = new Point(30, 42);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Verification Code";
            // 
            // confirmBtn
            // 
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(207, 79);
            confirmBtn.Margin = new Padding(2);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(78, 20);
            confirmBtn.TabIndex = 1;
            confirmBtn.Text = "&Confirm";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click_1;
            // 
            // codeBox
            // 
            codeBox.Enabled = false;
            codeBox.Location = new Point(136, 40);
            codeBox.Margin = new Padding(2);
            codeBox.MaxLength = 4;
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(150, 23);
            codeBox.TabIndex = 2;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(125, 79);
            sendBtn.Margin = new Padding(2);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(78, 20);
            sendBtn.TabIndex = 3;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // NotifcationTxT
            // 
            NotifcationTxT.AutoSize = true;
            NotifcationTxT.Location = new Point(30, 12);
            NotifcationTxT.Margin = new Padding(2, 0, 2, 0);
            NotifcationTxT.Name = "NotifcationTxT";
            NotifcationTxT.Size = new Size(64, 15);
            NotifcationTxT.TabIndex = 4;
            NotifcationTxT.Text = "Thông báo";
            NotifcationTxT.TextAlign = ContentAlignment.TopCenter;
            // 
            // _2FAMailVerify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 127);
            Controls.Add(NotifcationTxT);
            Controls.Add(sendBtn);
            Controls.Add(codeBox);
            Controls.Add(confirmBtn);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "_2FAMailVerify";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmailVerify";
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