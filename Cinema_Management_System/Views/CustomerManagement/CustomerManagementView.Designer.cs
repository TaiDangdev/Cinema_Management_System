namespace Cinema_Management_System.Views.CustomerManagement
{
    partial class CustomerManagementView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xuatEXEL_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.luachontim_cbb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgv_customer = new Guna.UI2.WinForms.Guna2DataGridView();
            this.chucnang_menu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.chỉnhSửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dulieutim_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.canhbao_label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Them_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.diem_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDK_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).BeginInit();
            this.chucnang_menu.SuspendLayout();
            this.SuspendLayout();
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
            this.xuatEXEL_bnt.Location = new System.Drawing.Point(868, 27);
            this.xuatEXEL_bnt.Name = "xuatEXEL_bnt";
            this.xuatEXEL_bnt.Size = new System.Drawing.Size(151, 39);
            this.xuatEXEL_bnt.TabIndex = 9;
            this.xuatEXEL_bnt.Text = "Xuất file excel";
            this.xuatEXEL_bnt.Click += new System.EventHandler(this.xuatEXEL_bnt_Click);
            // 
            // luachontim_cbb
            // 
            this.luachontim_cbb.BackColor = System.Drawing.Color.Transparent;
            this.luachontim_cbb.BorderColor = System.Drawing.Color.Black;
            this.luachontim_cbb.BorderRadius = 10;
            this.luachontim_cbb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.luachontim_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.luachontim_cbb.FillColor = System.Drawing.SystemColors.Control;
            this.luachontim_cbb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.luachontim_cbb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.luachontim_cbb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luachontim_cbb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.luachontim_cbb.ItemHeight = 30;
            this.luachontim_cbb.Items.AddRange(new object[] {
            "Kiểu tìm kiếm",
            "Tên khách hàng",
            "Số điện thoại"});
            this.luachontim_cbb.Location = new System.Drawing.Point(492, 27);
            this.luachontim_cbb.Name = "luachontim_cbb";
            this.luachontim_cbb.Size = new System.Drawing.Size(182, 36);
            this.luachontim_cbb.StartIndex = 0;
            this.luachontim_cbb.TabIndex = 7;
            this.luachontim_cbb.SelectedIndexChanged += new System.EventHandler(this.luachontim_cbb_SelectedIndexChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgv_customer);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 101);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1016, 591);
            this.guna2GroupBox1.TabIndex = 10;
            this.guna2GroupBox1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // dgv_customer
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_customer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_customer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_customer.ColumnHeadersHeight = 32;
            this.dgv_customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_customer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.Ten_col,
            this.gioitinh_col,
            this.sdt_col,
            this.email_col,
            this.ngaysinh_col,
            this.ngayDK_col,
            this.diem_col,
            this.Action});
            this.dgv_customer.ContextMenuStrip = this.chucnang_menu;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_customer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_customer.Location = new System.Drawing.Point(6, 42);
            this.dgv_customer.Name = "dgv_customer";
            this.dgv_customer.ReadOnly = true;
            this.dgv_customer.RowHeadersVisible = false;
            this.dgv_customer.RowHeadersWidth = 51;
            this.dgv_customer.Size = new System.Drawing.Size(1010, 539);
            this.dgv_customer.TabIndex = 0;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_customer.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_customer.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_customer.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_customer.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_customer.ThemeStyle.HeaderStyle.Height = 32;
            this.dgv_customer.ThemeStyle.ReadOnly = true;
            this.dgv_customer.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_customer.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_customer.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgv_customer.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_customer.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_customer.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_customer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_customer_CellContentClick);
            // 
            // chucnang_menu
            // 
            this.chucnang_menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.chucnang_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chỉnhSửaToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.chucnang_menu.Name = "guna2ContextMenuStrip1";
            this.chucnang_menu.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.chucnang_menu.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.chucnang_menu.RenderStyle.ColorTable = null;
            this.chucnang_menu.RenderStyle.RoundedEdges = true;
            this.chucnang_menu.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.chucnang_menu.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chucnang_menu.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.chucnang_menu.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.chucnang_menu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.chucnang_menu.Size = new System.Drawing.Size(126, 48);
            // 
            // chỉnhSửaToolStripMenuItem
            // 
            this.chỉnhSửaToolStripMenuItem.Name = "chỉnhSửaToolStripMenuItem";
            this.chỉnhSửaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.chỉnhSửaToolStripMenuItem.Text = "chỉnh sửa";
            this.chỉnhSửaToolStripMenuItem.Click += new System.EventHandler(this.chỉnhSửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.xóaToolStripMenuItem.Text = "xóa";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "dấu ba chấm";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 112;
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
            this.dulieutim_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dulieutim_txt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dulieutim_txt.ForeColor = System.Drawing.Color.Black;
            this.dulieutim_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dulieutim_txt.Location = new System.Drawing.Point(29, 27);
            this.dulieutim_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dulieutim_txt.Name = "dulieutim_txt";
            this.dulieutim_txt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.dulieutim_txt.PlaceholderText = "Tìm kiếm";
            this.dulieutim_txt.SelectedText = "";
            this.dulieutim_txt.Size = new System.Drawing.Size(434, 36);
            this.dulieutim_txt.TabIndex = 6;
            this.dulieutim_txt.TextChanged += new System.EventHandler(this.dulieutim_txt_TextChanged);
            // 
            // canhbao_label
            // 
            this.canhbao_label.BackColor = System.Drawing.Color.Transparent;
            this.canhbao_label.ForeColor = System.Drawing.Color.Red;
            this.canhbao_label.Location = new System.Drawing.Point(39, 70);
            this.canhbao_label.Name = "canhbao_label";
            this.canhbao_label.Size = new System.Drawing.Size(135, 15);
            this.canhbao_label.TabIndex = 11;
            this.canhbao_label.Text = "Vui lòng chọn kiểu tìm kiếm!";
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
            this.Them_bnt.Location = new System.Drawing.Point(700, 27);
            this.Them_bnt.Name = "Them_bnt";
            this.Them_bnt.Size = new System.Drawing.Size(153, 39);
            this.Them_bnt.TabIndex = 13;
            this.Them_bnt.Text = "Thêm Khách hàng";
            this.Them_bnt.Click += new System.EventHandler(this.Them_bnt_Click);
            // 
            // Action
            // 
            this.Action.FillWeight = 50F;
            this.Action.HeaderText = "";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // diem_col
            // 
            this.diem_col.DataPropertyName = "Point";
            this.diem_col.HeaderText = "Điểm";
            this.diem_col.MinimumWidth = 6;
            this.diem_col.Name = "diem_col";
            this.diem_col.ReadOnly = true;
            // 
            // ngayDK_col
            // 
            this.ngayDK_col.DataPropertyName = "RegDate";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.ngayDK_col.DefaultCellStyle = dataGridViewCellStyle4;
            this.ngayDK_col.HeaderText = "Ngày đăng ký";
            this.ngayDK_col.MinimumWidth = 6;
            this.ngayDK_col.Name = "ngayDK_col";
            this.ngayDK_col.ReadOnly = true;
            // 
            // ngaysinh_col
            // 
            this.ngaysinh_col.DataPropertyName = "Birth";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.ngaysinh_col.DefaultCellStyle = dataGridViewCellStyle3;
            this.ngaysinh_col.HeaderText = "Ngày sinh";
            this.ngaysinh_col.MinimumWidth = 6;
            this.ngaysinh_col.Name = "ngaysinh_col";
            this.ngaysinh_col.ReadOnly = true;
            // 
            // email_col
            // 
            this.email_col.DataPropertyName = "Email";
            this.email_col.HeaderText = "Email";
            this.email_col.MinimumWidth = 6;
            this.email_col.Name = "email_col";
            this.email_col.ReadOnly = true;
            // 
            // sdt_col
            // 
            this.sdt_col.DataPropertyName = "PhoneNumber";
            this.sdt_col.HeaderText = "SDT";
            this.sdt_col.MinimumWidth = 6;
            this.sdt_col.Name = "sdt_col";
            this.sdt_col.ReadOnly = true;
            // 
            // gioitinh_col
            // 
            this.gioitinh_col.DataPropertyName = "Gender";
            this.gioitinh_col.HeaderText = "Giới tính";
            this.gioitinh_col.MinimumWidth = 6;
            this.gioitinh_col.Name = "gioitinh_col";
            this.gioitinh_col.ReadOnly = true;
            // 
            // Ten_col
            // 
            this.Ten_col.DataPropertyName = "FullName";
            this.Ten_col.FillWeight = 150F;
            this.Ten_col.HeaderText = "Tên khách hàng";
            this.Ten_col.MinimumWidth = 6;
            this.Ten_col.Name = "Ten_col";
            this.Ten_col.ReadOnly = true;
            // 
            // id_col
            // 
            this.id_col.DataPropertyName = "IdFormat";
            this.id_col.HeaderText = "Mã khách hàng";
            this.id_col.MinimumWidth = 6;
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
            // 
            // CustomerManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.Them_bnt);
            this.Controls.Add(this.canhbao_label);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.xuatEXEL_bnt);
            this.Controls.Add(this.luachontim_cbb);
            this.Controls.Add(this.dulieutim_txt);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CustomerManagementView";
            this.Size = new System.Drawing.Size(1022, 682);
            this.Load += new System.EventHandler(this.CustomerManagementView_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).EndInit();
            this.chucnang_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton xuatEXEL_bnt;
        private Guna.UI2.WinForms.Guna2ComboBox luachontim_cbb;
        private Guna.UI2.WinForms.Guna2TextBox dulieutim_txt;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_customer;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip chucnang_menu;
        private System.Windows.Forms.ToolStripMenuItem chỉnhSửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2HtmlLabel canhbao_label;
        private Guna.UI2.WinForms.Guna2GradientButton Them_bnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayDK_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn diem_col;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}
