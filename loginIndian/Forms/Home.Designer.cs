namespace loginIndian.Forms
{
    partial class Home
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
            txtDisplayName = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            NhapPassPn = new Panel();
            label4 = new Label();
            textBox3 = new TextBox();
            panel2 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            ChangeDisplaynameBtn = new Button();
            button4 = new Button();
            label8 = new Label();
            NhapPassPn.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(98, 64);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(140, 23);
            txtDisplayName.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(98, 229);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(140, 23);
            textBox2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 66);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên hiển thị";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 237);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Mã khóa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 50);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 1;
            label3.Text = "Bảo vệ 2 lớp";
            label3.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(463, 103);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Bật/tắt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(556, 103);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 2;
            button2.Text = "Đổi mật khảu";
            button2.UseVisualStyleBackColor = true;
            // 
            // NhapPassPn
            // 
            NhapPassPn.Controls.Add(label4);
            NhapPassPn.Controls.Add(textBox3);
            NhapPassPn.Location = new Point(479, 151);
            NhapPassPn.Name = "NhapPassPn";
            NhapPassPn.Size = new Size(186, 182);
            NhapPassPn.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 13);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 1;
            label4.Text = "Nhập lại mk";
            label4.Click += label1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 31);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 23);
            textBox3.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox4);
            panel2.Location = new Point(465, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 186);
            panel2.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 121);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 1;
            label7.Text = "Nhập lại";
            label7.Click += label1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 64);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 1;
            label6.Text = "MK mới";
            label6.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 4);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 1;
            label5.Text = "MK cũ";
            label5.Click += label1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(17, 139);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(140, 23);
            textBox6.TabIndex = 0;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(17, 82);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(140, 23);
            textBox5.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(17, 22);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(140, 23);
            textBox4.TabIndex = 0;
            // 
            // ChangeDisplaynameBtn
            // 
            ChangeDisplaynameBtn.Location = new Point(80, 103);
            ChangeDisplaynameBtn.Name = "ChangeDisplaynameBtn";
            ChangeDisplaynameBtn.Size = new Size(75, 23);
            ChangeDisplaynameBtn.TabIndex = 2;
            ChangeDisplaynameBtn.Text = "Đổi";
            ChangeDisplaynameBtn.UseVisualStyleBackColor = true;
            ChangeDisplaynameBtn.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(80, 268);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 2;
            button4.Text = "Đổi";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 20);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 5;
            label8.Text = "Display name";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(panel2);
            Controls.Add(NhapPassPn);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(ChangeDisplaynameBtn);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(txtDisplayName);
            Name = "Home";
            Text = "Home";
            NhapPassPn.ResumeLayout(false);
            NhapPassPn.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplayName;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Panel NhapPassPn;
        private Label label4;
        private TextBox textBox3;
        private Panel panel2;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private Button ChangeDisplaynameBtn;
        private Button button4;
        private Label label8;
    }
}