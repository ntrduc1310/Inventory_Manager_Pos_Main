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

namespace PL
{
    public partial class Main : Form
    {
        static Main _obj;
       public Guna.UI2.WinForms.Guna2HtmlLabel username_lbl;
        public Main()
        {
            InitializeComponent();
            username_lbl = guna2HtmlLabel1;
        }
        public static Main Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Main();
                }
                return _obj;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();
            _obj.Visible = false;
        }
        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Users_Click(object sender, EventArgs e)
        {
            AddControls(new View.UserView());
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
