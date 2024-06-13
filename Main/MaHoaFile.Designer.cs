namespace X_Plore.Main
{
    partial class MaHoaFile
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
            this.components = new System.ComponentModel.Container();
            this.textBoxKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDuongDan = new System.Windows.Forms.Label();
            this.flowLayoutFileList = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSelectFile = new Guna.UI2.WinForms.Guna2Button();
            this.buttonEncrypt = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDecrypt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.textBoxFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // textBoxKey
            // 
            this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.textBoxKey.BorderRadius = 10;
            this.textBoxKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxKey.DefaultText = "";
            this.textBoxKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(60)))));
            this.textBoxKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxKey.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxKey.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxKey.Location = new System.Drawing.Point(551, 400);
            this.textBoxKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxKey.MaxLength = 20;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.PasswordChar = '\0';
            this.textBoxKey.PlaceholderText = "";
            this.textBoxKey.SelectedText = "";
            this.textBoxKey.Size = new System.Drawing.Size(133, 30);
            this.textBoxKey.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(475, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 61;
            this.label1.Text = "Mã khóa";
            // 
            // lbDuongDan
            // 
            this.lbDuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDuongDan.AutoSize = true;
            this.lbDuongDan.ForeColor = System.Drawing.Color.Silver;
            this.lbDuongDan.Location = new System.Drawing.Point(115, 411);
            this.lbDuongDan.Name = "lbDuongDan";
            this.lbDuongDan.Size = new System.Drawing.Size(16, 13);
            this.lbDuongDan.TabIndex = 62;
            this.lbDuongDan.Text = "...";
            // 
            // flowLayoutFileList
            // 
            this.flowLayoutFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutFileList.AutoScroll = true;
            this.flowLayoutFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(60)))));
            this.flowLayoutFileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.flowLayoutFileList.Location = new System.Drawing.Point(12, 90);
            this.flowLayoutFileList.Name = "flowLayoutFileList";
            this.flowLayoutFileList.Size = new System.Drawing.Size(776, 293);
            this.flowLayoutFileList.TabIndex = 60;
            this.flowLayoutFileList.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutFileList_Paint);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectFile.Animated = true;
            this.buttonSelectFile.BackColor = System.Drawing.Color.Transparent;
            this.buttonSelectFile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.buttonSelectFile.BorderRadius = 10;
            this.buttonSelectFile.BorderThickness = 2;
            this.buttonSelectFile.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.buttonSelectFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(60)))));
            this.buttonSelectFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSelectFile.ForeColor = System.Drawing.Color.White;
            this.buttonSelectFile.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSelectFile.Location = new System.Drawing.Point(12, 395);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(96, 39);
            this.buttonSelectFile.TabIndex = 57;
            this.buttonSelectFile.Text = "Chọn file";
            this.buttonSelectFile.UseTransparentBackground = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEncrypt.Animated = true;
            this.buttonEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.buttonEncrypt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.buttonEncrypt.BorderRadius = 10;
            this.buttonEncrypt.BorderThickness = 2;
            this.buttonEncrypt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(60)))));
            this.buttonEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEncrypt.ForeColor = System.Drawing.Color.White;
            this.buttonEncrypt.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonEncrypt.Location = new System.Drawing.Point(690, 395);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(98, 39);
            this.buttonEncrypt.TabIndex = 58;
            this.buttonEncrypt.Text = "Mã hóa file";
            this.buttonEncrypt.UseTransparentBackground = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 23);
            this.label5.TabIndex = 56;
            this.label5.Text = "Danh sách file của bạn";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.BackColor = System.Drawing.Color.Transparent;
            this.buttonDecrypt.BorderRadius = 10;
            this.buttonDecrypt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonDecrypt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonDecrypt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonDecrypt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonDecrypt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonDecrypt.FillColor = System.Drawing.Color.Purple;
            this.buttonDecrypt.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(20)))), ((int)(((byte)(137)))));
            this.buttonDecrypt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonDecrypt.ForeColor = System.Drawing.Color.White;
            this.buttonDecrypt.Location = new System.Drawing.Point(665, 42);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(123, 35);
            this.buttonDecrypt.TabIndex = 64;
            this.buttonDecrypt.Text = "Giải mã file";
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.textBoxFilePath.BorderRadius = 10;
            this.textBoxFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxFilePath.DefaultText = "";
            this.textBoxFilePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxFilePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxFilePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxFilePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxFilePath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(8)))), ((int)(((byte)(60)))));
            this.textBoxFilePath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxFilePath.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxFilePath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxFilePath.Location = new System.Drawing.Point(152, 400);
            this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFilePath.MaxLength = 20;
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.PasswordChar = '\0';
            this.textBoxFilePath.PlaceholderText = "";
            this.textBoxFilePath.SelectedText = "";
            this.textBoxFilePath.Size = new System.Drawing.Size(259, 30);
            this.textBoxFilePath.TabIndex = 65;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(712, 8);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(35, 28);
            this.guna2ControlBox2.TabIndex = 67;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(753, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 28);
            this.guna2ControlBox1.TabIndex = 66;
            // 
            // MaHoaFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDuongDan);
            this.Controls.Add(this.flowLayoutFileList);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaHoaFile";
            this.Text = "MaHoaFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textBoxKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDuongDan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutFileList;
        private Guna.UI2.WinForms.Guna2Button buttonSelectFile;
        private Guna.UI2.WinForms.Guna2Button buttonEncrypt;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2GradientButton buttonDecrypt;
        private Guna.UI2.WinForms.Guna2TextBox textBoxFilePath;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}