namespace Cinema_Management_System.Views.Notification
{
    partial class NotificationView
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
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.alert_pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.titleAlert_Txt = new System.Windows.Forms.Label();
            this.contentAlert_Txt = new System.Windows.Forms.Label();
            this.panelAlert = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.alert_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // alert_pic
            // 
            this.alert_pic.ImageRotate = 0F;
            this.alert_pic.Location = new System.Drawing.Point(35, 15);
            this.alert_pic.Name = "alert_pic";
            this.alert_pic.Size = new System.Drawing.Size(50, 50);
            this.alert_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alert_pic.TabIndex = 0;
            this.alert_pic.TabStop = false;
            // 
            // titleAlert_Txt
            // 
            this.titleAlert_Txt.AutoSize = true;
            this.titleAlert_Txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleAlert_Txt.Location = new System.Drawing.Point(103, 16);
            this.titleAlert_Txt.Name = "titleAlert_Txt";
            this.titleAlert_Txt.Size = new System.Drawing.Size(66, 21);
            this.titleAlert_Txt.TabIndex = 1;
            this.titleAlert_Txt.Text = "Tiêu đề";
            // 
            // contentAlert_Txt
            // 
            this.contentAlert_Txt.AutoSize = true;
            this.contentAlert_Txt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentAlert_Txt.Location = new System.Drawing.Point(103, 44);
            this.contentAlert_Txt.Name = "contentAlert_Txt";
            this.contentAlert_Txt.Size = new System.Drawing.Size(63, 17);
            this.contentAlert_Txt.TabIndex = 2;
            this.contentAlert_Txt.Text = "Nội dung";
            // 
            // panelAlert
            // 
            this.panelAlert.BackColor = System.Drawing.Color.Black;
            this.panelAlert.Location = new System.Drawing.Point(1, 75);
            this.panelAlert.Name = "panelAlert";
            this.panelAlert.Size = new System.Drawing.Size(5, 6);
            this.panelAlert.TabIndex = 3;
            // 
            // NotificationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 80);
            this.Controls.Add(this.panelAlert);
            this.Controls.Add(this.contentAlert_Txt);
            this.Controls.Add(this.titleAlert_Txt);
            this.Controls.Add(this.alert_pic);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationView";
            this.Text = "NotificationView";
            this.Load += new System.EventHandler(this.NotificationView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alert_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerAnimation;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panelAlert;
        private System.Windows.Forms.Label contentAlert_Txt;
        private System.Windows.Forms.Label titleAlert_Txt;
        private Guna.UI2.WinForms.Guna2PictureBox alert_pic;
    }
}