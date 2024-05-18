namespace loginIndian.Forms
{
    partial class MainMenu
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
            button1 = new Button();
            button2 = new Button();
            DisplayLbl = new Label();
            button3 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(154, 144);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(357, 44);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO MAIN";
            // 
            // button1
            // 
            button1.Location = new Point(391, 7);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 20);
            button1.TabIndex = 1;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(473, 7);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(78, 20);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DisplayLbl
            // 
            DisplayLbl.AutoSize = true;
            DisplayLbl.Location = new Point(125, 23);
            DisplayLbl.Margin = new Padding(2, 0, 2, 0);
            DisplayLbl.Name = "DisplayLbl";
            DisplayLbl.Size = new Size(38, 15);
            DisplayLbl.TabIndex = 3;
            DisplayLbl.Text = "label2";
            DisplayLbl.Click += DisplayLbl_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 12);
            button3.Name = "button3";
            button3.Size = new Size(94, 37);
            button3.TabIndex = 4;
            button3.Text = "Homescreen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(112, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(649, 340);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 386);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(DisplayLbl);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            FormClosing += MainMenu_FormClosing;
            FormClosed += MainMenu_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Label DisplayLbl;
        private Button button3;
        private Panel panel1;
    }
}