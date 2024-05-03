namespace loginIndian.Forms
{
    partial class ForgottenPassword
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
            registerMailBox = new TextBox();
            label2 = new Label();
            recoveryCodeBox = new TextBox();
            sendRecoveryBtn = new Button();
            confirmBtn = new Button();
            timvcode = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 112);
            label1.Name = "label1";
            label1.Size = new Size(199, 25);
            label1.TabIndex = 1;
            label1.Text = "Enter your register Mail:";
            // 
            // registerMailBox
            // 
            registerMailBox.Location = new Point(234, 112);
            registerMailBox.MaxLength = 100;
            registerMailBox.Name = "registerMailBox";
            registerMailBox.Size = new Size(263, 31);
            registerMailBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 149);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 1;
            label2.Text = "Enter recovery code:";
            // 
            // recoveryCodeBox
            // 
            recoveryCodeBox.Enabled = false;
            recoveryCodeBox.Location = new Point(234, 149);
            recoveryCodeBox.MaxLength = 4;
            recoveryCodeBox.Name = "recoveryCodeBox";
            recoveryCodeBox.Size = new Size(263, 31);
            recoveryCodeBox.TabIndex = 2;
            // 
            // sendRecoveryBtn
            // 
            sendRecoveryBtn.Location = new Point(234, 203);
            sendRecoveryBtn.Name = "sendRecoveryBtn";
            sendRecoveryBtn.Size = new Size(112, 34);
            sendRecoveryBtn.TabIndex = 3;
            sendRecoveryBtn.Text = "Send";
            sendRecoveryBtn.UseVisualStyleBackColor = true;
            sendRecoveryBtn.Click += button1_Click_1;
            // 
            // confirmBtn
            // 
            confirmBtn.Enabled = false;
            confirmBtn.Location = new Point(365, 203);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(112, 34);
            confirmBtn.TabIndex = 4;
            confirmBtn.Text = "Confirm";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += button2_Click;
            // 
            // ForgottenPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(confirmBtn);
            Controls.Add(sendRecoveryBtn);
            Controls.Add(recoveryCodeBox);
            Controls.Add(label2);
            Controls.Add(registerMailBox);
            Controls.Add(label1);
            Name = "ForgottenPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgottenPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox registerMailBox;
        private Label label2;
        private TextBox recoveryCodeBox;
        private Button sendRecoveryBtn;
        private Button confirmBtn;
        private System.Windows.Forms.Timer timvcode;
    }
}