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
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Cinema_Management_System.Views.MessageBox;
using ClosedXML.Excel;

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
            guna2TabControl1.SelectedIndex = 2;
            //VeCotkep_Tongquat();
            Tungay_label.Visible = false;
            Denngay_label.Visible = false;
            startDay_date.Visible = false;
            endDay_date.Visible = false; 
            startDay_date.MaxDate = DateTime.Now;
            endDay_date.MaxDate = DateTime.Now;
        }

        public void LoadChartMovie()
        {
            ShowTopMovieByRevenue(0, 0);
            ShowGeneStatistic(0, 0);
            ShowstaticMonthinYear(0);
        }




        private void VeCotkep_Tongquat(DateTime startDate, DateTime endDate)
        {
            var db = new ConnectDataContext();

            startDate = startDate.Date;
            endDate = endDate.Date;

            decimal totalRevenue_Product = db.Bill_SellProducts
                .Where(bdp => bdp.BillDate.Date >= startDate && bdp.BillDate.Date <= endDate)
                .Sum(bdp => (decimal?)bdp.TotalAmount) ?? 0;
            decimal totalRevenue_Ticket = db.Bills
                .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                .Sum(x => (decimal?)x.Total) ?? 0;
            decimal totalCost_Product = (db.Bill_ImportProducts
                .Where(bip => bip.BillDate.Date >= startDate && bip.BillDate.Date <= endDate)
                .Sum(bip => (decimal?)bip.Total) ?? 0) +
                (db.Bill_AddProducts
                .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                .Sum(x => (decimal?)x.Total) ?? 0);
            decimal totalCost_Ticket = db.Bill_AddMovies
                .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                .Sum(x => (decimal?)x.Total) ?? 0;

            decimal totalRevenue = totalRevenue_Product + totalRevenue_Ticket;
            decimal totalCost = totalCost_Product + totalCost_Ticket;


            tongdoanhthu_label.Text = $"{totalRevenue.ToString("N0")} VNĐ";
            tongchiphi_label.Text = $"{totalCost.ToString("N0")} VNĐ";

            // Xóa dữ liệu cũ nếu có
            bar_chart_TQ.Series.Clear();
            bar_chart_TQ.ChartAreas.Clear();
            bar_chart_TQ.Legends.Clear();

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.FromArgb(255, 253, 240);

            // Tắt nhãn trục X
            chartArea.AxisX.LabelStyle.Enabled = false;

            bar_chart_TQ.ChartAreas.Add(chartArea);

            // Tạo Legend
            Legend legend = new Legend("Legend1");
            legend.BackColor = Color.Transparent;
            bar_chart_TQ.Legends.Add(legend);

            // Tạo series cho Doanh thu
            Series seriesRevenue = new Series("Doanh thu");
            seriesRevenue.ChartType = SeriesChartType.Column;
            seriesRevenue.IsValueShownAsLabel = false;
            seriesRevenue.Color = Color.Cyan;
            seriesRevenue.Legend = "Legend1";

            // Tạo series cho Chi phí
            Series seriesCost = new Series("Chi phí");
            seriesCost.ChartType = SeriesChartType.Column;
            seriesCost.IsValueShownAsLabel = false;
            seriesCost.Color = Color.FromArgb(255, 192, 128);
            seriesCost.Legend = "Legend1";

            seriesRevenue.Points.AddXY("Doanh thu", totalRevenue);
            seriesCost.Points.AddXY("Chi phí", totalCost);


            // Thêm series vào biểu đồ
            bar_chart_TQ.Series.Add(seriesRevenue);
            bar_chart_TQ.Series.Add(seriesCost);


            // Vẽ biểu đồ tròn cho Doanh thu (DTTQ_piechart)
            DTTQ_piechart.Series.Clear();
            DTTQ_piechart.ChartAreas.Clear();
            DTTQ_piechart.Legends.Clear();

            ChartArea chartAreaRevenue = new ChartArea("RevenueArea");
            chartAreaRevenue.BackColor = Color.FromArgb(192, 255, 255);
            DTTQ_piechart.ChartAreas.Add(chartAreaRevenue);

            Legend legendRevenue = new Legend("LegendRevenue");
            legendRevenue.BackColor = Color.Transparent;
            DTTQ_piechart.Legends.Add(legendRevenue);

            Series seriesRevenuePie = new Series("Doanh thu chi tiết");
            seriesRevenuePie.ChartType = SeriesChartType.Pie;
            seriesRevenuePie.IsValueShownAsLabel = true;
            seriesRevenuePie.LabelFormat = "{0:N0} VNĐ";
            seriesRevenuePie.Legend = "LegendRevenue";
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
            if (totalRevenue > 0) // Chỉ tính phần trăm nếu tổng doanh thu lớn hơn 0
            {
                if (totalRevenue_Product > 0)
                {
                    int pointIndex = seriesRevenuePie.Points.AddXY("Sản phẩm", totalRevenue_Product);
                    seriesRevenuePie.Points[pointIndex].Color = Color.FromArgb(79, 145, 205);
                    seriesRevenuePie.Points[pointIndex].Label = $"{(totalRevenue_Product / totalRevenue * 100):0.##}%";
                    seriesRevenuePie.Points[pointIndex].LegendText = "Sản phẩm";
                }
                if (totalRevenue_Ticket > 0)
                {
                    int pointIndex = seriesRevenuePie.Points.AddXY("Vé", totalRevenue_Ticket);
                    seriesRevenuePie.Points[pointIndex].Color = Color.FromArgb(116, 206, 247);
                    seriesRevenuePie.Points[pointIndex].Label = $"{(totalRevenue_Ticket / totalRevenue * 100):0.##}%";
                    seriesRevenuePie.Points[pointIndex].LegendText = "Vé xem phim ";
                }
            }

            DTTQ_piechart.Series.Add(seriesRevenuePie);


            // Vẽ biểu đồ tròn cho Chi phí (CPTQ_piechart)
            CPTQ_piechart.Series.Clear();
            CPTQ_piechart.ChartAreas.Clear();
            CPTQ_piechart.Legends.Clear();

            ChartArea chartAreaCost = new ChartArea("CostArea");
            chartAreaCost.BackColor = Color.FromArgb(255, 224, 192);
            CPTQ_piechart.ChartAreas.Add(chartAreaCost);

            Legend legendCost = new Legend("LegendCost");
            legendCost.BackColor = Color.Transparent;
            CPTQ_piechart.Legends.Add(legendCost);

            // Create a new chart area
            ChartArea chartArea = new ChartArea("MainChartArea");
            chart_TongQuan.ChartAreas.Add(chartArea);
            Series seriesCostPie = new Series("Chi phí chi tiết");
            seriesCostPie.ChartType = SeriesChartType.Pie;
            seriesCostPie.IsValueShownAsLabel = true;
            seriesCostPie.LabelFormat = "{0:N0} VNĐ";
            seriesCostPie.Legend = "LegendCost";

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

            if (totalCost > 0) // Chỉ tính phần trăm nếu tổng chi phí lớn hơn 0
            {
                if (totalCost_Product > 0)
                {
                    int pointIndex = seriesCostPie.Points.AddXY("Sản phẩm", totalCost_Product);
                    seriesCostPie.Points[pointIndex].Color = Color.FromArgb(255, 192, 128);
                    seriesCostPie.Points[pointIndex].Label = $"{(totalCost_Product / totalCost * 100):0.##}%";
                    seriesCostPie.Points[pointIndex].LegendText = "Sản phẩm";
                }
                if (totalCost_Ticket > 0)
                {
                    int pointIndex = seriesCostPie.Points.AddXY("Vé", totalCost_Ticket);
                    seriesCostPie.Points[pointIndex].Color = Color.FromArgb(255, 160, 96);
                    seriesCostPie.Points[pointIndex].Label = $"{(totalCost_Ticket / totalCost * 100):0.##}%";
                    seriesCostPie.Points[pointIndex].LegendText = "Vé xem phim ";
                }
            }

            CPTQ_piechart.Series.Add(seriesCostPie);
        }

        private void loadChartBySlot(int month, int year)

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
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

        private void chart7_Click(object sender, EventArgs e)
        {          

        }

        private void chuki_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = chuki_cbb.SelectedItem.ToString();

            bool isCustom = !(selected == "Theo tháng" || selected == "Theo năm");
            Tungay_label.Visible = isCustom;
            Denngay_label.Visible = isCustom;
            startDay_date.Visible = isCustom;
            endDay_date.Visible = isCustom;
            thoidiem_cbb.Visible = !isCustom;
            thoidiem_label.Visible = !isCustom;

            thoidiem_cbb.Items.Clear();

            if (selected == "Theo tháng")
            {
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                for (int i = 1; i <= currentMonth; i++)
                {
                    thoidiem_cbb.Items.Add($"Tháng {i} - {currentYear}");
                }
            }
            else if (selected == "Theo năm")
            {
                int currentYear = DateTime.Now.Year;
                for (int i = currentYear - 5; i <= currentYear; i++) // 5 năm gần đây
                {
                    thoidiem_cbb.Items.Add(i.ToString());
                }
            }



            if (thoidiem_cbb.Items.Count > 0)
            {
                thoidiem_cbb.SelectedIndex = 0; // chọn mặc định
            }
        }

        private void thoidiem_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thoidiem_cbb.SelectedItem == null) return;

            string selectedPeriod = chuki_cbb.SelectedItem.ToString();
            string selectedItem = thoidiem_cbb.SelectedItem.ToString();
            DateTime startDate, endDate;

            if (selectedPeriod == "Theo tháng")
            {
                // Phân tích chuỗi "Tháng X - YYYY"
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);
                int month = int.Parse(parts[0].Replace("Tháng ", ""));
                int year = int.Parse(parts[1]);
                startDate = new DateTime(year, month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else // Theo năm
            {
                int year = int.Parse(selectedItem);
                startDate = new DateTime(year, 1, 1);
                endDate = new DateTime(year, 12, 31);
            }

            // Gọi hàm vẽ biểu đồ với ngày bắt đầu và kết thúc
            VeCotkep_Tongquat(startDate, endDate);
        }

        private void startDay_date_ValueChanged(object sender, EventArgs e)
        {
            if (startDay_date.Visible && endDay_date.Visible)
            {
                VeCotkep_Tongquat(startDay_date.Value, endDay_date.Value);
            }
        }

        private void endDay_pick_ValueChanged(object sender, EventArgs e)
        {
            if (startDay_date.Visible && endDay_date.Visible)
            {
                VeCotkep_Tongquat(startDay_date.Value, endDay_date.Value);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime startDate, endDate;

            if (startDay_date.Visible && endDay_date.Visible)
            {
                // Nếu đang dùng DateTimePicker
                startDate = startDay_date.Value;
                endDate = endDay_date.Value;
            }
            else
            {
                // Nếu đang dùng ComboBox
                string selectedPeriod = chuki_cbb.SelectedItem?.ToString();
                string selectedItem = thoidiem_cbb.SelectedItem?.ToString();

                if (selectedPeriod == null || selectedItem == null)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Vui lòng chọn thời gian để làm mới dữ liệu.");
                    //System.Windows.MessageBox.Show("Vui lòng chọn thời gian để làm mới dữ liệu.", "Thông báo");
                    return;
                }

                if (selectedPeriod == "Theo tháng")
                {
                    string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);
                    int month = int.Parse(parts[0].Replace("Tháng ", ""));
                    int year = int.Parse(parts[1]);
                    startDate = new DateTime(year, month, 1);
                    endDate = startDate.AddMonths(1).AddDays(-1);
                }
                else // Theo năm
                {
                    int year = int.Parse(selectedItem);
                    startDate = new DateTime(year, 1, 1);
                    endDate = new DateTime(year, 12, 31);
                }
            }

            // Gọi lại phương thức vẽ biểu đồ
            VeCotkep_Tongquat(startDate, endDate);
        }

        private void xuatExcel_bnt_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác định khoảng thời gian
                DateTime startDate, endDate;

                if (startDay_date.Visible && endDay_date.Visible)
                {
                    // Sử dụng DateTimePicker
                    startDate = startDay_date.Value;
                    endDate = endDay_date.Value;
                }
                else
                {
                    // Sử dụng ComboBox
                    string selectedPeriod = chuki_cbb.SelectedItem?.ToString();
                    string selectedItem = thoidiem_cbb.SelectedItem?.ToString();

                    if (selectedPeriod == null || selectedItem == null)
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Vui lòng chọn thời gian để xuất dữ liệu.");
                        return;
                    }

                    if (selectedPeriod == "Theo tháng")
                    {
                        string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);
                        int month = int.Parse(parts[0].Replace("Tháng ", ""));
                        int year = int.Parse(parts[1]);
                        startDate = new DateTime(year, month, 1);
                        endDate = startDate.AddMonths(1).AddDays(-1);
                    }
                    else // Theo năm
                    {
                        int year = int.Parse(selectedItem);
                        startDate = new DateTime(year, 1, 1);
                        endDate = new DateTime(year, 12, 31);
                    }
                }

                // Tính toán dữ liệu (tương tự VeCotkep_Tongquat)
                var db = new ConnectDataContext();

                startDate = startDate.Date;
                endDate = endDate.Date;

                decimal totalRevenue_Product = db.Bill_SellProducts
                    .Where(bdp => bdp.BillDate.Date >= startDate && bdp.BillDate.Date <= endDate)
                    .Sum(bdp => (decimal?)bdp.TotalAmount) ?? 0;
                decimal totalRevenue_Ticket = db.Bills
                    .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                    .Sum(x => (decimal?)x.Total) ?? 0;
                decimal totalCost_Product = (db.Bill_ImportProducts
                    .Where(bip => bip.BillDate.Date >= startDate && bip.BillDate.Date <= endDate)
                    .Sum(bip => (decimal?)bip.Total) ?? 0) +
                    (db.Bill_AddProducts
                    .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                    .Sum(x => (decimal?)x.Total) ?? 0);
                decimal totalCost_Ticket = db.Bill_AddMovies
                    .Where(x => x.BillDate.Date >= startDate && x.BillDate.Date <= endDate)
                    .Sum(x => (decimal?)x.Total) ?? 0;

                decimal totalRevenue = totalRevenue_Product + totalRevenue_Ticket;
                decimal totalCost = totalCost_Product + totalCost_Ticket;

                // Tạo file Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Thống kê");

                    // Thiết lập tiêu đề
                    worksheet.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ DOANH THU VÀ CHI PHÍ";
                    worksheet.Range("A1:D1").Merge();
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                    worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Thiết lập khoảng thời gian
                    worksheet.Cell(2, 1).Value = $"Từ ngày: {startDate:dd/MM/yyyy} - Đến ngày: {endDate:dd/MM/yyyy}";
                    worksheet.Range("A2:D2").Merge();
                    worksheet.Cell(2, 1).Style.Font.Italic = true;
                    worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Thiết lập tiêu đề cột
                    worksheet.Cell(4, 1).Value = "Danh mục";
                    worksheet.Cell(4, 2).Value = "Doanh thu (VNĐ)";
                    worksheet.Cell(4, 3).Value = "Chi phí (VNĐ)";
                    worksheet.Cell(4, 4).Value = "Tỷ lệ (%)";
                    var headerRange = worksheet.Range("A4:D4");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Thêm dữ liệu
                    // Tổng doanh thu
                    worksheet.Cell(5, 1).Value = "Tổng doanh thu";
                    worksheet.Cell(5, 2).Value = totalRevenue;
                    worksheet.Cell(5, 2).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(5, 4).Value = 100;
                    worksheet.Cell(5, 4).Style.NumberFormat.Format = "0.00";

                    // Doanh thu sản phẩm
                    worksheet.Cell(6, 1).Value = "Doanh thu sản phẩm";
                    worksheet.Cell(6, 2).Value = totalRevenue_Product;
                    worksheet.Cell(6, 2).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(6, 4).Value = totalRevenue > 0 ? (totalRevenue_Product / totalRevenue * 100) : 0;
                    worksheet.Cell(6, 4).Style.NumberFormat.Format = "0.00";

                    // Doanh thu vé
                    worksheet.Cell(7, 1).Value = "Doanh thu vé xem phim";
                    worksheet.Cell(7, 2).Value = totalRevenue_Ticket;
                    worksheet.Cell(7, 2).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(7, 4).Value = totalRevenue > 0 ? (totalRevenue_Ticket / totalRevenue * 100) : 0;
                    worksheet.Cell(7, 4).Style.NumberFormat.Format = "0.00";

                    // Tổng chi phí
                    worksheet.Cell(8, 1).Value = "Tổng chi phí";
                    worksheet.Cell(8, 3).Value = totalCost;
                    worksheet.Cell(8, 3).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(8, 4).Value = 100;
                    worksheet.Cell(8, 4).Style.NumberFormat.Format = "0.00";

                    // Chi phí sản phẩm
                    worksheet.Cell(9, 1).Value = "Chi phí sản phẩm";
                    worksheet.Cell(9, 3).Value = totalCost_Product;
                    worksheet.Cell(9, 3).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(9, 4).Value = totalCost > 0 ? (totalCost_Product / totalCost * 100) : 0;
                    worksheet.Cell(9, 4).Style.NumberFormat.Format = "0.00";

                    // Chi phí vé
                    worksheet.Cell(10, 1).Value = "Chi phí vé xem phim";
                    worksheet.Cell(10, 3).Value = totalCost_Ticket;
                    worksheet.Cell(10, 3).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(10, 4).Value = totalCost > 0 ? (totalCost_Ticket / totalCost * 100) : 0;
                    worksheet.Cell(10, 4).Style.NumberFormat.Format = "0.00";

                    // Tự động điều chỉnh kích thước cột
                    worksheet.Columns(1, 4).AdjustToContents();

                    // Lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx|Tất cả file (*.*)|*.*",
                        FileName = $"ThongKe_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBoxHelper.ShowSuccess("Thành công", "Xuất file Excel thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Đã xảy ra lỗi khi xuất file Excel: {ex.Message}");
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu báo cáo Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(data, saveFileDialog.FileName);
                MessageBoxHelper.ShowSuccess("Thông báo", "Xuất file thành công!");
            }
        }
    }
}
