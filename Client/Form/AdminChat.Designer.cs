namespace Client
{
    partial class AdminChat
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.file = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.delChat = new System.Windows.Forms.Button();
            this.keytextBox = new System.Windows.Forms.TextBox();
            this.keyInput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(7, 335);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 21);
            this.textBox1.TabIndex = 12;
            // 
            // sendTextButton
            // 
            this.sendTextButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendTextButton.Location = new System.Drawing.Point(392, 336);
            this.sendTextButton.Name = "sendTextButton";
            this.sendTextButton.Size = new System.Drawing.Size(75, 22);
            this.sendTextButton.TabIndex = 10;
            this.sendTextButton.Text = "Send";
            this.sendTextButton.UseVisualStyleBackColor = true;
            this.sendTextButton.Click += new System.EventHandler(this.sendTextButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(473, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(243, 344);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // file
            // 
            this.file.Location = new System.Drawing.Point(311, 335);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(75, 23);
            this.file.TabIndex = 18;
            this.file.Text = "File";
            this.file.UseVisualStyleBackColor = true;
            this.file.Click += new System.EventHandler(this.file_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(380, 303);
            this.listBox1.TabIndex = 19;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // delChat
            // 
            this.delChat.Location = new System.Drawing.Point(392, 19);
            this.delChat.Margin = new System.Windows.Forms.Padding(2);
            this.delChat.Name = "delChat";
            this.delChat.Size = new System.Drawing.Size(75, 23);
            this.delChat.TabIndex = 20;
            this.delChat.Text = "Delete Chat";
            this.delChat.UseVisualStyleBackColor = true;
            this.delChat.Click += new System.EventHandler(this.delChat_Click);
            // 
            // keytextBox
            // 
            this.keytextBox.Location = new System.Drawing.Point(392, 60);
            this.keytextBox.Name = "keytextBox";
            this.keytextBox.Size = new System.Drawing.Size(75, 20);
            this.keytextBox.TabIndex = 21;
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(392, 96);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(75, 23);
            this.keyInput.TabIndex = 22;
            this.keyInput.Text = "key";
            this.keyInput.UseVisualStyleBackColor = true;
            this.keyInput.Click += new System.EventHandler(this.keyInput_Click);
            // 
            // AdminChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 370);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.keytextBox);
            this.Controls.Add(this.delChat);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.file);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sendTextButton);
            this.Name = "AdminChat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AdminChat_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendTextButton;
        private System.Windows.Forms.Button file;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delChat;
        private System.Windows.Forms.TextBox keytextBox;
        private System.Windows.Forms.Button keyInput;
    }
}

