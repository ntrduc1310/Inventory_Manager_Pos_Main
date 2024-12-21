using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System.Windows.Forms.DataVisualization.Charting;
namespace PL.View
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void gunaChart1_Load(object sender, EventArgs e)
        {

        }


        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Thêm các mục vào ComboBox
            cb_chooseDate.Items.Add("Hôm nay");
            cb_chooseDate.Items.Add("7 ngày qua");
            cb_chooseDate.Items.Add("30 ngày qua");
            cb_chooseDate.Items.Add("Chọn khoảng ngày");

            // Gán sự kiện SelectedIndexChanged để xử lý khi người dùng chọn mục
            cb_chooseDate.SelectedIndexChanged += ReportComboBox_SelectedIndexChanged;
        }



        private void ReportComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Báo cáo hôm nay");

                        break;

                    case 1:
                        MessageBox.Show("Báo cáo 7 ngày qua");
                        // Thực hiện logic cho báo cáo 7 ngày qua
                        break;

                    case 2:
                        MessageBox.Show("Báo cáo 30 ngày qua");
                        // Thực hiện logic cho báo cáo 30 ngày qua
                        break;

                    case 3:
                        MessageBox.Show("Chọn khoảng ngày");
                        // Thực hiện logic hiển thị chọn ngày
                        ShowDateRangePicker();
                        break;

                    default:
                        break;
                }
            }
        }

        private void ShowDateRangePicker()
        {
            // Hiển thị một hộp thoại chọn khoảng ngày
            using (Form dateRangeForm = new Form())
            {
                dateRangeForm.Text = "Chọn khoảng ngày";
                dateRangeForm.StartPosition = FormStartPosition.CenterParent;
                dateRangeForm.Width = 400;
                dateRangeForm.Height = 300;

                Label lblStartDate = new Label { Text = "Ngày bắt đầu:", Top = 5, Left = 20, };
                DateTimePicker startDatePicker = new DateTimePicker { Top = 40, Left = 20, Width = 250 };

                Label lblEndDate = new Label { Text = "Ngày kết thúc:", Top = 80, Left = 20 };
                DateTimePicker endDatePicker = new DateTimePicker { Top = 110, Left = 20, Width = 250 };

                Button btnOk = new Button { Text = "OK", Width = 50, Height = 40, Top = 160, Left = 20 };
                btnOk.Click += (s, e) =>
                {
                    MessageBox.Show($"Khoảng ngày được chọn: {startDatePicker.Value.ToShortDateString()} - {endDatePicker.Value.ToShortDateString()}");
                    dateRangeForm.Close();
                };

                dateRangeForm.Controls.Add(lblStartDate);
                dateRangeForm.Controls.Add(startDatePicker);
                dateRangeForm.Controls.Add(lblEndDate);
                dateRangeForm.Controls.Add(endDatePicker);
                dateRangeForm.Controls.Add(btnOk);

                dateRangeForm.ShowDialog();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

