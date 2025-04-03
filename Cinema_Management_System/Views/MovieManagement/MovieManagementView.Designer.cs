namespace Cinema_Management_System.Views.MovieManagement
{
    partial class MovieManagementView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addMovie_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.movie_data = new Guna.UI2.WinForms.Guna2DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 10;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "Tất cả",
            "Ngưng phát hành",
            "Đang phát hành"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(23, 103);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(183, 36);
            this.guna2ComboBox1.StartIndex = 0;
            this.guna2ComboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bộ lọc";
            // 
            // addMovie_Btn
            // 
            this.addMovie_Btn.Animated = true;
            this.addMovie_Btn.BackColor = System.Drawing.Color.Transparent;
            this.addMovie_Btn.BorderRadius = 10;
            this.addMovie_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addMovie_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addMovie_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addMovie_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addMovie_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addMovie_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.addMovie_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.addMovie_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.addMovie_Btn.ForeColor = System.Drawing.Color.White;
            this.addMovie_Btn.Location = new System.Drawing.Point(561, 12);
            this.addMovie_Btn.Name = "addMovie_Btn";
            this.addMovie_Btn.Size = new System.Drawing.Size(166, 39);
            this.addMovie_Btn.TabIndex = 3;
            this.addMovie_Btn.Text = "Thêm phim";
            this.addMovie_Btn.Click += new System.EventHandler(this.addMovie_Btn_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.movie_data);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(27, 165);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(960, 500);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // movie_data
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.movie_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.movie_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.movie_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.movie_data.ColumnHeadersHeight = 30;
            this.movie_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.movie_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.Column2,
            this.Column3,
            this.update_col,
            this.delete_col});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.movie_data.DefaultCellStyle = dataGridViewCellStyle3;
            this.movie_data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.movie_data.Location = new System.Drawing.Point(16, 16);
            this.movie_data.Name = "movie_data";
            this.movie_data.RowHeadersVisible = false;
            this.movie_data.RowTemplate.Height = 40;
            this.movie_data.Size = new System.Drawing.Size(929, 468);
            this.movie_data.TabIndex = 0;
            this.movie_data.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.movie_data.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.movie_data.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.movie_data.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.movie_data.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.movie_data.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.movie_data.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.movie_data.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.movie_data.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.movie_data.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.movie_data.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.movie_data.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.movie_data.ThemeStyle.HeaderStyle.Height = 30;
            this.movie_data.ThemeStyle.ReadOnly = false;
            this.movie_data.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.movie_data.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.movie_data.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.movie_data.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.movie_data.ThemeStyle.RowsStyle.Height = 40;
            this.movie_data.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.movie_data.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.movie_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.movie_data_CellClick);
            // 
            // title
            // 
            this.title.DataPropertyName = "Title";
            this.title.FillWeight = 54.91481F;
            this.title.HeaderText = "Tên phim";
            this.title.Name = "title";
            this.title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.title.Width = 275;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Status";
            this.Column2.FillWeight = 54.91481F;
            this.Column2.HeaderText = "Tình trạng";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 275;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Length";
            this.Column3.FillWeight = 54.91481F;
            this.Column3.HeaderText = "Thời lượng (phút)";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 275;
            // 
            // update_col
            // 
            this.update_col.FillWeight = 253.8071F;
            this.update_col.HeaderText = "";
            this.update_col.Name = "update_col";
            this.update_col.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.update_col.Width = 50;
            // 
            // delete_col
            // 
            this.delete_col.FillWeight = 81.44846F;
            this.delete_col.HeaderText = "";
            this.delete_col.Name = "delete_col";
            this.delete_col.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delete_col.Width = 50;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Cinema_Management_System.Properties.Resources.icons8_plus_32;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(573, 18);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(28, 28);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Animated = true;
            this.guna2TextBox1.BorderRadius = 10;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconLeft = global::Cinema_Management_System.Properties.Resources.icons8_magnifying_glass_50;
            this.guna2TextBox1.Location = new System.Drawing.Point(23, 12);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "Tìm kiếm phim";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(500, 36);
            this.guna2TextBox1.TabIndex = 0;
            // 
            // MovieManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.addMovie_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ComboBox1);
            this.Controls.Add(this.guna2TextBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MovieManagementView";
            this.Size = new System.Drawing.Size(1022, 682);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movie_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton addMovie_Btn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView movie_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn update_col;
        private System.Windows.Forms.DataGridViewImageColumn delete_col;
    }
}
