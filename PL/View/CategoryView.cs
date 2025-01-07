using BL;
using BL.Category;
using BL.ProductsBL;
using Guna.UI2.WinForms;
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
            ConfigureDataGridView();
            guna2DataGridView1.ScrollBars = ScrollBars.Both;



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
            if (categoryAdd.DialogResult == DialogResult.OK)
            {
                LoadCategoryToGridViewFunction();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                    LoadCategoryToGridViewFunction();
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

        // Sửa lại phương thức txtsearch_TextChanged_1 trong CategoryView
        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text ?? string.Empty;
                var filteredData = await new CategoryBL().searchCategory(searchText);

                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "Id";
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvQuantityProducts"].DataPropertyName = "QuantityProducts";

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

        // Sửa lại phương thức guna2DataGridView1_CellFormatting để xử lý số thứ tự sau khi search
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

        private async Task ShowGunaMessageDialog(string message, string title, MessageDialogIcon icon, int autoCloseTime = 2000)
        {
            var tcs = new TaskCompletionSource<bool>();

            // Đảm bảo form đã sẵn sàng và có window handle hợp lệ
            if (this.IsHandleCreated)
            {
                // Chạy trên UI thread
                this.Invoke(new Action(async () =>
                {
                    // Tạo đối tượng Guna2MessageDialog
                    using (var gunaMessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
                    {
                        Text = message,
                        Caption = title,
                        Buttons = MessageDialogButtons.OK,
                        Icon = icon,
                        Style = MessageDialogStyle.Dark
                    })
                    {
                        // Hiển thị hộp thoại
                        gunaMessageDialog.Show();

                        // Chờ trong khoảng thời gian autoCloseTime
                        await Task.Delay(autoCloseTime);

                        // Tự động đóng dialog
                        SendKeys.Send("{ENTER}");

                        // Đánh dấu task đã hoàn thành
                        tcs.SetResult(true);
                    }
                }));
            }
            else
            {
                // Nếu form chưa sẵn sàng, chờ đến khi handle được tạo ra
                await Task.Delay(100);
                await ShowGunaMessageDialog(message, title, icon, autoCloseTime); // Gọi lại phương thức sau khi form đã hoàn tất khởi tạo
            }

            // Đợi cho đến khi dialog được đóng
            await tcs.Task;
        }


        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            ShowGunaMessageDialog("Chức năng dùng để tạo các phân loại sản Phẩm để dễ quản lí\n chức năng bao gồm thêm xóa và sửa tên các loại sản phẩm\n hiển thị số lượng sản phẩm thuộc loại đó ", "Chức năng phân loại sản phẩm", MessageDialogIcon.Information);

        }

        private void usermanual_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình Guna2MessageDialog
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = "Chức năng phân loại sản phẩm",
                Text = "Chức năng dùng để tạo các phân loại sản phẩm để dễ quản lý.\n" +
                       "Chức năng bao gồm:\n" +
                       "- Thêm: Thêm mới một danh mục sản phẩm.\n" +
                       "- Xóa: Xóa các danh mục không còn sử dụng.\n" +
                       "- Sửa: Thay đổi tên các danh mục hiện có.\n\n" +
                       "Ngoài ra, chức năng hiển thị số lượng sản phẩm thuộc từng loại, giúp dễ dàng quản lý và theo dõi.",
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Information, // Biểu tượng thông tin
                Style = MessageDialogStyle.Light // Phong cách sáng mặc định
            };

            // Hiển thị hộp thoại
            messageDialog.Show();
        }




    }
}
