using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using BL;
using BL.Category;
using BL.ProductsBL;
using BL.Purchase;
using BL.User;
using DTO.Suppiler;
using Guna.UI2.WinForms;
using PL.View;

namespace PL.Model
{
    public partial class PurchaseAddProduct : Form
    {
        public PurchaseAddProduct()
        {
            InitializeComponent();
            this.Load += LoadToComboBox;
            this.Load += LoadProducts;
            cb_Supplier.SelectedIndexChanged += cb_Supplier_select;


        }

        private async void LoadToComboBox(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu (ví dụ, danh sách employees)
            var CreatedBy = await new BL.Purchase.PurchaseBL().loadUsersToComboBox();
            // Giả sử bạn có một DataGridView để hiển thị danh sách
            cb_CreatedBy.DataSource = CreatedBy;
            cb_CreatedBy.DisplayMember = "UserName";
            cb_CreatedBy.ValueMember = "Id";

            var supplier = await new ProductsBL().LoadSupplierIntoComboBox();

            cb_Supplier.DataSource = supplier;
            cb_Supplier.DisplayMember = "Name";
            cb_Supplier.ValueMember = "Id";
        }


        private void PurchaseAddProduct_Load(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
        decimal total_Amount = 0;
        private void UpdateGrandTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["dgvAmount"].Value);
            }
            // Hiển thị tổng tiền lên giao diện
            lbl_Total.Text = total.ToString("C");
            total_Amount = total;
        }

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
                    // Kiểm tra ProductID trong giỏ hàng
                    if ((int)row.Cells["dgvSupplierId"].Value != 0 && (int)row.Cells["dgvSupplierId"].Value != product.SupplierID)
                    {
                        MessageBox.Show("Không thể thêm sản phẩm khác nhà cung cấp để tạo đơn hàng!");
                        isProductInCart = false;
                        return;
                    }    
                    else if (row.Cells["dgvProductName"].Value != null && row.Cells["dgvProductName"].Value.ToString().Equals(product.Name, StringComparison.OrdinalIgnoreCase))
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

                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                if (!isProductInCart)
                {
                    // Thêm sản phẩm vào DataGridView (lưu ý thêm ProductID, Name, Quantity, CostPrice, Price, Amount)
                    dataGridViewCart.Rows.Add(product.Name,product.SupplierID, 1, product.CostPrice, product.CostPrice);
                    

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
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
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

                foreach (DataGridViewRow row in dataGridViewCart.Rows)
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



        private async void cb_Supplier_select(object sender, EventArgs e)
        {
            // Kiểm tra nếu có giá trị được chọn trong ComboBox
            if (cb_Supplier.SelectedValue != null)
            {
                // Lấy giá trị của Id từ SelectedValue và ép kiểu sang int
                if (cb_Supplier.SelectedValue is int selectedSupplierId)
                {
                    var products = await new PurchaseBL().LoadProductFromSupplier(selectedSupplierId);
                    //var products = await new ProductsBL().LoadProducts();
                    foreach (var product in products)
                    {
                        // Tạo Panel chứa thông tin sản phẩm
                        Panel productPanel = new Panel();
                        productPanel.Controls.Clear();
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
                                AddToCart(product.ProductID);
                            };
                        }
                        // Thêm sản phẩm vào FlowLayoutPanel
                        guna2Panel1.Controls.Clear();
                        guna2Panel1.Controls.Add(productPanel);

                        dataGridViewCart.CellClick += async (s, e) =>
                        {
                            // Kiểm tra nếu click vào cột Edit
                            if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvAdd")
                            {
                                AddToCartForClickImage(product.ProductID);

                            }
                            else if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvSubtract")
                            {
                                SubtractToCart(product.ProductID);
                            }
                        };
                    }
                }
                else
                {
                    Console.WriteLine("Selected value is not of expected type.");
                }
            }
            else
            {
                Console.WriteLine("No supplier selected.");
            }
        }




        private async void LoadProducts(object sender, EventArgs e)
        {
            var products = await new PurchaseBL().LoadProductFromSupplier(1);
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
                        AddToCart(product.ProductID);
                    };
                }
                // Thêm sản phẩm vào FlowLayoutPanel
                guna2Panel1.Controls.Add(productPanel);

                dataGridViewCart.CellClick += async (s, e) =>
                {
                    // Kiểm tra nếu click vào cột Edit
                    if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvAdd")
                    {
                        AddToCartForClickImage(product.ProductID);

                    }
                    else if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "dgvSubtract")
                    {
                        SubtractToCart(product.ProductID);
                    }
                };
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_CreatedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            int supplierId = (int)cb_Supplier.SelectedValue;
            string createdBy = cb_CreatedBy.Text;
            string notes = txt_notes.Text;
            bool result = await new BL.Purchase.PurchaseBL().addPurchase(supplierId, total_Amount, createdBy, notes);
            if (result)
            {
                MessageBox.Show("Tạo đơn hàng thành công!");
                PurchaseView purchaseView = new PurchaseView();
                Main.Instance.LoadFormIntoPanelCenter(purchaseView);
                this.Close();
            }


        }



        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
