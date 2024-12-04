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
                    MessageBox.Show("Tên danh mục không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Name.Focus();
                    return;
                }


                // Gọi hàm UpdateCategory
                bool result = await new CategoryBL().UpdateCategory(id, name);

                if (result)
                {
                    MessageBox.Show("Cập nhật danh mục thành công!");
                    CategoryView categoryView = new CategoryView();
                    Main.Instance.LoadFormIntoPanelCenter(categoryView);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có danh mục hoặc thông tin không được thay đổi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
