namespace Cinema_Management_System.Views.ProductManagement
{
    partial class EditProductView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProductView));
            this.choseImage_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameProduct_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.control_Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.purchasepriceError_Txt = new System.Windows.Forms.Label();
            this.purchasePrice_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.acceptProduct_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.quantityError_Txt = new System.Windows.Forms.Label();
            this.quantity_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.poster_Pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.typeProduct_cbb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.reset_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.nameError_Txt = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.typeError_Txt = new System.Windows.Forms.Label();
            this.control_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poster_Pic)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // choseImage_btn
            // 
            this.choseImage_btn.Animated = true;
            this.choseImage_btn.BackColor = System.Drawing.Color.Transparent;
            this.choseImage_btn.BorderRadius = 5;
            this.choseImage_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.choseImage_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.choseImage_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.choseImage_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.choseImage_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.choseImage_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.choseImage_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.choseImage_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.choseImage_btn.ForeColor = System.Drawing.Color.White;
            this.choseImage_btn.Image = global::Cinema_Management_System.Properties.Resources.image_icon;
            this.choseImage_btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.choseImage_btn.Location = new System.Drawing.Point(271, 385);
            this.choseImage_btn.Name = "choseImage_btn";
            this.choseImage_btn.Size = new System.Drawing.Size(112, 39);
            this.choseImage_btn.TabIndex = 163;
            this.choseImage_btn.Text = "Chọn ảnh";
            this.choseImage_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.choseImage_btn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.choseImage_btn.Click += new System.EventHandler(this.choseImage_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 162;
            this.label6.Text = "Loại sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 161;
            this.label5.Text = "Giá nhập (VNĐ / chai, gói)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 160;
            this.label2.Text = "Số lượng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 159;
            this.label3.Text = "Tên sản phẩm";
            // 
            // nameProduct_Txt
            // 
            this.nameProduct_Txt.Animated = true;
            this.nameProduct_Txt.BackColor = System.Drawing.SystemColors.Control;
            this.nameProduct_Txt.BorderColor = System.Drawing.Color.Black;
            this.nameProduct_Txt.BorderRadius = 4;
            this.nameProduct_Txt.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.nameProduct_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameProduct_Txt.DefaultText = "";
            this.nameProduct_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameProduct_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.nameProduct_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameProduct_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameProduct_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.nameProduct_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.nameProduct_Txt.ForeColor = System.Drawing.Color.Black;
            this.nameProduct_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.nameProduct_Txt.Location = new System.Drawing.Point(21, 87);
            this.nameProduct_Txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameProduct_Txt.Name = "nameProduct_Txt";
            this.nameProduct_Txt.PlaceholderText = "";
            this.nameProduct_Txt.SelectedText = "";
            this.nameProduct_Txt.Size = new System.Drawing.Size(221, 34);
            this.nameProduct_Txt.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.nameProduct_Txt.TabIndex = 155;
            // 
            // control_Panel
            // 
            this.control_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.control_Panel.Controls.Add(this.guna2ControlBox1);
            this.control_Panel.Controls.Add(this.label1);
            this.control_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_Panel.Location = new System.Drawing.Point(0, 0);
            this.control_Panel.Name = "control_Panel";
            this.control_Panel.Size = new System.Drawing.Size(524, 37);
            this.control_Panel.TabIndex = 154;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(240)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(464, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sửa sản phẩm";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // purchasepriceError_Txt
            // 
            this.purchasepriceError_Txt.AutoSize = true;
            this.purchasepriceError_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasepriceError_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.purchasepriceError_Txt.Location = new System.Drawing.Point(21, 446);
            this.purchasepriceError_Txt.Name = "purchasepriceError_Txt";
            this.purchasepriceError_Txt.Size = new System.Drawing.Size(41, 17);
            this.purchasepriceError_Txt.TabIndex = 167;
            this.purchasepriceError_Txt.Text = "label1";
            // 
            // purchasePrice_Txt
            // 
            this.purchasePrice_Txt.Animated = true;
            this.purchasePrice_Txt.BackColor = System.Drawing.SystemColors.Control;
            this.purchasePrice_Txt.BorderColor = System.Drawing.Color.Black;
            this.purchasePrice_Txt.BorderRadius = 4;
            this.purchasePrice_Txt.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.purchasePrice_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.purchasePrice_Txt.DefaultText = "";
            this.purchasePrice_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.purchasePrice_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.purchasePrice_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.purchasePrice_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.purchasePrice_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.purchasePrice_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.purchasePrice_Txt.ForeColor = System.Drawing.Color.Black;
            this.purchasePrice_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.purchasePrice_Txt.Location = new System.Drawing.Point(21, 401);
            this.purchasePrice_Txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.purchasePrice_Txt.Name = "purchasePrice_Txt";
            this.purchasePrice_Txt.PlaceholderText = "";
            this.purchasePrice_Txt.SelectedText = "";
            this.purchasePrice_Txt.Size = new System.Drawing.Size(221, 34);
            this.purchasePrice_Txt.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.purchasePrice_Txt.TabIndex = 158;
            // 
            // acceptProduct_Btn
            // 
            this.acceptProduct_Btn.Animated = true;
            this.acceptProduct_Btn.BackColor = System.Drawing.Color.Transparent;
            this.acceptProduct_Btn.BorderRadius = 5;
            this.acceptProduct_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.acceptProduct_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.acceptProduct_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.acceptProduct_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.acceptProduct_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.acceptProduct_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.acceptProduct_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.acceptProduct_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.acceptProduct_Btn.ForeColor = System.Drawing.Color.White;
            this.acceptProduct_Btn.Location = new System.Drawing.Point(262, 446);
            this.acceptProduct_Btn.Name = "acceptProduct_Btn";
            this.acceptProduct_Btn.Size = new System.Drawing.Size(109, 39);
            this.acceptProduct_Btn.TabIndex = 165;
            this.acceptProduct_Btn.Text = "Xong";
            this.acceptProduct_Btn.Click += new System.EventHandler(this.acceptProduct_Btn_Click);
            // 
            // quantityError_Txt
            // 
            this.quantityError_Txt.AutoSize = true;
            this.quantityError_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityError_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.quantityError_Txt.Location = new System.Drawing.Point(21, 342);
            this.quantityError_Txt.Name = "quantityError_Txt";
            this.quantityError_Txt.Size = new System.Drawing.Size(41, 17);
            this.quantityError_Txt.TabIndex = 166;
            this.quantityError_Txt.Text = "label1";
            // 
            // quantity_Txt
            // 
            this.quantity_Txt.Animated = true;
            this.quantity_Txt.BackColor = System.Drawing.SystemColors.Control;
            this.quantity_Txt.BorderColor = System.Drawing.Color.Black;
            this.quantity_Txt.BorderRadius = 4;
            this.quantity_Txt.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.quantity_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantity_Txt.DefaultText = "";
            this.quantity_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.quantity_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.quantity_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quantity_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.quantity_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.quantity_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.quantity_Txt.ForeColor = System.Drawing.Color.Black;
            this.quantity_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.quantity_Txt.Location = new System.Drawing.Point(21, 297);
            this.quantity_Txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quantity_Txt.Name = "quantity_Txt";
            this.quantity_Txt.PlaceholderText = "";
            this.quantity_Txt.SelectedText = "";
            this.quantity_Txt.Size = new System.Drawing.Size(221, 34);
            this.quantity_Txt.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.quantity_Txt.TabIndex = 156;
            // 
            // poster_Pic
            // 
            this.poster_Pic.FillColor = System.Drawing.Color.WhiteSmoke;
            this.poster_Pic.ImageRotate = 0F;
            this.poster_Pic.Location = new System.Drawing.Point(3, 2);
            this.poster_Pic.Name = "poster_Pic";
            this.poster_Pic.Size = new System.Drawing.Size(228, 277);
            this.poster_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poster_Pic.TabIndex = 0;
            this.poster_Pic.TabStop = false;
            // 
            // typeProduct_cbb
            // 
            this.typeProduct_cbb.BackColor = System.Drawing.Color.Transparent;
            this.typeProduct_cbb.BorderColor = System.Drawing.Color.Black;
            this.typeProduct_cbb.BorderRadius = 4;
            this.typeProduct_cbb.DisplayMember = "Value";
            this.typeProduct_cbb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.typeProduct_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeProduct_cbb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.typeProduct_cbb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.typeProduct_cbb.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.typeProduct_cbb.ForeColor = System.Drawing.Color.Black;
            this.typeProduct_cbb.ItemHeight = 30;
            this.typeProduct_cbb.Items.AddRange(new object[] {
            "Đồ ăn ",
            "Nước uống"});
            this.typeProduct_cbb.Location = new System.Drawing.Point(21, 191);
            this.typeProduct_cbb.Name = "typeProduct_cbb";
            this.typeProduct_cbb.Size = new System.Drawing.Size(221, 36);
            this.typeProduct_cbb.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.typeProduct_cbb.TabIndex = 157;
            this.typeProduct_cbb.ValueMember = "Value";
            // 
            // reset_btn
            // 
            this.reset_btn.Animated = true;
            this.reset_btn.BackColor = System.Drawing.Color.Transparent;
            this.reset_btn.BorderRadius = 5;
            this.reset_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reset_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reset_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reset_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reset_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reset_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.reset_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.reset_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.reset_btn.ForeColor = System.Drawing.Color.White;
            this.reset_btn.Location = new System.Drawing.Point(403, 446);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(109, 39);
            this.reset_btn.TabIndex = 171;
            this.reset_btn.Text = "Làm mới";
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // nameError_Txt
            // 
            this.nameError_Txt.AutoSize = true;
            this.nameError_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameError_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.nameError_Txt.Location = new System.Drawing.Point(21, 132);
            this.nameError_Txt.Name = "nameError_Txt";
            this.nameError_Txt.Size = new System.Drawing.Size(41, 17);
            this.nameError_Txt.TabIndex = 170;
            this.nameError_Txt.Text = "label1";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.poster_Pic);
            this.guna2Panel2.Location = new System.Drawing.Point(274, 87);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(234, 282);
            this.guna2Panel2.TabIndex = 169;
            // 
            // typeError_Txt
            // 
            this.typeError_Txt.AutoSize = true;
            this.typeError_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeError_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.typeError_Txt.Location = new System.Drawing.Point(18, 230);
            this.typeError_Txt.Name = "typeError_Txt";
            this.typeError_Txt.Size = new System.Drawing.Size(41, 17);
            this.typeError_Txt.TabIndex = 172;
            this.typeError_Txt.Text = "label1";
            // 
            // EditProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 509);
            this.Controls.Add(this.typeError_Txt);
            this.Controls.Add(this.choseImage_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameProduct_Txt);
            this.Controls.Add(this.control_Panel);
            this.Controls.Add(this.purchasepriceError_Txt);
            this.Controls.Add(this.purchasePrice_Txt);
            this.Controls.Add(this.acceptProduct_Btn);
            this.Controls.Add(this.quantityError_Txt);
            this.Controls.Add(this.quantity_Txt);
            this.Controls.Add(this.typeProduct_cbb);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.nameError_Txt);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProductView";
            this.Text = "EditProductView";
            this.Load += new System.EventHandler(this.EditProductView_Load);
            this.control_Panel.ResumeLayout(false);
            this.control_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poster_Pic)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton choseImage_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox nameProduct_Txt;
        private Guna.UI2.WinForms.Guna2Panel control_Panel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label purchasepriceError_Txt;
        private Guna.UI2.WinForms.Guna2TextBox purchasePrice_Txt;
        private Guna.UI2.WinForms.Guna2GradientButton acceptProduct_Btn;
        private System.Windows.Forms.Label quantityError_Txt;
        private Guna.UI2.WinForms.Guna2TextBox quantity_Txt;
        private Guna.UI2.WinForms.Guna2PictureBox poster_Pic;
        private Guna.UI2.WinForms.Guna2ComboBox typeProduct_cbb;
        private Guna.UI2.WinForms.Guna2GradientButton reset_btn;
        private System.Windows.Forms.Label nameError_Txt;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label typeError_Txt;
    }
}