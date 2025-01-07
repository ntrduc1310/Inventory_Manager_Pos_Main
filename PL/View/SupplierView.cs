using BL;
using BL.Suppiler;
using BL.User;
using DL.Suppiler;
using PL.Edit;
using PL.Model;
using System;
using Guna.UI2.WinForms;
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
                ShowGunaMessageDialog("An error occurred while loading the data. Please try again.", "Error", MessageDialogIcon.Error);
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
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDelete")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = ShowGunaMessageDialog("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageDialogIcon.Question, MessageDialogButtons.YesNo);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new SuppilerDL().DeleteSuppiler(id);

                    if (deleteResult)
                    {
                        ShowGunaMessageDialog("Xóa nhà cung cấp thành công!", "Success", MessageDialogIcon.Information);
                        LoadSuppilerToGridViewFunction();
                    }
                    else
                    {
                        ShowGunaMessageDialog("Xóa nhà cung cấp thất bại!", "Error", MessageDialogIcon.Error);
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    ShowGunaMessageDialog("Hành động xóa đã bị hủy.", "Canceled", MessageDialogIcon.Information);
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
                ShowGunaMessageDialog("An error occurred while searching.", "Error", MessageDialogIcon.Error);
            }
        }

        private void usermanual_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình Guna2MessageDialog
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = "Chức năng quản lý nhà cung cấp",
                Text = "Chức năng dùng để quản lý các nhà cung cấp.\n" +
                       "Chức năng bao gồm:\n" +
                       "- Thêm: Thêm mới một nhà cung cấp.\n" +
                       "- Xóa: Xóa các nhà cung cấp không còn sử dụng.\n" +
                       "- Sửa: Thay đổi thông tin các nhà cung cấp hiện có.\n\n" +
                       "Ngoài ra, chức năng hiển thị chi tiết các nhà cung cấp, giúp dễ dàng quản lý và theo dõi.",
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Information, // Biểu tượng thông tin
                Style = MessageDialogStyle.Light // Phong cách sáng mặc định
            };

            // Hiển thị hộp thoại
            messageDialog.Show();
        }

        private DialogResult ShowGunaMessageDialog(string text, string caption, MessageDialogIcon icon, MessageDialogButtons buttons = MessageDialogButtons.OK)
        {
            Guna2MessageDialog messageDialog = new Guna2MessageDialog
            {
                Text = text,
                Caption = caption,
                Buttons = buttons,
                Icon = icon,
                Style = MessageDialogStyle.Light
            };
            messageDialog.Show(); // Correct method to show the dialog
            return DialogResult.OK; // Return a default DialogResult
        }
    }
}
