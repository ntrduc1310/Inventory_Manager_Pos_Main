using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PL
{
    public partial class Login : Form
    {
        public SignUp registerForm;
        public Login()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2vSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_label_Click(object sender, EventArgs e)
        {
            SignUp registerForm = new SignUp();
            registerForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            registerForm.Show();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            //chứng tới nữa 
            this.Close();
        }

        private void Username_txb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
