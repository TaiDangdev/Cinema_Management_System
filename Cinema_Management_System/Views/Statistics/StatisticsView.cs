using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Views.MessageBox;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cinema_Management_System.Views.Statistics
{
    public partial class StatisticsView : UserControl
    {

        private bool CheckMonthStatistic = true;
        public StatisticsView()
        {
            InitializeComponent();
            this.cb_selectMonth.Hide();
            this.select_typeDetail.Hide();
            this.OffPeriodOfTime();
            ShowTopMovieByRevenue(0,0);
            ShowGeneStatistic(0,0);
            ShowstaticMonthinYear(0);
        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int[] allowedTabs = { 2, 3, 4 };
            if (!allowedTabs.Contains(e.TabPageIndex))
            {
                e.Cancel = true;
            }
        }

        private void Select_typeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = Select_typeSearch.SelectedItem?.ToString();
            this.select_typeDetail.Items.Clear(); // Xoá các item cũ
            this.select_typeDetail.DisplayMember = "Key";
            this.select_typeDetail.ValueMember = "Value";

            if (selectedType == "Theo năm")
            {
                CheckMonthStatistic = true; 
                this.OffPeriodOfTime();
                this.select_typeDetail.Show();
                this.select_typeDetail.Enabled = true;
                this.select_typeDetail.Items.Add(new DictionaryEntry("Tòan bộ", 0));
                {
                    List<int> danhsachNam = BillForShowTimeDA.Instance.GetYearInBills();

                    foreach (int nam in danhsachNam)
                    {
                        this.select_typeDetail.Items.Add(new DictionaryEntry($"Năm {nam}", nam));
                    }
                    if (this.select_typeDetail.Items.Count > 0)
                    {
                        select_typeDetail.SelectedIndex = 0;
                    }
                    this.cb_selectMonth.Show();
                }
            }
            else
            {
                CheckMonthStatistic = false;
                this.OnPeriodOfTime();
                this.cb_selectMonth.Hide();
                this.select_typeDetail.Hide();
            }
        }

        private void select_typeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cb_selectMonth.SelectedIndex = 0;
            if (select_typeDetail.SelectedItem is DictionaryEntry selectedItem)
            {
                int selectYear = (int)selectedItem.Value;
                ShowTopMovieByRevenue(0,selectYear);
                ShowGeneStatistic(0,selectYear);
                ShowstaticMonthinYear(selectYear);
            }

        }

        public void ShowTopMovieByRevenue(int month,int year)
        {
            this.lb_Doanhthu.Text = "TOP DOANH THU PHIM";
                var Top5Movie = StatisticDA.Instance.GetTopMovie(month,year);
                this.chart_DoanhThu.Series.Clear();
                Series series = new Series("Cơ cấu doanh thu")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Label = "#PERCENT", // Hiện phần trăm
                    LegendText = "#VALX", // Hiện tên phim
                    Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold)
                };
            int DoanhThuText = 0; 
                foreach (var kvp in Top5Movie)
                {
                    series.Points.AddXY(kvp.Key, kvp.Value);
                DoanhThuText += kvp.Value;
                }
            this.lb_SoDoanhThu.Text = DoanhThuText.ToString("N0") + "VND";
                this.chart_DoanhThu.Series.Add(series);
            long ChiPhiText = StatisticDA.Instance.GetExpenseByTime(month,year);
            this.lb_ChiPhiBaoCao.Text = ChiPhiText.ToString("N0") + "VND";
        }


        public void ShowTopMovieByRevenue(DateTime from, DateTime End)
        {
            this.lb_Doanhthu.Text = "TOP DOANH THU PHIM";
            var Top5Movie = StatisticDA.Instance.GetTopMovieByDateRange(from, End);
            this.chart_DoanhThu.Series.Clear();
            Series series = new Series("Cơ cấu doanh thu")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT", // Hiện phần trăm
                LegendText = "#VALX", // Hiện tên phim
                Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold)
            };
            int DoanhThuText = 0;
            foreach (var kvp in Top5Movie)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
                DoanhThuText += kvp.Value;
            }
            this.lb_SoDoanhThu.Text = DoanhThuText.ToString("N0") + "VND";
            this.chart_DoanhThu.Series.Add(series);
            long ChiPhiText = StatisticDA.Instance.GetExpenseByTime(from, End);
            this.lb_ChiPhiBaoCao.Text = ChiPhiText.ToString("N0") + "VND";
        }

        public void ShowGeneStatistic(int month , int year)
        {
            this.lb_ChiPhi.Text = "SỐ VÉ BÁN THEO THỂ LOẠI";
            var Top5Genre = StatisticDA.Instance.GetTopGenre(month,year);
            this.chart_ChiPhi.Series.Clear();
            Series seriesGenre = new Series("Thể loại")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT", // Hiện phần trăm
                LegendText = "#VALX", // Hiện tên phim
                Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold)
            };

            foreach (var kvp in Top5Genre)
            {
                seriesGenre.Points.AddXY(kvp.Key, kvp.Value);
            }

            this.chart_ChiPhi.Series.Add(seriesGenre);

        }

        public void ShowGeneStatistic(DateTime from, DateTime End)
        {
            this.lb_ChiPhi.Text = "SỐ VÉ BÁN THEO THỂ LOẠI";
            var Top5Genre = StatisticDA.Instance.GetTopGenreByDateRange(from, End);
            this.chart_ChiPhi.Series.Clear();
            Series seriesGenre = new Series("Thể loại")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT", // Hiện phần trăm
                LegendText = "#VALX", // Hiện tên phim
                Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold)
            };

            foreach (var kvp in Top5Genre)
            {
                seriesGenre.Points.AddXY(kvp.Key, kvp.Value);
            }

            this.chart_ChiPhi.Series.Add(seriesGenre);

        }

        public void ShowstaticMonthinYear(int year)
        {
            var statisticMonth = StatisticDA.Instance.GetRevenueByMonth(year);

            chart_TongQuan.Series.Clear();
            chart_TongQuan.ChartAreas.Clear();

            // Create a new chart area
            ChartArea chartArea = new ChartArea("MainChartArea");
            chart_TongQuan.ChartAreas.Add(chartArea);

            // Create a new series for the bar chart
            Series series = new Series("Tổng Số Vé")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true, // Show values on top of the bars
                BorderWidth = 1,
                Color = System.Drawing.Color.Blue
            };
            chart_TongQuan.Series.Add(series);

            // Add data points (month, revenue) to the series
            foreach (var data in statisticMonth)
            {
                if (data.Month >= 1 && data.Month <= 12)
                {
                    series.Points.AddXY(data.Month, data.Revenue);
                }
            }

            // Optional: Set the title of the chart
            chart_TongQuan.Titles.Clear();
            chart_TongQuan.Titles.Add("Số vé theo tháng");

            // Optional: Set the X and Y axis titles
            chart_TongQuan.ChartAreas[0].AxisX.Title = "Tháng";
            chart_TongQuan.ChartAreas[0].AxisY.Title = "Số vé";
            // Set the X-axis to only show months from 1 to 12
            chart_TongQuan.ChartAreas[0].AxisX.Interval = 1; // Ensure interval is 1 month
            chart_TongQuan.ChartAreas[0].AxisX.Minimum = 0; // Start slightly before month 1
            chart_TongQuan.ChartAreas[0].AxisX.Maximum = 12.8; // End slightly after month 12
            chart_TongQuan.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // Hide grid lines if you want

            // Optional: Adjust the spacing for better visibility
            //chart_TongQuan.ChartAreas[0].AxisX.LabelStyle.Angle = 45; // Rotate labels if needed
            chart_TongQuan.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None; // Disable label auto-fit
        }


        private void cb_selectMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectindex=this.cb_selectMonth.SelectedIndex;
            if (select_typeDetail.SelectedItem is DictionaryEntry selectedItem)
            {
                int selectYear = (int)selectedItem.Value;
                ShowTopMovieByRevenue(selectindex, selectYear);
                ShowGeneStatistic(selectindex, selectYear);
                //ShowstaticMonthinYear(selectYear);
                loadChartBySlot(selectindex, selectYear);
            }

        }

        private void loadChartBySlot(int month, int year)
        {
            var data = StatisticDA.Instance.GetTicketCountBySlot(month, year);
            chart_TongQuan.Series.Clear();
            chart_TongQuan.ChartAreas.Clear();


            var chartArea = new ChartArea("TimeSlotArea");
            // Gán tiêu đề trục X và Y
            chartArea.AxisX.Title = "Khung giờ";
            chartArea.AxisY.Title = "Số vé bán";
            chart_TongQuan.ChartAreas.Add(chartArea);
            var series = new Series("Lượt vé theo khung giờ");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;

            // Thêm dữ liệu vào chart
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart_TongQuan.Series.Add(series);
        }

        private void loadChartBySlot(DateTime From, DateTime End)
        {
            var data = StatisticDA.Instance.GetTicketCountBySlot(From, End);
            chart_TongQuan.Series.Clear();
            chart_TongQuan.ChartAreas.Clear();


            var chartArea = new ChartArea("TimeSlotArea");
            // Gán tiêu đề trục X và Y
            chartArea.AxisX.Title = "Khung giờ";
            chartArea.AxisY.Title = "Số vé bán";
            chart_TongQuan.ChartAreas.Add(chartArea);
            var series = new Series("Lượt vé theo khung giờ");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;

            // Thêm dữ liệu vào chart
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart_TongQuan.Series.Add(series);
        }

        public void OnPeriodOfTime()
        {
            this.lb_End.Show();
            this.lb_Start.Show();
            this.DTP_End.Show();
            this.DTP_Start.Show();
            this.btn_statistic.Show();
        }

        public void OffPeriodOfTime()
        {
            this.lb_End.Hide();
            this.lb_Start.Hide();
            this.DTP_End.Hide();
            this.DTP_Start.Hide();
            this.btn_statistic.Hide();
        }

        private void btn_statistic_Click(object sender, EventArgs e)
        {
            DateTime from = this.DTP_Start.Value; 
            DateTime End = this.DTP_End.Value;
            ShowTopMovieByRevenue(from, End);
            ShowGeneStatistic(from, End);
            loadChartBySlot(from, End);
        }

        public void ExportToExcel(List<dynamic> data, string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Báo cáo");

            // Header
            worksheet.Cell(1, 1).Value = "Ngày";
            worksheet.Cell(1, 2).Value = "Tổng số vé";
            worksheet.Cell(1, 3).Value = "Tổng doanh thu";
            worksheet.Cell(1, 4).Value = "Số suất chiếu";
            worksheet.Cell(1, 5).Value = "Tên phim";

            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.Ngay.ToString("dd/MM/yyyy");
                worksheet.Cell(row, 2).Value = item.TongSoVe;
                worksheet.Cell(row, 3).Value = item.TongDoanhThu;
                worksheet.Cell(row, 4).Value = item.SoSuatChieu;
                worksheet.Cell(row, 5).Value = item.TenPhim;
                row++;
            }

            // Auto fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }


        private void btn_Print_Click(object sender, EventArgs e)
        {
            List<dynamic> data = new List<dynamic>();
            if (CheckMonthStatistic)
            {
                int selectindex = this.cb_selectMonth.SelectedIndex;
                this.cb_selectMonth.SelectedIndex = 0;

                if (select_typeDetail.SelectedItem is DictionaryEntry selectedItem)
                {
                    int selectYear = (int)selectedItem.Value;
                    data = StatisticDA.Instance.GetRevenueTableByMonthYear(selectindex, selectYear); // hoặc theo tháng
                }
            }
            else
            {
                DateTime from = this.DTP_Start.Value;
                DateTime End = this.DTP_End.Value;
                data = StatisticDA.Instance.GetRevenueTableByDateRange(from, End);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu báo cáo Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(data, saveFileDialog.FileName);
                MessageBoxHelper.ShowInfo("Thông báo", "Xuất file thành công!");
            }
        }
    }
}
