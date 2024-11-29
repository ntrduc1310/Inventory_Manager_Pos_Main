using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace PL.Model
{
    public partial class UserAdd : SampleAdd
    {
        public UserAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btn_Save_Click_1(object sender, EventArgs e)
        {
               
        }
        private void UserAdd_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {

        }
        public string filePath = "";
        Byte[] imageByteArray;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images(*.jpg, *.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtPic.Image = new Bitmap(filePath);

            }
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
