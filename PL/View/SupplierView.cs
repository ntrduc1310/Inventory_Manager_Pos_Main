using BL;
using BL.Suppiler;
using BL.User;
using DL.Suppiler;
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
    public partial class SupplierView : SampleView
    {
        public SupplierView()
        {
            InitializeComponent();
            this.Load += loadGridView;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_delete;
            txtsearch.TextChanged += txtsearch_TextChanged_1;
        }

        private void SupplierView_Load(object sender, EventArgs e)
        {

        }

        public async void LoadSuppilerToGridViewFunction()
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvEmail"].DataPropertyName = "Email";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvAddress"].DataPropertyName = "Address";

                // Đọc dữ liệu từ cơ sở dữ liệu
                var data = await new BL.Suppiler.SuppilerBL().LoadSuppiler(); // Giả sử LoadUserBL trả về danh sách các đối tượng User
                guna2DataGridView1.DataSource = data;
                guna2DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data into DataGridView: {ex.Message}");
                MessageBox.Show("An error occurred while loading the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadGridView(object sender, EventArgs e)
        {
            LoadSuppilerToGridViewFunction();
        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            SupplierAdd supplierAdd = new SupplierAdd();
            supplierAdd.ShowDialog();
            if (supplierAdd.DialogResult == DialogResult.OK)
            {
                LoadSuppilerToGridViewFunction();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
            {
                // Gán số thứ tự cho cột "#Sr"
                e.Value = (e.RowIndex + 1).ToString();
            }
        }

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
            {
                // Lấy thông tin từ dòng hiện tại
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string email = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvEmail"].Value.ToString();
                string phone = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPhone"].Value.ToString();
                string adress = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvAddress"].Value.ToString();
                // Lấy hình ảnh từ cột dgvPicture
                // Lấy giá trị từ cột dgvPicture

                // Hiển thị form chỉnh sửa và truyền dữ liệu
                editSupplierForm editForm = new editSupplierForm(id, name, email, phone, adress);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppilerToGridViewFunction();
                }
            }
        }

        private async void guna2DataGridView1_CellClick_delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new SuppilerDL().DeleteSuppiler(id);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!");
                        LoadSuppilerToGridViewFunction();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhà cung cấp thất bại!");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text ?? string.Empty;
                var filteredData = await new SuppilerBL().searchSupplier(searchText);  // Adjusted for Supplier search

                // Turn off auto-generation of columns
                guna2DataGridView1.AutoGenerateColumns = false;

                // Map columns to data properties
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id"; // Adjusted for your model
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvEmail"].DataPropertyName = "Email";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvAddress"].DataPropertyName = "Address";

                // Remove the existing handler before adding a new one to avoid duplicates
                guna2DataGridView1.CellFormatting -= guna2DataGridView1_CellFormatting;

                // Set the new data source to the filtered list
                guna2DataGridView1.DataSource = filteredData;

                // Add the new handler
                guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;

                // Refresh the DataGridView to reflect the changes
                guna2DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search error: {ex.Message}");
                MessageBox.Show("An error occurred while searching.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
