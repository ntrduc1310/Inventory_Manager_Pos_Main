using Guna.UI2.WinForms;
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
    public partial class invoice : Form
    {
        public invoice()
        {
            InitializeComponent();
            //this.Load += loadInvoiceToGridView;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private async void loadInvoiceToGridView(object sender, EventArgs e)
        //{
        //    guna2DataGridView2.AutoGenerateColumns = false;
        //    guna2DataGridView2.Columns["dgvId"].DataPropertyName = "SaleID";
        //    guna2DataGridView2.Columns["dgvDate"].DataPropertyName = "CreatedAt";
        //    guna2DataGridView2.Columns["dgvCustomerID"].DataPropertyName = "CustomerID";
        //    guna2DataGridView2.Columns["dgvTTAmount"].DataPropertyName = "TotalAmount";
        //    guna2DataGridView2.Columns["dgvCreatedBy"].DataPropertyName = "CreatedBy";
        //    guna2DataGridView2.Columns["dgvStatus"].DataPropertyName = "Status";
        //    guna2DataGridView2.Columns["dgvProName"].DataPropertyName = "ProductNameList";
        //    guna2DataGridView2.Columns["dgvQtt"].DataPropertyName = "ProductQuantityList";
        //    guna2DataGridView2.Columns["dgvPrice"].DataPropertyName = "ProductPriceList";
        //    var sale = await new BL.Sale.SaleBL().LoadSalesInvoice();

        //    guna2DataGridView2.DataSource = sale;
        //    guna2DataGridView2.Refresh();

        //}

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
    }
}
