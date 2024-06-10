namespace X_Plore.Chat
{
    partial class CallForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LeaveButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.StartButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LeaveButton
            // 
            this.LeaveButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.LeaveButton.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.LeaveButton.Image = global::X_Plore.Properties.Resources.accept_call_and_decline_phone_icons_red_and_green_yes_no_buttons_icon_illustration_answer_and_decline_phone_call_buttons_vector_removebg_preview__1_;
            this.LeaveButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.LeaveButton.ImageRotate = 0F;
            this.LeaveButton.ImageSize = new System.Drawing.Size(50, 50);
            this.LeaveButton.Location = new System.Drawing.Point(415, 326);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.LeaveButton.Size = new System.Drawing.Size(64, 54);
            this.LeaveButton.TabIndex = 2;
           
            // 
            // StartButton
            // 
            this.StartButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.StartButton.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.StartButton.Image = global::X_Plore.Properties.Resources.accept_call_and_decline_phone_icons_red_and_green_yes_no_buttons_icon_illustration_answer_and_decline_phone_call_buttons_vector_removebg_preview1;
            this.StartButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.StartButton.ImageRotate = 0F;
            this.StartButton.ImageSize = new System.Drawing.Size(50, 50);
            this.StartButton.Location = new System.Drawing.Point(274, 326);
            this.StartButton.Name = "StartButton";
            this.StartButton.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.StartButton.Size = new System.Drawing.Size(64, 54);
            this.StartButton.TabIndex = 2;
          
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(321, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // CallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.StartButton);
            this.Name = "CallForm";
            this.Text = "CallForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2ImageButton StartButton;
        private Guna.UI2.WinForms.Guna2ImageButton LeaveButton;
        private System.Windows.Forms.ListView listView1;
    }
}