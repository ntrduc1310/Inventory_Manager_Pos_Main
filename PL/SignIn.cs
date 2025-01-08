using BL;
using DTO;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PL
{
    public partial class SignIn : Form
    {
        private readonly ErrorProvider errorProvider1 = new ErrorProvider();
        private bool isPasswordVisible = false;
        private Guna2WinProgressIndicator progressIndicator;
        private Guna2Panel loadingPanel;
        private Guna2ShadowForm shadowForm;

        public SignIn()
        {
            InitializeComponent();
            InitializeLoadingPanel();
            CustomizeUI();
        }

        private void InitializeLoadingPanel()
        {
            loadingPanel = new Guna2Panel
            {
                Size = new Size(200, 100),
                FillColor = Color.FromArgb(40, Color.Black),
                BorderRadius = 10,
                Visible = false
            };

            progressIndicator = new Guna2WinProgressIndicator
            {
                Size = new Size(50, 50),
                Location = new Point(75, 10),
                AutoStart = true,
                CircleSize = 1.5f,
                BackColor = Color.Transparent
            };

            var loadingLabel = new Guna2HtmlLabel
            {
                Text = "Đang tải...",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(65, 70),
                BackColor = Color.Transparent
            };

            loadingPanel.Controls.Add(progressIndicator);
            loadingPanel.Controls.Add(loadingLabel);
            this.Controls.Add(loadingPanel);
        }

        private void CustomizeUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            Username_txb.PlaceholderText = "Nhập tên đăng nhập";
            Password_txb.PlaceholderText = "Nhập mật khẩu";

            Sign_In.BorderRadius = 15;
            Sign_In.FillColor = Color.FromArgb(95, 71, 204);
            Sign_In.HoverState.FillColor = Color.FromArgb(94, 81, 200);
            Sign_In.BorderRadius = 30;

            shadowForm = new Guna2ShadowForm(this);
            shadowForm.SetShadowForm(this);
        }

        private void ShowLoading()
        {
            loadingPanel.Location = new Point(
                (this.ClientSize.Width - loadingPanel.Width) / 2,
                (this.ClientSize.Height - loadingPanel.Height) / 2
            );
            loadingPanel.Visible = true;
            loadingPanel.BringToFront();
            Application.DoEvents();
        }

        private void HideLoading()
        {
            loadingPanel.Visible = false;
        }

        private async void Sign_In_Click_1(object sender, EventArgs e)
        {
            await PerformSignIn();
        }
        public static string role;
        private async Task PerformSignIn()
        {
            if (!ValidateInputs())
            {
                ShowError("Vui lòng nhập đúng thông tin tài khoản và mật khẩu.");
                return;
            }

            ShowLoading();

            try
            {
                string username = Username_txb.Text.Trim();
                string password = Password_txb.Text.Trim();

                await Task.Delay(1000);

                var loginBL = new LoginBL();
                role = await loginBL.GetRoleByUsernamePassword(username, password);

                if (role != "Unknown")
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
            finally
            {
                HideLoading();
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

                main.ShowDialog();
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
                Icon = MessageDialogIcon.Information,
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

        private void TogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            Password_txb.PasswordChar = isPasswordVisible ? '\0' : '*';
            Password_txb.UseSystemPasswordChar = !isPasswordVisible;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                ShowError("Vui lòng nhập đầy đủ thông tin vào tất cả các ô.");
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sign_In_Click_1(sender, e);
            }
        }

        #region Form Dragging

        private Point dragOffset;
        private bool mouseDown;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                dragOffset = new Point(e.X, e.Y);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - dragOffset.X,
                                   currentScreenPos.Y - dragOffset.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }

        #endregion

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowLoading();
            await Task.Delay(1500);
            HideLoading();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}