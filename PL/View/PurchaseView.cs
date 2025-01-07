using BL.Customer;
using BL.ProductsBL;
using BL.Purchase;
using DTO.Purchase;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Guna.UI2.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PL.View
{
    public partial class PurchaseView : SampleView
    {
        public PurchaseView()
        {
            InitializeComponent();
            this.Load += loadToPurchaseView;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            //guna2DataGridView1.CellClick += DgvCellClickImageColumn;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Sr;
            txtsearch.TextChanged += txtsearch_TextChanged_1;
            ConfigureDataGridView();



        }
        private void ConfigureDataGridView()
        {
            // Cấu hình cơ bản cho DGV
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.RowTemplate.Height = 60;

            // Theme và màu sắc mới (94,71,204)
            guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(94, 71, 204);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Style cho rows
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 243, 252); // màu nhạt của tím
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(235, 232, 247); // màu tím nhạt khi select
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Border và Grid
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.Scroll += Guna2DataGridView1_Scroll;

        }

        private void Guna2DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine($"Scrolled: Orientation={e.ScrollOrientation}, NewValue={e.NewValue}");
        }

        private void PurchaseView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            PurchaseAddProduct purchaseAdd = new PurchaseAddProduct();
            purchaseAdd.ShowDialog();
            if (purchaseAdd.DialogResult == DialogResult.OK)
                loadtoPurchaseViewFunction();
        }

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng có nhấp vào cột dgvAllInformation hay không
                if (e.ColumnIndex == guna2DataGridView1.Columns["dgvAllInformation"].Index)
                {
                    // Lấy ID từ cột dgvid
                    int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;

                    // Lấy thông tin chi tiết của Purchase từ ID
                    string details = await new PurchaseBL().LoadPurchaseDetailsByIdAsString(id);

                    MessageBox.Show(details);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CellClick: {ex.Message}");
            }
        }

        private async void loadtoPurchaseViewFunction()
        {
            try
            {
                guna2DataGridView1.AutoGenerateColumns = false;

                // Cấu hình DataPropertyName
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "PurchaseID";
                guna2DataGridView1.Columns["dgvDate"].DataPropertyName = "CreatedAt";
                guna2DataGridView1.Columns["dgvSupID"].DataPropertyName = "SupplierID";
                guna2DataGridView1.Columns["dgvAmount"].DataPropertyName = "TotalAmount";
                guna2DataGridView1.Columns["dgvCreatedBy"].DataPropertyName = "CreatedBy";
                // Load dữ liệu
                var data = await new PurchaseBL().LoadPurchase();
                guna2DataGridView1.DataSource = data;

                guna2DataGridView1.Refresh();

                guna2DataGridView1.CellFormatting += async (s, e) =>
                {
                    try
                    {
                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvSupplier"].Index)
                        {
                            int cellValue = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupID"].Value;
                            if (cellValue != 0)
                            {
                                string supplierName = await new ProductsBL().GetSupplierNameById(cellValue);
                                guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupplier"].Value = supplierName;
                            }
                            else
                            {
                                Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
                                {
                                    Caption = "Error",
                                    Text = "Invalid Supplier ID",
                                    Buttons = MessageDialogButtons.OK,
                                    Icon = MessageDialogIcon.Error,
                                    Style = MessageDialogStyle.Light
                                };
                                messageDialog.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"CellFormatting error: {ex.Message}");
                    }
                };
            }
            catch (Exception ex)
            {
                Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Caption = "Error",
                    Text = $"Error: {ex.Message}",
                    Buttons = MessageDialogButtons.OK,
                    Icon = MessageDialogIcon.Error,
                    Style = MessageDialogStyle.Light
                };
                messageDialog.Show();
                throw ex;
            }
        }

        private async void loadToPurchaseView(object sender, EventArgs e)
        {
            loadtoPurchaseViewFunction();
        }

        private void guna2DataGridView1_CellFormatting_Sr(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
            {
                // Gán số thứ tự cho cột "#Sr"
                e.Value = (e.RowIndex + 1).ToString();
            }
            // Format cột số tiền
            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvAmount"].Index && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("N0") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        //private async void DgvCellClickImageColumn(object sender, DataGridViewCellEventArgs e)
        //{


        //}
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    var filteredData = await new PurchaseBL().searchPurchase(searchText);
                    guna2DataGridView1.DataSource = filteredData;
                }
                else
                {
                    loadtoPurchaseViewFunction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
                {
                    // Gán số thứ tự cho cột "#Sr"
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CellFormatting error: {ex.Message}");
            }
        }

        private void usermanual_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình Guna2MessageDialog
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = "Chức năng quản lý nhập hàng",
                Text = "Chức năng dùng để quản lý các giao dịch nhập hàng.\n" +
                       "Chức năng bao gồm:\n" +
                       "- Thêm: Thêm mới một giao dịch nhập hàng.\n" +
                       "- Xóa: Xóa các giao dịch không còn sử dụng.\n" +
                       "- Sửa: Thay đổi thông tin các giao dịch hiện có.\n\n" +
                       "Ngoài ra, chức năng hiển thị chi tiết các giao dịch, giúp dễ dàng quản lý và theo dõi.",
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Information, // Biểu tượng thông tin
                Style = MessageDialogStyle.Light // Phong cách sáng mặc định
            };

            // Hiển thị hộp thoại
            messageDialog.Show();
        }
    }
}
