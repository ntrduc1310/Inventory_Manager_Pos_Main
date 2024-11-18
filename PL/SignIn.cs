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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void SignIn_btn_Click(object sender, EventArgs e)
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


}
}
