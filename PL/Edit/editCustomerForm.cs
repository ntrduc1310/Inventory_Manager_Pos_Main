using BL.Customer;
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
                    MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                // Gọi hàm UpdateCustomer
                bool result = await new CustomerBL().UpdateCustomer(id, name, phone, email);

                if (result)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có khách hàng hoặc thông tin không được thay đổi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }

        }
    }
}
       