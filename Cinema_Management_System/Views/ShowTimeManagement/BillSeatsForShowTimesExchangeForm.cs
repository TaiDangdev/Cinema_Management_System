using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Views.MessageBox;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class BillSeatsForShowTimesExchangeForm : Form
    {
        private enum SearchType { MaDon, MaPhim }
        private SearchType _currentSearchType = SearchType.MaPhim;
        public BillSeatsForShowTimesExchangeForm()
        {
            InitializeComponent();
            this.LoadBillData();
            btn_Del.UseColumnTextForButtonValue = true;
            btn_Del.Text = "Xóa";
           
            //dulieutim_txt.TextChanged += dulieutim_txt_TextChanged;
           

        }
        private void dulieutim_txt_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadBillData()
        {
            try
            {
                this.dgv_DataBill.AutoGenerateColumns = false;
                this.dgv_DataBill.DataSource = BillForShowTimeDA.Instance.GetListBillSeatsForShowTimes();
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể tải dữ liệu hóa đơn");
            }
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            string keyword = dulieutim_txt.Text.ToLower().Trim();

            var filtered = BillForShowTimeDA.Instance.GetListBillSeatsForShowTimes().Where(c =>
              (c.Id.ToString().ToLower().Trim() == keyword)
                ).ToList();
            if (filtered.Count > 0)
            {
                this.dgv_DataBill.DataSource = filtered;
            }
            else
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Không tìm thấy Hóa Đơn");
            }
        }

        private void dgv_DataBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng bấm vào cột Button (cột có kiểu DataGridViewButtonColumn)
            if (e.ColumnIndex == this.dgv_DataBill.Columns["btn_Del"].Index)  // "btnAction" là tên của cột Button
            {
                DialogResult result = MessageBoxHelper.ShowQuestion("Xóa", "Bạn có chắc chắn muốn xóa hóa đơn này không?");
                if (DialogResult.No == result)
                {
                    return;
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        // Lấy ID của hóa đơn từ dòng hiện tại
                        int billId = Convert.ToInt32(this.dgv_DataBill.Rows[e.RowIndex].Cells["MaDon"].Value);
                        // Gọi phương thức xóa hóa đơn
                        if (BillForShowTimeDA.Instance.DeleleteBill(billId))
                        {
                            MessageBoxHelper.ShowInfo("Xóa thành công", "Hóa đơn đã được xóa thành công.");
                            LoadBillData();
                        }
                        else
                        {
                            MessageBoxHelper.ShowError("Lỗi", "Không thể xóa hóa đơn.");
                        }
                    }

                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.LoadBillData();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
