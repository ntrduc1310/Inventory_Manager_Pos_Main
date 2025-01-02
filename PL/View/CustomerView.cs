using BL;
using BL.Category;
using BL.Customer;
using PL.Edit;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.View
{
    public partial class CustomerView : SampleView
    {
        public CustomerView()
        {
            InitializeComponent();
            this.Load += LoadGridView;
            guna2DataGridView1.CellFormatting += Guna2DataGridView1_CellFormatting;
            guna2DataGridView1.CellClick += Guna2DataGridView1_CellClick;
            guna2DataGridView1.CellClick += Guna2DataGridView1_CellClick_Delete;
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
        private void LoadGridView(object sender, EventArgs e)
        {
            LoadCustomerToGridViewFunction();
        }

        public async void LoadCustomerToGridViewFunction()
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvEmail"].DataPropertyName = "Email";

                // Đọc dữ liệu từ cơ sở dữ liệu
                var data = await new CustomerBL().LoadCustomers(); // Giả sử LoadCustomers trả về danh sách các đối tượng Customer
                guna2DataGridView1.DataSource = data;
                guna2DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data into DataGridView: {ex.Message}");
                MessageBox.Show("An error occurred while loading the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
            {
                // Gán số thứ tự cho cột "#Sr"
                e.Value = (e.RowIndex + 1).ToString();
            }
        }


        private async void Guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
            {
                // Lấy thông tin từ dòng hiện tại
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string phone = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPhone"].Value.ToString();
                string email = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvEmail"].Value.ToString();

                // Hiển thị form chỉnh sửa và truyền dữ liệu
                PL.Edit.editCustomerForm editForm = new editCustomerForm(id, name, phone, email);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerToGridViewFunction();
                    // Load lại dữ liệu sau khi chỉnh sửa
                }
            }
        }

        private async void Guna2DataGridView1_CellClick_Delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Delete
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new CustomerBL().DeleteCustomer(id);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        LoadCustomerToGridViewFunction();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            CustomerAdd customerAdd = new CustomerAdd();
            customerAdd.ShowDialog();
            if (customerAdd.DialogResult == DialogResult.OK)
            {
                LoadCustomerToGridViewFunction();
            }

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text ?? string.Empty;
                var filteredData = await new CustomerBL().searchCustomer(searchText);

                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvEmail"].DataPropertyName = "Email";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";



                // Remove existing handler trước khi thêm handler mới để tránh duplicate
                guna2DataGridView1.CellFormatting -= guna2DataGridView1_CellFormatting;

                // Gán dữ liệu mới
                guna2DataGridView1.DataSource = filteredData;

                // Thêm handler mới
                guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;

                // Refresh DataGridView
                guna2DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search error: {ex.Message}");
                MessageBox.Show("An error occurred while searching.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
