﻿using BL;
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
        public async void LoadUsersToGridViewFunction()
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvUserName"].DataPropertyName = "UserName";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvPass"].DataPropertyName = "Password";
                guna2DataGridView1.Columns["dgvRole"].DataPropertyName = "Role";
                guna2DataGridView1.Columns["dgvPictureTemp"].DataPropertyName = "Picture";

                // Đọc dữ liệu từ cơ sở dữ liệu,
                var data = await new LoadUserBL().loadUser(); // Giả sử LoadUserBL trả về danh sách các đối tượng User
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
                Console.WriteLine($"Lỗi khi tải dữ liệu vào DataGridView: {ex.Message}");
                ShowMessage("Đã xảy ra lỗi khi tải dữ liệu. Vui lòng thử lại.", "Lỗi", MessageDialogIcon.Error);
            }
            

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

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
            {
                // Lấy thông tin từ dòng hiện tại
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string username = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvUserName"].Value.ToString();
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
                    LoadUsersToGridViewFunction();

                }
            }
        }

        private async void guna2DataGridView1_CellClick_delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Delete
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = ShowMessage("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageDialogIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new deleteUsersBL().DeleteUser(id);

                    if (deleteResult)
                    {
                        ShowMessage("Xóa người dùng thành công!", "Success", MessageDialogIcon.Information);
                        LoadUsersToGridViewFunction();
                    }
                    else
                    {
                        ShowMessage("Xóa người dùng thất bại!", "Error", MessageDialogIcon.Error);
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    ShowMessage("Hành động xóa đã bị hủy.", "Canceled", MessageDialogIcon.Information);
                }
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
            if (userAdd.DialogResult == DialogResult.OK)
            {
                LoadUsersToGridViewFunction();
            }
        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text ?? string.Empty;
                var filteredData = await new LoadUserBL().searchUser(searchText);  // Adjusted for User search

                // Turn off auto-generation of columns
                guna2DataGridView1.AutoGenerateColumns = false;

                // Map columns to data properties
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "UserId"; // Adjusted for your model
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvUsername"].DataPropertyName = "UserName";
                guna2DataGridView1.Columns["dgvPhone"].DataPropertyName = "Phone";
                guna2DataGridView1.Columns["dgvPass"].DataPropertyName = "Password";
                guna2DataGridView1.Columns["dgvPictureTemp"].DataPropertyName = "Picture";  // Adjusted

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
                Console.WriteLine($"Lỗi tìm kiếm: {ex.Message}");
                ShowMessage("Đã xảy ra lỗi khi tìm kiếm.", "Lỗi", MessageDialogIcon.Error);
            }
        }
        private DialogResult ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            // Tạo đối tượng Guna2MessageDialog
            Guna2MessageDialog messageDialog = new Guna2MessageDialog
            {
                Caption = title,
                Text = message,
                Icon = icon,
                Buttons = MessageDialogButtons.YesNo,  // Đặt Yes/No cho các nút
                Style = MessageDialogStyle.Default
            };

            // Hiển thị hộp thoại
            messageDialog.Show();

            // Trả về một giá trị mặc định, bạn có thể điều chỉnh thêm nếu cần.
            return DialogResult.None; // Thay thế bằng giá trị DialogResult mong muốn
        }




        private void usermanual_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình Guna2MessageDialog
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = "Chức năng quản lý người dùng",
                Text = "Chức năng này dùng để quản lý các giao dịch người dùng.\n" +
                       "Chức năng bao gồm:\n" +
                       "- Thêm: Thêm mới một giao dịch người dùng.\n" +
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
