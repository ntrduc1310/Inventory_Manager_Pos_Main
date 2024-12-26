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
using PL.View;

namespace PL.Model
{
    public partial class SaleAddProduct : Form
    {
        private decimal total_Amount = 0;
        private decimal totalCostPrice = 0;

        public SaleAddProduct()
        {
            InitializeComponent();
            this.Load += LoadCustomers;  // Load khách hàng vào ComboBox
            this.Load += LoadProducts;   // Load sản phẩm vào Panel
            dataGridViewCart.CellClick += AddToCartForClickImageCellClick;
            dataGridViewCart.CellClick += SubtractToCartCellClick;
        }

        // Load danh sách khách hàng vào ComboBox
        private async void LoadCustomers(object sender, EventArgs e)
        {
            var customers = await new SaleBL().LoadCustomersToComboBox();
            cb_Customer.DataSource = customers;
            cb_Customer.DisplayMember = "Name";
            cb_Customer.ValueMember = "CustomerID";
            cb_OnOff.Items.Add("Trực tiếp");
            cb_OnOff.Items.Add("Trực tuyến");

        }




        private void UpdateGrandTotal()
        {
            decimal total = 0;
            decimal costPrice = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["dgvAmount"].Value);
                costPrice += Convert.ToDecimal(row.Cells["dgvTotalCostPrice"].Value);
            }
            // Hiển thị tổng tiền lên giao diện
            lbl_Total.Text = total.ToString("C");
            total_Amount = total;
            totalCostPrice = costPrice;
        }


        // Thêm sản phẩm vào giỏ hàng
        private async void AddToCart(int productId)
        {
            // Lấy sản phẩm từ database
            var product = await new ProductsBL().getProducts(productId);

            if (product != null)
            {
                // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
                bool isProductInCart = false;
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.Cells["dgvId"].Value != null && (int)row.Cells["dgvId"].Value == product.ProductID)
                    {
                        // Nếu có, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        row.Cells["dgvQuantity"].Value = currentQuantity + 1;  // Tăng số lượng lên 1

                        // Cập nhật lại Amount
                        decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                        row.Cells["dgvAmount"].Value = price * (currentQuantity + 1);

                        decimal costprice = Convert.ToDecimal(row.Cells["dgvCostPrice"].Value);
                        row.Cells["dgvTotalCostPrice"].Value = costprice * (currentQuantity + 1);

                        // Đánh dấu là sản phẩm đã có trong giỏ hàng
                        isProductInCart = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                if (!isProductInCart)
                {
                    // Thêm sản phẩm vào DataGridView (lưu ý thêm ProductID, Name, Quantity, CostPrice, Price, Amount)
                    dataGridViewCart.Rows.Add(product.Name, product.ProductID, 1, product.Price, product.Price, product.CostPrice, product.CostPrice);


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
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    // Kiểm tra ProductID trong giỏ hàng (xử lý null)
                    if (row.Cells["dgvId"].Value != null && Convert.ToInt32(row.Cells["dgvId"].Value) == product.ProductID)
                    {
                        // Nếu có, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        row.Cells["dgvQuantity"].Value = currentQuantity + 1;  // Tăng số lượng lên 1

                        // Cập nhật lại Amount
                        decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                        row.Cells["dgvAmount"].Value = price * (currentQuantity + 1);

                        decimal costprice = Convert.ToDecimal(row.Cells["dgvCostPrice"].Value);
                        row.Cells["dgvTotalCostPrice"].Value = costprice * (currentQuantity + 1);

                        // Cập nhật tổng tiền
                        UpdateGrandTotal();
                        return; // Dừng vòng lặp
                    }
                }

            }
        }

        private async void AddToCartForClickImageCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvAdd")
            {
                // Lấy ProductID từ dòng hiện tại
                int productId = Convert.ToInt32(dataGridViewCart.Rows[e.RowIndex].Cells["dgvId"].Value);

                // Gọi phương thức thêm sản phẩm
                AddToCartForClickImage(productId);
            }
        }



        private async void SubtractToCart(int productId)
        {
            // Lấy sản phẩm từ database
            var product = await new ProductsBL().getProducts(productId);

            if (product != null)
            {
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    // Kiểm tra ProductID trong giỏ hàng
                    if (row.Cells["dgvId"].Value != null && Convert.ToInt32(row.Cells["dgvId"].Value) == product.ProductID)
                    {
                        // Nếu sản phẩm được tìm thấy, cập nhật số lượng và Amount
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);

                        if (currentQuantity > 1)
                        {
                            row.Cells["dgvQuantity"].Value = currentQuantity - 1;  // Giảm số lượng
                            decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value);
                            row.Cells["dgvAmount"].Value = price * (currentQuantity - 1); // Cập nhật Amount

                            decimal costprice = Convert.ToDecimal(row.Cells["dgvCostPrice"].Value);
                            row.Cells["dgvTotalCostPrice"].Value = costprice * (currentQuantity - 1); // Cập nhật Amount



                        }
                        else
                        {
                            // Nếu số lượng là 1, xóa sản phẩm khỏi giỏ hàng
                            dataGridViewCart.Rows.Remove(row);
                        }

                        UpdateGrandTotal();
                        return; // Dừng vòng lặp sau khi tìm thấy và xử lý sản phẩm
                    }
                }
            }
        }

        private async void SubtractToCartCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvSubtract")
            {
                // Lấy ProductID từ dòng hiện tại
                int productId = Convert.ToInt32(dataGridViewCart.Rows[e.RowIndex].Cells["dgvId"].Value);

                // Gọi phương thức thêm sản phẩm
                SubtractToCart(productId);
            }
        }



        private async void LoadProducts(object sender, EventArgs e)
        {
            var products = await new ProductsBL().LoadProducts();
            //var products = await new ProductsBL().LoadProducts();
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
                productPrice.Text = product.Price.ToString("C2"); // Định dạng thành tiền tệ
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
                        AddToCart(product.ProductID);
                    };
                }
                // Thêm sản phẩm vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(productPanel);


            }
        }


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

            string createdBy = Main.Instance.username_lbl.Text;
            string notes = txt_notes.Text;
            string status = "";
            if (cb_OnOff.Text.Equals("Trực tiếp"))
            {
                status = "Hoàn thành";
            }
            else
            {
                status = "Đang xử lý";
            }
            bool result = await new SaleBL().AddSale(customerId, total_Amount, status, createdBy, notes,totalCostPrice);
            if (result)
            {
                MessageBox.Show("Tạo đơn hàng thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
