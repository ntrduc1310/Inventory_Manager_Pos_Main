using Guna.UI2.WinForms;
using PL.Edit;
using PL.View;
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

<<<<<<< HEAD
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Kích hoạt DoubleBuffered cho toàn bộ form
            this.DoubleBuffered = true;
            EnableDoubleBufferingForControls(this);
        }

        private void EnableDoubleBufferingForControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, c, new object[] { true });

                // Đệ quy với các control con
                if (c.Controls.Count > 0)
                    EnableDoubleBufferingForControls(c);
            }
        }

=======
>>>>>>> 26e82526e934b3b603e0db291b0cf254dce06e28
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void LoadFormIntoPanel(Form form, Panel panel)
        {
            panel.Visible = false;
            // Xóa tất cả control đang hiển thị trong panel
            panel.Controls.Clear();

            // Cấu hình form con
            form.TopLevel = false; // Không phải form độc lập
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            form.Dock = DockStyle.Fill; // Chiếm toàn bộ panel

            // Thêm form vào panel
            panel.Controls.Add(form);
            panel.Tag = form;

            // Hiển thị form
            form.BringToFront();
            form.Show();
            panel.Visible = true;
        }

        public void LoadFormIntoPanelCenter(Form form)
        {
            CenterPanel.Visible = false;
            // Xóa tất cả control đang hiển thị trong panel
            CenterPanel.Controls.Clear();

            // Debug: Kiểm tra CenterPanel trước khi thêm form vào
            Console.WriteLine("CenterPanel size: " + CenterPanel.Size.ToString());

            // Cấu hình form con
            form.TopLevel = false; // Không phải form độc lập
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            form.Dock = DockStyle.Fill; // Chiếm toàn bộ panel

            // Thêm form vào panel
            CenterPanel.Controls.Add(form);
            CenterPanel.Tag = form;

            // Debug: Kiểm tra sau khi thêm form vào
            Console.WriteLine("Form added: " + form.Name);

            // Hiển thị form
            form.BringToFront();
            form.Show();
            CenterPanel.Visible = true;
        }


        private void btn_Users_Click(object sender, EventArgs e)
        {
            UserView userView = new UserView();
            LoadFormIntoPanel(userView, CenterPanel);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {
            CustomerView customerView = new CustomerView();
            LoadFormIntoPanel(customerView, CenterPanel);

        }

<<<<<<< HEAD
        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

=======
        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductView productView = new ProductView();
            LoadFormIntoPanel(productView, CenterPanel);
>>>>>>> 26e82526e934b3b603e0db291b0cf254dce06e28
        }
    }
}
