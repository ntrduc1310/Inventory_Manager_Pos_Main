using BL.Customer;
using BL.ProductsBL;
using BL.Purchase;
using DTO.Purchase;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PL.View
{
    public partial class PurchaseView : SampleView
    {
        public PurchaseView()
        {
            InitializeComponent();
            this.Load += loadToPurchaseView;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            //guna2DataGridView1.CellClick += DgvCellClickImageColumn;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Sr ;
            txtsearch.TextChanged += txtsearch_TextChanged_1;
            ConfigureDataGridView();



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
            PurchaseAddProduct purchaseAdd = new PurchaseAddProduct();
            purchaseAdd.ShowDialog();
            if (purchaseAdd.DialogResult == DialogResult.OK)
                loadtoPurchaseViewFunction();
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
                    string details = await new PurchaseBL().LoadPurchaseDetailsByIdAsString(id);

                    MessageBox.Show(details);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CellClick: {ex.Message}");
            }
        }

        private async void loadtoPurchaseViewFunction()
        {
            try
            {
                guna2DataGridView1.AutoGenerateColumns = false;

                // Cấu hình DataPropertyName
                guna2DataGridView1.Columns["dgvid"].DataPropertyName = "PurchaseID";
                guna2DataGridView1.Columns["dgvDate"].DataPropertyName = "CreatedAt";
                guna2DataGridView1.Columns["dgvSupID"].DataPropertyName = "SupplierID";
                guna2DataGridView1.Columns["dgvAmount"].DataPropertyName = "TotalAmount";
                guna2DataGridView1.Columns["dgvCreatedBy"].DataPropertyName = "CreatedBy";
                // Load dữ liệu
                var data = await new PurchaseBL().LoadPurchase();
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

                        if (e.ColumnIndex == guna2DataGridView1.Columns["dgvSupplier"].Index)
                        {

                            int cellValue = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvSupID"].Value;
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
                MessageBox.Show($"Error: {ex.Message}");
                throw ex;
            }
        }

        private async void loadToPurchaseView(object sender, EventArgs e)
        {
            loadtoPurchaseViewFunction();
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

    

        //private async void DgvCellClickImageColumn(object sender, DataGridViewCellEventArgs e)
        //{


        //}
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    var filteredData = await new PurchaseBL().searchPurchase(searchText);
                    guna2DataGridView1.DataSource = filteredData;
                }
                else
                {
                    loadtoPurchaseViewFunction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvSr"].Index)
                {
                    // Gán số thứ tự cho cột "#Sr"
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CellFormatting error: {ex.Message}");
            }
        }
    }
}
