namespace Cinema_Management_System
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.logout_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.profile_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.thongKe_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.voucher_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.productManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.customerManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.staffManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.showtimeManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.filmManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.customerManagementView1 = new Cinema_Management_System.Views.CustomerManagement.CustomerManagementView();
            this.aboutAccount_Form2 = new Cinema_Management_System.AboutAccount_Form();
            this.aboutAccount_Form1 = new Cinema_Management_System.AboutAccount_Form();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1222, 62);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1111, 8);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 5;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1162, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dành cho quản trị viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(46, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "StarCinema\r\n";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.logout_Btn);
            this.guna2Panel2.Controls.Add(this.profile_Btn);
            this.guna2Panel2.Controls.Add(this.thongKe_Btn);
            this.guna2Panel2.Controls.Add(this.voucher_Btn);
            this.guna2Panel2.Controls.Add(this.productManage_Btn);
            this.guna2Panel2.Controls.Add(this.customerManage_Btn);
            this.guna2Panel2.Controls.Add(this.staffManage_Btn);
            this.guna2Panel2.Controls.Add(this.showtimeManage_Btn);
            this.guna2Panel2.Controls.Add(this.filmManage_Btn);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 62);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(186, 665);
            this.guna2Panel2.TabIndex = 1;
            // 
            // logout_Btn
            // 
            this.logout_Btn.Animated = true;
            this.logout_Btn.BackColor = System.Drawing.Color.Transparent;
            this.logout_Btn.BorderRadius = 10;
            this.logout_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logout_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logout_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logout_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logout_Btn.FillColor = System.Drawing.Color.White;
            this.logout_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.logout_Btn.ForeColor = System.Drawing.Color.Black;
            this.logout_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.logout_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.logout_Btn.Image = global::Cinema_Management_System.Properties.Resources.logout;
            this.logout_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.logout_Btn.Location = new System.Drawing.Point(12, 632);
            this.logout_Btn.Name = "logout_Btn";
            this.logout_Btn.Size = new System.Drawing.Size(174, 45);
            this.logout_Btn.TabIndex = 12;
            this.logout_Btn.Text = "Đăng Xuất";
            this.logout_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.logout_Btn.UseTransparentBackground = true;
            this.logout_Btn.Click += new System.EventHandler(this.logout_Btn_Click);
            // 
            // profile_Btn
            // 
            this.profile_Btn.Animated = true;
            this.profile_Btn.BackColor = System.Drawing.Color.Transparent;
            this.profile_Btn.BorderRadius = 10;
            this.profile_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.profile_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.profile_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.profile_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.profile_Btn.FillColor = System.Drawing.Color.White;
            this.profile_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.profile_Btn.ForeColor = System.Drawing.Color.Black;
            this.profile_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.profile_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.profile_Btn.Image = global::Cinema_Management_System.Properties.Resources.profile;
            this.profile_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.profile_Btn.Location = new System.Drawing.Point(12, 581);
            this.profile_Btn.Name = "profile_Btn";
            this.profile_Btn.Size = new System.Drawing.Size(174, 45);
            this.profile_Btn.TabIndex = 11;
            this.profile_Btn.Text = "Cá Nhân";
            this.profile_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.profile_Btn.UseTransparentBackground = true;
            this.profile_Btn.Click += new System.EventHandler(this.profile_Btn_Click);
            // 
            // thongKe_Btn
            // 
            this.thongKe_Btn.Animated = true;
            this.thongKe_Btn.BackColor = System.Drawing.Color.Transparent;
            this.thongKe_Btn.BorderRadius = 10;
            this.thongKe_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.thongKe_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.thongKe_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.thongKe_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.thongKe_Btn.FillColor = System.Drawing.Color.White;
            this.thongKe_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.thongKe_Btn.ForeColor = System.Drawing.Color.Black;
            this.thongKe_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.thongKe_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongKe_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.thongKe_Btn.Image = global::Cinema_Management_System.Properties.Resources.data;
            this.thongKe_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.thongKe_Btn.Location = new System.Drawing.Point(11, 452);
            this.thongKe_Btn.Name = "thongKe_Btn";
            this.thongKe_Btn.Size = new System.Drawing.Size(174, 45);
            this.thongKe_Btn.TabIndex = 10;
            this.thongKe_Btn.Text = "Thống Kê";
            this.thongKe_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.thongKe_Btn.UseTransparentBackground = true;
            this.thongKe_Btn.Click += new System.EventHandler(this.thongKe_Btn_Click);
            // 
            // voucher_Btn
            // 
            this.voucher_Btn.Animated = true;
            this.voucher_Btn.BackColor = System.Drawing.Color.Transparent;
            this.voucher_Btn.BorderRadius = 10;
            this.voucher_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.voucher_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.voucher_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.voucher_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.voucher_Btn.FillColor = System.Drawing.Color.White;
            this.voucher_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.voucher_Btn.ForeColor = System.Drawing.Color.Black;
            this.voucher_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.voucher_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucher_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.voucher_Btn.Image = global::Cinema_Management_System.Properties.Resources.promo_code;
            this.voucher_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.voucher_Btn.Location = new System.Drawing.Point(11, 401);
            this.voucher_Btn.Name = "voucher_Btn";
            this.voucher_Btn.Size = new System.Drawing.Size(174, 45);
            this.voucher_Btn.TabIndex = 5;
            this.voucher_Btn.Text = "Voucher";
            this.voucher_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.voucher_Btn.UseTransparentBackground = true;
            this.voucher_Btn.Click += new System.EventHandler(this.voucher_Btn_Click);
            // 
            // productManage_Btn
            // 
            this.productManage_Btn.Animated = true;
            this.productManage_Btn.BackColor = System.Drawing.Color.Transparent;
            this.productManage_Btn.BorderRadius = 10;
            this.productManage_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.productManage_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.productManage_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.productManage_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.productManage_Btn.FillColor = System.Drawing.Color.White;
            this.productManage_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.productManage_Btn.ForeColor = System.Drawing.Color.Black;
            this.productManage_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.productManage_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManage_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.productManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.QLProduct;
            this.productManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productManage_Btn.Location = new System.Drawing.Point(11, 350);
            this.productManage_Btn.Name = "productManage_Btn";
            this.productManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.productManage_Btn.TabIndex = 4;
            this.productManage_Btn.Text = "Quản Lý Sản Phẩm";
            this.productManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productManage_Btn.UseTransparentBackground = true;
            this.productManage_Btn.Click += new System.EventHandler(this.productManage_Btn_Click);
            // 
            // customerManage_Btn
            // 
            this.customerManage_Btn.Animated = true;
            this.customerManage_Btn.BackColor = System.Drawing.Color.Transparent;
            this.customerManage_Btn.BorderRadius = 10;
            this.customerManage_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.customerManage_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.customerManage_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customerManage_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.customerManage_Btn.FillColor = System.Drawing.Color.White;
            this.customerManage_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.customerManage_Btn.ForeColor = System.Drawing.Color.Black;
            this.customerManage_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.customerManage_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerManage_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.customerManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.audience;
            this.customerManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.customerManage_Btn.Location = new System.Drawing.Point(11, 299);
            this.customerManage_Btn.Name = "customerManage_Btn";
            this.customerManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.customerManage_Btn.TabIndex = 3;
            this.customerManage_Btn.Text = "Quản Lý Khách Hàng";
            this.customerManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.customerManage_Btn.UseTransparentBackground = true;
            this.customerManage_Btn.Click += new System.EventHandler(this.customerManage_Btn_Click);
            // 
            // staffManage_Btn
            // 
            this.staffManage_Btn.Animated = true;
            this.staffManage_Btn.BackColor = System.Drawing.Color.Transparent;
            this.staffManage_Btn.BorderRadius = 10;
            this.staffManage_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.staffManage_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.staffManage_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.staffManage_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.staffManage_Btn.FillColor = System.Drawing.Color.White;
            this.staffManage_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.staffManage_Btn.ForeColor = System.Drawing.Color.Black;
            this.staffManage_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.staffManage_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffManage_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.staffManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.icons8_person_32;
            this.staffManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.staffManage_Btn.Location = new System.Drawing.Point(11, 248);
            this.staffManage_Btn.Name = "staffManage_Btn";
            this.staffManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.staffManage_Btn.TabIndex = 2;
            this.staffManage_Btn.Text = "Quản Lý Nhân Sự";
            this.staffManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.staffManage_Btn.UseTransparentBackground = true;
            this.staffManage_Btn.Click += new System.EventHandler(this.staffManage_Btn_Click);
            // 
            // showtimeManage_Btn
            // 
            this.showtimeManage_Btn.Animated = true;
            this.showtimeManage_Btn.BackColor = System.Drawing.Color.Transparent;
            this.showtimeManage_Btn.BorderRadius = 10;
            this.showtimeManage_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.showtimeManage_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.showtimeManage_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.showtimeManage_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.showtimeManage_Btn.FillColor = System.Drawing.Color.White;
            this.showtimeManage_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.showtimeManage_Btn.ForeColor = System.Drawing.Color.Black;
            this.showtimeManage_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.showtimeManage_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showtimeManage_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.showtimeManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.watching_a_movie;
            this.showtimeManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.showtimeManage_Btn.Location = new System.Drawing.Point(11, 197);
            this.showtimeManage_Btn.Name = "showtimeManage_Btn";
            this.showtimeManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.showtimeManage_Btn.TabIndex = 1;
            this.showtimeManage_Btn.Text = "Quản Lý Suất Chiếu";
            this.showtimeManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.showtimeManage_Btn.UseTransparentBackground = true;
            this.showtimeManage_Btn.Click += new System.EventHandler(this.showtimeManage_Btn_Click);
            // 
            // filmManage_Btn
            // 
            this.filmManage_Btn.Animated = true;
            this.filmManage_Btn.BackColor = System.Drawing.Color.Transparent;
            this.filmManage_Btn.BorderRadius = 10;
            this.filmManage_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.filmManage_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.filmManage_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.filmManage_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.filmManage_Btn.FillColor = System.Drawing.Color.White;
            this.filmManage_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.filmManage_Btn.ForeColor = System.Drawing.Color.Black;
            this.filmManage_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.filmManage_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filmManage_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.filmManage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("filmManage_Btn.Image")));
            this.filmManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filmManage_Btn.Location = new System.Drawing.Point(12, 146);
            this.filmManage_Btn.Name = "filmManage_Btn";
            this.filmManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.filmManage_Btn.TabIndex = 0;
            this.filmManage_Btn.Text = "Quản Lý Phim";
            this.filmManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filmManage_Btn.UseTransparentBackground = true;
            this.filmManage_Btn.Click += new System.EventHandler(this.filmManage_Btn_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.customerManagementView1);
            this.guna2Panel3.Controls.Add(this.aboutAccount_Form2);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(186, 62);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1036, 665);
            this.guna2Panel3.TabIndex = 2;
            // 
            // customerManagementView1
            // 
            this.customerManagementView1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.customerManagementView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.customerManagementView1.Location = new System.Drawing.Point(0, 0);
            this.customerManagementView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.customerManagementView1.Name = "customerManagementView1";
            this.customerManagementView1.Size = new System.Drawing.Size(1022, 682);
            this.customerManagementView1.TabIndex = 2;
            this.customerManagementView1.Load += new System.EventHandler(this.customerManagementView1_Load_1);
            // 
            // aboutAccount_Form2
            // 
            this.aboutAccount_Form2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutAccount_Form2.Location = new System.Drawing.Point(0, 0);
            this.aboutAccount_Form2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutAccount_Form2.Name = "aboutAccount_Form2";
            this.aboutAccount_Form2.Size = new System.Drawing.Size(1022, 682);
            this.aboutAccount_Form2.TabIndex = 1;
            // 
            // aboutAccount_Form1
            // 
            this.aboutAccount_Form1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutAccount_Form1.Location = new System.Drawing.Point(0, 0);
            this.aboutAccount_Form1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutAccount_Form1.Name = "aboutAccount_Form1";
            this.aboutAccount_Form1.Size = new System.Drawing.Size(1022, 682);
            this.aboutAccount_Form1.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1222, 727);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1222, 727);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button filmManage_Btn;
        private Guna.UI2.WinForms.Guna2Button voucher_Btn;
        private Guna.UI2.WinForms.Guna2Button productManage_Btn;
        private Guna.UI2.WinForms.Guna2Button customerManage_Btn;
        private Guna.UI2.WinForms.Guna2Button staffManage_Btn;
        private Guna.UI2.WinForms.Guna2Button showtimeManage_Btn;
        private Guna.UI2.WinForms.Guna2Button logout_Btn;
        private Guna.UI2.WinForms.Guna2Button profile_Btn;
        private Guna.UI2.WinForms.Guna2Button thongKe_Btn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private AboutAccount_Form aboutAccount_Form1;
        private AboutAccount_Form aboutAccount_Form2;
        private Views.CustomerManagement.CustomerManagementView customerManagementView1;
    }
}

