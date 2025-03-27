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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.close_Btn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.title_txt = new System.Windows.Forms.Label();
            this.message_Txt = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ok_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.close_Btn);
            this.guna2GradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.title_txt);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(312, 43);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // close_Btn
            // 
            this.close_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Btn.BackColor = System.Drawing.Color.Transparent;
            this.close_Btn.FillColor = System.Drawing.Color.Transparent;
            this.close_Btn.IconColor = System.Drawing.Color.White;
            this.close_Btn.Location = new System.Drawing.Point(261, 8);
            this.close_Btn.Name = "close_Btn";
            this.close_Btn.Size = new System.Drawing.Size(45, 29);
            this.close_Btn.TabIndex = 3;
            this.close_Btn.Click += new System.EventHandler(this.close_Btn_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Cinema_Management_System.Properties.Resources.clapboard;
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
            this.title_txt.Location = new System.Drawing.Point(33, 10);
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
            this.message_Txt.Location = new System.Drawing.Point(119, 95);
            this.message_Txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.message_Txt.Name = "message_Txt";
            this.message_Txt.Size = new System.Drawing.Size(52, 21);
            this.message_Txt.TabIndex = 1;
            this.message_Txt.Text = "label1";
            this.message_Txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2ShadowForm1
            // 
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
            this.ok_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ok_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ok_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ok_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ok_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ok_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.ok_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.ok_Btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ok_Btn.ForeColor = System.Drawing.Color.White;
            this.ok_Btn.Location = new System.Drawing.Point(108, 141);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Size = new System.Drawing.Size(73, 28);
            this.ok_Btn.TabIndex = 2;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // YesMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 178);
            this.Controls.Add(this.message_Txt);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.ok_Btn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "YesMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YesMessage";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label message_Txt;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.Label title_txt;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox close_Btn;
        private Guna.UI2.WinForms.Guna2GradientButton ok_Btn;
    }
}