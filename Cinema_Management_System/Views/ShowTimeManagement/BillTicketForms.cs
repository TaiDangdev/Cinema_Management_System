using Cinema_Management_System.Views.MessageBox;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class BillTicketForms : Form
    {
        private DataSet reportBill;
        public BillTicketForms()
        {
            InitializeComponent();
        }

        public BillTicketForms(DataSet Bill)
        {
            InitializeComponent();
            this.reportBill = Bill;
        }

        private void BillTicketForms_Load(object sender, EventArgs e)
        {
            try
            {
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "BillSeatsForShowTimesRP.rpt");
                if (System.IO.File.Exists(reportPath))
                {
                    ReportDocument report=new ReportDocument();
                    report.Load(reportPath);
                    report.SetDataSource(reportBill.Tables["BillReport"]);

                    crystalReportViewer1.ReportSource = report;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBoxHelper.ShowError("Lỗi","Không tìm thấy đường dẫn");
                    //MessageBox.MessageBoxType.Warning("Report file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Report file not found.");
                }
            }
            catch
            {

            }
        }
    }
}
