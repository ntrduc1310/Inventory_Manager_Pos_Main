using BL.Category;
using PL.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;  // Đảm bảo rằng thư viện này được thêm vào

namespace PL.Edit
{
    public partial class editCategoryForm : Form
    {
        int categoryId;
        public editCategoryForm(int id, string name)
        {
            InitializeComponent();
            categoryId = id;
            txt_Name.Text = name;
        }

        private void editCategoryForm_Load(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                int id = categoryId; // Đảm bảo CategoryId đã được gán giá trị
                string name = txt_Name.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên danh mục không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                // Gọi hàm UpdateCategory
                bool result = await new CategoryBL().UpdateCategory(id, name);

                if (result)
                {
                    ShowMessage("Cập nhật danh mục thành công!", "Thông báo", MessageDialogIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Không có danh mục hoặc thông tin không được thay đổi.", "Lỗi", MessageDialogIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageDialogIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Phương thức hiển thị thông báo
        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            Guna2MessageDialog messageDialog = new Guna2MessageDialog();
            messageDialog.Caption = title;  // Sử dụng Caption cho tiêu đề
            messageDialog.Text = message;   // Sử dụng Text cho nội dung thông báo
            messageDialog.Icon = icon;
            messageDialog.Buttons = MessageDialogButtons.OK;
            messageDialog.Show();
            messageDialog.Style = MessageDialogStyle.Default;  // Thêm style
            messageDialog.Parent = this;  // Set parent là form hiện tại
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
