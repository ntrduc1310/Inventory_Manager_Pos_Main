using BL;
using DTO;
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

namespace PL
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Username_txb_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Login_btn_Click(object sender, EventArgs e)
        {
            
            string username = Username_txb.Text;
            string password = Password_txb.Text;
            Account acc = new Account(username, password);
            bool b = true;
            try
            {
                b = await new LoginBL().LoginAsync(acc);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("...." + ex.Message);

            }
            if (b)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("success");

            }
            else
            {
                DialogResult result = MessageBox.Show("Username or Password is wrong", "Error", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    Username_txb.Clear();
                    Password_txb.Clear();
                }
            }


        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void Sign_Up_Click(object sender, EventArgs e)
        {

        }
    }

}
