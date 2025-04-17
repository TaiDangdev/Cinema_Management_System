namespace Cinema_Management_System.Views.MessageBox
{
    partial class YesMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesMessage));
            this.panel_Title = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.close_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.title_txt = new System.Windows.Forms.Label();
            this.message_Txt = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ok_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.yes_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.no_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.icon_pic = new System.Windows.Forms.PictureBox();
            this.panel_Message = new System.Windows.Forms.Panel();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_pic)).BeginInit();
            this.panel_Message.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.Controls.Add(this.close_Btn);
            this.panel_Title.Controls.Add(this.guna2PictureBox1);
            this.panel_Title.Controls.Add(this.title_txt);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.panel_Title.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(355, 43);
            this.panel_Title.TabIndex = 0;
            // 
            // close_Btn
            // 
            this.close_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Btn.BackColor = System.Drawing.Color.Transparent;
            this.close_Btn.FillColor = System.Drawing.Color.Transparent;
            this.close_Btn.IconColor = System.Drawing.Color.White;
            this.close_Btn.Location = new System.Drawing.Point(304, 8);
            this.close_Btn.Name = "close_Btn";
            this.close_Btn.Size = new System.Drawing.Size(45, 29);
            this.close_Btn.TabIndex = 3;
            this.close_Btn.Click += new System.EventHandler(this.close_Btn_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            //this.guna2PictureBox1.Image = global::Cinema_Management_System.Properties.Resources.icons8_cinema_ticket_32;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(7, 10);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(26, 24);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // title_txt
            // 
            this.title_txt.AutoSize = true;
            this.title_txt.BackColor = System.Drawing.Color.Transparent;
            this.title_txt.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_txt.ForeColor = System.Drawing.Color.White;
            this.title_txt.Location = new System.Drawing.Point(40, 10);
            this.title_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(103, 25);
            this.title_txt.TabIndex = 2;
            this.title_txt.Text = "Thông báo";
            // 
            // message_Txt
            // 
            this.message_Txt.AutoSize = true;
            this.message_Txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.message_Txt.Location = new System.Drawing.Point(3, 7);
            this.message_Txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.message_Txt.Name = "message_Txt";
            this.message_Txt.Size = new System.Drawing.Size(52, 21);
            this.message_Txt.TabIndex = 1;
            this.message_Txt.Text = "label1";
            this.message_Txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.DimGray;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // ok_Btn
            // 
            this.ok_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ok_Btn.Animated = true;
            this.ok_Btn.AutoRoundedCorners = true;
            this.ok_Btn.BorderRadius = 16;
            this.ok_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ok_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ok_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ok_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ok_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ok_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.ok_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.ok_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ok_Btn.ForeColor = System.Drawing.Color.White;
            this.ok_Btn.Location = new System.Drawing.Point(130, 101);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Size = new System.Drawing.Size(73, 34);
            this.ok_Btn.TabIndex = 2;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.yes_Btn);
            this.panel1.Controls.Add(this.no_Btn);
            this.panel1.Controls.Add(this.icon_pic);
            this.panel1.Controls.Add(this.panel_Message);
            this.panel1.Controls.Add(this.ok_Btn);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 138);
            this.panel1.TabIndex = 3;
            // 
            // yes_Btn
            // 
            this.yes_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yes_Btn.Animated = true;
            this.yes_Btn.AutoRoundedCorners = true;
            this.yes_Btn.BorderRadius = 16;
            this.yes_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.yes_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.yes_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.yes_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.yes_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.yes_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.yes_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.yes_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.yes_Btn.ForeColor = System.Drawing.Color.White;
            this.yes_Btn.Location = new System.Drawing.Point(77, 101);
            this.yes_Btn.Name = "yes_Btn";
            this.yes_Btn.Size = new System.Drawing.Size(73, 34);
            this.yes_Btn.TabIndex = 6;
            this.yes_Btn.Text = "Đồng ý";
            this.yes_Btn.Click += new System.EventHandler(this.yes_Btn_Click);
            // 
            // no_Btn
            // 
            this.no_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.no_Btn.Animated = true;
            this.no_Btn.AutoRoundedCorners = true;
            this.no_Btn.BorderRadius = 16;
            this.no_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.no_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.no_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.no_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.no_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.no_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.no_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.no_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.no_Btn.ForeColor = System.Drawing.Color.White;
            this.no_Btn.Location = new System.Drawing.Point(187, 101);
            this.no_Btn.Name = "no_Btn";
            this.no_Btn.Size = new System.Drawing.Size(73, 34);
            this.no_Btn.TabIndex = 5;
            this.no_Btn.Text = "Không";
            this.no_Btn.Click += new System.EventHandler(this.no_Btn_Click);
            // 
            // icon_pic
            // 
            //this.icon_pic.Image = global::Cinema_Management_System.Properties.Resources.ErrorIcon;
            this.icon_pic.Location = new System.Drawing.Point(17, 26);
            this.icon_pic.Name = "icon_pic";
            this.icon_pic.Size = new System.Drawing.Size(57, 53);
            this.icon_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_pic.TabIndex = 4;
            this.icon_pic.TabStop = false;
            // 
            // panel_Message
            // 
            this.panel_Message.Controls.Add(this.message_Txt);
            this.panel_Message.Location = new System.Drawing.Point(77, 14);
            this.panel_Message.Name = "panel_Message";
            this.panel_Message.Size = new System.Drawing.Size(242, 78);
            this.panel_Message.TabIndex = 3;
            // 
            // YesMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 199);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Title);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "YesMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YesMessage";
            this.panel_Title.ResumeLayout(false);
            this.panel_Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_pic)).EndInit();
            this.panel_Message.ResumeLayout(false);
            this.panel_Message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel panel_Title;
        private System.Windows.Forms.Label message_Txt;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.Label title_txt;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox close_Btn;
        private Guna.UI2.WinForms.Guna2GradientButton ok_Btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Message;
        private System.Windows.Forms.PictureBox icon_pic;
        private Guna.UI2.WinForms.Guna2GradientButton yes_Btn;
        private Guna.UI2.WinForms.Guna2GradientButton no_Btn;
    }
}