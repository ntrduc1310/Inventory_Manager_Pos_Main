using BL;
using DTO;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class SignIn : Form
    {
        private readonly ErrorProvider errorProvider1 = new ErrorProvider();
        private bool isPasswordVisible = false;

        public SignIn()
        {
            InitializeComponent();
        }

        private async void SignIn_btn_Click(object sender, EventArgs e)
        {
            await SignInAsync();
        }

        private async Task SignInAsync()
        {
            if (!ValidateInputs())
            {
                ShowError("Vui lòng nhập đúng thông tin tài khoản và mật khẩu.");
                return;
            }

            string username = Username_txb.Text.Trim();
            string password = Password_txb.Text.Trim();

            try
            {
                var loginBL = new LoginBL();
                bool loginSuccess = await loginBL.LoginAsync(username, password);

                if (loginSuccess)
                {
                    await HandleSuccessfulLogin(username, password);
                }
                else
                {
                    HandleFailedLogin();
                }
            }
            catch (SqlException ex)
            {
                ShowError($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                ShowError($"Đã xảy ra lỗi không xác định: {ex.Message}");
            }
        }

        private async Task HandleSuccessfulLogin(string username, string password)
        {
            ShowSuccess("Đăng nhập thành công!");

            try
            {
                var main = new Main();
                string imagePath = await new LoginBL().GetImagePathByUsernamePasssword(username, password);

                main.username_lbl.Text = username;

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    main.pictureBox.Image = Image.FromFile(imagePath);
                }

                this.Hide();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi mở form chính: {ex.Message}");
                this.Show();
            }
        }

        private void HandleFailedLogin()
        {
            ShowError("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.");
            Username_txb.Clear();
            Password_txb.Clear();
            Username_txb.Focus();
        }

        private void ShowError(string message)
        {
            var dialog = new Guna2MessageDialog
            {
                Text = message,
                Caption = "Lỗi",
                Buttons = MessageDialogButtons.OK,
                Style = MessageDialogStyle.Dark,
                Icon = MessageDialogIcon.Error,
                Parent = this
            };
            dialog.Show();
        }

        private void ShowSuccess(string message)
        {
            var dialog = new Guna2MessageDialog
            {
                Text = message,
                Caption = "Thông báo",
                Buttons = MessageDialogButtons.OK,
                Style = MessageDialogStyle.Light,
                Parent = this
            };
            dialog.Show();
        }

        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            SignIn_label.BackColor = Color.LightBlue;
            SignIn_label.Cursor = Cursors.Hand;
        }

        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            SignIn_label.BackColor = SystemColors.Control;
            SignIn_label.Cursor = Cursors.Default;
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            Password_txb.PasswordChar = isPasswordVisible ? '\0' : '*';
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
            return new Regex(pattern).IsMatch(password);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Username_txb.Text) ||
                string.IsNullOrWhiteSpace(Password_txb.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin vào tất cả các ô.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (!IsValidPassword(Password_txb.Text))
            {
                errorProvider1.SetError(
                    Password_txb,
                    "Mật khẩu phải chứa ít nhất một ký tự thường, một ký tự hoa và một số."
                );
                return false;
            }

            errorProvider1.SetError(Password_txb, "");
            return true;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            Username_txb.Text = "Ducci";
            Password_txb.Text = "Ducci123";
        }

        private void Username_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn_btn_Click(sender, e);
            }
        }

        private void Password_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn_btn_Click(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}