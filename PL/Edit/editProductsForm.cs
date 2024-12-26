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

namespace PL.Edit
{
    public partial class editProductsForm : Form
    {
        int productId;
        public editProductsForm(int id, string name, string barcode, int categoryID, int quantityInStock, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            InitializeComponent();
            productId = id;
            txt_Name.Text = name;
            txt_Barcode.Text = barcode;
            txt_Quantity.Text = quantityInStock.ToString();
            txt_Price.Text = price.ToString();
            txt_Cost.Text = costPrice.ToString();
            txt_Discount.Text = discount.ToString();
            txt_Description.Text = description;
            string imagePath = image;
            this.Load += LoadToComboBox;
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
                // Lấy thông tin từ các TextBox và ComboBox
                string name = txt_Name.Text.Trim();
                string barcode = txt_Barcode.Text.Trim();
                int categoryId = Convert.ToInt32(cb_Category.SelectedValue);
                int supplierId = Convert.ToInt32(cb_Supplier.SelectedValue);
                int quantity = int.TryParse(txt_Quantity.Text.Trim(), out int q) ? q : 0;
                decimal price = decimal.TryParse(txt_Price.Text.Trim(), out decimal p) ? p : 0;
                decimal cost = decimal.TryParse(txt_Cost.Text.Trim(), out decimal c) ? c : 0;
                decimal discount = decimal.TryParse(txt_Discount.Text.Trim(), out decimal d) ? d : 0;
                string description = txt_Description.Text.Trim();

                // Lấy đường dẫn hình ảnh
                string imagePath = txtPic.ImageLocation;

                // Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Name.Focus();
                    return;
                }

                if (quantity < 0 || price < 0 || cost < 0)
                {
                    MessageBox.Show("Giá hoặc số lượng không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi hàm UpdateProduct từ Business Logic
                bool result = await new ProductsBL().UpdateProduct(productId, name, barcode, categoryId, quantity, price, cost, discount, supplierId, description, imagePath);

                // Kiểm tra kết quả
                if (result)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Đóng form sau khi lưu thành công
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được lưu. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
