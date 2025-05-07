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
            this.control_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.slidebar_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.name_Txt = new System.Windows.Forms.Label();
            this.usercontrol_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.statisticsView1 = new Cinema_Management_System.Views.Statistics.StatisticsView();
            this.staffManagementView1 = new Cinema_Management_System.Views.StaffManagement.StaffManagementView();
            this.productManagementView1 = new Cinema_Management_System.Views.ProductManagement.ProductManagementView();
            this.movieManagementView1 = new Cinema_Management_System.Views.MovieManagement.MovieManagementView();
            this.customerManagementView1 = new Cinema_Management_System.Views.CustomerManagement.CustomerManagementView();
            this.aboutAccount_Form1 = new Cinema_Management_System.AboutAccount_Form();
            this.showTimeManagementyForm1 = new Cinema_Management_System.Views.ShowTimeManagement.ShowTimeManagementyForm();
            this.avatar_pic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.logout_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.profile_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.thongKe_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.productManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.customerManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.staffManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.showtimeManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.filmManage_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.control_Panel.SuspendLayout();
            this.slidebar_Panel.SuspendLayout();
            this.usercontrol_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // control_Panel
            // 
            this.control_Panel.BackColor = System.Drawing.SystemColors.Info;
            this.control_Panel.Controls.Add(this.pictureBox1);
            this.control_Panel.Controls.Add(this.guna2ControlBox2);
            this.control_Panel.Controls.Add(this.guna2ControlBox1);
            this.control_Panel.Controls.Add(this.label2);
            this.control_Panel.Controls.Add(this.label1);
            this.control_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_Panel.Location = new System.Drawing.Point(0, 0);
            this.control_Panel.Name = "control_Panel";
            this.control_Panel.Size = new System.Drawing.Size(1540, 46);
            this.control_Panel.TabIndex = 0;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.SystemColors.Info;
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1435, 4);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(51, 39);
            this.guna2ControlBox2.TabIndex = 5;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.SystemColors.Info;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1485, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(52, 39);
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
            // slidebar_Panel
            // 
            this.slidebar_Panel.BackColor = System.Drawing.Color.White;
            this.slidebar_Panel.Controls.Add(this.avatar_pic);
            this.slidebar_Panel.Controls.Add(this.name_Txt);
            this.slidebar_Panel.Controls.Add(this.logout_Btn);
            this.slidebar_Panel.Controls.Add(this.profile_Btn);
            this.slidebar_Panel.Controls.Add(this.thongKe_Btn);
            this.slidebar_Panel.Controls.Add(this.productManage_Btn);
            this.slidebar_Panel.Controls.Add(this.customerManage_Btn);
            this.slidebar_Panel.Controls.Add(this.staffManage_Btn);
            this.slidebar_Panel.Controls.Add(this.showtimeManage_Btn);
            this.slidebar_Panel.Controls.Add(this.filmManage_Btn);
            this.slidebar_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidebar_Panel.Location = new System.Drawing.Point(0, 46);
            this.slidebar_Panel.Name = "slidebar_Panel";
            this.slidebar_Panel.Size = new System.Drawing.Size(211, 799);
            this.slidebar_Panel.TabIndex = 1;
            // 
            // name_Txt
            // 
            this.name_Txt.AutoSize = true;
            this.name_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.name_Txt.Location = new System.Drawing.Point(70, 141);
            this.name_Txt.Name = "name_Txt";
            this.name_Txt.Size = new System.Drawing.Size(70, 21);
            this.name_Txt.TabIndex = 14;
            this.name_Txt.Text = "Tên user";
            // 
            // usercontrol_Panel
            // 
            this.usercontrol_Panel.Controls.Add(this.statisticsView1);
            this.usercontrol_Panel.Controls.Add(this.staffManagementView1);
            this.usercontrol_Panel.Controls.Add(this.productManagementView1);
            this.usercontrol_Panel.Controls.Add(this.movieManagementView1);
            this.usercontrol_Panel.Controls.Add(this.customerManagementView1);
            this.usercontrol_Panel.Controls.Add(this.aboutAccount_Form1);
            this.usercontrol_Panel.Controls.Add(this.showTimeManagementyForm1);
            this.usercontrol_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usercontrol_Panel.Location = new System.Drawing.Point(211, 46);
            this.usercontrol_Panel.Name = "usercontrol_Panel";
            this.usercontrol_Panel.Size = new System.Drawing.Size(1329, 799);
            this.usercontrol_Panel.TabIndex = 2;
            // 
            // statisticsView1
            // 
            this.statisticsView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsView1.Location = new System.Drawing.Point(0, 0);
            this.statisticsView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.statisticsView1.Name = "statisticsView1";
            this.statisticsView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statisticsView1.Size = new System.Drawing.Size(1329, 799);
            this.statisticsView1.TabIndex = 9;
            // 
            // staffManagementView1
            // 
            this.staffManagementView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staffManagementView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.staffManagementView1.Location = new System.Drawing.Point(0, 0);
            this.staffManagementView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.staffManagementView1.Name = "staffManagementView1";
            this.staffManagementView1.Size = new System.Drawing.Size(1329, 799);
            this.staffManagementView1.TabIndex = 8;
            // 
            // productManagementView1
            // 
            this.productManagementView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productManagementView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.productManagementView1.Location = new System.Drawing.Point(0, 0);
            this.productManagementView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.productManagementView1.Name = "productManagementView1";
            this.productManagementView1.Size = new System.Drawing.Size(1329, 799);
            this.productManagementView1.TabIndex = 6;
            // 
            // movieManagementView1
            // 
            this.movieManagementView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movieManagementView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.movieManagementView1.Location = new System.Drawing.Point(0, 0);
            this.movieManagementView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.movieManagementView1.Name = "movieManagementView1";
            this.movieManagementView1.Size = new System.Drawing.Size(1329, 799);
            this.movieManagementView1.TabIndex = 5;
            // 
            // customerManagementView1
            // 
            this.customerManagementView1.BackColor = System.Drawing.SystemColors.Control;
            this.customerManagementView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerManagementView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.customerManagementView1.ForeColor = System.Drawing.Color.Black;
            this.customerManagementView1.Location = new System.Drawing.Point(0, 0);
            this.customerManagementView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.customerManagementView1.Name = "customerManagementView1";
            this.customerManagementView1.Size = new System.Drawing.Size(1329, 799);
            this.customerManagementView1.TabIndex = 4;
            // 
            // aboutAccount_Form1
            // 
            this.aboutAccount_Form1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutAccount_Form1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutAccount_Form1.Location = new System.Drawing.Point(0, 0);
            this.aboutAccount_Form1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutAccount_Form1.Name = "aboutAccount_Form1";
            this.aboutAccount_Form1.Size = new System.Drawing.Size(1329, 799);
            this.aboutAccount_Form1.TabIndex = 3;
            // 
            // showTimeManagementyForm1
            // 
            this.showTimeManagementyForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showTimeManagementyForm1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.showTimeManagementyForm1.Location = new System.Drawing.Point(0, 0);
            this.showTimeManagementyForm1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showTimeManagementyForm1.Name = "showTimeManagementyForm1";
            this.showTimeManagementyForm1.Size = new System.Drawing.Size(1329, 799);
            this.showTimeManagementyForm1.TabIndex = 2;
            // 
            // avatar_pic
            // 
            this.avatar_pic.BackColor = System.Drawing.Color.Transparent;
            this.avatar_pic.ImageRotate = 0F;
            this.avatar_pic.Location = new System.Drawing.Point(60, 47);
            this.avatar_pic.Name = "avatar_pic";
            this.avatar_pic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.avatar_pic.Size = new System.Drawing.Size(83, 83);
            this.avatar_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatar_pic.TabIndex = 13;
            this.avatar_pic.TabStop = false;
            this.avatar_pic.UseTransparentBackground = true;
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
            this.logout_Btn.Location = new System.Drawing.Point(12, 764);
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
            this.profile_Btn.Location = new System.Drawing.Point(12, 713);
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
            this.thongKe_Btn.FillColor = System.Drawing.Color.Transparent;
            this.thongKe_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.thongKe_Btn.ForeColor = System.Drawing.Color.Black;
            this.thongKe_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.thongKe_Btn.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongKe_Btn.HoverState.ForeColor = System.Drawing.Color.White;
            this.thongKe_Btn.Image = global::Cinema_Management_System.Properties.Resources.data;
            this.thongKe_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.thongKe_Btn.Location = new System.Drawing.Point(11, 478);
            this.thongKe_Btn.Name = "thongKe_Btn";
            this.thongKe_Btn.Size = new System.Drawing.Size(174, 45);
            this.thongKe_Btn.TabIndex = 10;
            this.thongKe_Btn.Text = "Thống Kê";
            this.thongKe_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.thongKe_Btn.UseTransparentBackground = true;
            this.thongKe_Btn.Click += new System.EventHandler(this.thongKe_Btn_Click);
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
            this.productManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.icons8_food_and_drink_32;
            this.productManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productManage_Btn.Location = new System.Drawing.Point(11, 427);
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
            this.customerManage_Btn.Location = new System.Drawing.Point(11, 376);
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
            this.staffManage_Btn.Image = global::Cinema_Management_System.Properties.Resources.icons8_person_322;
            this.staffManage_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.staffManage_Btn.Location = new System.Drawing.Point(11, 325);
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
            this.showtimeManage_Btn.Location = new System.Drawing.Point(11, 274);
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
            this.filmManage_Btn.Location = new System.Drawing.Point(12, 223);
            this.filmManage_Btn.Name = "filmManage_Btn";
            this.filmManage_Btn.Size = new System.Drawing.Size(174, 45);
            this.filmManage_Btn.TabIndex = 0;
            this.filmManage_Btn.Text = "Quản Lý Phim";
            this.filmManage_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filmManage_Btn.UseTransparentBackground = true;
            this.filmManage_Btn.Click += new System.EventHandler(this.filmManage_Btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cinema_Management_System.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(11, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.usercontrol_Panel);
            this.Controls.Add(this.slidebar_Panel);
            this.Controls.Add(this.control_Panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1540, 884);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.control_Panel.ResumeLayout(false);
            this.control_Panel.PerformLayout();
            this.slidebar_Panel.ResumeLayout(false);
            this.slidebar_Panel.PerformLayout();
            this.usercontrol_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel control_Panel;
        private Guna.UI2.WinForms.Guna2Panel slidebar_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button filmManage_Btn;
        private Guna.UI2.WinForms.Guna2Button productManage_Btn;
        private Guna.UI2.WinForms.Guna2Button customerManage_Btn;
        private Guna.UI2.WinForms.Guna2Button staffManage_Btn;
        private Guna.UI2.WinForms.Guna2Button showtimeManage_Btn;
        private Guna.UI2.WinForms.Guna2Button logout_Btn;
        private Guna.UI2.WinForms.Guna2Button profile_Btn;
        private Guna.UI2.WinForms.Guna2Button thongKe_Btn;
        private Guna.UI2.WinForms.Guna2Panel usercontrol_Panel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox avatar_pic;
        private System.Windows.Forms.Label name_Txt;
        private Views.ShowTimeManagement.ShowTimeManagementyForm showTimeManagementyForm1;
        private Views.MovieManagement.MovieManagementView movieManagementView1;
        private Views.CustomerManagement.CustomerManagementView customerManagementView1;
        private AboutAccount_Form aboutAccount_Form1;
        private Views.ProductManagement.ProductManagementView productManagementView1;
        private Views.StaffManagement.StaffManagementView staffManagementView1;
        private Views.Statistics.StatisticsView statisticsView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        //private Views.ProductManagement.ProductManagementView productManagementView1;
    }
}

