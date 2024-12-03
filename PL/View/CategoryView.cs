using BL;
using BL.Category;
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
                guna2DataGridView1.Columns["dgvQuantityProducts"].DataPropertyName = "QuantityProducts";


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

    }
}
