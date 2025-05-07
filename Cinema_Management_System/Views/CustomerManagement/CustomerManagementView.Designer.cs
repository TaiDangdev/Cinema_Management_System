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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xuatEXEL_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.luachontim_cbb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dulieutim_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.canhbao_label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Them_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dgv_customer = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDK_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diem_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).BeginInit();
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
            this.xuatEXEL_bnt.Image = global::Cinema_Management_System.Properties.Resources.file_icon;
            this.xuatEXEL_bnt.Location = new System.Drawing.Point(1105, 24);
            this.xuatEXEL_bnt.Name = "xuatEXEL_bnt";
            this.xuatEXEL_bnt.Size = new System.Drawing.Size(162, 39);
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
            this.luachontim_cbb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.luachontim_cbb.ForeColor = System.Drawing.Color.Black;
            this.luachontim_cbb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.luachontim_cbb.ItemHeight = 30;
            this.luachontim_cbb.Items.AddRange(new object[] {
            "Kiểu tìm kiếm",
            "Tên khách hàng",
            "Số điện thoại"});
            this.luachontim_cbb.Location = new System.Drawing.Point(587, 27);
            this.luachontim_cbb.Name = "luachontim_cbb";
            this.luachontim_cbb.Size = new System.Drawing.Size(224, 36);
            this.luachontim_cbb.StartIndex = 0;
            this.luachontim_cbb.TabIndex = 7;
            this.luachontim_cbb.SelectedIndexChanged += new System.EventHandler(this.luachontim_cbb_SelectedIndexChanged);
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
            this.dulieutim_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.dulieutim_txt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dulieutim_txt.ForeColor = System.Drawing.Color.Black;
            this.dulieutim_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.dulieutim_txt.Location = new System.Drawing.Point(29, 27);
            this.dulieutim_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dulieutim_txt.Name = "dulieutim_txt";
            this.dulieutim_txt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.dulieutim_txt.PlaceholderText = "Tìm kiếm";
            this.dulieutim_txt.SelectedText = "";
            this.dulieutim_txt.Size = new System.Drawing.Size(492, 36);
            this.dulieutim_txt.TabIndex = 6;
            this.dulieutim_txt.TextChanged += new System.EventHandler(this.dulieutim_txt_TextChanged);
            // 
            // canhbao_label
            // 
            this.canhbao_label.BackColor = System.Drawing.Color.Transparent;
            this.canhbao_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canhbao_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.canhbao_label.Location = new System.Drawing.Point(29, 70);
            this.canhbao_label.Name = "canhbao_label";
            this.canhbao_label.Size = new System.Drawing.Size(183, 19);
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
            this.Them_bnt.Image = global::Cinema_Management_System.Properties.Resources.add_icon;
            this.Them_bnt.Location = new System.Drawing.Point(877, 24);
            this.Them_bnt.Name = "Them_bnt";
            this.Them_bnt.Size = new System.Drawing.Size(162, 39);
            this.Them_bnt.TabIndex = 13;
            this.Them_bnt.Text = "Thêm khách hàng";
            this.Them_bnt.Click += new System.EventHandler(this.Them_bnt_Click);
            // 
            // dgv_customer
            // 
            this.dgv_customer.AllowUserToAddRows = false;
            this.dgv_customer.AllowUserToDeleteRows = false;
            this.dgv_customer.AllowUserToResizeColumns = false;
            this.dgv_customer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_customer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_customer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_customer.GridColor = System.Drawing.Color.White;
            this.dgv_customer.Location = new System.Drawing.Point(5, 138);
            this.dgv_customer.Name = "dgv_customer";
            this.dgv_customer.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_customer.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_customer.RowHeadersVisible = false;
            this.dgv_customer.RowHeadersWidth = 51;
            this.dgv_customer.Size = new System.Drawing.Size(1314, 671);
            this.dgv_customer.TabIndex = 0;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_customer.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_customer.ThemeStyle.GridColor = System.Drawing.Color.White;
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
            // id_col
            // 
            this.id_col.DataPropertyName = "IdFormat";
            this.id_col.HeaderText = "Mã khách hàng";
            this.id_col.MinimumWidth = 6;
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
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
            // gioitinh_col
            // 
            this.gioitinh_col.DataPropertyName = "Gender";
            this.gioitinh_col.HeaderText = "Giới tính";
            this.gioitinh_col.MinimumWidth = 6;
            this.gioitinh_col.Name = "gioitinh_col";
            this.gioitinh_col.ReadOnly = true;
            // 
            // sdt_col
            // 
            this.sdt_col.DataPropertyName = "PhoneNumber";
            this.sdt_col.HeaderText = "SĐT";
            this.sdt_col.MinimumWidth = 6;
            this.sdt_col.Name = "sdt_col";
            this.sdt_col.ReadOnly = true;
            // 
            // email_col
            // 
            this.email_col.DataPropertyName = "Email";
            this.email_col.HeaderText = "Email";
            this.email_col.MinimumWidth = 6;
            this.email_col.Name = "email_col";
            this.email_col.ReadOnly = true;
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
            // diem_col
            // 
            this.diem_col.DataPropertyName = "Point";
            this.diem_col.HeaderText = "Điểm";
            this.diem_col.MinimumWidth = 6;
            this.diem_col.Name = "diem_col";
            this.diem_col.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // CustomerManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_customer);
            this.Controls.Add(this.Them_bnt);
            this.Controls.Add(this.canhbao_label);
            this.Controls.Add(this.xuatEXEL_bnt);
            this.Controls.Add(this.luachontim_cbb);
            this.Controls.Add(this.dulieutim_txt);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CustomerManagementView";
            this.Size = new System.Drawing.Size(1329, 838);
            this.Load += new System.EventHandler(this.CustomerManagementView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton xuatEXEL_bnt;
        private Guna.UI2.WinForms.Guna2ComboBox luachontim_cbb;
        private Guna.UI2.WinForms.Guna2TextBox dulieutim_txt;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2HtmlLabel canhbao_label;
        private Guna.UI2.WinForms.Guna2GradientButton Them_bnt;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_customer;
        private System.Windows.Forms.Label label1;
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
