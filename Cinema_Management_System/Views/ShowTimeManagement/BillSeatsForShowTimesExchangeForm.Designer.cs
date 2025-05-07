namespace Cinema_Management_System.Views.ShowTimeManagement
{
    partial class BillSeatsForShowTimesExchangeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillSeatsForShowTimesExchangeForm));
            this.canhbao_label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.xuatEXEL_bnt = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dulieutim_txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_search = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgv_DataBill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheHoiVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ghe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.luachontim_cbb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataBill)).BeginInit();
            this.SuspendLayout();
            // 
            // canhbao_label
            // 
            this.canhbao_label.BackColor = System.Drawing.Color.Transparent;
            this.canhbao_label.ForeColor = System.Drawing.Color.Red;
            this.canhbao_label.Location = new System.Drawing.Point(27, 56);
            this.canhbao_label.Name = "canhbao_label";
            this.canhbao_label.Size = new System.Drawing.Size(135, 15);
            this.canhbao_label.TabIndex = 17;
            this.canhbao_label.Text = "Vui lòng chọn kiểu tìm kiếm!";
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
            this.xuatEXEL_bnt.Location = new System.Drawing.Point(797, 10);
            this.xuatEXEL_bnt.Name = "xuatEXEL_bnt";
            this.xuatEXEL_bnt.Size = new System.Drawing.Size(151, 39);
            this.xuatEXEL_bnt.TabIndex = 16;
            this.xuatEXEL_bnt.Text = "Xuất file excel";
            this.xuatEXEL_bnt.Click += new System.EventHandler(this.xuatEXEL_bnt_Click);
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
            this.dulieutim_txt.Location = new System.Drawing.Point(12, 13);
            this.dulieutim_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dulieutim_txt.Name = "dulieutim_txt";
            this.dulieutim_txt.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.dulieutim_txt.PlaceholderText = "Tìm kiếm";
            this.dulieutim_txt.SelectedText = "";
            this.dulieutim_txt.Size = new System.Drawing.Size(434, 36);
            this.dulieutim_txt.TabIndex = 14;
            // 
            // btn_search
            // 
            this.btn_search.Animated = true;
            this.btn_search.BackColor = System.Drawing.Color.Transparent;
            this.btn_search.BorderRadius = 10;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.btn_search.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btn_search.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(640, 10);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(151, 39);
            this.btn_search.TabIndex = 18;
            this.btn_search.Text = "Tìm kiếm";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgv_DataBill);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(9, 84);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1349, 600);
            this.guna2GroupBox1.TabIndex = 19;
            this.guna2GroupBox1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // dgv_DataBill
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_DataBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DataBill.ColumnHeadersHeight = 32;
            this.dgv_DataBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DataBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDon,
            this.NhanVien,
            this.TheHoiVien,
            this.Phim,
            this.GioChieu,
            this.Phong,
            this.Ghe,
            this.GiaVe,
            this.GiamGia,
            this.TongTien,
            this.btn_Del});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DataBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DataBill.Location = new System.Drawing.Point(3, 43);
            this.dgv_DataBill.Name = "dgv_DataBill";
            this.dgv_DataBill.ReadOnly = true;
            this.dgv_DataBill.RowHeadersVisible = false;
            this.dgv_DataBill.RowHeadersWidth = 51;
            this.dgv_DataBill.Size = new System.Drawing.Size(1346, 547);
            this.dgv_DataBill.TabIndex = 0;
            this.dgv_DataBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DataBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_DataBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_DataBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_DataBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_DataBill.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DataBill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DataBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_DataBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_DataBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_DataBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_DataBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DataBill.ThemeStyle.HeaderStyle.Height = 32;
            this.dgv_DataBill.ThemeStyle.ReadOnly = true;
            this.dgv_DataBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DataBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DataBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_DataBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgv_DataBill.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_DataBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DataBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_DataBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DataBill_CellContentClick);
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "Id";
            this.MaDon.FillWeight = 57.36788F;
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NhanVien
            // 
            this.NhanVien.DataPropertyName = "NameStaff";
            this.NhanVien.FillWeight = 57.36788F;
            this.NhanVien.HeaderText = "Nhân Viên";
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.ReadOnly = true;
            // 
            // TheHoiVien
            // 
            this.TheHoiVien.DataPropertyName = "PhoneNumber";
            this.TheHoiVien.FillWeight = 57.36788F;
            this.TheHoiVien.HeaderText = "Thẻ Hội Viên";
            this.TheHoiVien.Name = "TheHoiVien";
            this.TheHoiVien.ReadOnly = true;
            // 
            // Phim
            // 
            this.Phim.DataPropertyName = "MovieName";
            this.Phim.FillWeight = 57.36788F;
            this.Phim.HeaderText = "Phim";
            this.Phim.Name = "Phim";
            this.Phim.ReadOnly = true;
            // 
            // GioChieu
            // 
            this.GioChieu.DataPropertyName = "DateTimeShowTime";
            this.GioChieu.FillWeight = 57.36788F;
            this.GioChieu.HeaderText = "Giờ Chiếu";
            this.GioChieu.Name = "GioChieu";
            this.GioChieu.ReadOnly = true;
            // 
            // Phong
            // 
            this.Phong.DataPropertyName = "AuditoriumName";
            this.Phong.FillWeight = 57.36788F;
            this.Phong.HeaderText = "Phòng";
            this.Phong.Name = "Phong";
            this.Phong.ReadOnly = true;
            // 
            // Ghe
            // 
            this.Ghe.DataPropertyName = "quantity";
            this.Ghe.FillWeight = 57.36788F;
            this.Ghe.HeaderText = "Ghế";
            this.Ghe.Name = "Ghe";
            this.Ghe.ReadOnly = true;
            // 
            // GiaVe
            // 
            this.GiaVe.DataPropertyName = "ticketPrice";
            this.GiaVe.FillWeight = 57.36788F;
            this.GiaVe.HeaderText = "Giá Vé";
            this.GiaVe.Name = "GiaVe";
            this.GiaVe.ReadOnly = true;
            // 
            // GiamGia
            // 
            this.GiamGia.DataPropertyName = "Discount";
            this.GiamGia.FillWeight = 57.36788F;
            this.GiamGia.HeaderText = "Giảm Giá";
            this.GiamGia.Name = "GiamGia";
            this.GiamGia.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TotalPrice";
            this.TongTien.FillWeight = 57.36788F;
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // btn_Del
            // 
            this.btn_Del.FillWeight = 50F;
            this.btn_Del.HeaderText = "";
            this.btn_Del.MinimumWidth = 6;
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.ReadOnly = true;
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
            this.luachontim_cbb.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.luachontim_cbb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.luachontim_cbb.ItemHeight = 30;
            this.luachontim_cbb.Items.AddRange(new object[] {
            "Kiểu tìm kiếm",
            "Mã Đơn",
            "Mã Phim"});
            this.luachontim_cbb.Location = new System.Drawing.Point(452, 13);
            this.luachontim_cbb.Name = "luachontim_cbb";
            this.luachontim_cbb.Size = new System.Drawing.Size(182, 36);
            this.luachontim_cbb.StartIndex = 0;
            this.luachontim_cbb.TabIndex = 20;
            // 
            // BillSeatsForShowTimesExchangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 686);
            this.Controls.Add(this.luachontim_cbb);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.canhbao_label);
            this.Controls.Add(this.xuatEXEL_bnt);
            this.Controls.Add(this.dulieutim_txt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillSeatsForShowTimesExchangeForm";
            this.Text = "BillSeatsForShowTimesExchangeForm";
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel canhbao_label;
        private Guna.UI2.WinForms.Guna2GradientButton xuatEXEL_bnt;
        private Guna.UI2.WinForms.Guna2TextBox dulieutim_txt;
        private Guna.UI2.WinForms.Guna2GradientButton btn_search;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DataBill;
        private Guna.UI2.WinForms.Guna2ComboBox luachontim_cbb;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheHoiVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phim;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioChieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewButtonColumn btn_Del;
    }
}