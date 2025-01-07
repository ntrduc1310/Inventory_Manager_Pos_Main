using BL.ProductsBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PL.Edit
{
    public partial class editProductsForm : Form
    {
        private int productId;
        private string originalName;
        private string originalBarcode;
        private int originalCategoryId;
        private int originalSupplierId;
        private decimal originalPrice;
        private decimal originalCost;
        private decimal originalDiscount;
        private string originalDescription;
        private string originalImagePath;

        public editProductsForm(int id, string name, string barcode, int categoryID, int quantityInStock,
            decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            InitializeComponent();

            // Lưu giá trị ban đầu
            productId = id;
            originalName = name;
            originalBarcode = barcode;
            originalCategoryId = categoryID;
            originalSupplierId = supplierId;
            originalPrice = price;
            originalCost = costPrice;
            originalDiscount = discount;
            originalDescription = description;
            originalImagePath = image;

            // Set giá trị cho controls
            txt_Name.Text = name;
            txt_Barcode.Text = barcode;
            txt_Price.Text = price.ToString();
            txt_Cost.Text = costPrice.ToString();
            txt_Discount.Text = discount.ToString();
            txt_Description.Text = description;

            this.Load += LoadToComboBox;

            if (!string.IsNullOrEmpty(image) && File.Exists(image))
            {
                try
                {
                    txtPic.Image = Image.FromFile(image);
                    txtPic.ImageLocation = image;
                }
                catch (Exception ex)
                {
                    ShowMessage($"Lỗi tải ảnh: {ex.Message}", "Lỗi", MessageDialogIcon.Error);
                }
            }
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
        private void editProductsForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text.Trim();
                string barcode = txt_Barcode.Text.Trim();
                int categoryId = Convert.ToInt32(cb_Category.SelectedValue);
                int supplierId = Convert.ToInt32(cb_Supplier.SelectedValue);
                decimal price = decimal.TryParse(txt_Price.Text.Trim(), out decimal p) ? p : 0;
                decimal cost = decimal.TryParse(txt_Cost.Text.Trim(), out decimal c) ? c : 0;
                decimal discount = decimal.TryParse(txt_Discount.Text.Trim(), out decimal d) ? d : 0;
                string description = txt_Description.Text.Trim();
                string imagePath = filePathnew ?? originalImagePath; // Sử dụng ảnh mới nếu có, không thì giữ ảnh cũ

                // Kiểm tra dữ liệu trống
                if (string.IsNullOrEmpty(name))
                {
                    ShowMessage("Tên sản phẩm không được để trống!", "Lỗi", MessageDialogIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                // Kiểm tra có thay đổi không
                bool hasChanges = name != originalName ||
                                barcode != originalBarcode ||
                                categoryId != originalCategoryId ||
                                supplierId != originalSupplierId ||
                                price != originalPrice ||
                                cost != originalCost ||
                                discount != originalDiscount ||
                                description != originalDescription ||
                                (filePathnew != null && filePathnew != originalImagePath);

                if (!hasChanges)
                {
                    ShowMessage("Không có thông tin nào được thay đổi!", "Thông báo", MessageDialogIcon.Information);
                    return;
                }

                bool result = await new ProductsBL().UpdateProduct(productId, name, barcode, categoryId,
                    price, cost, discount, supplierId, description, imagePath);

                if (result)
                {
                    ShowMessage("Cập nhật sản phẩm thành công!", "Thành công", MessageDialogIcon.Information);
                    bool updateCat = await new ProductsBL().addQuantityCategory(categoryId, 1);
                    bool updateSubtractCat = await new ProductsBL().subtractQuantityCategory(originalCategoryId, 1);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMessage("Không thể cập nhật sản phẩm. Vui lòng thử lại!", "Thông báo", MessageDialogIcon.Warning);
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


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
