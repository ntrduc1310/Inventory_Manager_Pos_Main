using BL.Customer;
using DL.Customer;
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
using System.Collections;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using BL;
using DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using BL.Category;
using Guna.UI2.WinForms;

namespace PL.Model
{
    public partial class CustomerAdd : SampleAdd
    {
        public CustomerAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void CustomerAdd_Load(object sender, EventArgs e)
        {

        }



        // Phương thức kiểm tra dữ liệu đầu vào
        private bool ValidateInput(out string name, out string phone, out string email)
        {
            name = txt_Name.Text.Trim();
            phone = txt_Phone.Text.Trim();
            email = txt_Email.Text.Trim();

            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên khách hàng không được để trống.");
                txt_Name.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(phone) || !IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập đúng định dạng.");
                txt_Phone.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập đúng định dạng.");
                txt_Email.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra định dạng số điện thoại
        private bool IsValidPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9]{10,15}$");
        }

        // Kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btn_Save_Click_2(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text.Trim();
                string phone = txt_Phone.Text.Trim();
                string email = txt_Email.Text.Trim();

                // Kiểm tra nếu các trường không rỗng hoặc null
                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên khách hàng không được để trống.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    ShowMessage("Số điện thoại không được để trống.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    ShowMessage("Email không được để trống.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                // Kiểm tra định dạng email hợp lệ
                if (!email.Contains("@") || !email.Contains("."))
                {
                    ShowMessage("Email không hợp lệ.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                // Kiểm tra số điện thoại chỉ chứa chữ số
                if (!phone.All(char.IsDigit))
                {
                    ShowMessage("Số điện thoại chỉ được chứa các chữ số.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                // Thêm khách hàng và kiểm tra kết quả
                bool result = await new CustomerBL().AddCustomer(name, phone, email);
                if (result)
                {
                    ShowMessage("Thêm khách hàng thành công!", "Thông báo", MessageDialogIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Khách hàng đã tồn tại.", "Thông báo", MessageDialogIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageDialogIcon.Error);
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

    }
}
