using Guna.UI2.WinForms;
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

namespace PL.View
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // Gọi phương thức InitializeChart khi Form được load
            InitializeChart1();
        }

        // Phương thức InitializeChart nằm trong lớp DashBoard
        private void InitializeChart1()
        {
            // Tạo một Panel Guna2 để chứa biểu đồ
            var chartPanel = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 350,
                Padding = new Padding(10),
                BorderColor = Color.Gray,
                BorderThickness = 1
            };

            // Tạo biểu đồ Chart
            var chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(250, 250, 250), // Nền trắng nhạt
            };

            // Khu vực biểu đồ
            var chartArea = new ChartArea("MainArea")
            {
                BackColor = Color.FromArgb(245, 245, 245), // Nền khu vực biểu đồ
                AxisX = new Axis
                {
                    LineColor = Color.Gray,
                    LabelStyle = { ForeColor = Color.DimGray, Font = new Font("Arial", 10) }
                },
                AxisY = new Axis
                {
                    LineColor = Color.Gray,
                    LabelStyle = { ForeColor = Color.DimGray, Font = new Font("Arial", 10) }
                }
            };

            chart.ChartAreas.Add(chartArea);

            // Series (Dữ liệu biểu đồ)
            var series1 = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(100, 0, 120, 255), // Màu vùng
                BorderWidth = 2,
                Points =
                {
                    new DataPoint(0, 10),
                    new DataPoint(1, 20),
                    new DataPoint(2, 15),
                    new DataPoint(3, 25),
                    new DataPoint(4, 18),
                    new DataPoint(5, 30)
                }
            };

            var series2 = new Series
            {
                Name = "Series2",
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(100, 255, 165, 0), // Màu vùng
                BorderWidth = 2,
                Points =
                {
                    new DataPoint(0, 5),
                    new DataPoint(1, 15),
                    new DataPoint(2, 10),
                    new DataPoint(3, 20),
                    new DataPoint(4, 12),
                    new DataPoint(5, 25)
                }
            };

            chart.Series.Add(series1);
            chart.Series.Add(series2);

            // Thêm Chart vào Panel
            chartPanel.Controls.Add(chart);

            // Thêm Panel vào Form
            this.Controls.Add(chartPanel);
        }
    


        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
