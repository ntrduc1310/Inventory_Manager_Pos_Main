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
using Guna.UI2.WinForms;
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
            try
            {
                // Thông tin cần cập nhật
                int Id = userId;
                string name = txt_Name.Text.Trim();
                string email = txt_Email.Text.Trim();
                string phone = txt_Phone.Text.Trim();
                string adress = txt_Adress.Text.Trim();

                // Kiểm tra dữ liệu trống
                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    ShowMessage("Email không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(email);
                }
                catch
                {
                    ShowMessage("Định dạng email không hợp lệ.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    ShowMessage("Số điện thoại không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                // Gọi hàm UpdateSupplier
                bool result = await new SuppilerBL().UpdateSupplier(Id, name, email, phone, adress);

                if (result)
                {
                    ShowMessage("Cập nhật nhà cung cấp thành công!", "Thành công", MessageDialogIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Không có thông tin nào được thay đổi!", "Thông báo", MessageDialogIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageDialogIcon.Error);
            }
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            Guna2MessageDialog messageDialog = new Guna2MessageDialog();
            messageDialog.Caption = title;
            messageDialog.Text = message;
            messageDialog.Icon = icon;
            messageDialog.Buttons = MessageDialogButtons.OK;
            messageDialog.Style = MessageDialogStyle.Default;
            messageDialog.Parent = this;
            messageDialog.Show();
        }
    }
}
