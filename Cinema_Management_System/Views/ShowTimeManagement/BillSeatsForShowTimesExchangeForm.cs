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
            //dulieutim_txt.TextChanged += dulieutim_txt_TextChanged;
            luachontim_cbb.SelectedIndexChanged += luachontim_cbb_SelectedIndexChanged;

        }
        private void dulieutim_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void luachontim_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedItem?.ToString() == "Mã Đơn")
                _currentSearchType = SearchType.MaDon;
            else if (luachontim_cbb.SelectedItem?.ToString() == "Mã Phim")
                _currentSearchType = SearchType.MaPhim;
        }

        public void LoadBillData()
        {
            try
            {
                this.dgv_DataBill.AutoGenerateColumns = false;
                this.dgv_DataBill.DataSource = BillForShowTimeDA.Instance.GetListBillSeatsForShowTimes();
            }
            catch{
                MessageBoxHelper.ShowError("Lỗi", "Không thể tải dữ liệu hóa đơn");
            }
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedIndex <= 0)
            {
                canhbao_label.Visible = true;
                return;
            }

            canhbao_label.Visible = false;

            string keyword = dulieutim_txt.Text.ToLower().Trim();

            var filtered = BillForShowTimeDA.Instance.GetListBillSeatsForShowTimes().Where(c =>
              (_currentSearchType == SearchType.MaDon && c.Id.ToString().ToLower().Trim() == keyword) ||
              (_currentSearchType == SearchType.MaPhim && c.MovieId.ToString().ToLower().Trim()==keyword)
                ).ToList();

            this.dgv_DataBill.DataSource = filtered;
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
                    if (result== DialogResult.Yes)
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
    }}
}
