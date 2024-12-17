using BL;
using DL;
using Guna.UI2.WinForms;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using PL.View;
using BL.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PL.Edit
{
    public partial class editUserForm : Form
    {
        public int userId;
        // Thuộc tính để truy cập panelMain từ bên ngoài
        // Khai báo sự kiện


        public editUserForm(int id, string name, string username, string password, string phone, string piture)
        {
            InitializeComponent();

            // Gán giá trị ban đầu cho các TextBox
            userId = id;
            txt_Name.Text = name;
            txt_UserName.Text = username;
            txt_Phone.Text = phone;
            txt_Password.Text = password;
            string imagePath = piture;
            // Kiểm tra đường dẫn có hợp lệ không
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    // Tải hình ảnh và gán vào PictureBox
                    txtPic.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
        }
      


        private void txtPic_Click(object sender, EventArgs e)
        {

        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void editUserForm_Load(object sender, EventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        // lưu hình ảnh vào folder trả về đường dẫn

        private string filePathnew = null;

        private void loadImagesByPath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn ảnh được chọn
                    string filePath = openFileDialog.FileName;
                    filePathnew = filePath;

                    // Hiển thị ảnh trong PictureBox
                    txtPic.Image = Image.FromFile(filePath);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            loadImagesByPath();
        }

        private string SaveImageToFolder(string path)
        {
            if (path != null)
            {
                // Lấy thư mục gốc của dự án bằng cách đi lên từ thư mục chứa tệp thực thi (EXE)
                string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;

                // Đảm bảo rằng thư mục ImagesUsers đã tồn tại trong thư mục gốc
                string destinationFolder = Path.Combine(projectDirectory, "ImagesUsers");

                // Kiểm tra nếu thư mục chưa tồn tại thì tạo mới
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Tạo tên file mới để tránh trùng lặp
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(path);

                // Đường dẫn file đích (lưu vào thư mục ImagesUsers ở thư mục gốc)
                string destinationFilePath = Path.Combine(destinationFolder, fileName);

                // Copy file vào thư mục ImagesUsers
                File.Copy(path, destinationFilePath);

                // Trả về đường dẫn file đích
                return destinationFilePath;
            }

            return null; // Trường hợp không chọn file
        }


        // sự kiện nhấn save
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    // Thông tin cần cập nhật
                    int Id = userId; // Đảm bảo userId đã được gán giá trị     
                    string name = txt_Name.Text.Trim();
                    string userName = txt_UserName.Text.Trim();
                    string password = txt_Password.Text.Trim();
                    string phone = txt_Phone.Text.Trim();
                    string role = txt_Role.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Name.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_UserName.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Password.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(role))
                    {
                        MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Password.Focus();
                        return;
                    }

                    // Lấy mảng byte từ PictureBox
                    string picture = SaveImageToFolder(filePathnew);
                    // Gọi hàm UpdateUser
                    bool result = new UpdateUsersBL().UpdateUser(Id, name, userName, password, phone, picture,role);

                    if (result)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        UserView userView = new UserView();
                        Main.Instance.LoadFormIntoPanelCenter(userView);
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

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
