using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using BL;
using PL.View;
using DL.Products;
using DL.Suppiler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using BL.ProductsBL;
using Guna.UI2.WinForms;

namespace PL.Model
{
    public partial class ProductAdd : SampleAdd
    {
        public ProductAdd()
        {
            InitializeComponent();
            this.Load += LoadToComboBox;
        }

        private async void LoadToComboBox(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu (ví dụ, danh sách employees)
            var product = await new ProductsBL().LoadCategoriesIntoComboBox();

            // Giả sử bạn có một DataGridView để hiển thị danh sách
            cb_Category.DataSource = product;
            cb_Category.DisplayMember = "Name";
            cb_Category.ValueMember = "Id";

            var supplier = await new ProductsBL().LoadSupplierIntoComboBox();

            cb_Supplier.DataSource = supplier;
            cb_Supplier.DisplayMember = "Name";
            cb_Supplier.ValueMember = "Id";
        }

        private void ProductAdd_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
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

        private string CalculateFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                // Đọc file và tính toán hash
                using (var fileStream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(fileStream);
                    // Chuyển đổi hash thành chuỗi hex
                    StringBuilder hashStringBuilder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hashStringBuilder.Append(b.ToString("x2"));
                    }
                    return hashStringBuilder.ToString();
                }
            }
        }

        private string SaveImageToFolder(string path)
        {
            if (path != null)
            {
                // Lấy thư mục gốc của dự án
                string projectDirectory = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;

                // Đảm bảo thư mục ImagesUsers tồn tại
                string destinationFolder = Path.Combine(projectDirectory, "ImagesUsers");
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Tính toán hash của file ảnh (Sử dụng SHA256)
                string fileHash = CalculateFileHash(path);

                // Tạo đường dẫn đích với hash làm tên file
                string destinationFilePath = Path.Combine(destinationFolder, fileHash + Path.GetExtension(path));

                // Kiểm tra nếu file đã tồn tại trong thư mục đích
                if (File.Exists(destinationFilePath))
                {
                    // Nếu file đã tồn tại, không cần lưu lại nữa
                    return destinationFilePath;
                }

                // Sao chép file vào thư mục đích
                File.Copy(path, destinationFilePath);

                // Trả về đường dẫn file đích
                return destinationFilePath;
            }

            return null; // Trường hợp không có file được chọn
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_Save_Click_2(object sender, EventArgs e)
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    var productDL = new ProductsDL();
                    string name = txt_Name.Text;
                    string barcode = txt_Barcode.Text;
                    string description = txt_Description.Text;
                    decimal cost = decimal.Parse(txt_Cost.Text);
                    decimal salePrice = decimal.Parse(txt_Price.Text);
                    decimal discount = decimal.Parse(txt_Discount.Text);
                    int quantity = 0;
                    int categoryId = (int)cb_Category.SelectedValue;
                    int supplierId = (int)cb_Supplier.SelectedValue;

                    // Validate fields
                    if (string.IsNullOrEmpty(name))
                    {
                        ShowMessage("Tên sản phẩm không được để trống.");
                        return;
                    }

                    if (string.IsNullOrEmpty(barcode))
                    {
                        ShowMessage("Mã vạch không được để trống.");
                        return;
                    }

                    if (!decimal.TryParse(txt_Cost.Text, out cost))
                    {
                        ShowMessage("Giá nhập không hợp lệ.");
                        return;
                    }

                    if (!decimal.TryParse(txt_Price.Text, out salePrice))
                    {
                        ShowMessage("Giá bán không hợp lệ.");
                        return;
                    }

                    if (!decimal.TryParse(txt_Discount.Text, out discount))
                    {
                        ShowMessage("Chiết khấu không hợp lệ.");
                        return;
                    }

                    if (cb_Category.SelectedValue == null || !int.TryParse(cb_Category.SelectedValue.ToString(), out categoryId))
                    {
                        ShowMessage("Danh mục không hợp lệ.");
                        return;
                    }

                    if (cb_Supplier.SelectedValue == null || !int.TryParse(cb_Supplier.SelectedValue.ToString(), out supplierId))
                    {
                        ShowMessage("Nhà cung cấp không hợp lệ.");
                        return;
                    }

                    string image = SaveImageToFolder(filePathnew);

                    bool result = await new BL.ProductsBL.ProductsBL().AddProducts(name, barcode, categoryId, quantity, salePrice, cost, discount, supplierId, description, image);
                    if (result)
                    {
                        ShowMessage("Thêm sản phẩm thành công!");
                        bool updateCat = await new ProductsBL().addQuantityCategory(categoryId, 1);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        isValid = true;
                    }
                    else
                    {
                        ShowMessage("Sản phẩm đã tồn tại.");
                        isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }

        private void ShowMessage(string message)
        {
            Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            messageDialog.Text = message;  // Sử dụng Text thay vì Message
            messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;

            messageDialog.Show();
        }

        private void cb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
