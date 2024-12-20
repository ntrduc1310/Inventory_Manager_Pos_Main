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
            guna2DataGridView1.CellClick += guna2DataGridView_CellClick_Status;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Status;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting_Sr;




        }

        private void PurchaseView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            SaleAddProduct saleAddProduct = new SaleAddProduct();
            saleAddProduct.ShowDialog();
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

        private async void loadToSaleView(object sender, EventArgs e)
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
                guna2DataGridView1.Columns["dgvStatus"].DataPropertyName = "Status";

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

        private async void guna2DataGridView1_CellFormatting_Status(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu là cột "dgvAccepted" hoặc "dgvDontAccepted"
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvAccepted" ||
                guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDontAccepted")
            {
                // Lấy trạng thái từ cột trạng thái
                string status = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvStatus"].Value?.ToString();

                // Kiểm tra trạng thái
                if (status == "Hoàn thành")
                {
                    // Gán hình ảnh "không chọn được"
                    e.Value = Image.FromFile("D:\\LapTrinhCoSoDuLieu\\Inventory_Manager_Pos\\Inventory_Manager_Pos\\PL\\Resources\\icons8-select-none-50.png");

                }
            }
        }

        private async void guna2DataGridView_CellClick_Status(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu là cột "dgvAccepted" hoặc "dgvDontAccepted"
            if (e.RowIndex >= 0 && (guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvAccepted" ||
                guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDontAccepted"))
            {
                // Lấy trạng thái từ cột trạng thái
                string status = guna2DataGridView1.Rows[e.RowIndex].Cells["dgvStatus"].Value?.ToString();

                // Ngăn click nếu trạng thái là "Hoàn thành" hoặc "Đã hủy"
                if (status == "Hoàn thành")
                {
                    return; // Không thực hiện thêm hành động nào
                }
                else
                {
                    if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvAccepted")
                    {
                        var resultAccepted = MessageBox.Show("Bạn có chắc chắn đã nhận hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultAccepted == DialogResult.Yes)
                        {
                            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvAccepted"].Index)
                            {
                                int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;
                                bool updateStatus = await new SaleBL().updateStatus("Hoàn thành", id);
                                if (updateStatus)
                                {
                                    SaleView saleView = new SaleView();
                                    Main.Instance.LoadFormIntoPanelCenter(saleView);
                                }
                            }
                        }


                    }
                    if (e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "dgvDontAccepted")
                    {
                        var resultDontAccepted = MessageBox.Show("Bạn có chắc chắn chưa nhận hàng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultDontAccepted == DialogResult.Yes)
                        {
                            if (e.ColumnIndex == guna2DataGridView1.Columns["dgvDontAccepted"].Index)
                            {
                                int id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value;
                                bool deletePurchase = await new DL.Purchase.PurchaseDL().DeletePurchase(id);
                                if (deletePurchase)
                                {
                                    SaleView saleView = new SaleView();
                                    Main.Instance.LoadFormIntoPanelCenter(saleView);
                                }
                            }
                        }

                    }
                }

            }

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
