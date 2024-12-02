using BL;
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
                guna2DataGridView1.Columns["dgvAdress"].DataPropertyName = "Adress";

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
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
