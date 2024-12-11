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
    public partial class SaleAdd : Form
    {
        public SaleAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void SaleAdd_Load(object sender, EventArgs e)
        {

        }

        private void cb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
