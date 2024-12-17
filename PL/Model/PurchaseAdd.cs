using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Model
{
    public partial class PurchaseAdd : SampleAdd
    {
        public PurchaseAdd()
        {
            InitializeComponent();
        }

        private void PurchaseAdd_Load(object sender, EventArgs e)
        {
            //string qry = "Select proID 'id', pName 'name' from Product";
            //string qry2 = "Select proID 'id', supName 'name' from Supplier";
        }

        //private void cb_Product_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cb_Product.SelectedIndex != -1)
        //    {
        //        GetDetails();
        //    }
        //}
        private void GetDetails()
        {
            //string qry = "Select * from Product where proID = " + Convert.ToString(cb_Product.SelectedValue) + "";
            //SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //txtCost.Text = dt.Rows[0]["pCost"].ToString();
        }


      



        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
