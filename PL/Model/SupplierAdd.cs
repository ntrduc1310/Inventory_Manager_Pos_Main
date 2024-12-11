using BL;
using BL.Suppiler;
using DL.Suppiler;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PL.Model
{
    public partial class SupplierAdd : SampleAdd
    {
        public SupplierAdd()
        {
            InitializeComponent();
        }

        private void SupplierAdd_Load(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click_2(object sender, EventArgs e)
        {

            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    string Name = txt_Name.Text;
                    string Email = txt_Email.Text;
                    string Phone = txt_Phone.Text;
                    string Adress = txt_Adress.Text;

                    // Kiểm tra nếu trường không rỗng hoặc null
                    if (string.IsNullOrEmpty(Name))
                    {
                        MessageBox.Show("Tên không được để trống.");
                        return;
                    }

                    if (string.IsNullOrEmpty(Email))
                    {
                        MessageBox.Show("Email không được để trống.");
                        return;
                    }

                    // Kiểm tra định dạng email
                    try
                    {
                        var mailAddress = new System.Net.Mail.MailAddress(Email);
                    }
                    catch
                    {
                        MessageBox.Show("Định dạng email không hợp lệ.");
                        return;
                    }

                    if (string.IsNullOrEmpty(Phone))
                    {
                        MessageBox.Show("Số điện thoại không được để trống.");
                        return;
                    }

                    if (string.IsNullOrEmpty(Adress))
                    {
                        MessageBox.Show("Địa chỉ không được để trống.");
                        return;
                    }

                    // Thêm nhà cung cấp và kiểm tra kết quả
                    bool result = await new SuppilerBL().AddSuppiler(Name, Email, Phone, Adress);
                    if (result)
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công!");
                        SupplierView supplierView = new SupplierView();
                        Main.Instance.LoadFormIntoPanelCenter(supplierView);
                        this.Close();
                        isValid = true; // Đánh dấu là hợp lệ và thoát khỏi vòng lặp
                    }
                    else
                    {
                        MessageBox.Show("Nhà cung cấp đã tồn tại.");
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

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
