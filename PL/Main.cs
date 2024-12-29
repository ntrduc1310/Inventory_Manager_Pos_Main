using BL.ProductsBL;
using DL.Products;
using Guna.UI2.WinForms;
using PL.Edit;
using PL.Model;
using PL.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace PL
{
    public partial class Main : Form
    {
        static Main _obj;
        public Guna.UI2.WinForms.Guna2HtmlLabel username_lbl;
        public Guna.UI2.WinForms.Guna2PictureBox pictureBox;


        public Main()
        {

            InitializeComponent();
            username_lbl = LabelName;
            pictureBox = guna2PictureBox1;

        }
        public static Main Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Main();
                }
                return _obj;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED: Kích hoạt giao diện hợp nhất để giảm nhấp nháy
                return cp;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();
            _obj.Visible = false;
            btn_DashBoard.PerformClick();
            LoadStockNotification();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void LoadFormIntoPanel(Form form, Panel panel)
        {
            panel.Visible = false;
            // Xóa tất cả control đang hiển thị trong panel
            panel.Controls.Clear();

            // Cấu hình form con
            form.TopLevel = false; // Không phải form độc lập
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            form.Dock = DockStyle.Fill; // Chiếm toàn bộ panel

            // Thêm form vào panel
            panel.Controls.Add(form);
            panel.Tag = form;

            // Hiển thị form
            form.BringToFront();
            form.Show();
            panel.Visible = true;
        }

        public void LoadFormIntoPanelCenter(Form form)
        {
            CenterPanel.Visible = false;
            // Xóa tất cả control đang hiển thị trong panel
            CenterPanel.Controls.Clear();

            // Debug: Kiểm tra CenterPanel trước khi thêm form vào
            Console.WriteLine("CenterPanel size: " + CenterPanel.Size.ToString());

            // Cấu hình form con
            form.TopLevel = false; // Không phải form độc lập
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            form.Dock = DockStyle.Fill; // Chiếm toàn bộ panel

            // Thêm form vào panel
            CenterPanel.Controls.Add(form);
            CenterPanel.Tag = form;

            // Debug: Kiểm tra sau khi thêm form vào
            Console.WriteLine("Form added: " + form.Name);

            // Hiển thị form
            form.BringToFront();
            form.Show();
            CenterPanel.Visible = true;
            CenterPanel.ResumeLayout();
        }


        private void btn_Users_Click(object sender, EventArgs e)
        {
            UserView userView = new UserView();
            LoadFormIntoPanel(userView, CenterPanel);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        public void showLabelUsername(string name)
        {
            LabelName.Text = name;
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {
            DashBoard dashboard = new DashBoard();
            LoadFormIntoPanelCenter(dashboard);

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_Purchases_Click(object sender, EventArgs e)
        {
            PurchaseView purchaseView = new PurchaseView();
            LoadFormIntoPanel(purchaseView, CenterPanel);
        }

        private void btn_Category_Click(object sender, EventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            LoadFormIntoPanel(categoryView, CenterPanel);
        }

        private void btn_Supplier_Click(object sender, EventArgs e)
        {
            SupplierView supplierView = new SupplierView();
            LoadFormIntoPanel(supplierView, CenterPanel);
        }

        private void btn_Customers_Click(object sender, EventArgs e)
        {
            CustomerView customView = new CustomerView();
            LoadFormIntoPanel(customView, CenterPanel);
        }

        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductView productView = new ProductView();
            LoadFormIntoPanel(productView, CenterPanel);
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SaleView saleView = new SaleView();
            LoadFormIntoPanel(saleView, CenterPanel);

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            LoadFormIntoPanel(report, CenterPanel);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        // Phương thức hiển thị thông báo tồn kho
        private async Task LoadStockNotification()
        {
            try
            {
                // Lấy danh sách sản phẩm từ CSDL
                var products = await new ProductsBL().LoadProducts();
                // Duyệt qua danh sách sản phẩm
                foreach (var product in products)
                {
                    // Kiểm tra nếu số lượng sản phẩm ít hơn 10
                    if (product.QuantityInStock < 10)
                    {
                        // Sử dụng Guna2MessageDialog để hiển thị thông báo
                        Guna2MessageDialog stockNotificationDialog = new Guna2MessageDialog
                        {
                            Text = $"Sản phẩm {product.Name} có số lượng tồn kho ít hơn 10. Vui lòng nhập thêm hàng.",
                            Caption = "Thông báo nhập hàng",
                            Parent = this
                        };
                        stockNotificationDialog.Show(); // Hiển thị thông báo
                    }
                }
            }
            catch (Exception ex)
            {
                Guna2MessageDialog errorDialog = new Guna2MessageDialog
                {
                    Text = $"Đã xảy ra lỗi: {ex.Message}",
                    Caption = "Lỗi",
                    Style = MessageDialogStyle.Dark,
                    Icon = MessageDialogIcon.Error
                };
                errorDialog.Show();
            }
        }





        private void btn_Invoice_Click(object sender, EventArgs e)
        {
            invoice invoice = new invoice();
            LoadFormIntoPanel(invoice, CenterPanel);
        }

        private void Print_Invoice_Click(object sender, EventArgs e)
        {
            //Invoice_Print invoice_Print = new Invoice_Print();
            //LoadFormIntoPanel(invoice_Print, CenterPanel);
        }
    }
}