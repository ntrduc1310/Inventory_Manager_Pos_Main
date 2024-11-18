using BL;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PL
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;

        }

        private void Username_txb_TextChanged(object? sender, EventArgs e)
        {

        }

        private async void Login_btn_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {

                var username = Username_txb.Text.Trim();

                var password = Password_txb.Text.Trim();

                var email = Email_txb.Text.Trim();
                Account acc = new Account(username, password);
                bool b = await new LoginBL().LoginAsync(acc);
                if (b)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
                }
                else
                {
                    bool f = false;
                    f = await new DL.SignUp().AddUserAsync(username, password, email);
                    if (f)
                    {
                        MessageBox.Show("Đăng kí tài khoản thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí tài khoản thất bại!");

                    }


                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin email và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
        private bool isPasswordVisible = false;
        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                Password_txb.PasswordChar = '*';
                isPasswordVisible = false;
            }
            else
            {
                Password_txb.PasswordChar = '\0'; // Hiển thị mật khẩu
                isPasswordVisible = true;
            }
        }

        private void SignIn_label_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form SignUp
            SignIn signInForm = new SignIn();

            // Hiển thị form SignUp
            signInForm.Show();

            // Ẩn form SignIn
            this.Hide();
        }

        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            // Đổi màu Button khi di chuột vào
            SignIn_label.BackColor = Color.LightBlue;
            // Đổi con trỏ chuột thành hình tay
            SignIn_label.Cursor = Cursors.Hand;
        }

        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            // Khôi phục màu Button khi di chuột ra
            SignIn_label.BackColor = SystemColors.Control;
            // Khôi phục con trỏ chuột mặc định
            SignIn_label.Cursor = Cursors.Default;
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Điều kiện nhập email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private ErrorProvider errorProvider1 = new ErrorProvider();
        //private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!IsValidEmail(Email_txb.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Email_txb, "Email không hợp lệ");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Email_txb, "");
        //    }
        //}
        private void Email_txb_TextChanged(object sender, EventArgs e)
        {

        }

        // Kiểm tra điều kiện cho password
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        //private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!IsValidPassword(Password_txb.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Password_txb, "Mật khẩu phải chứa ít nhất một ký tự thường, một ký tự hoa và một số.");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Password_txb, "");
        //    }
        //}

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Kiểm tra xem tất cả các TextBox có được nhập liệu hay không
            if (string.IsNullOrWhiteSpace(Username_txb.Text) || string.IsNullOrWhiteSpace(Password_txb.Text) || string.IsNullOrWhiteSpace(Email_txb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào tất cả các ô.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra tính hợp lệ của email
            if (!IsValidEmail(Email_txb.Text))
            {
                errorProvider1.SetError(Email_txb, "Email không hợp lệ");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(Email_txb, "");
            }

            // Kiểm tra tính hợp lệ của mật khẩu
            if (!IsValidPassword(Password_txb.Text))
            {
                errorProvider1.SetError(Password_txb, "Mật khẩu phải chứa ít nhất một ký tự thường, một ký tự hoa và một số.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(Password_txb, "");
            }

            return isValid;
        }
        private void Password_txb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
    }

}
