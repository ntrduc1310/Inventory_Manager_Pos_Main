using BL;
using BL.Suppiler;
using DL.Suppiler;
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
            try
            {
                string Name = txt_Name.Text.Trim();
                string Email = txt_Email.Text.Trim();
                string Phone = txt_Phone.Text.Trim();
                string Adress = txt_Adress.Text.Trim();

                // Kiểm tra nếu trường không rỗng hoặc null
                if (string.IsNullOrEmpty(Name))
                {
                    ShowMessage("Tên không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(Email))
                {
                    ShowMessage("Email không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                // Kiểm tra định dạng email
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(Email);
                }
                catch
                {
                    ShowMessage("Định dạng email không hợp lệ.", "Lỗi", MessageDialogIcon.Warning);
                    txt_Email.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(Phone))
                {
                    ShowMessage("Số điện thoại không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Phone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(Adress))
                {
                    ShowMessage("Địa chỉ không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Adress.Focus();
                    return;
                }

                // Thêm nhà cung cấp và kiểm tra kết quả
                bool result = await new SuppilerBL().AddSuppiler(Name, Email, Phone, Adress);
                if (result)
                {
                    ShowMessage("Thêm nhà cung cấp thành công!", "Thành công", MessageDialogIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Nhà cung cấp đã tồn tại.", "Thông báo", MessageDialogIcon.Warning);
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

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
