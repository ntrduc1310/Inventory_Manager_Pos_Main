using BL;
using DL;
using DTO;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
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
                    Application.Exit();
                }
                else
                {
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                }
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
