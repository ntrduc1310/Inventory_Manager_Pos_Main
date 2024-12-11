using BL;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using BL.User;

namespace PL.View
{
    public partial class UserView : SampleView
    {
        public Guna2DataGridView gridViewUser;
        public UserView()
        {
            InitializeComponent();
            this.Load += loadUserstoGridview;
            // Đăng ký sự kiện CellFormatting
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_delete;
            gridViewUser = guna2DataGridView1;

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

        // Sự kiện CellFormatting để điền số thứ tự vào cột "#Sr"
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
            {
                // Gán số thứ tự cho cột "#Sr"
                e.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
            {
                // Lấy thông tin từ dòng hiện tại
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string username = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvUsername"].Value.ToString();
                string phone = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPhone"].Value.ToString();
                string password = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPass"].Value.ToString();
                // Lấy hình ảnh từ cột dgvPicture
                // Lấy giá trị từ cột dgvPicture
                var cellValue = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPictureTemp"].Value;
                string image = null;
                // Kiểm tra nếu giá trị không phải là null và có thể chuyển đổi sang string
                if (cellValue != null && cellValue is string imagePath)
                {
                    image = cellValue.ToString();
                }
                // Hiển thị form chỉnh sửa và truyền dữ liệu
                editUserForm editForm = new editUserForm(id, name, username, password, phone, image);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Load lại dữ liệu sau khi chỉnh sửa
                    guna2DataGridView1.DataSource = new LoadUserBL().loadUser();
                }
            }
        }

        private async void guna2DataGridView1_CellClick_delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new deleteUsersBL().DeleteUser(id);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa người dùng thành công!");
                        UserView userView = new UserView();
                        Main.Instance.LoadFormIntoPanelCenter(userView);
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng thất bại!");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
        }

        public void LoadUsersToGridViewFunction()
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvUsername"].DataPropertyName = "UserName";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvPass"].DataPropertyName = "Password";

                guna2DataGridView1.Columns["dgvPictureTemp"].DataPropertyName = "Picture";

                // Đọc dữ liệu từ cơ sở dữ liệu
                var data = new LoadUserBL().loadUser(); // Giả sử LoadUserBL trả về danh sách các đối tượng User
                guna2DataGridView1.DataSource = data;
                guna2DataGridView1.Refresh();

                // Sử dụng sự kiện CellFormatting để hiển thị hình ảnh từ đường dẫn
                guna2DataGridView1.CellFormatting += (s, e) =>
                {
                    try
                    {
                        // Kiểm tra nếu cột hiện tại là dgvPicture
                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvPicture"].Index)
                        {
                            // Đọc đường dẫn hình ảnh từ giá trị cột "dgvPictureTemp" (cột lưu đường dẫn file ảnh)
                            string imagePath = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvPictureTemp"].Value?.ToString()?.Trim();

                            // Kiểm tra đường dẫn hợp lệ và tồn tại
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                try
                                {
                                    // Hiển thị hình ảnh từ đường dẫn vào cột dgvPicture
                                    e.Value = Image.FromFile(imagePath);
                                }
                                catch (Exception ex)
                                {
                                    // Nếu có lỗi trong việc tải hình ảnh, gán null hoặc ảnh mặc định
                                    Console.WriteLine($"Error loading image: {ex.Message}");
                                    e.Value = null;
                                }
                            }
                            else
                            {
                                // Nếu không có ảnh, gán null
                                e.Value = null;
                                Console.WriteLine($"No image found at path: {imagePath}");
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
                Console.WriteLine($"Error loading data into DataGridView: {ex.Message}");
                MessageBox.Show("An error occurred while loading the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void loadUserstoGridview(object sender, EventArgs e)
        {
            LoadUsersToGridViewFunction();
        }



        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
        }

        private void btnAdd1_Click_2(object sender, EventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.ShowDialog();
        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
