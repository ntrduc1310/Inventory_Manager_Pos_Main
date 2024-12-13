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
    public partial class PurchaseView : SampleView
    {
        public PurchaseView()
        {
            InitializeComponent();
        }

        private void PurchaseView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            PurchaseAdd purchaseAdd = new PurchaseAdd();
            purchaseAdd.ShowDialog();
        }
    }
}
