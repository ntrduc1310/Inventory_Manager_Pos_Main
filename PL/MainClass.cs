using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
    

namespace PL
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source=nhannt\\mssqlserver02;Initial Catalog=POS and Inventory System;Integrated Security=True;Encrypt=False; User ID=sa; Password =123;";
        public static SqlConnection con = new SqlConnection(con_string);

        //Methord to check user validation 

        public static bool IsValidUser(string Username, string Password, byte[] imageArray)
        {
            bool isValid = false;

            string qry = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                Username = dt.Rows[0]["uName"].ToString();

                Byte[] retrievedImageArray = (Byte[])dt.Rows[0]["uImage"];
                byte[] imageByteArray = retrievedImageArray;
                IMG = Image.FromStream(new MemoryStream(retrievedImageArray));

            }

            return isValid;
        }

        public static void StopBuffering(Panel ctr, bool doubleBuffer)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance |
                    BindingFlags.NonPublic, null, ctr, new object[] { doubleBuffer });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Create property for username 

        public static string Username;
        private static SqlCommand cmd;

        public static string USERNAME
        {
            get { return Username; }
            private set { Username = value; }
        }
        public static string img;
        public static System.Drawing.Image IMG { get; private set; }


        //Method for curd operation

        public static int SQl(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }


        // For Loading data from database
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            // Serial no in gridview
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                SqlCommand cod = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }
                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        //for blur screen

        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.50;
                Background.BackColor = Color.Black;
                Background.Size = Main.Instance.Size;
                Background.Location = Main.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
        //
        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cnd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cnd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }

    }
}

