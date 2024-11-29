using BL;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class UserView : SampleView
    {
        public UserView()
        {
            InitializeComponent();
            this.Load += loadUserstoGridview;
        }

        private void UserView_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public override void btnAdd1_Click(object sender, EventArgs e)
        {

        }

        public override void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }



        private void LoadData()
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadUserstoGridview(object sender,EventArgs e)
        {
            // Tắt tự động tạo cột
            guna2DataGridView1.AutoGenerateColumns = false;

            // Ánh xạ cột đã tạo sẵn đến trường dữ liệu
            guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
            guna2DataGridView1.Columns["dgvUsername"].DataPropertyName = "UserName";
            guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
            var data = new LoadUserBL().loadUser();
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
            else
            {
                guna2DataGridView1.DataSource = data;
            }
        }
    }
}
