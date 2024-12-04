using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using BL;
using DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using PL.View;
using BL.Category;
using DL.Category;
using System.Xml.Linq;

namespace PL.Model
{
    public partial class CategoryAdd : SampleAdd
    {
        public CategoryAdd()
        {
            InitializeComponent();
        }

        private void CategoryAdd_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }



        private async void btn_Save_Click(object sender, EventArgs e)
        {
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    string Name = txt_Name.Text;

                    // Kiểm tra nếu trường không rỗng hoặc null
                    if (string.IsNullOrEmpty(Name))
                    {
                        MessageBox.Show("Tên danh mục không được để trống.");
                        return;
                    }

                   

                    // Thêm danh mục và kiểm tra kết quả
                    bool result = await new CategoryBL().AddCategory(Name);
                    if (result)
                    {
                        MessageBox.Show("Thêm danh mục thành công!");
                        CategoryView CategoryView = new CategoryView(); // Mở trang danh mục
                        Main.Instance.LoadFormIntoPanelCenter(CategoryView);
                        this.Close();
                        isValid = true; // Đánh dấu là hợp lệ và thoát khỏi vòng lặp
                    }
                    else
                    {
                        MessageBox.Show("Danh mục đã tồn tại.");
                        // Yêu cầu người dùng nhập lại thông tin
                        isValid = true; // Không hợp lệ, tiếp tục vòng lặp
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
