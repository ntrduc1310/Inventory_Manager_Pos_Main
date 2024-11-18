using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class SampleAdd : Form
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

       public virtual void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btn_save_Click(object sender, EventArgs e)
        {

        }
    }
}
