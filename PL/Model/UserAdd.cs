using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using BL;
using Microsoft.VisualBasic.ApplicationServices;
using PL.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DL;

namespace PL.Model
{
    public partial class UserAdd : SampleAdd
    {
        public UserAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btn_Save_Click_1(object sender, EventArgs e)
        {

        }
        private void UserAdd_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {

        }
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    // Thông tin cần cập nhật
                    string name = txt_Name.Text.Trim();
                    string userName = txt_UserName.Text.Trim();
                    string password = txt_Password.Text.Trim();
                    string phone = txt_Phone.Text.Trim();
                    // Kiểm tra nếu trường không rỗng hoặc null
                    if (string.IsNullOrEmpty(Name))
                    {
                        MessageBox.Show("Tên không được để trống.");
                        return;
                    }

                    if (string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show("Tên tài khoản không được để trống.");
                        return;
                    }

                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Mật khẩu không được để trống.");
                        return;
                    }

                    // Tiến hành các xử lý tiếp theo nếu mọi trường hợp đều hợp lệ


                    // Lấy mảng byte từ PictureBox
                    string picture = SaveImageToFolder(filePathnew);
                    // Gọi hàm UpdateUser
                    bool result = new addUsersBL().AddUser(name, userName, password, phone, picture);
                    if (result)
                    {
                        MessageBox.Show("thêm người dùng thành công!");
                        UserView userView = new UserView();
                        Main.Instance.LoadFormIntoPanelCenter(userView);
                        this.Close();
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Người dùng đã tồn tại.");
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }



        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
