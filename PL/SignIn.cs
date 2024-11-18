using BL;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PL
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();

        }

        private void guna2PictureBox1_Click(object? sender, EventArgs e)
        {

        }

        private async void SignIn_btn_Click(object sender, EventArgs e)
        {
            // kiểm tra các textbox nhập hết chưa
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {



                string username = Username_txb.Text;
                string password = Password_txb.Text;
                Account acc = new Account(username, password);
                bool b = true;
                try
                {
                    b = await new LoginBL().LoginAsync(acc);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("...." + ex.Message);

                }
                if (b)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("success");

                }
                else
                {
                    DialogResult result = MessageBox.Show("Username or Password is wrong", "Error", MessageBoxButtons.RetryCancel);
                    if (result == DialogResult.Cancel)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        Username_txb.Clear();
                        Password_txb.Clear();
                    }
                }
            }

        }

        private void SignIn_label_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form SignUp
            SignUp signUpForm = new SignUp();

            // Hiển thị form SignUp
            signUpForm.Show();

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

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Password_txb_TextChanged(object sender, EventArgs e)
        {

        }
        //điều kiện kiểm tra password

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
        private ErrorProvider errorProvider1 = new ErrorProvider();

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Kiểm tra xem tất cả các TextBox có được nhập liệu hay không
            if (string.IsNullOrWhiteSpace(Username_txb.Text) || string.IsNullOrWhiteSpace(Password_txb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào tất cả các ô.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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

        private void Username_txb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
