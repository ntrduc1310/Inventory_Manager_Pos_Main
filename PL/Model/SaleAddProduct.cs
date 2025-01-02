using BL.Invoice;
using BL.ProductsBL;
using BL.Sale;
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
            ConfigureFlowLayoutPanel();
            dataGridViewCart.CellClick += AddToCartForClickImageCellClick;
            dataGridViewCart.CellClick += SubtractToCartCellClick;
            txt_Search.TextChanged += txt_Search_TextChanged;
        }
        private void ConfigureFlowLayoutPanel()
        {


            // Bật tính năng cuộn
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.VerticalScroll.Enabled = true;
            flowLayoutPanel1.VerticalScroll.Visible = true;

            // Cấu hình hiển thị
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoSize = false; // Không cho panel tự động mở rộng

            // Thiết lập padding và margin
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Margin = new Padding(0);

            // Thiết lập style
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.BackColor = Color.White;
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
            cb_Invoice.Items.Add("Có");
            cb_Invoice.Items.Add("Không");

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
            lbl_Total.Text = total.ToString("N0") + " VNĐ";
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

                if (product.QuantityInStock == 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng!");
                    return;
                }

                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                else if (!isProductInCart)
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

            flowLayoutPanel1.Controls.Clear(); // Xóa các controls cũ nếu có

            var products = await new ProductsBL().LoadProducts();

            foreach (var product in products)
            {
                // Main product panel
                Panel productPanel = new Panel();
                productPanel.Width = 150;
                productPanel.Height = 200;
                productPanel.Padding = new Padding(5);
                productPanel.BackColor = Color.White;
                productPanel.BorderStyle = BorderStyle.FixedSingle;

                // Product Image
                PictureBox productImage = new PictureBox();
                productImage.Width = 100;
                productImage.Height = 100;
                productImage.SizeMode = PictureBoxSizeMode.Zoom;
                productImage.Location = new Point((productPanel.Width - productImage.Width) / 2, 10);
                if (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                {
                    productImage.Image = Image.FromFile(product.Image);
                }
                productPanel.Controls.Add(productImage);

                // Product name
                Label productName = new Label();
                productName.Text = product.Name;
                productName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                productName.TextAlign = ContentAlignment.MiddleCenter;
                productName.Size = new Size(productPanel.Width - 10, 25);
                productName.Location = new Point(5, productImage.Bottom + 10);
                productPanel.Controls.Add(productName);

                // Price
                Label productPrice = new Label();
                productPrice.Text = product.Price.ToString("N0") + " VNĐ"; // Thêm đơn vị tiền tệ
                productPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                productPrice.ForeColor = Color.FromArgb(94, 71, 204); // Màu tím theo yêu cầu
                productPrice.TextAlign = ContentAlignment.MiddleCenter;
                productPrice.Size = new Size(productPanel.Width - 10, 25);
                productPrice.Location = new Point(5, productName.Bottom + 5);
                productPanel.Controls.Add(productPrice);

                // Add click event to the entire panel and all controls
                var controls = new List<Control> { productPanel, productName, productPrice, productImage };
                foreach (var control in controls)
                {
                    control.Click += (s, evt) => AddToCart(product.ProductID);
                    control.Cursor = Cursors.Hand;
                }


                // Hiệu ứng hover với màu tím nhạt
                Color hoverColor = Color.FromArgb(235, 232, 247); // Màu tím nhạt khi hover
                productPanel.MouseEnter += (s, evt) =>
                {
                    productPanel.BackColor = hoverColor;
                    foreach (Control control in productPanel.Controls)
                    {
                        control.BackColor = hoverColor;
                    }
                };
                productPanel.MouseLeave += (s, evt) =>
                {
                    productPanel.BackColor = Color.White;
                    foreach (Control control in productPanel.Controls)
                    {
                        control.BackColor = Color.White;
                    }
                };

                // Add the product panel to the flow layout
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
            // Danh sách sản phẩm, số lượng, giá
            List<string> productNameList = new List<string>();
            List<int> productQuantityList = new List<int>();
            List<decimal> productPriceList = new List<decimal>();

            // Lặp qua các hàng trong DataGridView
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.Cells["dgvProductName"].Value != null &&
                    row.Cells["dgvQuantity"].Value != null &&
                    row.Cells["dgvPrice"].Value != null)
                {
                    // Lấy tên sản phẩm
                    string name = row.Cells["dgvProductName"].Value.ToString();

                    // Lấy số lượng
                    if (int.TryParse(row.Cells["dgvQuantity"].Value.ToString(), out int quantity))
                    {
                        // Lấy giá
                        if (decimal.TryParse(row.Cells["dgvPrice"].Value.ToString(), out decimal price))
                        {
                            // Thêm vào danh sách
                            productNameList.Add(name);
                            productQuantityList.Add(quantity);
                            productPriceList.Add(price);
                        }
                        else
                        {
                            Console.WriteLine($"Giá không hợp lệ cho sản phẩm: {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Số lượng không hợp lệ cho sản phẩm: {name}");
                    }
                }
            }

            // Chuyển danh sách thành chuỗi phân cách bằng dấu phẩy
            string productNames = string.Join(",", productNameList.Select(name => $"'{name}'")); // Thêm dấu nháy đơn để sử dụng trong SQL
            string productQuantities = string.Join(",", productQuantityList);
            string productPrices = string.Join(",", productPriceList);

            if (cb_OnOff.Text.Equals("Trực tiếp"))
            {
                status = "Hoàn thành";
            }
            else
            {
                status = "Đang xử lý";
            }

            int saleId = await new SaleBL().AddSalegetID(customerId, total_Amount, status, createdBy, notes, totalCostPrice, productNames, productQuantities, productPrices);
            if (saleId > 0)
            {
                MessageBox.Show("Tạo đơn hàng thành công!");
                bool invoiceId = await new InvoiceBL().AddInvoice(customerId, saleId, total_Amount, productNames, productQuantities, productPrices);
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.Cells["dgvId"].Value != null && row.Cells["dgvQuantity"].Value != null)
                    {
                        int productId = Convert.ToInt32(row.Cells["dgvId"].Value);
                        int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                        // Add your logic here to handle productId and quantity
                        bool resultAdd = await new ProductsBL().SubtractQuantityProduct(productId, quantity);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (cb_Invoice.Text.Equals("Có"))
            {
                var invoice = await new InvoiceBL().SaleIdGetInvoice(saleId);
                Invoice_Print invoice_Print = new Invoice_Print(invoice);
                invoice_Print.ShowDialog();
            }
            else
            {
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
            string searchText = txt_Search.Text.ToLower();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel productPanel)
                {
                    Label productName = productPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.ToLower().Contains(searchText));
                    productPanel.Visible = productName != null;
                }
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Total_Click(object sender, EventArgs e)
        {

        }
    }
}
