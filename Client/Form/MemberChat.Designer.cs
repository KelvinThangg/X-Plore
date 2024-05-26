namespace Client
{
    partial class MemberChat
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendTextButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.file = new System.Windows.Forms.Button();
            this.keyInput = new System.Windows.Forms.Button();
            this.keytextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 21);
            this.textBox1.TabIndex = 22;
            // 
            // sendTextButton
            // 
            this.sendTextButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendTextButton.Location = new System.Drawing.Point(381, 279);
            this.sendTextButton.Name = "sendTextButton";
            this.sendTextButton.Size = new System.Drawing.Size(75, 20);
            this.sendTextButton.TabIndex = 20;
            this.sendTextButton.Text = "Send";
            this.sendTextButton.UseVisualStyleBackColor = true;
            this.sendTextButton.Click += new System.EventHandler(this.sendTextButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(459, 238);
            this.listBox1.TabIndex = 24;
            // 
            // file
            // 
            this.file.Location = new System.Drawing.Point(310, 279);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(64, 20);
            this.file.TabIndex = 25;
            this.file.Text = "File";
            this.file.UseVisualStyleBackColor = true;
            this.file.Click += new System.EventHandler(this.file_Click);
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(382, 4);
            this.keyInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(87, 23);
            this.keyInput.TabIndex = 26;
            this.keyInput.Text = "Key";
            this.keyInput.UseVisualStyleBackColor = true;
            this.keyInput.Click += new System.EventHandler(this.keyInput_Click);
            // 
            // keytextBox
            // 
            this.keytextBox.Location = new System.Drawing.Point(257, 4);
            this.keytextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keytextBox.Name = "keytextBox";
            this.keytextBox.Size = new System.Drawing.Size(121, 20);
            this.keytextBox.TabIndex = 27;
            // 
            // MemberChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 309);
            this.Controls.Add(this.keytextBox);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.file);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sendTextButton);
            this.Name = "MemberChat";
            this.Text = "MemberChat";
            this.Load += new System.EventHandler(this.MemberChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendTextButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button file;
        private System.Windows.Forms.Button keyInput;
        private System.Windows.Forms.TextBox keytextBox;
    }
}