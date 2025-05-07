namespace Cinema_Management_System.Views.ShowTimeManagement
{
    partial class BillTicketForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillTicketForms));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.BillSeatsForShowTimesRP3 = new Cinema_Management_System.Views.ShowTimeManagement.BillSeatsForShowTimesRP();
            this.BillSeatsForShowTimesRP1 = new Cinema_Management_System.Views.ShowTimeManagement.BillSeatsForShowTimesRP();
            this.BillSeatsForShowTimesRP2 = new Cinema_Management_System.Views.ShowTimeManagement.BillSeatsForShowTimesRP();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.BillSeatsForShowTimesRP3;
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 579);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // BillTicketForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 579);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillTicketForms";
            this.Text = "BillTicketForms";
            this.Load += new System.EventHandler(this.BillTicketForms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BillSeatsForShowTimesRP BillSeatsForShowTimesRP1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private BillSeatsForShowTimesRP BillSeatsForShowTimesRP2;
        private BillSeatsForShowTimesRP BillSeatsForShowTimesRP3;
    }
}