namespace Cinema_Management_System.Views.StaffManagement
{
    partial class StaffManagementView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_staff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Them_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.canhbao_label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dulieutim_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.luachontim_cbb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.xuatEXEL_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.more_Btn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // dgv_staff
            // 
            this.dgv_staff.AllowUserToAddRows = false;
            this.dgv_staff.AllowUserToDeleteRows = false;
            this.dgv_staff.AllowUserToResizeColumns = false;
            this.dgv_staff.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_staff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_staff.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_staff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_staff.ColumnHeadersHeight = 32;
            this.dgv_staff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_staff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.Ten_col,
            this.gioitinh_col,
            this.sdt_col,
            this.email_col,
            this.role_col,
            this.more_Btn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_staff.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_staff.GridColor = System.Drawing.Color.White;
            this.dgv_staff.Location = new System.Drawing.Point(7, 141);
            this.dgv_staff.Name = "dgv_staff";
            this.dgv_staff.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_staff.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_staff.RowHeadersVisible = false;
            this.dgv_staff.RowHeadersWidth = 51;
            this.dgv_staff.Size = new System.Drawing.Size(1314, 671);
            this.dgv_staff.TabIndex = 16;
            this.dgv_staff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_staff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_staff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_staff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_staff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_staff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_staff.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgv_staff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_staff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_staff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_staff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_staff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_staff.ThemeStyle.HeaderStyle.Height = 32;
            this.dgv_staff.ThemeStyle.ReadOnly = true;
            this.dgv_staff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_staff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_staff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_staff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgv_staff.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_staff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_staff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_staff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_staff_CellContentClick);
            // 
            // Them_bnt
            // 
            this.Them_bnt.Animated = true;
            this.Them_bnt.BackColor = System.Drawing.Color.Transparent;
            this.Them_bnt.BorderRadius = 10;
            this.Them_bnt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Them_bnt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Them_bnt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Them_bnt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Them_bnt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Them_bnt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.Them_bnt.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.Them_bnt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.Them_bnt.ForeColor = System.Drawing.Color.White;
            this.Them_bnt.Location = new System.Drawing.Point(869, 27);
            this.Them_bnt.Name = "Them_bnt";
            this.Them_bnt.Size = new System.Drawing.Size(177, 39);
            this.Them_bnt.TabIndex = 21;
            this.Them_bnt.Text = "Thêm nhân viên";
            this.Them_bnt.Click += new System.EventHandler(this.Them_bnt_Click);
            // 
            // canhbao_label
            // 
            this.canhbao_label.BackColor = System.Drawing.Color.Transparent;
            this.canhbao_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canhbao_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.canhbao_label.Location = new System.Drawing.Point(31, 73);
            this.canhbao_label.Name = "canhbao_label";
            this.canhbao_label.Size = new System.Drawing.Size(183, 19);
            this.canhbao_label.TabIndex = 20;
            this.canhbao_label.Text = "Vui lòng chọn kiểu tìm kiếm!";
            // 
            // dulieutim_txt
            // 
            this.dulieutim_txt.Animated = true;
            this.dulieutim_txt.BorderColor = System.Drawing.Color.Black;
            this.dulieutim_txt.BorderRadius = 10;
            this.dulieutim_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dulieutim_txt.DefaultText = "";
            this.dulieutim_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.dulieutim_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.dulieutim_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.dulieutim_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.dulieutim_txt.FillColor = System.Drawing.SystemColors.Control;
            this.dulieutim_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.dulieutim_txt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dulieutim_txt.ForeColor = System.Drawing.Color.Black;
            this.dulieutim_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.dulieutim_txt.Location = new System.Drawing.Point(31, 30);
            this.dulieutim_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dulieutim_txt.Name = "dulieutim_txt";
            this.dulieutim_txt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.dulieutim_txt.PlaceholderText = "Tìm kiếm";
            this.dulieutim_txt.SelectedText = "";
            this.dulieutim_txt.Size = new System.Drawing.Size(492, 36);
            this.dulieutim_txt.TabIndex = 17;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "dấu ba chấm";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 112;
            // 
            // luachontim_cbb
            // 
            this.luachontim_cbb.BackColor = System.Drawing.Color.Transparent;
            this.luachontim_cbb.BorderColor = System.Drawing.Color.Black;
            this.luachontim_cbb.BorderRadius = 10;
            this.luachontim_cbb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.luachontim_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.luachontim_cbb.FillColor = System.Drawing.SystemColors.Control;
            this.luachontim_cbb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.luachontim_cbb.ForeColor = System.Drawing.Color.Black;
            this.luachontim_cbb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.ItemHeight = 30;
            this.luachontim_cbb.Items.AddRange(new object[] {
            "Kiểu tìm kiếm",
            "Tên nhân viên",
            "Số điện thoại"});
            this.luachontim_cbb.Location = new System.Drawing.Point(584, 30);
            this.luachontim_cbb.Name = "luachontim_cbb";
            this.luachontim_cbb.Size = new System.Drawing.Size(224, 36);
            this.luachontim_cbb.StartIndex = 0;
            this.luachontim_cbb.TabIndex = 18;
            // 
            // xuatEXEL_bnt
            // 
            this.xuatEXEL_bnt.Animated = true;
            this.xuatEXEL_bnt.BackColor = System.Drawing.Color.Transparent;
            this.xuatEXEL_bnt.BorderRadius = 10;
            this.xuatEXEL_bnt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xuatEXEL_bnt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xuatEXEL_bnt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xuatEXEL_bnt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xuatEXEL_bnt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xuatEXEL_bnt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.xuatEXEL_bnt.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.xuatEXEL_bnt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.xuatEXEL_bnt.ForeColor = System.Drawing.Color.White;
            this.xuatEXEL_bnt.Location = new System.Drawing.Point(1107, 27);
            this.xuatEXEL_bnt.Name = "xuatEXEL_bnt";
            this.xuatEXEL_bnt.Size = new System.Drawing.Size(177, 39);
            this.xuatEXEL_bnt.TabIndex = 19;
            this.xuatEXEL_bnt.Text = "Xuất file excel";
            this.xuatEXEL_bnt.Click += new System.EventHandler(this.xuatEXEL_bnt_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Red;
            this.guna2PictureBox2.Image = global::Cinema_Management_System.Properties.Resources.file_icon;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(1113, 33);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(28, 28);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 24;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Red;
            this.guna2PictureBox1.Image = global::Cinema_Management_System.Properties.Resources.add_icon;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(873, 32);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(28, 28);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 22;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // id_col
            // 
            this.id_col.DataPropertyName = "IdFormat";
            this.id_col.FillWeight = 23.18797F;
            this.id_col.HeaderText = "ID";
            this.id_col.MinimumWidth = 6;
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
            // 
            // Ten_col
            // 
            this.Ten_col.DataPropertyName = "FullName";
            this.Ten_col.FillWeight = 34.78196F;
            this.Ten_col.HeaderText = "Họ và tên";
            this.Ten_col.MinimumWidth = 6;
            this.Ten_col.Name = "Ten_col";
            this.Ten_col.ReadOnly = true;
            // 
            // gioitinh_col
            // 
            this.gioitinh_col.DataPropertyName = "Gender";
            this.gioitinh_col.FillWeight = 23.18797F;
            this.gioitinh_col.HeaderText = "Giới tính";
            this.gioitinh_col.MinimumWidth = 6;
            this.gioitinh_col.Name = "gioitinh_col";
            this.gioitinh_col.ReadOnly = true;
            // 
            // sdt_col
            // 
            this.sdt_col.DataPropertyName = "PhoneNumber";
            this.sdt_col.FillWeight = 23.18797F;
            this.sdt_col.HeaderText = "SĐT";
            this.sdt_col.MinimumWidth = 6;
            this.sdt_col.Name = "sdt_col";
            this.sdt_col.ReadOnly = true;
            // 
            // email_col
            // 
            this.email_col.DataPropertyName = "Email";
            this.email_col.FillWeight = 23.18797F;
            this.email_col.HeaderText = "Email";
            this.email_col.MinimumWidth = 6;
            this.email_col.Name = "email_col";
            this.email_col.ReadOnly = true;
            // 
            // role_col
            // 
            this.role_col.DataPropertyName = "Role";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.role_col.DefaultCellStyle = dataGridViewCellStyle3;
            this.role_col.FillWeight = 23.18797F;
            this.role_col.HeaderText = "Chức vụ";
            this.role_col.MinimumWidth = 6;
            this.role_col.Name = "role_col";
            this.role_col.ReadOnly = true;
            // 
            // more_Btn
            // 
            this.more_Btn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.more_Btn.FillWeight = 50F;
            this.more_Btn.HeaderText = "";
            this.more_Btn.MinimumWidth = 6;
            this.more_Btn.Name = "more_Btn";
            this.more_Btn.ReadOnly = true;
            this.more_Btn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.more_Btn.Width = 86;
            // 
            // StaffManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_staff);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.Them_bnt);
            this.Controls.Add(this.canhbao_label);
            this.Controls.Add(this.dulieutim_txt);
            this.Controls.Add(this.luachontim_cbb);
            this.Controls.Add(this.xuatEXEL_bnt);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StaffManagementView";
            this.Size = new System.Drawing.Size(1329, 838);
            this.Load += new System.EventHandler(this.StaffManagementView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton Them_bnt;
        private Guna.UI2.WinForms.Guna2HtmlLabel canhbao_label;
        private Guna.UI2.WinForms.Guna2TextBox dulieutim_txt;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2ComboBox luachontim_cbb;
        private Guna.UI2.WinForms.Guna2GradientButton xuatEXEL_bnt;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_staff;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_col;
        private System.Windows.Forms.DataGridViewButtonColumn more_Btn;
    }
}
