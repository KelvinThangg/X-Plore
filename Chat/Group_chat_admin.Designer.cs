namespace X_Plore.Chat
{
    partial class Group_chat_admin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Group_chat_admin));
            this.pnLichSu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHideOrShowPass = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lbStt = new System.Windows.Forms.Label();
            this.tbNoiDung = new System.Windows.Forms.TextBox();
            this.btnMinisize = new System.Windows.Forms.Button();
            this.btnMaxsize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DataGridViewsMember = new System.Windows.Forms.DataGridView();
            this.identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbMatKhauGr = new System.Windows.Forms.Label();
            this.lbTenNhom = new System.Windows.Forms.Label();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GrPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageRadioButton1 = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            this.guna2ImageRadioButton2 = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            this.pnLichSu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewsMember)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLichSu
            // 
            this.pnLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLichSu.AutoScroll = true;
            this.pnLichSu.BackColor = System.Drawing.Color.Black;
            this.pnLichSu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLichSu.Controls.Add(this.panel1);
            this.pnLichSu.Location = new System.Drawing.Point(7, 68);
            this.pnLichSu.Name = "pnLichSu";
            this.pnLichSu.Size = new System.Drawing.Size(541, 308);
            this.pnLichSu.TabIndex = 59;
            this.pnLichSu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnLichSu_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.guna2ImageButton2);
            this.panel1.Controls.Add(this.guna2ImageButton1);
            this.panel1.Controls.Add(this.guna2ImageRadioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 46);
            this.panel1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Shopee Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 60;
            this.label1.Text = "LTMCB";
            this.label1.Click += new System.EventHandler(this.lbMatKhauGr_Click);
            // 
            // cbHideOrShowPass
            // 
            this.cbHideOrShowPass.Animated = true;
            this.cbHideOrShowPass.Checked = true;
            this.cbHideOrShowPass.CheckedState.BorderColor = System.Drawing.Color.White;
            this.cbHideOrShowPass.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbHideOrShowPass.CheckedState.InnerBorderColor = System.Drawing.Color.Navy;
            this.cbHideOrShowPass.CheckedState.InnerColor = System.Drawing.Color.White;
            this.cbHideOrShowPass.Location = new System.Drawing.Point(250, 34);
            this.cbHideOrShowPass.Name = "cbHideOrShowPass";
            this.cbHideOrShowPass.Size = new System.Drawing.Size(35, 20);
            this.cbHideOrShowPass.TabIndex = 68;
            this.cbHideOrShowPass.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.cbHideOrShowPass.UncheckedState.BorderThickness = 2;
            this.cbHideOrShowPass.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.cbHideOrShowPass.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.cbHideOrShowPass.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.cbHideOrShowPass.CheckedChanged += new System.EventHandler(this.cbHideOrShowPass_CheckedChanged);
            // 
            // lbStt
            // 
            this.lbStt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStt.AutoSize = true;
            this.lbStt.CausesValidation = false;
            this.lbStt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStt.ForeColor = System.Drawing.Color.Gray;
            this.lbStt.Location = new System.Drawing.Point(-33, 457);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(110, 18);
            this.lbStt.TabIndex = 67;
            this.lbStt.Text = "Nhập tin nhắn...";
            this.lbStt.Click += new System.EventHandler(this.lbStt_Click);
            // 
            // tbNoiDung
            // 
            this.tbNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tbNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoiDung.ForeColor = System.Drawing.Color.Silver;
            this.tbNoiDung.Location = new System.Drawing.Point(-31, 456);
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.Size = new System.Drawing.Size(487, 17);
            this.tbNoiDung.TabIndex = 58;
            this.tbNoiDung.TextChanged += new System.EventHandler(this.tbNoiDung_TextChanged);
            // 
            // btnMinisize
            // 
            this.btnMinisize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinisize.FlatAppearance.BorderSize = 0;
            this.btnMinisize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinisize.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinisize.ForeColor = System.Drawing.Color.White;
            this.btnMinisize.Location = new System.Drawing.Point(741, -38);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(30, 30);
            this.btnMinisize.TabIndex = 66;
            this.btnMinisize.Text = "O";
            this.btnMinisize.UseVisualStyleBackColor = true;
            this.btnMinisize.Click += new System.EventHandler(this.btnMinisize_Click);
            // 
            // btnMaxsize
            // 
            this.btnMaxsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxsize.FlatAppearance.BorderSize = 0;
            this.btnMaxsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxsize.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxsize.ForeColor = System.Drawing.Color.White;
            this.btnMaxsize.Location = new System.Drawing.Point(772, -38);
            this.btnMaxsize.Name = "btnMaxsize";
            this.btnMaxsize.Size = new System.Drawing.Size(30, 30);
            this.btnMaxsize.TabIndex = 65;
            this.btnMaxsize.Text = "O";
            this.btnMaxsize.UseVisualStyleBackColor = true;
            this.btnMaxsize.Click += new System.EventHandler(this.btnMaxsize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(803, -38);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "O";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DataGridViewsMember
            // 
            this.DataGridViewsMember.AllowUserToAddRows = false;
            this.DataGridViewsMember.AllowUserToDeleteRows = false;
            this.DataGridViewsMember.AllowUserToResizeColumns = false;
            this.DataGridViewsMember.AllowUserToResizeRows = false;
            this.DataGridViewsMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewsMember.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.DataGridViewsMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridViewsMember.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DataGridViewsMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewsMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewsMember.ColumnHeadersHeight = 24;
            this.DataGridViewsMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewsMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.identifier,
            this.name,
            this.dc});
            this.DataGridViewsMember.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewsMember.EnableHeadersVisualStyles = false;
            this.DataGridViewsMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.DataGridViewsMember.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DataGridViewsMember.Location = new System.Drawing.Point(555, -2);
            this.DataGridViewsMember.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewsMember.MultiSelect = false;
            this.DataGridViewsMember.Name = "DataGridViewsMember";
            this.DataGridViewsMember.ReadOnly = true;
            this.DataGridViewsMember.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DataGridViewsMember.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewsMember.RowHeadersVisible = false;
            this.DataGridViewsMember.RowHeadersWidth = 40;
            this.DataGridViewsMember.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewsMember.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewsMember.RowTemplate.Height = 24;
            this.DataGridViewsMember.RowTemplate.ReadOnly = true;
            this.DataGridViewsMember.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewsMember.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewsMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewsMember.ShowCellErrors = false;
            this.DataGridViewsMember.ShowCellToolTips = false;
            this.DataGridViewsMember.ShowEditingIcon = false;
            this.DataGridViewsMember.ShowRowErrors = false;
            this.DataGridViewsMember.Size = new System.Drawing.Size(248, 482);
            this.DataGridViewsMember.TabIndex = 62;
            this.DataGridViewsMember.TabStop = false;
            this.DataGridViewsMember.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewsMember_CellContentClick);
            // 
            // identifier
            // 
            this.identifier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.identifier.DefaultCellStyle = dataGridViewCellStyle2;
            this.identifier.HeaderText = "ID";
            this.identifier.MaxInputLength = 20;
            this.identifier.MinimumWidth = 20;
            this.identifier.Name = "identifier";
            this.identifier.ReadOnly = true;
            this.identifier.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.identifier.Width = 70;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "Name";
            this.name.MaxInputLength = 20;
            this.name.MinimumWidth = 20;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dc
            // 
            this.dc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dc.HeaderText = "Disconnect";
            this.dc.MinimumWidth = 20;
            this.dc.Name = "dc";
            this.dc.ReadOnly = true;
            this.dc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dc.Text = "Kick";
            this.dc.UseColumnTextForButtonValue = true;
            this.dc.Width = 80;
            // 
            // lbMatKhauGr
            // 
            this.lbMatKhauGr.AutoSize = true;
            this.lbMatKhauGr.Font = new System.Drawing.Font("Shopee Display", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhauGr.ForeColor = System.Drawing.Color.White;
            this.lbMatKhauGr.Location = new System.Drawing.Point(12, 30);
            this.lbMatKhauGr.Name = "lbMatKhauGr";
            this.lbMatKhauGr.Size = new System.Drawing.Size(112, 22);
            this.lbMatKhauGr.TabIndex = 60;
            this.lbMatKhauGr.Text = "Mật khẩu nhóm";
            this.lbMatKhauGr.Click += new System.EventHandler(this.lbMatKhauGr_Click);
            // 
            // lbTenNhom
            // 
            this.lbTenNhom.AutoSize = true;
            this.lbTenNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNhom.ForeColor = System.Drawing.Color.White;
            this.lbTenNhom.Location = new System.Drawing.Point(-24, -16);
            this.lbTenNhom.Name = "lbTenNhom";
            this.lbTenNhom.Size = new System.Drawing.Size(49, 18);
            this.lbTenNhom.TabIndex = 61;
            this.lbTenNhom.Text = "Nhóm";
            this.lbTenNhom.Click += new System.EventHandler(this.lbTenNhom_Click);
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderRadius = 15;
            this.guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton3.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.Location = new System.Drawing.Point(343, 23);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.Size = new System.Drawing.Size(81, 35);
            this.guna2GradientButton3.TabIndex = 70;
            this.guna2GradientButton3.Text = "Mời";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderRadius = 15;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(430, 23);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(118, 35);
            this.guna2GradientButton1.TabIndex = 70;
            this.guna2GradientButton1.Text = "Đổi mật khẩu";
            // 
            // GrPass
            // 
            this.GrPass.BackColor = System.Drawing.Color.Transparent;
            this.GrPass.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.GrPass.BorderRadius = 5;
            this.GrPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GrPass.DefaultText = "";
            this.GrPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GrPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GrPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GrPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GrPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GrPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GrPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GrPass.Location = new System.Drawing.Point(123, 30);
            this.GrPass.Name = "GrPass";
            this.GrPass.PasswordChar = '\0';
            this.GrPass.PlaceholderText = "";
            this.GrPass.SelectedText = "";
            this.GrPass.Size = new System.Drawing.Size(112, 24);
            this.GrPass.TabIndex = 71;
            this.GrPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.DimGray;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.CustomizableEdges.TopLeft = false;
            this.guna2TextBox1.DefaultText = "Nhập tin nhắn...";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.Black;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(16, 398);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(394, 36);
            this.guna2TextBox1.TabIndex = 72;
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BackgroundImage = global::X_Plore.Properties.Resources.send_3354313;
            this.guna2GradientButton2.BorderRadius = 15;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.Location = new System.Drawing.Point(467, 398);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(81, 35);
            this.guna2GradientButton2.TabIndex = 70;
            this.guna2GradientButton2.Text = "Gửi";
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Image = global::X_Plore.Properties.Resources.video_call_12595734;
            this.guna2ImageButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton2.ImageRotate = 0F;
            this.guna2ImageButton2.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2ImageButton2.Location = new System.Drawing.Point(473, 2);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.Size = new System.Drawing.Size(45, 42);
            this.guna2ImageButton2.TabIndex = 61;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::X_Plore.Properties.Resources.phone_call_597177;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(28, 28);
            this.guna2ImageButton1.Location = new System.Drawing.Point(423, 1);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(45, 42);
            this.guna2ImageButton1.TabIndex = 61;
            // 
            // guna2ImageRadioButton1
            // 
            this.guna2ImageRadioButton1.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2ImageRadioButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageRadioButton1.Image")));
            this.guna2ImageRadioButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageRadioButton1.ImageRotate = 0F;
            this.guna2ImageRadioButton1.ImageSize = new System.Drawing.Size(42, 42);
            this.guna2ImageRadioButton1.Location = new System.Drawing.Point(4, 3);
            this.guna2ImageRadioButton1.Name = "guna2ImageRadioButton1";
            this.guna2ImageRadioButton1.Size = new System.Drawing.Size(42, 42);
            this.guna2ImageRadioButton1.TabIndex = 0;
            // 
            // guna2ImageRadioButton2
            // 
            this.guna2ImageRadioButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageRadioButton2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.guna2ImageRadioButton2.Image = global::X_Plore.Properties.Resources.picture_7126547;
            this.guna2ImageRadioButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageRadioButton2.ImageRotate = 0F;
            this.guna2ImageRadioButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageRadioButton2.Location = new System.Drawing.Point(420, 394);
            this.guna2ImageRadioButton2.Name = "guna2ImageRadioButton2";
            this.guna2ImageRadioButton2.Size = new System.Drawing.Size(41, 44);
            this.guna2ImageRadioButton2.TabIndex = 73;
            // 
            // Group_chat_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2ImageRadioButton2);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.GrPass);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.guna2GradientButton2);
            this.Controls.Add(this.guna2GradientButton3);
            this.Controls.Add(this.pnLichSu);
            this.Controls.Add(this.cbHideOrShowPass);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.tbNoiDung);
            this.Controls.Add(this.btnMinisize);
            this.Controls.Add(this.btnMaxsize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.DataGridViewsMember);
            this.Controls.Add(this.lbMatKhauGr);
            this.Controls.Add(this.lbTenNhom);
            this.Name = "Group_chat_admin";
            this.Text = "Group_chat";
            this.pnLichSu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewsMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLichSu;
        private Guna.UI2.WinForms.Guna2ToggleSwitch cbHideOrShowPass;
        private System.Windows.Forms.Label lbStt;
        private System.Windows.Forms.TextBox tbNoiDung;
        private System.Windows.Forms.Button btnMinisize;
        private System.Windows.Forms.Button btnMaxsize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DataGridViewsMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewButtonColumn dc;
        private System.Windows.Forms.Label lbMatKhauGr;
        private System.Windows.Forms.Label lbTenNhom;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2TextBox GrPass;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ImageRadioButton guna2ImageRadioButton1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2ImageRadioButton guna2ImageRadioButton2;
    }
}