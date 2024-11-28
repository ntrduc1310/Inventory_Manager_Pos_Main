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
            if (MainClass.Validation(this) == false)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Please remove error");
                return;
            }
            else
            {
                string qry = "";
                if (id ==0)
                {
                    qry = @"Insert into Users values(@name,@username, @pass, @phone, @image)";
                }
                else
                {
                    qry = @"Update Users set uName = @name
                            uUsername = @username,
                            uPass = @pass,
                            uPhone = @phone,
                            uImage = @image
                            where uID = @id";
                }

                Image temp = new Bitmap(txtPic.Image);
                MemoryStream ms = new MemoryStream();
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();


                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txt_Name.Text);
                ht.Add("@username", txt_UserName.Text);
                ht.Add("@pass", txt_Password.Text);
                ht.Add("@phone", txt_Phone.Text);
                ht.Add("@image", imageByteArray);

                if (MainClass.SQl(qry, ht)>0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Show("Data Saved Successfully");
                    id = 0;
                    txt_Name.Text = "";
                    txt_UserName.Text = "";
                    txt_Password.Text = "";
                    txt_Phone.Text = "";
                    txtPic.Image = PL.Properties.Resources.userPic;
                    txt_Name.Focus();

                }
                    




            }
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

        
    }
}
