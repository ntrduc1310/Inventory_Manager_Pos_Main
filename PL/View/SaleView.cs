using BL.Invoice;
using BL.ProductsBL;
using BL.Purchase;
using BL.Sale;
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
    public partial class SaleView : SampleView
    {
        public SaleView()
        {
            InitializeComponent();
            ConfigureDataGridView();
            this.Load += loadToSaleView;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Sr;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_Print;
            txtsearch.TextChanged += txtsearch_TextChanged;
        }
        private void ConfigureDataGridView()
        {
            // Cấu hình cơ bản cho DGV
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.RowTemplate.Height = 60;

            // Theme và màu sắc mới (94,71,204)
            guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(94, 71, 204);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Style cho rows
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 243, 252); // màu nhạt của tím
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(235, 232, 247); // màu tím nhạt khi select
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Border và Grid
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.BorderStyle = BorderStyle.None;

            
        }

        private void PurchaseView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            SaleAddProduct saleAddProduct = new SaleAddProduct();
            saleAddProduct.ShowDialog();
            if (saleAddProduct.DialogResult == DialogResult.OK)
                loadSaleViewFunction();
        }

        private async void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng có nhấp vào cột dgvAllInformation hay không
                if (e.ColumnIndex == guna2DataGridView1.Columns["dgvAllInformation"].Index)
                {
                    // Lấy ID từ cột dgvid
                    int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;

                    // Lấy thông tin chi tiết của Purchase từ ID
                    string details = await new SaleBL().LoadSaleDetailsByIdAsString(id);

                    MessageBox.Show(details);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CellClick: {ex.Message}");
            }
        }
        private async void loadSaleViewFunction()
        {
            try
            {
                guna2DataGridView1.AutoGenerateColumns = false;

                // Cấu hình DataPropertyName
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "SaleID";
                guna2DataGridView1.Columns["dgvDate"].DataPropertyName = "CreatedAt";
                guna2DataGridView1.Columns["dgvCustomerID"].DataPropertyName = "CustomerID";
                guna2DataGridView1.Columns["dgvAmount"].DataPropertyName = "TotalAmount";
                guna2DataGridView1.Columns["dgvCreatedBy"].DataPropertyName = "CreatedBy";

                // Load dữ liệu
                var data = await new SaleBL().LoadSales();
                guna2DataGridView1.DataSource = data;

                guna2DataGridView1.Refresh();

                guna2DataGridView1.CellFormatting += async (s, e) =>
                {
                    try
                    {
                     

                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvCustomer"].Index)
                        {

                            int cellValue = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCustomerID"].Value;
                            if (cellValue != 0)
                            {
                                string supplierName = await new SaleBL().GetCustomerNameById(cellValue);
                                guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCustomer"].Value = supplierName;
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
                MessageBox.Show($"Error: {ex.Message}");
                throw ex;
            }
        }
        private async void loadToSaleView(object sender, EventArgs e)
        {
            loadSaleViewFunction();
        }

        private void guna2DataGridView1_CellFormatting_Sr(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
            {
                // Gán số thứ tự cho cột "#Sr"
                e.Value = (e.RowIndex + 1).ToString();
            }
            // Format cột số tiền
            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvAmount"].Index && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("N0") + " đ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void guna2DataGridView1_CellClick_Print(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvPrintInvoice")
                {
                    if (guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"] != null)
                    {
                        int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;
                        var invoice = await new InvoiceBL().SaleIdGetInvoice(id);
                        Invoice_Print invoice_Print = new Invoice_Print(invoice);
                        invoice_Print.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID column.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void guna2DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    var data = await new SaleBL().searchSale(searchText);
                    guna2DataGridView1.DataSource = data;
                }
                else
                {
                    loadSaleViewFunction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
