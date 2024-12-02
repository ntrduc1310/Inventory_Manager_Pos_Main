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
    public partial class CustomerAdd : SampleAdd
    {
        public CustomerAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void CustomerAdd_Load(object sender, EventArgs e)
        {

        }

        //private void btn_Save_Click_2(object sender, EventArgs e)
        //{
        //    //if (MainClass.Valdation(this) == false)
        //    //{ 
        //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.Enums.MessageDialogButtons.OK;
        //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.Enums.MessageDialogIcon.WARNING;
        //    guna2MessageDialog1.Show = ("Please remove errors");
        //    //}
        //    else
        //    {
        //        string qry = "";

        //            if (id == 0)
        //        {
        //            qry = "insert into tbl_customer (cust_name, cust_contact, cust_email, cust_address, cust_status) values ('" + txt_Name.Text + "', '" + txt_Contact.Text + "', '" + txt_Email.Text + "', '" + txt_Address.Text + "', 1)";
        //        }
        //        else
        //        {
        //            qry = "update tbl_customer set cust_name = '" + txt_Name.Text + "', cust_contact = '" + txt_Contact.Text + "', cust_email = '" + txt_Email.Text + "', cust_address = '" + txt_Address.Text + "' where cust_id = " + id + "";
        //        }
        //    }
    }
}
