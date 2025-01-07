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
using Guna.UI2.WinForms;
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
                    string name = txt_Name.Text.Trim();

                    // Kiểm tra nếu trường Name không rỗng hoặc null
                    if (string.IsNullOrEmpty(name))
                    {
                        ShowMessage("Tên danh mục không được để trống.", "Lỗi", MessageDialogIcon.Warning);
                        return;
                    }

                    // Thêm danh mục và kiểm tra kết quả
                    bool result = await new CategoryBL().AddCategory(name);
                    if (result)
                    {
                        ShowMessage("Thêm danh mục thành công!", "Thành công", MessageDialogIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        isValid = true; // Đánh dấu là hợp lệ và thoát khỏi vòng lặp
                    }
                    else
                    {
                        ShowMessage("Danh mục đã tồn tại. Vui lòng thử lại!", "Thông báo", MessageDialogIcon.Warning);
                        isValid = true; // Không hợp lệ, tiếp tục vòng lặp
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageDialogIcon.Error);
                }
            }
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog
            {
                Caption = title,
                Text = message,
                Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                Icon = icon,
                Style = Guna.UI2.WinForms.MessageDialogStyle.Default,
                Parent = this
            };

            messageDialog.Show();
        }


        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
