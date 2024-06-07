namespace Lab5_LTM
{
    partial class Feedback
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
            richTextBox1 = new RichTextBox();
            textBox4 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(102, 160);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(529, 220);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(102, 101);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(529, 31);
            textBox4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 160);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 5;
            label5.Text = "Body:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 104);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 6;
            label4.Text = "Subject:";
            // 
            // button1
            // 
            button1.Location = new Point(663, 309);
            button1.Name = "button1";
            button1.Size = new Size(112, 71);
            button1.TabIndex = 4;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(663, 199);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 15;
            button2.Text = "Picture";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(663, 237);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 16;
            button3.Text = "Video";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(663, 274);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 17;
            button4.Text = "File";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(663, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(112, 142);
            listView1.TabIndex = 18;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(559, 14);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 19;
            label6.Text = "Images: 0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(559, 39);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 20;
            label7.Text = "Videos: 0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(560, 64);
            label8.Name = "label8";
            label8.Size = new Size(65, 25);
            label8.TabIndex = 21;
            label8.Text = "Files: 0";
            // 
            // button5
            // 
            button5.Location = new Point(663, 160);
            button5.Name = "button5";
            button5.Size = new Size(112, 33);
            button5.TabIndex = 22;
            button5.Text = "Remove";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 12);
            button6.Name = "button6";
            button6.Size = new Size(87, 43);
            button6.TabIndex = 23;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(12, 309);
            button7.Name = "button7";
            button7.Size = new Size(84, 68);
            button7.TabIndex = 24;
            button7.Text = "Auto Fill";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 26F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 28);
            label1.Name = "label1";
            label1.Size = new Size(295, 61);
            label1.TabIndex = 6;
            label1.Text = "FEEDBACK";
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 393);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(listView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(button1);
            Name = "Feedback";
            Text = "Feedback";
            FormClosed += Feedback_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TextBox textBox4;
        private Label label5;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListView listView1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label1;
    }
}