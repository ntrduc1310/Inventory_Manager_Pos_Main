using BL.Customer;
using Guna.UI2.WinForms;
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
    public partial class editCustomerForm : Form
    {
        int customerId;

        public editCustomerForm(int id, string name, string phone, string email)
        {
            InitializeComponent();
            customerId = id;
            txt_Name.Text = name;
            txt_Phone.Text = phone;
            txt_Email.Text = email;
        }

        private void editCustomerForm_Load(object sender, EventArgs e)
        {

        }



        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                int id = customerId;
                string name = txt_Name.Text.Trim();
                string phone = txt_Phone.Text.Trim();
                string email = txt_Email.Text.Trim();

                // Kiểm tra nếu các trường rỗng
                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên khách hàng không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    ShowMessage("Số điện thoại không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    ShowMessage("Email không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                // Gọi hàm UpdateCustomer
                bool result = await new CustomerBL().UpdateCustomer(id, name, phone, email);

                if (result)
                {
                    ShowMessage("Cập nhật khách hàng thành công!", "Thông báo", MessageDialogIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Không có khách hàng hoặc thông tin không được thay đổi.", "Lỗi", MessageDialogIcon.Error);
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


        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       