using BL;
using BL.Category;
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
    public partial class CategoryView : SampleView
    {
        public CategoryView()
        {
            InitializeComponent();
            this.Load += loadGridView;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_delete;
        }
        private void loadGridView(object sender, EventArgs e)
        {
            LoadCategoryToGridViewFunction();
        }

        public async void LoadCategoryToGridViewFunction()
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";

                // Đọc dữ liệu từ cơ sở dữ liệu
                var data = await new CategoryBL().LoadCategory(); // Giả sử LoadCategory trả về danh sách các đối tượng Category
                guna2DataGridView1.DataSource = data;
                guna2DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data into DataGridView: {ex.Message}");
                MessageBox.Show("An error occurred while loading the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            CategoryAdd categoryAdd = new CategoryAdd();
            categoryAdd.ShowDialog();
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

                // Hiển thị form chỉnh sửa và truyền dữ liệu
                PL.Edit.editCategoryForm editForm = new PL.Edit.editCategoryForm(id, name);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Load lại dữ liệu sau khi chỉnh sửa
                    guna2DataGridView1.DataSource = await new CategoryBL().LoadCategory();
                }
            }
        }

        private async void guna2DataGridView1_CellClick_delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Delete
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new CategoryBL().DeleteCategory(id);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa danh mục thành công!");
                        LoadCategoryToGridViewFunction();
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại!");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
        }

        public void loadCategoryToGridView(object sender, EventArgs e)
        {
            LoadCategoryToGridViewFunction();
        }

    }
}
