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
            guna2TabControl1.SelectedIndex = 2;
            Tungay_label.Visible = false;
            Denngay_label.Visible = false;
            startDay_date.Visible = false;
            endDay_date.Visible = false; 
            //startDay_date.MaxDate = DateTime.Now;
            //endDay_date.MaxDate = DateTime.Now;
            setupUI();

            dtpker_product1.MaxDate = DateTime.Now;
            dtpker_product2.MaxDate = DateTime.Now;
            tungay_lbl_Product.Visible = false;
            denngay_lbl_Product.Visible = false;

            dtpker_product1.Visible = false;
            dtpker_product2.Visible = false;
            //Thiết lập Timer để kiểm tra hàng ngày
            Timer timer = new Timer();
            timer.Interval = 24 * 60 * 60 * 1000; // 24 giờ
            timer.Tick += (s, e) =>
            {
                // Kiểm tra nếu là ngày đầu tiên của tháng
                if (DateTime.Now.Day == 1)
                {
                    // Gửi báo cáo cho tháng trước
                    DateTime lastMonth = DateTime.Now.AddMonths(-1);
                    SendMonthlyStatisticsEmail(lastMonth.Year, lastMonth.Month, "recipient@example.com");
                }
            };
            timer.Start();
        }

        private void setupUI()
        {
            tongdoanhthu1_label.Text = "0";
            tongchiphi_label.Text = "0";
            guna2TabControl1.SelectedIndex = 2;
            var db = new ConnectDataContext();
            // Lấy ngày nhỏ nhất
            var minDate = new[] {
                db.Bills.Min(b => b.BillDate),
                db.Bill_SellProducts.Min(sp => sp.BillDate)
            }.Min();

            // Lấy ngày lớn nhất
            var maxDate = new[] {
                    db.Bills.Max(b => b.BillDate),
                    db.Bill_SellProducts.Max(sp => sp.BillDate)
                }.Max();

            VeBieuDo_Tongquat(minDate, maxDate);
        }

        private void SendMonthlyStatisticsEmail(int year, int month, string toEmail)
        {
            try
            {
                // Xác định khoảng thời gian cho tháng cần gửi
                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                // Tạo file Excel tạm thời
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"ThongKe_Thang_{month}_{year}.xlsx");
                GenerateExcelReport(startDate, endDate, tempFilePath);

                // Thiết lập thông tin email
                string fromEmail = "your-email@gmail.com"; // Thay bằng email của bạn
                string fromPassword = "your-app-password"; // Thay bằng app password của bạn
                string subject = $"Báo cáo thống kê tháng {month}/{year}";
                string body = $"Kính gửi,\n\nĐính kèm là báo cáo thống kê doanh thu và chi phí tháng {month}/{year}.\n\nTrân trọng,\nHệ thống quản lý rạp chiếu phim";

                // Tạo đối tượng MailMessage
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.Attachments.Add(new Attachment(tempFilePath));

                    // Thiết lập SMTP client (dùng Gmail làm ví dụ)
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                // Xóa file tạm sau khi gửi
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }

                MessageBoxHelper.ShowSuccess("Thành công", "Email báo cáo thống kê đã được gửi!");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Đã xảy ra lỗi khi gửi email: {ex.Message}");
            }

        public void LoadChartMovie()
        {
            ShowTopMovieByRevenue(0, 0);
            ShowGeneStatistic(0, 0);
            ShowstaticMonthinYear(0);
        }

        private void VeBieuDo_Tongquat(DateTime startDate, DateTime endDate)
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

            //decimal totalCost_Salary = 10000000;
            decimal totalCost_Salary = db.Staff_Salaries
        .Where(ss => ss.BillDate.HasValue && ss.BillDate.Value.Date >= startDate && ss.BillDate.Value.Date <= endDate)
        .Sum(ss => (decimal?)ss.Total) ?? 0;

            decimal totalRevenue = totalRevenue_Product + totalRevenue_Ticket;
            decimal totalCost = totalCost_Product + totalCost_Ticket + totalCost_Salary;


            tongdoanhthu1_label.Text = $"{totalRevenue.ToString("N0")} VNĐ";
            tongchiphi_label.Text = $"{totalCost.ToString("N0")} VNĐ";

            // Xóa dữ liệu cũ nếu có
            bar_chart_TQ.Series.Clear();
            bar_chart_TQ.ChartAreas.Clear();
            bar_chart_TQ.Legends.Clear();

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = System.Drawing.Color.White;

            // Tắt nhãn trục X
            chartArea.AxisX.LabelStyle.Enabled = false;

            bar_chart_TQ.ChartAreas.Add(chartArea);

            // Tạo Legend
            System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend("Legend1");
            legend.BackColor = System.Drawing.Color.Transparent;
            bar_chart_TQ.Legends.Add(legend);

            // Tạo series cho Doanh thu
            Series seriesRevenue = new Series("Doanh thu");
            seriesRevenue.ChartType = SeriesChartType.Column;
            seriesRevenue.IsValueShownAsLabel = false;
            seriesRevenue.Color = System.Drawing.Color.Cyan;
            //seriesRevenue.Color = System.Drawing.Color.White;
            seriesRevenue.Legend = "Legend1";

            // Tạo series cho Chi phí
            Series seriesCost = new Series("Chi phí");
            seriesCost.ChartType = SeriesChartType.Column;
            seriesCost.IsValueShownAsLabel = false;
            seriesCost.Color = System.Drawing.Color.FromArgb(255, 192, 128);
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
            chartAreaRevenue.BackColor = System.Drawing.Color.White;
            //chartAreaRevenue.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            DTTQ_piechart.ChartAreas.Add(chartAreaRevenue);

            System.Windows.Forms.DataVisualization.Charting.Legend legendRevenue = new System.Windows.Forms.DataVisualization.Charting.Legend("LegendRevenue");
            legendRevenue.BackColor = System.Drawing.Color.Transparent;
            DTTQ_piechart.Legends.Add(legendRevenue);

            Series seriesRevenuePie = new Series("Doanh thu chi tiết");
            seriesRevenuePie.ChartType = SeriesChartType.Pie;
            seriesRevenuePie.IsValueShownAsLabel = true;
            seriesRevenuePie.LabelFormat = "{0:N0} VNĐ";
            seriesRevenuePie.Legend = "LegendRevenue";

            if (totalRevenue > 0) // Chỉ tính phần trăm nếu tổng doanh thu lớn hơn 0
            {
                if (totalRevenue_Product > 0)
                {
                    int pointIndex = seriesRevenuePie.Points.AddXY("Sản phẩm", totalRevenue_Product);
                    seriesRevenuePie.Points[pointIndex].Color = System.Drawing.Color.FromArgb(79, 145, 205);
                    seriesRevenuePie.Points[pointIndex].Label = $"{(totalRevenue_Product / totalRevenue * 100):0.##}%";
                    seriesRevenuePie.Points[pointIndex].LegendText = "Sản phẩm";
                }
                if (totalRevenue_Ticket > 0)
                {
                    int pointIndex = seriesRevenuePie.Points.AddXY("Vé", totalRevenue_Ticket);
                    seriesRevenuePie.Points[pointIndex].Color = System.Drawing.Color.FromArgb(116, 206, 247);
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
            chartAreaCost.BackColor = System.Drawing.Color.White;
            //chartAreaCost.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            CPTQ_piechart.ChartAreas.Add(chartAreaCost);

            System.Windows.Forms.DataVisualization.Charting.Legend legendCost = new System.Windows.Forms.DataVisualization.Charting.Legend("LegendCost");
            legendCost.BackColor = System.Drawing.Color.Transparent;
            CPTQ_piechart.Legends.Add(legendCost);

            Series seriesCostPie = new Series("Chi phí chi tiết");
            seriesCostPie.ChartType = SeriesChartType.Pie;
            seriesCostPie.IsValueShownAsLabel = true;
            seriesCostPie.LabelFormat = "{0:N0} VNĐ";
            seriesCostPie.Legend = "LegendCost";

            if (totalCost > 0) // Chỉ tính phần trăm nếu tổng chi phí lớn hơn 0
            {
                if (totalCost_Product > 0)
                {
                    int pointIndex = seriesCostPie.Points.AddXY("Sản phẩm", totalCost_Product);
                    seriesCostPie.Points[pointIndex].Color = System.Drawing.Color.FromArgb(255, 192, 128);
                    seriesCostPie.Points[pointIndex].Label = $"{(totalCost_Product / totalCost * 100):0.##}%";
                    seriesCostPie.Points[pointIndex].LegendText = "Sản phẩm";
                }
                if (totalCost_Ticket > 0)
                {
                    int pointIndex = seriesCostPie.Points.AddXY("Vé", totalCost_Ticket);
                    seriesCostPie.Points[pointIndex].Color = System.Drawing.Color.FromArgb(255, 160, 96);
                    seriesCostPie.Points[pointIndex].Label = $"{(totalCost_Ticket / totalCost * 100):0.##}%";
                    seriesCostPie.Points[pointIndex].LegendText = "Vé xem phim ";
                }
                if (totalCost_Salary > 0)
                {
                    int pointIndex = seriesCostPie.Points.AddXY("Lương Nhân viên", totalCost_Salary);
                    seriesCostPie.Points[pointIndex].Color = System.Drawing.Color.FromArgb(255, 255, 65);
                    seriesCostPie.Points[pointIndex].Label = $"{(totalCost_Salary / totalCost * 100):0.##}%";
                    seriesCostPie.Points[pointIndex].LegendText = "Nhân Viên";
                }

            }

            CPTQ_piechart.Series.Add(seriesCostPie);
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
            int selectindex = this.cb_selectMonth.SelectedIndex;
            if (select_typeDetail.SelectedItem is DictionaryEntry selectedItem)
            {
                int selectYear = (int)selectedItem.Value;
                ShowTopMovieByRevenue(selectindex, selectYear);
                ShowGeneStatistic(selectindex, selectYear);
                //ShowstaticMonthinYear(selectYear);
                loadChartBySlot(selectindex, selectYear);
            }
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
                MessageBoxHelper.ShowSuccess("Thông báo", "Xuất file thành công!");
            }
        }

        private void GenerateExcelReport(DateTime startDate, DateTime endDate, string filePath)
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

            decimal totalCost_Salary = db.Staff_Salaries
                .Where(ss => ss.BillDate.HasValue && ss.BillDate.Value.Date >= startDate && ss.BillDate.Value.Date <= endDate)
                .Sum(ss => (decimal?)ss.Total) ?? 0;

            decimal totalRevenue = totalRevenue_Product + totalRevenue_Ticket;
            decimal totalCost = totalCost_Product + totalCost_Ticket;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thống kê");

                worksheet.Cell(1, 1).Value = "BÁO CÁO THỐNG KẾ DOANH THU VÀ CHI PHÍ";
                worksheet.Range("A1:D1").Merge();
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Cell(2, 1).Value = $"Từ ngày: {startDate:dd/MM/yyyy} - Đến ngày: {endDate:dd/MM/yyyy}";
                worksheet.Range("A2:D2").Merge();
                worksheet.Cell(2, 1).Style.Font.Italic = true;
                worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Cell(4, 1).Value = "Danh mục";
                worksheet.Cell(4, 2).Value = "Doanh thu (VNĐ)";
                worksheet.Cell(4, 3).Value = "Chi phí (VNĐ)";
                worksheet.Cell(4, 4).Value = "Tỷ lệ (%)";
                var headerRange = worksheet.Range("A4:D4");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                worksheet.Cell(5, 1).Value = "Tổng doanh thu";
                worksheet.Cell(5, 2).Value = totalRevenue;
                worksheet.Cell(5, 2).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(5, 4).Value = 100;
                worksheet.Cell(5, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(6, 1).Value = "Doanh thu sản phẩm";
                worksheet.Cell(6, 2).Value = totalRevenue_Product;
                worksheet.Cell(6, 2).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(6, 4).Value = totalRevenue > 0 ? (totalRevenue_Product / totalRevenue * 100) : 0;
                worksheet.Cell(6, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(7, 1).Value = "Doanh thu vé xem phim";
                worksheet.Cell(7, 2).Value = totalRevenue_Ticket;
                worksheet.Cell(7, 2).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(7, 4).Value = totalRevenue > 0 ? (totalRevenue_Ticket / totalRevenue * 100) : 0;
                worksheet.Cell(7, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(8, 1).Value = "Tổng chi phí";
                worksheet.Cell(8, 3).Value = totalCost;
                worksheet.Cell(8, 3).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(8, 4).Value = 100;
                worksheet.Cell(8, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(9, 1).Value = "Chi phí sản phẩm";
                worksheet.Cell(9, 3).Value = totalCost_Product;
                worksheet.Cell(9, 3).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(9, 4).Value = totalCost > 0 ? (totalCost_Product / totalCost * 100) : 0;
                worksheet.Cell(9, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(10, 1).Value = "Chi phí vé xem phim";
                worksheet.Cell(10, 3).Value = totalCost_Ticket;
                worksheet.Cell(10, 3).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(10, 4).Value = totalCost > 0 ? (totalCost_Ticket / totalCost * 100) : 0;
                worksheet.Cell(10, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Cell(11, 1).Value = "Chi phí lương nhân viên";
                worksheet.Cell(11, 3).Value = totalCost_Salary;
                worksheet.Cell(11, 3).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(11, 4).Value = totalCost > 0 ? (totalCost_Salary / totalCost * 100) : 0;
                worksheet.Cell(11, 4).Style.NumberFormat.Format = "0.00";

                worksheet.Columns(1, 4).AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        private void chuki_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new ConnectDataContext();
            // Lấy ngày nhỏ nhất
            var minDate = new[] {
            db.Bills.Min(b => b.BillDate),
            db.Bill_SellProducts.Min(sp => sp.BillDate)
            }.Min();

            // Lấy ngày lớn nhất
            var maxDate = new[] {
            db.Bills.Max(b => b.BillDate),
            db.Bill_SellProducts.Max(sp => sp.BillDate)
            }.Max();
            string selected = chuki_cbb.SelectedItem.ToString();
            if (selected == "Toàn bộ")
            {
                Tungay_label.Visible = false;
                Denngay_label.Visible = false;
                startDay_date.Visible = false;
                endDay_date.Visible = false;
                thoidiem_cbb.Visible = false;
                thoidiem_label.Visible = false;
                VeBieuDo_Tongquat(minDate, maxDate);

            }
            else
            {
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
                    int minMonth = minDate.Month;
                    int minYear = minDate.Year;
                    int currentMonth = DateTime.Now.Month;
                    int currentYear = DateTime.Now.Year;

                    // Duyệt qua các năm từ minYear đến currentYear
                    for (int year = minYear; year <= currentYear; year++)
                    {
                        int startMonth = (year == minYear) ? minMonth : 1; // Bắt đầu từ minMonth nếu là minYear
                        int endMonth = (year == currentYear) ? currentMonth : 12; // Kết thúc ở currentMonth nếu là currentYear

                        for (int month = startMonth; month <= endMonth; month++)
                        {
                            thoidiem_cbb.Items.Add($"Tháng {month} - {year}");
                        }
                    }
                }
                else if (selected == "Theo năm")
                {
                    int minYear = minDate.Year;
                    int currentYear = DateTime.Now.Year;

                    for (int year = minYear; year <= currentYear; year++)
                    {
                        thoidiem_cbb.Items.Add(year.ToString());
                    }
                }
                if (thoidiem_cbb.Items.Count > 0)
                {
                    thoidiem_cbb.SelectedIndex = 0; // chọn mặc định
                }
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
            VeBieuDo_Tongquat(startDate, endDate);
        }

        private void xuatExcel_bnt_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate, endDate;

                if (startDay_date.Visible && endDay_date.Visible)
                {
                    startDate = startDay_date.Value;
                    endDate = endDay_date.Value;
                }
                else
                {
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

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx|Tất cả file (*.*)|*.*",
                    FileName = $"ThongKe_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerateExcelReport(startDate, endDate, saveFileDialog.FileName);
                    MessageBoxHelper.ShowSuccess("Thành công", "Xuất file Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Đã xảy ra lỗi khi xuất file Excel");
            }
        }

        private void lammoi_bnt_Click(object sender, EventArgs e)
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
            VeBieuDo_Tongquat(startDate, endDate);
        }

        private void thodiem_cbb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            vebieudocotdoi_product();
            vebieudotron_doanhthuProduct();
            vebieudotron_chiphiProduct();
        }

        private void vebieudotron_doanhthuProduct()
        {
            var db = new ConnectDataContext();
            if (chuky_cbb_product.SelectedItem != null)
            {
                if (chuky_cbb_product.SelectedItem.ToString().Trim() == "Theo năm")
                {
                    if (thodiem_cbb_product.SelectedItem == null)
                    {
                        return;
                    }

                    // Lấy năm từ ComboBox
                    string selectedYear = thodiem_cbb_product.SelectedItem.ToString().Trim();
                    int targetYear;
                    if (!int.TryParse(selectedYear, out targetYear))
                    {
                        return;
                    }

                    var revenueData = db.BillDetailProducts
                        .Join(db.Products, bd => bd.Product_Id, p => p.ID, (bd, p) => new { p.Name, bd.TotalPrice, bd.Bill_SellProduct.BillDate })
                        .Where(x => x.BillDate.Year == targetYear)
                        .GroupBy(x => x.Name)
                        .Select(g => new
                        {
                            ProductName = g.Key,
                            TotalRevenue = g.Sum(x => x.TotalPrice)
                        })
                        .OrderByDescending(x => x.TotalRevenue) // Sắp xếp theo doanh thu từ cao đến thấp
                        .Take(5) // Lấy top 5 sản phẩm có doanh thu cao nhất
                        .ToList();

                    // Tính tổng doanh thu của top 5 sản phẩm
                    double totalRevenue = revenueData.Sum(x => x.TotalRevenue);

                    // Clear any previous data from the pie chart
                    doanhthu_product_pie.Series.Clear();
                    doanhthu_product_pie.ChartAreas.Clear();

                    // Create a new chart area if necessary
                    var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

                    // Đặt màu nền cho ChartArea
                    chartArea.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);  // Màu nền (192, 255, 255)

                    doanhthu_product_pie.ChartAreas.Add(chartArea);

                    // Tạo Legend và thay đổi màu nền của Legend
                    //Legend legend = new Legend("RevenueLegend");
                    //legend.BackColor = System.Drawing.Color.FromArgb(192, 255, 255); // Đặt màu nền cho Legend

                    //doanhthu_product_pie.Legends.Add(legend);

                    // Create a new series for the pie chart with additional styling
                    var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Revenue",
                        IsValueShownAsLabel = false, // Tắt hiển thị giá trị và tên trên các phần trong biểu đồ tròn
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                        BorderWidth = 1,
                        BorderColor = System.Drawing.Color.White, // Clear border color
                        ShadowOffset = 4 // Adding shadow for a 3D effect
                    };

                    // Customize the chart's colors
                    series1["ExplodedSliceColor"] = "White"; // Exploded slice color
                    series1["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

                    // Add data points to the pie chart
                    foreach (var data in revenueData)
                    {
                        // Tính tỷ lệ phần trăm
                        double percentage = (data.TotalRevenue / totalRevenue) * 100;

                        // Thêm điểm vào biểu đồ tròn
                        int pointIndex = series1.Points.AddXY(data.ProductName, data.TotalRevenue);
                        series1.Points[pointIndex].Label = ""; // Không hiển thị tỷ lệ phần trăm trên phần biểu đồ
                        series1.Points[pointIndex].Color = GetColorForIndex(pointIndex); // Assign dynamic colors based on the index or other logic

                        // Thêm tỷ lệ phần trăm vào Legend
                        series1.Points[pointIndex].LegendText = $"{data.ProductName}: {percentage:0.##}%"; // Hiển thị tên sản phẩm và tỷ lệ phần trăm trong Legend
                    }

                    // Add the series to the chart
                    doanhthu_product_pie.Series.Add(series1);



                    // Truy vấn Bill_AddProducts
                    var query1 = from bap in db.Bill_AddProducts
                                 join p in db.Products on bap.Product_Id equals p.ID
                                 where bap.BillDate.Year == targetYear // Lọc theo năm
                                 select new
                                 {
                                     ProductName = p.Name,
                                     TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                                 };

                    // Truy vấn Bill_ImportProducts
                    var query2 = from bap in db.Bill_ImportProducts
                                 join p in db.Products on bap.Product_Id equals p.ID
                                 where bap.BillDate.Year == targetYear // Lọc theo năm
                                 select new
                                 {
                                     ProductName = p.Name,
                                     TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                                 };

                    // Gộp kết quả từ hai bảng và nhóm theo tên sản phẩm
                    var combinedQuery = query1
                        .Union(query2) // Gộp kết quả từ Bill_AddProducts và Bill_ImportProducts
                        .GroupBy(x => x.ProductName) // Nhóm theo tên sản phẩm
                        .Select(group => new
                        {
                            ProductName = group.Key,
                            TotalPrice = group.Sum(x => x.TotalPrice) // Tính tổng chi phí cho mỗi sản phẩm
                        })
                        .OrderByDescending(x => x.TotalPrice) // Sắp xếp theo chi phí từ cao đến thấp
                        .Take(5) // Lấy top 5 sản phẩm có chi phí cao nhất
                        .ToList();

                    // Tính tổng chi phí của top 5 sản phẩm
                    double totalCost = combinedQuery.Sum(x => x.TotalPrice);

                    // Clear any previous data from the pie chart
                    chiphi_product_pie.Series.Clear();
                    chiphi_product_pie.ChartAreas.Clear();

                    // Create a new chart area if necessary
                    var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                    chartArea1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                    chiphi_product_pie.ChartAreas.Add(chartArea1);

                    // Create a new series for the pie chart with additional styling
                    var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Cost",
                        IsValueShownAsLabel = false, // Tắt hiển thị giá trị và tên trên các phần trong biểu đồ tròn
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                        BorderWidth = 1,
                        BorderColor = System.Drawing.Color.White, // Clear border color
                        ShadowOffset = 4 // Adding shadow for a 3D effect
                    };

                    // Customize the chart's colors
                    series2["ExplodedSliceColor"] = "White"; // Exploded slice color
                    series2["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

                    // Add data points to the pie chart
                    foreach (var data in combinedQuery)
                    {
                        // Tính tỷ lệ phần trăm
                        double percentage = (data.TotalPrice / totalCost) * 100;

                        // Thêm điểm vào biểu đồ tròn
                        int pointIndex = series2.Points.AddXY(data.ProductName, data.TotalPrice);
                        series2.Points[pointIndex].Label = ""; // Không hiển thị tỷ lệ phần trăm trên phần biểu đồ
                        series2.Points[pointIndex].Color = GetColorForIndex(pointIndex); // Assign dynamic colors

                        // Thêm tỷ lệ phần trăm vào Legend
                        series2.Points[pointIndex].LegendText = $"{data.ProductName}: {percentage:0.##}%"; // Hiển thị tên sản phẩm và tỷ lệ phần trăm trong Legend
                    }

                    // Add the series to the chart
                    chiphi_product_pie.Series.Add(series2);
                }
                else if (chuky_cbb_product.SelectedItem.ToString().Trim() == "Theo tháng")
                {
                    if (thodiem_cbb_product.SelectedItem == null)
                    {
                        return;
                    }

                    // Lấy năm và tháng từ ComboBox
                    string selectedMonthYear = thodiem_cbb_product.SelectedItem.ToString().Trim();
                    var parts = selectedMonthYear.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    int month = 0;
                    int currentYear = DateTime.Now.Year;

                    if (int.TryParse(parts[1], out month))
                    {
                        // Truy vấn doanh thu cho BillDetailProducts
                        var revenueData = db.BillDetailProducts
                            .Join(db.Products, bd => bd.Product_Id, p => p.ID, (bd, p) => new { p.Name, bd.TotalPrice, bd.Bill_SellProduct.BillDate })
                            .Where(x => x.BillDate.Year == currentYear && x.BillDate.Month == month)
                            .GroupBy(x => x.Name)
                            .Select(g => new
                            {
                                ProductName = g.Key,
                                TotalRevenue = g.Sum(x => x.TotalPrice)
                            })
                            .OrderByDescending(x => x.TotalRevenue) // Sắp xếp theo doanh thu từ cao đến thấp
                            .Take(5) // Lấy top 5 sản phẩm có doanh thu cao nhất
                            .ToList();

                        // Tính tổng doanh thu của top 5 sản phẩm
                        double totalRevenue = revenueData.Sum(x => x.TotalRevenue);

                        // Clear any previous data from the pie chart
                        doanhthu_product_pie.Series.Clear();
                        doanhthu_product_pie.ChartAreas.Clear();

                        // Create a new chart area if necessary
                        var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                        chartArea.BackColor = System.Drawing.Color.FromArgb(192, 255, 255); // Màu nền ChartArea
                        doanhthu_product_pie.ChartAreas.Add(chartArea);

                        // Create a new series for the pie chart with additional styling
                        var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                        {
                            Name = "Revenue",
                            IsValueShownAsLabel = true,
                            ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                            BorderWidth = 1,
                            BorderColor = System.Drawing.Color.White,
                            LabelFormat = "#", // Custom label format
                            ShadowOffset = 4 // Adding shadow for a 3D effect
                        };

                        // Customize the chart's colors
                        series1["ExplodedSliceColor"] = "White"; // Exploded slice color
                        series1["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

                        // Add data points to the pie chart
                        foreach (var data in revenueData)
                        {
                            series1.Points.AddXY(data.ProductName, data.TotalRevenue);
                        }

                        // Apply custom colors to each slice (if needed)
                        for (int i = 0; i < series1.Points.Count; i++)
                        {
                            series1.Points[i].Color = GetColorForIndex(i); // Assign dynamic colors
                        }

                        // Add the series to the chart
                        doanhthu_product_pie.Series.Add(series1);


                        // Truy vấn Bill_AddProducts
                        var query1 = from bap in db.Bill_AddProducts
                                     join p in db.Products on bap.Product_Id equals p.ID
                                     where bap.BillDate.Year == currentYear && bap.BillDate.Month == month
                                     select new
                                     {
                                         ProductName = p.Name,
                                         TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                                     };

                        // Truy vấn Bill_ImportProducts
                        var query2 = from bap in db.Bill_ImportProducts
                                     join p in db.Products on bap.Product_Id equals p.ID
                                     where bap.BillDate.Year == currentYear && bap.BillDate.Month == month
                                     select new
                                     {
                                         ProductName = p.Name,
                                         TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                                     };

                        // Gộp kết quả từ hai bảng và nhóm theo tên sản phẩm
                        var combinedQuery = query1
                            .Concat(query2) // Sử dụng Concat thay vì Union nếu muốn giữ tất cả các bản sao
                            .GroupBy(x => x.ProductName)
                            .Select(group => new
                            {
                                ProductName = group.Key,
                                TotalPrice = group.Sum(x => x.TotalPrice)
                            })
                            .OrderByDescending(x => x.TotalPrice) // Sắp xếp theo chi phí từ cao đến thấp
                            .Take(5) // Lấy top 5 sản phẩm có chi phí cao nhất
                            .ToList();

                        // Clear any previous data from the pie chart
                        chiphi_product_pie.Series.Clear();
                        chiphi_product_pie.ChartAreas.Clear();

                        // Create a new chart area if necessary
                        var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                        chartArea1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); // Màu nền ChartArea
                        chiphi_product_pie.ChartAreas.Add(chartArea1);

                        // Tạo và thay đổi màu nền cho Legend
                        //Legend legend = new Legend("RevenueLegend");
                        //legend.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); // Màu nền Legend
                        //chiphi_product_pie.Legends.Add(legend);

                        // Create a new series for the pie chart with additional styling
                        var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
                        {
                            Name = "Revenue",
                            IsValueShownAsLabel = true,
                            ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                            BorderWidth = 1,
                            BorderColor = System.Drawing.Color.White,
                            LabelFormat = "#,0", // Custom label format
                            ShadowOffset = 4 // Adding shadow for a 3D effect
                        };

                        // Customize the chart's colors
                        series2["ExplodedSliceColor"] = "White"; // Exploded slice color
                        series2["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

                        // Add data points to the pie chart
                        foreach (var data in combinedQuery)
                        {
                            series2.Points.AddXY(data.ProductName, data.TotalPrice);
                        }

                        // Apply custom colors to each slice (if needed)
                        for (int i = 0; i < series2.Points.Count; i++)
                        {
                            series2.Points[i].Color = GetColorForIndex(i); // Assign dynamic colors based on the index or other logic
                        }

                        // Add the series to the chart
                        chiphi_product_pie.Series.Add(series2);
                    }

                }
            }
        }
        private System.Drawing.Color GetColorForIndex(int index)
        {
            var colors = new[] {
                    System.Drawing.Color.LightBlue,
                    System.Drawing.Color.Pink,
                    System.Drawing.Color.LightGreen,
                    System.Drawing.Color.LightCoral,
                    System.Drawing.Color.Lavender,
                    System.Drawing.Color.PeachPuff,
                    System.Drawing.Color.MistyRose,
                    System.Drawing.Color.Wheat
                };
            return colors[index % colors.Length];
        }

        private void vebieudotron_chiphiProduct()
        {

        }

        private void vebieudocotdoi_product()
        {
            var db = new ConnectDataContext();
            if (chuky_cbb_product.SelectedItem != null)
            {
                if (chuky_cbb_product.SelectedItem.ToString().Trim() == "Theo năm")
                {
                    if (thodiem_cbb_product.SelectedItem == null)
                    {
                        return;
                    }
                    string selectedYear = thodiem_cbb_product.SelectedItem.ToString().Trim();
                    int targetYear;
                    if (!int.TryParse(selectedYear, out targetYear))
                    {
                        return;
                    }
                    // 1. Tổng doanh thu, lọc theo năm
                    var totalRevenue = db.Bill_SellProducts
                                          .Where(b => b.BillDate.Year == targetYear)
                                          .Sum(b => (decimal?)b.TotalAmount) ?? 0;

                    // 2. Tổng chi phí nhập hàng Bill_ImportProducts, lọc theo năm
                    var totalImportProductCost = db.Bill_ImportProducts
                                                    .Where(b => b.BillDate.Year == targetYear)
                                                    .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

                    // 3. Tổng chi phí nhập hàng Bill_AddProducts, lọc theo năm
                    var totalAddProductCost = db.Bill_AddProducts
                                                 .Where(b => b.BillDate.Year == targetYear)
                                                 .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

                    doanhthuProduct_lbl.Text = totalRevenue.ToString("N0");
                    var totalCost = (totalImportProductCost + totalAddProductCost);
                    tongchiphiProduct_lbl.Text = totalCost.ToString("N0");

                    vecotdoi(totalRevenue, totalImportProductCost + totalAddProductCost);
                }
                else if (chuky_cbb_product.SelectedItem.ToString().Trim() == "Theo tháng")
                {
                    if (thodiem_cbb_product.SelectedItem == null)
                    {
                        return;
                    }
                    string selectedMonthYear = thodiem_cbb_product.SelectedItem.ToString().Trim();
                    var parts = selectedMonthYear.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    int month = 0;
                    int currentYear = DateTime.Now.Year;
                    if (int.TryParse(parts[1], out month))
                    {
                        // 1. Tổng doanh thu, lọc theo tháng và năm
                        var totalRevenue = db.Bill_SellProducts
                                              .Where(b => b.BillDate.Year == currentYear && b.BillDate.Month == month)
                                              .Sum(b => (decimal?)b.TotalAmount) ?? 0;

                        // 2. Tổng chi phí nhập hàng Bill_ImportProducts, lọc theo tháng và năm
                        var totalImportProductCost = db.Bill_ImportProducts
                                                        .Where(b => b.BillDate.Year == currentYear && b.BillDate.Month == month)
                                                        .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

                        // 3. Tổng chi phí nhập hàng Bill_AddProducts, lọc theo tháng và năm
                        var totalAddProductCost = db.Bill_AddProducts
                                                     .Where(b => b.BillDate.Year == currentYear && b.BillDate.Month == month)
                                                     .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

                        doanhthuProduct_lbl.Text = totalRevenue.ToString("N0");
                        var totalCost = (totalImportProductCost + totalAddProductCost);
                        tongchiphiProduct_lbl.Text = totalCost.ToString("N0");

                        vecotdoi(totalRevenue, totalImportProductCost + totalAddProductCost);
                    }

                }
            }

        }


        void vecotdoi(decimal a, decimal b)
        {
            barchart_product.Series.Clear();
            barchart_product.ChartAreas.Clear();

            // Tạo ChartArea
            ChartArea chartArea = new ChartArea("MainArea");
            barchart_product.ChartAreas.Add(chartArea);

            // Tạo series cột
            Series series = new Series("Tổng hợp");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            series.Points.AddXY("Doanh thu", a);
            series.Points.AddXY("Vốn", b);

            // Thêm series vào biểu đồ
            barchart_product.Series.Add(series);
        }

        private void guna2TabControl1_Selecting_1(object sender, TabControlCancelEventArgs e)
        {
            int[] allowedTabs = { 2, 3, 4 };
            if (!allowedTabs.Contains(e.TabPageIndex))
            {
                e.Cancel = true;
            }
        }

        private void chuky_cbb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = chuky_cbb_product.SelectedItem.ToString();

            bool isCustom = !(selected == "Theo tháng" || selected == "Theo năm");
            tungay_lbl_Product.Visible = isCustom;
            denngay_lbl_Product.Visible = isCustom;

            dtpker_product1.Visible = isCustom;
            dtpker_product2.Visible = isCustom;
            thodiem_cbb_product.Visible = !isCustom;
            label26.Visible = !isCustom;

            thodiem_cbb_product.Items.Clear();

            if (selected == "Theo tháng")
            {
                int currentMonth = DateTime.Now.Month;
                for (int i = 1; i <= currentMonth; i++)
                {
                    thodiem_cbb_product.Items.Add($"Tháng {i} - {DateTime.Now.Year}");
                }
            }
            else if (selected == "Theo năm")
            {
                for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year; i++) // 5 năm gần đây
                {
                    thodiem_cbb_product.Items.Add(i.ToString());
                }
            }
        }

        private void dtpker_product1_ValueChanged(object sender, EventArgs e)
        {
            loadByrange_bieudocot();
            loadByrange_bieudotron();
        }

        private void dtpker_product2_ValueChanged(object sender, EventArgs e)
        {
            loadByrange_bieudocot();
            loadByrange_bieudotron();
        }

        private void loadByrange_bieudocot()
        {
            var db = new ConnectDataContext();

            // Lấy giá trị ngày từ các DateTimePicker (bao gồm ngày, giờ, phút, giây)
            DateTime startDate = dtpker_product1.Value.Date;  // Lấy chỉ phần ngày (ngày bắt đầu)
            DateTime endDate = dtpker_product2.Value.Date;    // Lấy chỉ phần ngày (ngày kết thúc)

            // 1. Tổng doanh thu, lọc theo ngày bắt đầu và kết thúc
            var totalRevenue = db.Bill_SellProducts
                                  .Where(b => b.BillDate >= startDate && b.BillDate <= endDate.AddDays(1).AddMilliseconds(-1))
                                  .Sum(b => (decimal?)b.TotalAmount) ?? 0;

            // 2. Tổng chi phí nhập hàng Bill_ImportProducts, lọc theo ngày bắt đầu và kết thúc
            var totalImportProductCost = db.Bill_ImportProducts
                                            .Where(b => b.BillDate >= startDate && b.BillDate <= endDate.AddDays(1).AddMilliseconds(-1))
                                            .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

            // 3. Tổng chi phí nhập hàng Bill_AddProducts, lọc theo ngày bắt đầu và kết thúc
            var totalAddProductCost = db.Bill_AddProducts
                                         .Where(b => b.BillDate >= startDate && b.BillDate <= endDate.AddDays(1).AddMilliseconds(-1))
                                         .Sum(b => (decimal?)b.Quantity * b.UnitPurchasePrice) ?? 0;

            // Cập nhật các nhãn
            doanhthuProduct_lbl.Text = totalRevenue.ToString("N0");
            var totalCost = totalImportProductCost + totalAddProductCost;
            tongchiphiProduct_lbl.Text = totalCost.ToString("N0");

            vecotdoi(totalRevenue, totalImportProductCost + totalAddProductCost);
        }

        private void loadByrange_bieudotron()
        {
            var db = new ConnectDataContext();
            DateTime startDate = dtpker_product1.Value.Date;  // Lấy chỉ phần ngày (ngày bắt đầu)
            DateTime endDate = dtpker_product2.Value.Date;    // Lấy chỉ phần ngày (ngày kết thúc)

            // Cập nhật câu truy vấn để lọc theo khoảng thời gian
            var revenueData = db.BillDetailProducts
                       .Join(db.Products, bd => bd.Product_Id, p => p.ID, (bd, p) => new { p.Name, bd.TotalPrice, bd.Bill_SellProduct.BillDate })
                       .Where(x => x.BillDate >= startDate && x.BillDate <= endDate)  // Lọc theo khoảng thời gian
                       .GroupBy(x => x.Name)
                       .Select(g => new
                       {
                           ProductName = g.Key,
                           TotalRevenue = g.Sum(x => x.TotalPrice)
                       })
                       .OrderByDescending(x => x.TotalRevenue) // Sắp xếp theo doanh thu từ cao đến thấp
                       .Take(5)  // Lấy top 5 sản phẩm có doanh thu cao nhất
                       .ToList();

            // Tính tổng doanh thu của top 5 sản phẩm
            double totalRevenue = revenueData.Sum(x => x.TotalRevenue);

            // Clear any previous data from the pie chart
            doanhthu_product_pie.Series.Clear();
            doanhthu_product_pie.ChartAreas.Clear();

            // Create a new chart area if necessary
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea.BackColor = System.Drawing.Color.FromArgb(192, 255, 255); // Màu nền ChartArea
            doanhthu_product_pie.ChartAreas.Add(chartArea);

            // Create a new series for the pie chart with additional styling
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Revenue",
                IsValueShownAsLabel = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                BorderWidth = 1,
                BorderColor = System.Drawing.Color.White,
                LabelFormat = "#", // Custom label format
                ShadowOffset = 4 // Adding shadow for a 3D effect
            };

            // Customize the chart's colors
            series1["ExplodedSliceColor"] = "White"; // Exploded slice color
            series1["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

            // Add data points to the pie chart
            foreach (var data in revenueData)
            {
                series1.Points.AddXY(data.ProductName, data.TotalRevenue);
            }

            // Apply custom colors to each slice (if needed)
            for (int i = 0; i < series1.Points.Count; i++)
            {
                series1.Points[i].Color = GetColorForIndex(i); // Assign dynamic colors
            }

            // Add the series to the chart
            doanhthu_product_pie.Series.Add(series1);

            // Truy vấn Bill_AddProducts
            var query1 = from bap in db.Bill_AddProducts
                         join p in db.Products on bap.Product_Id equals p.ID
                         where bap.BillDate >= startDate && bap.BillDate <= endDate // Lọc theo khoảng thời gian
                         select new
                         {
                             ProductName = p.Name,
                             TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                         };

            // Truy vấn Bill_ImportProducts
            var query2 = from bap in db.Bill_ImportProducts
                         join p in db.Products on bap.Product_Id equals p.ID
                         where bap.BillDate >= startDate && bap.BillDate <= endDate // Lọc theo khoảng thời gian
                         select new
                         {
                             ProductName = p.Name,
                             TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                         };

            // Gộp kết quả từ hai bảng và nhóm theo tên sản phẩm
            var combinedQuery = query1
                .Concat(query2) // Sử dụng Concat thay vì Union nếu muốn giữ tất cả các bản sao
                .GroupBy(x => x.ProductName)
                .Select(group => new
                {
                    ProductName = group.Key,
                    TotalPrice = group.Sum(x => x.TotalPrice)
                })
                .OrderByDescending(x => x.TotalPrice) // Sắp xếp theo chi phí từ cao đến thấp
                .Take(5) // Lấy top 5 sản phẩm có chi phí cao nhất
                .ToList();

            // Clear any previous data from the pie chart
            chiphi_product_pie.Series.Clear();
            chiphi_product_pie.ChartAreas.Clear();

            // Create a new chart area if necessary
            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); // Màu nền ChartArea
            chiphi_product_pie.ChartAreas.Add(chartArea1);

            // Tạo và thay đổi màu nền cho Legend
            //Legend legend = new Legend("RevenueLegend");
            //legend.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); // Màu nền Legend
            //chiphi_product_pie.Legends.Add(legend);

            // Create a new series for the pie chart with additional styling
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Revenue",
                IsValueShownAsLabel = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                BorderWidth = 1,
                BorderColor = System.Drawing.Color.White,
                LabelFormat = "#,0", // Custom label format
                ShadowOffset = 4 // Adding shadow for a 3D effect
            };

            // Customize the chart's colors
            series2["ExplodedSliceColor"] = "White"; // Exploded slice color
            series2["DoughnutRadius"] = "70"; // Optional: makes it look like a doughnut chart

            // Add data points to the pie chart
            foreach (var data in combinedQuery)
            {
                series2.Points.AddXY(data.ProductName, data.TotalPrice);
            }

            // Apply custom colors to each slice (if needed)
            for (int i = 0; i < series2.Points.Count; i++)
            {
                series2.Points[i].Color = GetColorForIndex(i); // Assign dynamic colors based on the index or other logic
            }

            // Add the series to the chart
            chiphi_product_pie.Series.Add(series2);
        }

        private void xuatfile_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate, endDate;
                if (dtpker_product1.Visible && dtpker_product2.Visible)
                {
                    startDate = dtpker_product1.Value;
                    endDate = dtpker_product2.Value;
                }
                else
                {
                    string selectedPeriod = chuky_cbb_product.SelectedItem?.ToString();
                    string selectedItem = thodiem_cbb_product.SelectedItem?.ToString();
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
                    else
                    {
                        int year = int.Parse(selectedItem);
                        startDate = new DateTime(year, 1, 1);
                        endDate = new DateTime(year, 12, 31);
                    }
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx|Tất cả file (*.*)|*.*",
                    FileName = $"ThongKe_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerateExcelReportProduct(startDate, endDate, saveFileDialog.FileName);
                    MessageBoxHelper.ShowSuccess("Thành công", "Xuất file Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Đã xảy ra lỗi khi xuất file Excel");
            }
        }

        private void GenerateExcelReportProduct(DateTime startDate, DateTime endDate, string filePath)
        {
            var db = new ConnectDataContext();
            // Query for sales details (query1)
            var query1 = from bap in db.Bill_AddProducts
                         join p in db.Products on bap.Product_Id equals p.ID
                         where bap.BillDate >= startDate && bap.BillDate <= endDate // Filter by date range
                         select new
                         {
                             ProductName = p.Name,
                             TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                         };

            // Query for product imports (query2)
            var query2 = from bap in db.Bill_ImportProducts
                         join p in db.Products on bap.Product_Id equals p.ID
                         where bap.BillDate >= startDate && bap.BillDate <= endDate // Filter by date range
                         select new
                         {
                             ProductName = p.Name,
                             TotalPrice = bap.Quantity * bap.UnitPurchasePrice
                         };

            // Other calculations...

            // Create the Excel report using the existing code
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Thống kê");

                // Your existing code to add general report data (header, totals, etc.)

                // Insert the query1 results (Sales Details)
                int currentRow = 12; // Starting row for Sales Data Table
                worksheet.Cell(currentRow, 1).Value = "Bảng Doanh Thu Chi Tiết Bán Sản Phẩm";
                worksheet.Range($"A{currentRow}:D{currentRow}").Merge();
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Table header for Sales Details
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Tên Sản Phẩm";
                worksheet.Cell(currentRow, 2).Value = "Doanh Thu (VNĐ)";
                worksheet.Range($"A{currentRow}:B{currentRow}").Style.Font.Bold = true;

                // Insert data from query1
                foreach (var sale in query1)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = sale.ProductName;
                    worksheet.Cell(currentRow, 2).Value = sale.TotalPrice;
                    worksheet.Cell(currentRow, 2).Style.NumberFormat.Format = "#,##0";
                }

                // Insert the query2 results (Product Imports)
                currentRow += 2; // Leave a gap between tables
                worksheet.Cell(currentRow, 1).Value = "Bảng Nhập Sản Phẩm";
                worksheet.Range($"A{currentRow}:D{currentRow}").Merge();
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Table header for Product Imports
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Tên Sản Phẩm";
                worksheet.Cell(currentRow, 2).Value = "Tổng Chi Phí (VNĐ)";
                worksheet.Range($"A{currentRow}:B{currentRow}").Style.Font.Bold = true;

                // Insert data from query2
                foreach (var import in query2)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = import.ProductName;
                    worksheet.Cell(currentRow, 2).Value = import.TotalPrice;
                    worksheet.Cell(currentRow, 2).Style.NumberFormat.Format = "#,##0";
                }

                // Adjust column widths
                worksheet.Columns(1, 4).AdjustToContents();

                // Save the workbook to the specified file path
                workbook.SaveAs(filePath);
            }
        }

        private void thodiem_cbb_product_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            vebieudocotdoi_product();
            vebieudotron_doanhthuProduct();
            vebieudotron_chiphiProduct();
        }
    }
}
