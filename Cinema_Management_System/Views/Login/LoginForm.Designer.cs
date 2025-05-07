namespace Cinema_Management_System
{
    partial class LoginForm
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
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.close_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.hide_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.posterPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.forgetpassword_Txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.showMess_label = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.hide_Pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.password_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.username_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posterPic)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // close_Btn
            // 
            this.close_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Btn.Animated = true;
            this.guna2Transition1.SetDecoration(this.close_Btn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.close_Btn.FillColor = System.Drawing.Color.White;
            this.close_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.close_Btn.IconColor = System.Drawing.Color.DimGray;
            this.close_Btn.Location = new System.Drawing.Point(869, 12);
            this.close_Btn.Name = "close_Btn";
            this.close_Btn.Size = new System.Drawing.Size(45, 29);
            this.close_Btn.TabIndex = 6;
            this.close_Btn.Click += new System.EventHandler(this.close_Btn_Click);
            // 
            // hide_Btn
            // 
            this.hide_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hide_Btn.Animated = true;
            this.hide_Btn.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2Transition1.SetDecoration(this.hide_Btn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.hide_Btn.FillColor = System.Drawing.Color.White;
            this.hide_Btn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hide_Btn.ForeColor = System.Drawing.Color.Black;
            this.hide_Btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.hide_Btn.IconColor = System.Drawing.Color.DimGray;
            this.hide_Btn.Location = new System.Drawing.Point(827, 12);
            this.hide_Btn.Name = "hide_Btn";
            this.hide_Btn.Size = new System.Drawing.Size(45, 29);
            this.hide_Btn.TabIndex = 7;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.posterPic);
            this.guna2Transition1.SetDecoration(this.guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(442, 589);
            this.guna2Panel2.TabIndex = 9;
            // 
            // posterPic
            // 
            this.guna2Transition1.SetDecoration(this.posterPic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.posterPic.ImageRotate = 0F;
            this.posterPic.Location = new System.Drawing.Point(-3, -10);
            this.posterPic.Name = "posterPic";
            this.posterPic.Size = new System.Drawing.Size(442, 600);
            this.posterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.posterPic.TabIndex = 0;
            this.posterPic.TabStop = false;
            // 
            // forgetpassword_Txt
            // 
            this.forgetpassword_Txt.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.forgetpassword_Txt, Guna.UI2.AnimatorNS.DecorationType.None);
            this.forgetpassword_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetpassword_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.forgetpassword_Txt.Location = new System.Drawing.Point(214, 257);
            this.forgetpassword_Txt.Name = "forgetpassword_Txt";
            this.forgetpassword_Txt.Size = new System.Drawing.Size(111, 19);
            this.forgetpassword_Txt.TabIndex = 4;
            this.forgetpassword_Txt.Text = "Quên mật khẩu?";
            this.forgetpassword_Txt.Click += new System.EventHandler(this.forgetpassword_Txt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.label2.Location = new System.Drawing.Point(56, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đăng nhập tài khoản";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.UseWaitCursor = true;
            // 
            // login_Btn
            // 
            this.login_Btn.Animated = true;
            this.login_Btn.AutoRoundedCorners = true;
            this.guna2Transition1.SetDecoration(this.login_Btn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.login_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.login_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.login_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.login_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.login_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.login_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.login_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.login_Btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.login_Btn.ForeColor = System.Drawing.Color.White;
            this.login_Btn.Location = new System.Drawing.Point(60, 331);
            this.login_Btn.Name = "login_Btn";
            this.login_Btn.Size = new System.Drawing.Size(263, 45);
            this.login_Btn.TabIndex = 3;
            this.login_Btn.Text = "Đăng Nhập";
            this.login_Btn.Click += new System.EventHandler(this.login_Btn_Click);
            // 
            // showMess_label
            // 
            this.showMess_label.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.showMess_label, Guna.UI2.AnimatorNS.DecorationType.None);
            this.showMess_label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMess_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.showMess_label.Location = new System.Drawing.Point(57, 294);
            this.showMess_label.Name = "showMess_label";
            this.showMess_label.Size = new System.Drawing.Size(41, 17);
            this.showMess_label.TabIndex = 6;
            this.showMess_label.Text = "label1";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.hide_Pic);
            this.guna2Panel1.Controls.Add(this.showMess_label);
            this.guna2Panel1.Controls.Add(this.password_Txt);
            this.guna2Panel1.Controls.Add(this.login_Btn);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.forgetpassword_Txt);
            this.guna2Panel1.Controls.Add(this.username_Txt);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(494, 75);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.guna2Panel1.ShadowDecoration.Depth = 15;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(7);
            this.guna2Panel1.Size = new System.Drawing.Size(378, 450);
            this.guna2Panel1.TabIndex = 8;
            // 
            // hide_Pic
            // 
            this.hide_Pic.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.hide_Pic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.hide_Pic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.hide_Pic.Image = global::Cinema_Management_System.Properties.Resources.eye;
            this.hide_Pic.ImageRotate = 0F;
            this.hide_Pic.Location = new System.Drawing.Point(285, 203);
            this.hide_Pic.Name = "hide_Pic";
            this.hide_Pic.Size = new System.Drawing.Size(25, 24);
            this.hide_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hide_Pic.TabIndex = 7;
            this.hide_Pic.TabStop = false;
            this.hide_Pic.UseTransparentBackground = true;
            this.hide_Pic.Click += new System.EventHandler(this.hide_Pic_Click);
            // 
            // password_Txt
            // 
            this.password_Txt.Animated = true;
            this.password_Txt.BorderRadius = 8;
            this.password_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.password_Txt, Guna.UI2.AnimatorNS.DecorationType.None);
            this.password_Txt.DefaultText = "Abc123@@";
            this.password_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.password_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_Txt.ForeColor = System.Drawing.Color.Black;
            this.password_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.password_Txt.IconLeft = global::Cinema_Management_System.Properties.Resources.icons8_lock_32;
            this.password_Txt.Location = new System.Drawing.Point(60, 190);
            this.password_Txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password_Txt.Name = "password_Txt";
            this.password_Txt.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.password_Txt.PlaceholderText = "Mật khẩu";
            this.password_Txt.SelectedText = "";
            this.password_Txt.Size = new System.Drawing.Size(263, 48);
            this.password_Txt.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.password_Txt.TabIndex = 2;
            // 
            // username_Txt
            // 
            this.username_Txt.Animated = true;
            this.username_Txt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.username_Txt.BorderRadius = 8;
            this.username_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.username_Txt, Guna.UI2.AnimatorNS.DecorationType.None);
            this.username_Txt.DefaultText = "admin";
            this.username_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.username_Txt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_Txt.ForeColor = System.Drawing.Color.Black;
            this.username_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.username_Txt.IconLeft = global::Cinema_Management_System.Properties.Resources.icons8_person_322;
            this.username_Txt.Location = new System.Drawing.Point(60, 123);
            this.username_Txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username_Txt.Name = "username_Txt";
            this.username_Txt.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.username_Txt.PlaceholderText = "Tên đăng nhập";
            this.username_Txt.SelectedText = "";
            this.username_Txt.Size = new System.Drawing.Size(263, 48);
            this.username_Txt.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.username_Txt.TabIndex = 1;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.ScaleAndRotate;
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0.5F;
            animation1.RotateLimit = 0.2F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 589);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.hide_Btn);
            this.Controls.Add(this.close_Btn);
            this.Controls.Add(this.guna2Panel1);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.posterPic)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hide_Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2PictureBox posterPic;
        private Guna.UI2.WinForms.Guna2ControlBox hide_Btn;
        private Guna.UI2.WinForms.Guna2ControlBox close_Btn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox hide_Pic;
        private System.Windows.Forms.Label showMess_label;
        private Guna.UI2.WinForms.Guna2TextBox username_Txt;
        private Guna.UI2.WinForms.Guna2TextBox password_Txt;
        private Guna.UI2.WinForms.Guna2GradientButton login_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label forgetpassword_Txt;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
    }
}