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
    public partial class UserView : SampleView
    {
        private object dgvUsername;

        public UserView()
        {
            InitializeComponent();
        }

        private void UserView_Load(object sender, EventArgs e)
        {

        }

        public override void btnAdd1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new UserAdd());
        }

        public override void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            //Load data from database
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvUsername);
            lb.Items.Add(dgvpassword);
            lb.Items.Add(dgvPhone);
            
            string qry = @"SELECT UserID, uName, uUsername, uPassword, uPhone, from Users
                        where uName like '%" + txtsearch.Text + " %' other by userID desc" ;
            MainClass.LoadData(qry,guna2DataGridView1,lb);
        }
    }
}
