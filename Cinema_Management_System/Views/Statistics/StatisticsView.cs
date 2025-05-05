using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cinema_Management_System.Views.Statistics
{
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();
            ////    // Vẽ biểu đồ cột cho tổng doanh thu (tongquat_chart)
            guna2TabControl1.SelectedIndex = 2;
            //tongquat_chart.Series.Clear();
            //tongquat_chart.ChartAreas.Clear();
            //ChartArea chartArea1 = new ChartArea("Default");
            //tongquat_chart.ChartAreas.Add(chartArea1);

            //Series series1 = new Series("Tổng doanh thu")
            //{
            //    ChartType = SeriesChartType.Column
            //};
            //series1.Points.AddXY("Th1", 10);
            //series1.Points.AddXY("Th2", 20);
            //series1.Points.AddXY("Th3", 15);
            //series1.Points.AddXY("Th4", 30);
            //series1.Points.AddXY("Th5", 25);
            //tongquat_chart.Series.Add(series1);
            //tongquat_chart.ChartAreas[0].AxisX.Title = "Tháng";
            //tongquat_chart.ChartAreas[0].AxisY.Title = "Doanh thu (triệu)";

            // Vẽ biểu đồ tròn cho cơ cấu doanh thu (chart2)
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            ChartArea chartArea2 = new ChartArea("Default");
            chart2.ChartAreas.Add(chartArea2);

            Series series2 = new Series("Cơ cấu doanh thu")
            {
                ChartType = SeriesChartType.Pie
            };
            series2.Points.AddXY("Phim A", 20);
            series2.Points.AddXY("Phim B", 30);
            series2.Points.AddXY("Phim C", 15);
            series2.Points.AddXY("Phim D", 35);
            series2.IsValueShownAsLabel = true;
            chart2.Series.Add(series2);

            // Vẽ biểu đồ cột cho tổng chi phí (chart3)
            chart3.Series.Clear();
            chart3.ChartAreas.Clear();
            ChartArea chartArea3 = new ChartArea("Default");
            chart3.ChartAreas.Add(chartArea3);

            Series series3 = new Series("Tổng chi phí")
            {
                ChartType = SeriesChartType.Column
            };
            series3.Points.AddXY("Th1", 5);
            series3.Points.AddXY("Th2", 15);
            series3.Points.AddXY("Th3", 10);
            series3.Points.AddXY("Th4", 25);
            series3.Points.AddXY("Th5", 20);
            chart3.Series.Add(series3);
            chart3.ChartAreas[0].AxisX.Title = "Tháng";
            chart3.ChartAreas[0].AxisY.Title = "Chi phí (triệu)";
        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int[] allowedTabs = { 2, 3, 4 };
            if (!allowedTabs.Contains(e.TabPageIndex))
            {
                e.Cancel = true;
            }
        }



        private void tongquat_chart_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void chart7_Click(object sender, EventArgs e)
        {

        }
    }
}
