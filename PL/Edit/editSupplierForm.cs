using BL;
using BL.Suppiler;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PL.Edit
{
    public partial class editSupplierForm : Form
    {
        int userId;
        public editSupplierForm(int id, string name, string email, string phone, string adress)
        {
            InitializeComponent();
            userId = id;
            txt_Name.Text = name;
            txt_Email.Text = email;
            txt_Phone.Text = phone;
            txt_Adress.Text = adress;
        }

        private void EditSupplier_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    // Thông tin cần cập nhật
                    int Id = userId; // Đảm bảo userId đã được gán giá trị     
                    string name = txt_Name.Text.Trim();
                    string email = txt_Email.Text.Trim();
                    string phone = txt_Phone.Text.Trim();
                    string adress = txt_Adress.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Name.Focus();
                        return;
                    }


                    if (string.IsNullOrEmpty(email))
                    {
                        MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Email.Focus();
                        return;
                    }

                    try
                    {
                        var mailAddress = new System.Net.Mail.MailAddress(email);
                    }
                    catch
                    {
                        MessageBox.Show("Định dạng email không hợp lệ.");
                        return;
                    }

                    if (string.IsNullOrEmpty(phone))
                    {
                        MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Phone.Focus();
                        return;
                    }

                    // Gọi hàm UpdateUser
                    bool result = await new SuppilerBL().UpdateSupplier(Id, name,email,phone, adress);

                    if (result)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        SupplierView supplierView = new SupplierView();
                        Main.Instance.LoadFormIntoPanelCenter(supplierView);
                        this.Close();
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có người dùng hoặc thông tin không được thay đổi.");
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }

        }
    }
}
