using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class NotificationShow
    {
        public static void ShowMessageDialog(string message)
        {
            Guna2MessageDialog messageDialog = new Guna2MessageDialog
            {
                Text = message, // Truyền vào message
                Caption = "Thông báo", // Tiêu đề mặc định
                Buttons = MessageDialogButtons.OK, // Nút OK mặc định
                Icon = MessageDialogIcon.Information, // Biểu tượng thông báo mặc định
                Style = MessageDialogStyle.Light, // Kiểu giao diện Light mặc định
            };

            // Hiển thị thông báo
            messageDialog.Show();
        }
    }

}

