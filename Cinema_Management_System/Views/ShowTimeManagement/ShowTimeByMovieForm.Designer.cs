namespace Cinema_Management_System.Views.ShowTimeManagement
{
    partial class ShowTimeByMovieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowTimeByMovieForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.seatForShowTineUC1 = new Cinema_Management_System.Views.ShowTimeManagement.SeatForShowTineUC();
            this.FLP_ShowTimeFoerMovie = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_showTimes = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_DescribeMovie = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Genre = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Country = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Length = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_Director = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_MovieName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PB_imageMovie = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_Exit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btn_Back = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_imageMovie)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.seatForShowTineUC1);
            this.panel1.Controls.Add(this.FLP_ShowTimeFoerMovie);
            this.panel1.Controls.Add(this.panel_showTimes);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txt_Genre);
            this.panel1.Controls.Add(this.txt_Country);
            this.panel1.Controls.Add(this.txt_Length);
            this.panel1.Controls.Add(this.guna2HtmlLabel5);
            this.panel1.Controls.Add(this.guna2HtmlLabel4);
            this.panel1.Controls.Add(this.guna2HtmlLabel3);
            this.panel1.Controls.Add(this.txt_Director);
            this.panel1.Controls.Add(this.guna2HtmlLabel2);
            this.panel1.Controls.Add(this.txt_MovieName);
            this.panel1.Controls.Add(this.guna2HtmlLabel1);
            this.panel1.Controls.Add(this.PB_imageMovie);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 835);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // seatForShowTineUC1
            // 
            this.seatForShowTineUC1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.seatForShowTineUC1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.seatForShowTineUC1.Location = new System.Drawing.Point(5, 324);
            this.seatForShowTineUC1.Margin = new System.Windows.Forms.Padding(4);
            this.seatForShowTineUC1.Name = "seatForShowTineUC1";
            this.seatForShowTineUC1.Size = new System.Drawing.Size(802, 498);
            this.seatForShowTineUC1.TabIndex = 13;
            // 
            // FLP_ShowTimeFoerMovie
            // 
            this.FLP_ShowTimeFoerMovie.AutoScroll = true;
            this.FLP_ShowTimeFoerMovie.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FLP_ShowTimeFoerMovie.Location = new System.Drawing.Point(8, 325);
            this.FLP_ShowTimeFoerMovie.Margin = new System.Windows.Forms.Padding(4);
            this.FLP_ShowTimeFoerMovie.Name = "FLP_ShowTimeFoerMovie";
            this.FLP_ShowTimeFoerMovie.Size = new System.Drawing.Size(794, 490);
            this.FLP_ShowTimeFoerMovie.TabIndex = 1;
            // 
            // panel_showTimes
            // 
            this.panel_showTimes.Location = new System.Drawing.Point(5, 334);
            this.panel_showTimes.Name = "panel_showTimes";
            this.panel_showTimes.Size = new System.Drawing.Size(802, 498);
            this.panel_showTimes.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_DescribeMovie);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(233, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 130);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giới thiệu phim";
            // 
            // txt_DescribeMovie
            // 
            this.txt_DescribeMovie.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_DescribeMovie.BorderColor = System.Drawing.Color.Black;
            this.txt_DescribeMovie.BorderThickness = 0;
            this.txt_DescribeMovie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_DescribeMovie.DefaultText = "";
            this.txt_DescribeMovie.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_DescribeMovie.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_DescribeMovie.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_DescribeMovie.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_DescribeMovie.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_DescribeMovie.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_DescribeMovie.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_DescribeMovie.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_DescribeMovie.Location = new System.Drawing.Point(0, 19);
            this.txt_DescribeMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_DescribeMovie.Multiline = true;
            this.txt_DescribeMovie.Name = "txt_DescribeMovie";
            this.txt_DescribeMovie.PlaceholderText = "";
            this.txt_DescribeMovie.ReadOnly = true;
            this.txt_DescribeMovie.SelectedText = "";
            this.txt_DescribeMovie.Size = new System.Drawing.Size(569, 104);
            this.txt_DescribeMovie.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_DescribeMovie.TabIndex = 11;
            // 
            // txt_Genre
            // 
            this.txt_Genre.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Genre.BorderColor = System.Drawing.Color.Black;
            this.txt_Genre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Genre.DefaultText = "";
            this.txt_Genre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Genre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Genre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Genre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Genre.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Genre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Genre.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_Genre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Genre.Location = new System.Drawing.Point(619, 149);
            this.txt_Genre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Genre.Name = "txt_Genre";
            this.txt_Genre.PlaceholderText = "";
            this.txt_Genre.ReadOnly = true;
            this.txt_Genre.SelectedText = "";
            this.txt_Genre.Size = new System.Drawing.Size(187, 32);
            this.txt_Genre.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Genre.TabIndex = 10;
            // 
            // txt_Country
            // 
            this.txt_Country.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Country.BorderColor = System.Drawing.Color.Black;
            this.txt_Country.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Country.DefaultText = "";
            this.txt_Country.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Country.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Country.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Country.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Country.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Country.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Country.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_Country.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Country.Location = new System.Drawing.Point(413, 149);
            this.txt_Country.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.PlaceholderText = "";
            this.txt_Country.ReadOnly = true;
            this.txt_Country.SelectedText = "";
            this.txt_Country.Size = new System.Drawing.Size(163, 32);
            this.txt_Country.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Country.TabIndex = 9;
            // 
            // txt_Length
            // 
            this.txt_Length.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Length.BorderColor = System.Drawing.Color.Black;
            this.txt_Length.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Length.DefaultText = "";
            this.txt_Length.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Length.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Length.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Length.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Length.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Length.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Length.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_Length.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Length.Location = new System.Drawing.Point(233, 149);
            this.txt_Length.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Length.Name = "txt_Length";
            this.txt_Length.PlaceholderText = "";
            this.txt_Length.ReadOnly = true;
            this.txt_Length.SelectedText = "";
            this.txt_Length.Size = new System.Drawing.Size(154, 32);
            this.txt_Length.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Length.TabIndex = 8;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(619, 119);
            this.guna2HtmlLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(61, 22);
            this.guna2HtmlLabel5.TabIndex = 7;
            this.guna2HtmlLabel5.Text = "Thể loại:";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(413, 119);
            this.guna2HtmlLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(68, 22);
            this.guna2HtmlLabel4.TabIndex = 6;
            this.guna2HtmlLabel4.Text = "Quốc gia:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(233, 119);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(81, 22);
            this.guna2HtmlLabel3.TabIndex = 5;
            this.guna2HtmlLabel3.Text = "Thời lượng:";
            // 
            // txt_Director
            // 
            this.txt_Director.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Director.BorderColor = System.Drawing.Color.Black;
            this.txt_Director.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Director.DefaultText = "";
            this.txt_Director.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Director.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Director.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Director.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Director.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Director.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Director.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_Director.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Director.Location = new System.Drawing.Point(619, 71);
            this.txt_Director.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Director.Name = "txt_Director";
            this.txt_Director.PlaceholderText = "";
            this.txt_Director.ReadOnly = true;
            this.txt_Director.SelectedText = "";
            this.txt_Director.Size = new System.Drawing.Size(187, 36);
            this.txt_Director.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Director.TabIndex = 4;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(619, 50);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(69, 22);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "Đạo diễn:";
            // 
            // txt_MovieName
            // 
            this.txt_MovieName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_MovieName.BorderColor = System.Drawing.Color.Black;
            this.txt_MovieName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MovieName.DefaultText = "";
            this.txt_MovieName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MovieName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MovieName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MovieName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MovieName.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_MovieName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MovieName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.txt_MovieName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MovieName.Location = new System.Drawing.Point(233, 75);
            this.txt_MovieName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_MovieName.Name = "txt_MovieName";
            this.txt_MovieName.PlaceholderText = "";
            this.txt_MovieName.ReadOnly = true;
            this.txt_MovieName.SelectedText = "";
            this.txt_MovieName.Size = new System.Drawing.Size(343, 32);
            this.txt_MovieName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_MovieName.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(233, 50);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(71, 22);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Tên phim:";
            // 
            // PB_imageMovie
            // 
            this.PB_imageMovie.FillColor = System.Drawing.Color.Silver;
            this.PB_imageMovie.ImageRotate = 0F;
            this.PB_imageMovie.Location = new System.Drawing.Point(8, 43);
            this.PB_imageMovie.Margin = new System.Windows.Forms.Padding(4);
            this.PB_imageMovie.Name = "PB_imageMovie";
            this.PB_imageMovie.Size = new System.Drawing.Size(218, 273);
            this.PB_imageMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_imageMovie.TabIndex = 0;
            this.PB_imageMovie.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.guna2Panel1.Controls.Add(this.btn_Exit);
            this.guna2Panel1.Controls.Add(this.btn_Back);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(811, 43);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BorderRadius = 5;
            this.btn_Exit.BorderThickness = 1;
            this.btn_Exit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.btn_Exit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.btn_Exit.HoverState.IconColor = System.Drawing.Color.White;
            this.btn_Exit.IconColor = System.Drawing.Color.DimGray;
            this.btn_Exit.Location = new System.Drawing.Point(754, 3);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(45, 30);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click_1);
            // 
            // btn_Back
            // 
            this.btn_Back.BorderRadius = 5;
            this.btn_Back.BorderThickness = 1;
            this.btn_Back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.btn_Back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Back.ForeColor = System.Drawing.Color.Black;
            this.btn_Back.Image = global::Cinema_Management_System.Properties.Resources.icons8_left_50;
            this.btn_Back.Location = new System.Drawing.Point(700, 3);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(47, 30);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(20, 3);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(98, 30);
            this.guna2HtmlLabel6.TabIndex = 3;
            this.guna2HtmlLabel6.Text = "Suất chiếu";
            // 
            // ShowTimeByMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(811, 835);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowTimeByMovieForm";
            this.Text = "ShowTimeByMovieForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_imageMovie)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox PB_imageMovie;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_MovieName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txt_DescribeMovie;
        private Guna.UI2.WinForms.Guna2TextBox txt_Genre;
        private Guna.UI2.WinForms.Guna2TextBox txt_Country;
        private Guna.UI2.WinForms.Guna2TextBox txt_Length;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txt_Director;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Button btn_Back;
        private System.Windows.Forms.FlowLayoutPanel FLP_ShowTimeFoerMovie;
        private System.Windows.Forms.Panel panel_showTimes;
        private SeatForShowTineUC seatForShowTineUC1;
        private Guna.UI2.WinForms.Guna2ControlBox btn_Exit;
        //private SeatForShowTineUC seatForShowTineUC1;
        //private Cinema_Management_System.Views.ShowTimeManagement.SeatForShowTineUC seatForShowTineUC1;

    }
}