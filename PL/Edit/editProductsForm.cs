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
    }
}
