using BL.Category;
using BL.ProductsBL;
using DL.Category;
using Guna.UI2.WinForms.Suite;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.View
{
    public partial class ProductView : SampleView
    {
        public ProductView()
        {
            InitializeComponent();
            this.Load += LoadProductsToGridViewFunction;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_delete;

        }

        private void ProductView_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            ProductAdd productAdd = new ProductAdd();
            productAdd.ShowDialog();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Edit
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
            {
                // Lấy thông tin từ dòng hiện tại
                int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                string barcode = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvBarcode"].Value.ToString();
                int categoryID = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCatID"].Value;
                int supplierId = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupplierID"].Value;
                int quantityInStock = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvQuantityInStock"].Value;
                decimal price = (decimal)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCost"].Value;
                decimal costPrice = (decimal)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSalePrice"].Value;
                decimal discount = (decimal)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvDiscount"].Value;
                string description = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvDescription"].Value.ToString();
                string image = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvImage"].Value.ToString() ?? string.Empty;

                // Hiển thị form chỉnh sửa và truyền dữ liệu
                PL.Edit.editProductsForm editProductsForm = new PL.Edit.editProductsForm(id, name, barcode, categoryID, quantityInStock, price, costPrice, discount, supplierId, description, image);
                if (editProductsForm.ShowDialog() == DialogResult.OK)
                {
                    // Load lại dữ liệu sau khi chỉnh sửa
                    guna2DataGridView1.DataSource = await new CategoryBL().LoadCategory();
                }
            }
        }

        private async void guna2DataGridView1_CellClick_delete(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào cột Delete
            if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDel")
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);
                    bool deleteResult = await new ProductsBL().DeleteProducts(id);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa danh mục thành công!");
                        ProductView productView = new ProductView();
                        Main.Instance.LoadFormIntoPanelCenter(productView);
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại!");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không thực hiện xóa
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
        }


        private async void LoadProductsToGridViewFunction(object sender, EventArgs e)
        {
            try
            {
                // Tắt tự động tạo cột
                guna2DataGridView1.AutoGenerateColumns = false;

                // Ánh xạ cột với dữ liệu từ cơ sở dữ liệu
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "ProductId";
                guna2DataGridView1.Columns["dgvName"].DataPropertyName = "Name";
                guna2DataGridView1.Columns["dgvCatID"].DataPropertyName = "CategoryID";
                guna2DataGridView1.Columns["dgvBarcode"].DataPropertyName = "Barcode";
                guna2DataGridView1.Columns["dgvCost"].DataPropertyName = "CostPrice";
                guna2DataGridView1.Columns["dgvsalePrice"].DataPropertyName = "Price";
                guna2DataGridView1.Columns["dgvQuantityInStock"].DataPropertyName = "QuantityInStock";
                guna2DataGridView1.Columns["dgvDiscount"].DataPropertyName = "Discount";
                guna2DataGridView1.Columns["dgvSupplierID"].DataPropertyName = "SupplierID";
                guna2DataGridView1.Columns["dgvDescription"].DataPropertyName = "Description";
                guna2DataGridView1.Columns["dgvCreateDate"].DataPropertyName = "CreatedAt";
                guna2DataGridView1.Columns["dgvUpdateDate"].DataPropertyName = "UpdatedAt";
                guna2DataGridView1.Columns["dgvImage"].DataPropertyName = "Image";

                // Đọc dữ liệu từ cơ sở dữ liệu
                var data = await new ProductsBL().LoadProducts();
                guna2DataGridView1.DataSource = data;
                guna2DataGridView1.Refresh();

                // Sử dụng sự kiện CellFormatting để hiển thị hình ảnh từ đường dẫn
                guna2DataGridView1.CellFormatting += async (s, e) =>
                {
                    try
                    {
                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvImageShow"].Index)
                        {
                            string imagePath = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvImage"].Value?.ToString()?.Trim();

                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                try
                                {
                                    e.Value = Image.FromFile(imagePath);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error loading image: {ex.Message}");
                                    e.Value = null;
                                }
                            }
                            else
                            {
                                e.Value = null;
                                Console.WriteLine($"No image found at path: {imagePath}");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"CellFormatting error: {ex.Message}");
                    }
                };

                // Thêm sự kiện CellValueChanged để xử lý cập nhật giá trị tên danh mục và nhà cung cấp
                guna2DataGridView1.CellFormatting += async (s, e) =>
                {
                    try
                    {
                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvCategory"].Index)
                        {
                            int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCatID"].Value;

                            if (id != 0)
                            {
                                string categoryName = await new ProductsBL().GetCategoryNameById(id);
                                guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCategory"].Value = categoryName; // Gán giá trị hiển thị vào e.Value
                            }
                        }
                        else if (e.ColumnIndex == guna2DataGridView1.Columns["dgvSupplier"].Index)
                        {

                            int cellValue = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupplierID"].Value;
                            if (cellValue != 0)
                            {
                                string supplierName = await new ProductsBL().GetSupplierNameById(cellValue);
                                guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupplier"].Value = supplierName;
                            }
                            else
                            {
                                MessageBox.Show("Invalid Supplier ID");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"CellFormatting error: {ex.Message}");
                    }
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data into DataGridView: {ex.Message}");
                MessageBox.Show("An error occurred while loading the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
