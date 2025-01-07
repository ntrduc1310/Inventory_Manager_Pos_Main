using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization; 
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PL.View
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.Load += Form1_Load;
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
            cb_chooseDate.SelectedIndex = 0;
            // Gán sự kiện SelectedIndexChanged để xử lý khi người dùng chọn mục
            cb_chooseDate.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            HandleComboBoxSelection(cb_chooseDate.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi logic xử lý khi mục được chọn thay đổi
            HandleComboBoxSelection(cb_chooseDate.SelectedIndex);
        }
        private async void LoadSalesByDate()
        {
            // Lấy danh sách đơn hàng theo ngày
            var sales = await new BL.Report.reportBL().SaleTodayBL();

            // Hiển thị danh sách trong ListBox
            listBox1.Items.Clear(); // Xóa dữ liệu cũ
            foreach (var order in sales)
            {
                listBox1.Items.Add($"Mã đơn hàng: {order.SaleID}, Ngày bán: {order.SaleDate.Date.ToShortDateString()}, Tổng tiền: {order.TotalAmount:N0} VNĐ");
            }

            // Nếu không có đơn hàng nào
            if (sales.Count == 0)
            {
                listBox1.Items.Add("Không có đơn hàng nào trong ngày được chọn.");
            }
        }

        private async void LoadSales7Date()
        {
            // Lấy danh sách đơn hàng theo khoảng ngày
            var sales = await new BL.Report.reportBL().Sale7DayBL();
            // Hiển thị danh sách trong ListBox
            listBox1.Items.Clear(); // Xóa dữ liệu cũ
            foreach (var order in sales)
            {
                listBox1.Items.Add($"Mã đơn hàng: {order.SaleID}, Ngày bán: {order.SaleDate.Date.ToShortDateString()}, Tổng tiền: {order.TotalAmount:N0} VNĐ");
            }

            // Nếu không có đơn hàng nào
            if (sales.Count == 0)
            {
                listBox1.Items.Add("Không có đơn hàng nào trong ngày được chọn.");
            }
        }

        private async void LoadSales30Date()
        {
            // Lấy danh sách đơn hàng theo khoảng ngày
            var sales = await new BL.Report.reportBL().Sale30DayBL();
            // Hiển thị danh sách trong ListBox
            listBox1.Items.Clear(); // Xóa dữ liệu cũ
            foreach (var order in sales)
            {
                listBox1.Items.Add($"Mã đơn hàng: {order.SaleID}, Ngày bán: {order.SaleDate.Date.ToShortDateString()}, Tổng tiền: {order.TotalAmount:N0} VNĐ");
            }

            // Nếu không có đơn hàng nào
            if (sales.Count == 0)
            {
                listBox1.Items.Add("Không có đơn hàng nào trong ngày được chọn.");
            }
        }
        public async void HandleComboBoxSelection(int selectIndex)
        {
            switch (selectIndex)
            {
                case 0:
                    var report = await new BL.Report.reportBL().GetSalesSummaryTodayBL();
                    if (decimal.TryParse(report.TotalSale.ToString(), out decimal totalSaleToday))
                    {
                        lbl_turnover.Text = totalSaleToday.ToString("N0") + " VNĐ";
                    }
                    lbl_TotalCostPrice.Text = report.TotalCostPrice.ToString("N0") + " VNĐ";
                    lbl_Profit.Text = (report.TotalSale - report.TotalCostPrice).ToString("N0") + " VNĐ";
                    lbl_Quantity.Text = report.OrderCount.ToString();
                    LoadSalesByDate();
                    break;

                case 1:
                    var report1 = await new BL.Report.reportBL().GetSalesSummaryLast7DaysBL();
                    if (decimal.TryParse(report1.TotalSale.ToString(), out decimal totalSale7Days))
                    {
                        lbl_turnover.Text = totalSale7Days.ToString("N0") + " VNĐ";
                    }
                    lbl_TotalCostPrice.Text = report1.TotalCostPrice.ToString("N0") + " VNĐ";
                    lbl_Profit.Text = (report1.TotalSale - report1.TotalCostPrice).ToString("N0") + " VNĐ";
                    lbl_Quantity.Text = report1.OrderCount.ToString();
                    LoadSales7Date();
                    break;

                case 2:
                    var report2 = await new BL.Report.reportBL().GetSalesSummaryLast30DaysBL();
                    if (decimal.TryParse(report2.TotalSale.ToString(), out decimal totalSale30Days))
                    {
                        lbl_turnover.Text = totalSale30Days.ToString("N0") + " VNĐ";
                    }
                    lbl_TotalCostPrice.Text = report2.TotalCostPrice.ToString("N0") + " VNĐ";
                    lbl_Profit.Text = (report2.TotalSale - report2.TotalCostPrice).ToString("N0") + " VNĐ";
                    lbl_Quantity.Text = report2.OrderCount.ToString();
                    LoadSales30Date();
                    break;

                case 3:
                    ShowDateRangePicker();
                    break;

                default:
                    break;
            }
        }

        private async void ReportComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Report_Load_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void ShowDateRangePicker()
        {
            // Hiển thị một hộp thoại chọn khoảng ngày
            using (Form dateRangeForm = new Form())
            {
                // Thiết lập thuộc tính cho form
                dateRangeForm.Text = "Chọn khoảng ngày";
                dateRangeForm.StartPosition = FormStartPosition.CenterParent;
                dateRangeForm.Width = 400;
                dateRangeForm.Height = 300;
                dateRangeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                dateRangeForm.MaximizeBox = false;
                dateRangeForm.MinimizeBox = false;

                // Nhãn và picker cho ngày bắt đầu
                Label lblStartDate = new Label { Text = "Ngày bắt đầu:", Top = 20, Left = 20 };
                DateTimePicker startDatePicker = new DateTimePicker { Top = 40, Left = 20, Width = 250 };

                // Nhãn và picker cho ngày kết thúc
                Label lblEndDate = new Label { Text = "Ngày kết thúc:", Top = 80, Left = 20 };
                DateTimePicker endDatePicker = new DateTimePicker { Top = 100, Left = 20, Width = 250 };

                // Nút OK để chọn ngày
                Button btnOk = new Button { Text = "OK", Width = 80, Height = 40, Top = 160, Left = 20 };
                btnOk.Click += async (s, e) =>
                {
                    // Lấy giá trị khoảng ngày đã chọn
                    DateTime startDate = startDatePicker.Value.Date;
                    DateTime endDate = endDatePicker.Value.Date;

                    // Gọi hàm lấy báo cáo dữ liệu theo khoảng ngày
                    var report = await new BL.Report.reportBL().GetSalesSummaryByDateRangeBL(startDate, endDate);

                    // Cập nhật các thông số lên UI
                    lbl_turnover.Text = report.TotalSale.ToString("N0") + " VNĐ";
                    lbl_TotalCostPrice.Text = report.TotalCostPrice.ToString("N0") + " VNĐ";
                    lbl_Profit.Text = (report.TotalSale - report.TotalCostPrice).ToString("N0") + " VNĐ";
                    lbl_Quantity.Text = report.OrderCount.ToString();

                    // Hiển thị các đơn hàng trong khoảng ngày chọn
                    LoadSalesByDateRange(startDate, endDate);

                    // Đóng form chọn khoảng ngày
                    dateRangeForm.Close();
                };

                // Thêm các điều khiển vào form
                dateRangeForm.Controls.Add(lblStartDate);
                dateRangeForm.Controls.Add(startDatePicker);
                dateRangeForm.Controls.Add(lblEndDate);
                dateRangeForm.Controls.Add(endDatePicker);
                dateRangeForm.Controls.Add(btnOk);

                // Hiển thị form
                dateRangeForm.ShowDialog();

            }
        }

        private async void LoadSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            // Lấy danh sách đơn hàng theo khoảng ngày
            var sales = await new BL.Report.reportBL().SaleByDateBL(startDate, endDate);
            // Hiển thị danh sách trong ListBox
            listBox1.Items.Clear(); // Xóa dữ liệu cũ
            foreach (var order in sales)
            {
                listBox1.Items.Add($"Mã đơn hàng: {order.SaleID}, Ngày bán: {order.SaleDate.Date.ToShortDateString()}, Tổng tiền: {order.TotalAmount:N0} VNĐ");
            }

            // Nếu không có đơn hàng nào
            if (sales.Count == 0)
            {
                listBox1.Items.Add("Không có đơn hàng nào trong ngày được chọn.");
            }
        }

        private void usermanual_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình Guna2MessageDialog
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = "Chức năng báo cáo",
                Text = "Chức năng dùng để xem báo cáo doanh thu và đơn hàng.\n" +
                       "Chức năng bao gồm:\n" +
                       "- Hôm nay: Xem báo cáo doanh thu và đơn hàng trong ngày.\n" +
                       "- 7 ngày qua: Xem báo cáo doanh thu và đơn hàng trong 7 ngày qua.\n" +
                       "- 30 ngày qua: Xem báo cáo doanh thu và đơn hàng trong 30 ngày qua.\n" +
                       "- Chọn khoảng ngày: Xem báo cáo doanh thu và đơn hàng trong khoảng ngày tùy chọn.\n\n" +
                       "Ngoài ra, chức năng hiển thị chi tiết các đơn hàng, giúp dễ dàng quản lý và theo dõi.",
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Information, // Biểu tượng thông tin
                Style = MessageDialogStyle.Light // Phong cách sáng mặc định
            };

            // Hiển thị hộp thoại
            messageDialog.Show();
        }
    }
}