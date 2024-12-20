using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Sale;
using BL.ProductsBL;
using DTO.Products;
using DTO.Sale;
using BL.Purchase;

namespace PL.Model
{
    public partial class SaleAddProduct : Form
    {
        private decimal total_Amount = 0;

        public SaleAddProduct()
        {
            InitializeComponent();
            this.Load += LoadCustomers;  // Load khách hàng vào ComboBox
            this.Load += LoadProducts;   // Load sản phẩm vào Panel
        }

        // Load danh sách khách hàng vào ComboBox
        private async void LoadCustomers(object sender, EventArgs e)
        {
            var customers = await new SaleBL().LoadCustomersToComboBox();
            cb_Customer.DataSource = customers;
            cb_Customer.DisplayMember = "Name";
            cb_Customer.ValueMember = "CustomerID";

        }






        // Load danh sách sản phẩm vào Panel
        private async void LoadProducts(object sender, EventArgs e)
        {
            //var products = await new SaleBL().LoadProductsFromCustomer(1);
            var products = await new ProductsBL().LoadProducts();
            foreach (var product in products)
            {
                // Tạo Panel chứa thông tin sản phẩm
                Panel productPanel = new Panel();
                productPanel.Width = 120;
                productPanel.Height = 180;
                //productPanel.Margin = new Padding(10);
                productPanel.Padding = new Padding(0, 10, 0, 10);
                productPanel.BorderStyle = BorderStyle.Fixed3D;

                // Tạo PictureBox hiển thị hình ảnh sản phẩm
                PictureBox productImage = new PictureBox();
                productImage.Width = 100;
                productImage.Height = 100;
                productImage.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                {
                    productImage.Image = Image.FromFile(product.Image);
                }
                productPanel.Controls.Add(productImage);

                // Tạo Label hiển thị tên sản phẩm
                Label productName = new Label();
                productName.Text = product.Name;
                productName.TextAlign = ContentAlignment.MiddleCenter;
                productName.Dock = DockStyle.Bottom;
                Font boldFont = new Font(productName.Font.FontFamily, 9, FontStyle.Bold);
                productName.Font = boldFont;
                productPanel.Controls.Add(productName);

                // Tạo Label hiển thị giá sản phẩm
                Label productPrice = new Label();
                productPrice.Text = product.CostPrice.ToString("C2"); // Định dạng thành tiền tệ
                productPrice.TextAlign = ContentAlignment.MiddleCenter;
                productPrice.Dock = DockStyle.Bottom;
                productPrice.Font = boldFont;
                productPanel.Controls.Add(productPrice);

                // Thêm sự kiện khi click vào sản phẩm
                var controls = new List<Control> { productPanel, productName, productPrice, productImage };

                // Lặp qua các điều khiển và gắn sự kiện Click
                foreach (var control in controls)
                {
                    control.Click += (s, e) =>
                    {
                        if (cb_Customer.SelectedValue != null)
                        {
                            int customerId = Convert.ToInt32(cb_Customer.SelectedValue);
                            AddToCart(product.ProductID, customerId);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn khách hàng!");
                        }
                    };

                }
                // Thêm sản phẩm vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(productPanel);


                dataGridViewCart2.CellClick += async (s, e) =>
                {
                    // Kiểm tra nếu click vào cột Edit
                    if (e.RowIndex >= 0 && dataGridViewCart2.Columns[e.ColumnIndex].Name == "dgvAdd")
                    {
                        AddToCartForClickImage(product.ProductID);

                    }
                    else if (e.RowIndex >= 0 && dataGridViewCart2.Columns[e.ColumnIndex].Name == "dgvSubtract")
                    {
                        SubtractToCart(product.ProductID);
                    }
                };
            }
        }


        // Thêm sản phẩm vào giỏ hàng
        private async void AddToCart(int productId, int customerId)
        {
            // Lấy sản phẩm từ database
            var product = await new ProductsBL().getProducts(productId);

            if (product != null)
            {
                // Kiểm tra CustomerID trong giỏ hàng
                if (dataGridViewCart2.Rows.Count > 0)
                {
                    int existingCustomerId;
                    if (int.TryParse(dataGridViewCart2.Rows[0].Cells["dgvCustomerId"].Value?.ToString(), out existingCustomerId))
                    {
                        if (existingCustomerId != customerId)
                        {
                            MessageBox.Show("Không thể thêm sản phẩm cho khách hàng khác vào giỏ hàng hiện tại!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer ID không hợp lệ!");
                        return;
                    }
                    if (existingCustomerId != customerId)
                    {
                        MessageBox.Show("Không thể thêm sản phẩm cho khách hàng khác vào giỏ hàng hiện tại!");
                        return;
                    }
                }

                // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
                bool isProductInCart = false;
                foreach (DataGridViewRow row in dataGridViewCart2.Rows)
                {
                    if (row.Cells["dgvProductName"].Value != null && row.Cells["dgvProductName"].Value.ToString().Equals(product.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu có, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        row.Cells["dgvQuantity"].Value = currentQuantity + 1; // Tăng số lượng lên 1

                        // Cập nhật lại Amount
                        decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                        row.Cells["dgvAmount"].Value = price * (currentQuantity + 1);

                        // Đánh dấu là sản phẩm đã có trong giỏ hàng
                        isProductInCart = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                if (!isProductInCart)
                {
                    // Thêm sản phẩm vào DataGridView (lưu ý thêm ProductID, Name, Quantity, CostPrice, Price, Amount, CustomerID)
                    dataGridViewCart2.Rows.Add(customerId, product.Name, product.SupplierID, 1, product.CostPrice, product.CostPrice);

                    // Cập nhật tổng tiền (có thể tính lại tổng tiền ở đây)
                    UpdateGrandTotal();
                }
                else
                {
                    // Cập nhật tổng tiền nếu sản phẩm đã có trong giỏ hàng
                    UpdateGrandTotal();
                }
            }
        }
        private async void AddToCartForClickImage(int productId)
        {
            // Lấy sản phẩm từ database
            var product = await new ProductsBL().getProducts(productId);

            if (product != null)
            {
                // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
                bool isProductInCart = false;
                foreach (DataGridViewRow row in dataGridViewCart2.Rows)
                {
                    if (row.Cells["dgvProductName"].Value != null && row.Cells["dgvProductName"].Value.ToString().Equals(product.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu có, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        row.Cells["dgvQuantity"].Value = currentQuantity + 1;  // Tăng số lượng lên 1

                        // Cập nhật lại Amount
                        decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                        row.Cells["dgvAmount"].Value = price * (currentQuantity + 1);

                        // Đánh dấu là sản phẩm đã có trong giỏ hàng
                        isProductInCart = true;
                        break;
                    }
                }

            }
        }




        private async void SubtractToCart(int productId)
        {
            // Lấy sản phẩm từ database
            var product = await new ProductsBL().getProducts(productId);

            if (product != null)
            {

                foreach (DataGridViewRow row in dataGridViewCart2.Rows)
                {
                    // Kiểm tra ProductID trong giỏ hàng
                    if (row.Cells["dgvProductName"].Value != null && row.Cells["dgvProductName"].Value.ToString().Equals(product.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu có, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        if (currentQuantity <= 0)
                        {
                            currentQuantity = 0;
                        }
                        else
                        {
                            row.Cells["dgvQuantity"].Value = currentQuantity - 1;  // Tăng số lượng lên 1
                            // Cập nhật lại Amount
                            decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                            row.Cells["dgvAmount"].Value = price * (currentQuantity - 1);
                            break;
                        }

                    }
                }
                UpdateGrandTotal();

            }
        }




        // Cập nhật tổng tiền
        private void UpdateGrandTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCart2.Rows)
            {
                total += Convert.ToDecimal(row.Cells["dgvAmount"].Value);
            }

            lbl_Total.Text = total.ToString("C");
            total_Amount = total;
        }

        // Xử lý tăng/giảm số lượng sản phẩm
        //private void dataGridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        if (dataGridViewCart2.Columns[e.ColumnIndex].Name == "dgvAdd")
        //        {
        //            int quantity = Convert.ToInt32(dataGridViewCart2.Rows[e.RowIndex].Cells["dgvQuantity"].Value) + 1;
        //            decimal price = Convert.ToDecimal(dataGridViewCart2.Rows[e.RowIndex].Cells["dgvPrice"].Value);
        //            dataGridViewCart2.Rows[e.RowIndex].Cells["dgvQuantity"].Value = quantity;
        //            dataGridViewCart2.Rows[e.RowIndex].Cells["dgvAmount"].Value = price * quantity;
        //        }
        //        else if (dataGridViewCart2.Columns[e.ColumnIndex].Name == "dgvSubtract")
        //        {
        //            int quantity = Convert.ToInt32(dataGridViewCart2.Rows[e.RowIndex].Cells["dgvQuantity"].Value) - 1;
        //            if (quantity > 0)
        //            {
        //                decimal price = Convert.ToDecimal(dataGridViewCart2.Rows[e.RowIndex].Cells["dgvPrice"].Value);
        //                dataGridViewCart2.Rows[e.RowIndex].Cells["dgvQuantity"].Value = quantity;
        //                dataGridViewCart2.Rows[e.RowIndex].Cells["dgvAmount"].Value = price * quantity;
        //            }
        //            else
        //            {
        //                dataGridViewCart2.Rows.RemoveAt(e.RowIndex);
        //            }
        //        }

        //        UpdateGrandTotal();
        //    }
        //}

        // Lưu đơn hàng
        private async void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void txt_notes_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task btn_Save_Click_1Async(object sender, EventArgs e)
        {


        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_Save_Click_1(object sender, EventArgs e)
        {
            if (cb_Customer.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return;
            }

            int customerId = (int)cb_Customer.SelectedValue;
            string notes = txt_notes.Text;

            var saleDetails = new List<SaleDetail>(); 
            foreach (DataGridViewRow row in dataGridViewCart2.Rows)
            {
                saleDetails.Add(new SaleDetail
                {
                    ProductID = Convert.ToInt32(row.Cells["dgvProductID"].Value),
                    Quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value),
                    Price = Convert.ToDecimal(row.Cells["dgvPrice"].Value),
                    Amount = Convert.ToDecimal(row.Cells["dgvAmount"].Value), 
                });
            }

            bool result = await new SaleBL().SaveSale(customerId, total_Amount, saleDetails, notes);

            if (result)
            {
                MessageBox.Show("Lưu đơn hàng thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!");
            }
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }



        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void SaleAddProduct_Load(object sender, EventArgs e)
        {

        }

        private void cb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
