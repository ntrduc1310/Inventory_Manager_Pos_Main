using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class UserView : SampleView
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void UserView_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public override void btnAdd1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.UserAdd());
            LoadData();
        }

        public override void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

       

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvUsername);
            lb.Items.Add(dgvPass);
            lb.Items.Add(dgvPhone);

            string qry = @"Select UserID, uName, uUserName, uPass, uPhone from USERS
                Where uName  like '%" + txtsearch.Text + "%' order by userID desc";

            MainClass.LoadData(qry,guna2DataGridView1,lb);

        }
    }
}
