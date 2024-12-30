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
            this.Load += loadToSaleView;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            //guna2DataGridView1.CellClick += DgvCellClickImageColumn;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Sr;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_Print;
            txtsearch.TextChanged += txtsearch_TextChanged;




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
                        //if (e.ColumnIndex == guna2DataGridView1.Columns["dgvCategory"].Index)
                        //{
                        //    int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCatID"].Value;

                        //    if (id != 0)
                        //    {
                        //        string categoryName = await new ProductsBL().GetCategoryNameById(id);
                        //        guna2DataGridView1.Rows[e.RowIndex].Cells["dgvCategory"].Value = categoryName; // Gán giá trị hiển thị vào e.Value
                        //    }
                        //}
                        //else

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
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void guna2DataGridView1_CellClick_Print(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvPrintInvoice")
            {
                int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;
                var invoice = await new InvoiceBL().SaleIdGetInvoice(id);
                Invoice_Print invoice_Print = new Invoice_Print(invoice);
                invoice_Print.ShowDialog();
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
