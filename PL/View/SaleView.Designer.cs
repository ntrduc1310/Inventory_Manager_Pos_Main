namespace PL.View
{
    partial class SaleView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            dgvSr = new DataGridViewTextBoxColumn();
            dgvid = new DataGridViewTextBoxColumn();
            dgvDate = new DataGridViewTextBoxColumn();
            dgvCustomerID = new DataGridViewTextBoxColumn();
            dgvCustomer = new DataGridViewTextBoxColumn();
            dgvAmount = new DataGridViewTextBoxColumn();
            dgvCreatedBy = new DataGridViewTextBoxColumn();
            dgvAllInformation = new DataGridViewTextBoxColumn();
            dgvPrintInvoice = new DataGridViewImageColumn();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.Controls.Add(guna2HtmlLabel3);
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2Panel1.Size = new Size(1051, 208);
            guna2Panel1.Paint += guna2Panel1_Paint;
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel1, 0);
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel2, 0);
            guna2Panel1.Controls.SetChildIndex(btnAdd1, 0);
            guna2Panel1.Controls.SetChildIndex(txtsearch, 0);
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel3, 0);
            guna2Panel1.Controls.SetChildIndex(guna2PictureBox1, 0);
            // 
            // btnAdd1
            // 
            btnAdd1.DialogResult = DialogResult.None;
            btnAdd1.DisabledState.BorderColor = Color.DarkGray;
            btnAdd1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd1.Location = new Point(63, 123);
            btnAdd1.Margin = new Padding(4);
            btnAdd1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAdd1.Text = "Thêm Mới";
            btnAdd1.Click += btnAdd1_Click_1;
            // 
            // txtsearch
            // 
            txtsearch.BorderRadius = 31;
            txtsearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtsearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtsearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.Location = new Point(578, 123);
            txtsearch.Margin = new Padding(4, 5, 4, 5);
            txtsearch.PlaceholderText = "Nhập Mã Đơn Để Tìm Kiếm";
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtsearch.Size = new Size(416, 64);
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(150, 21);
            guna2HtmlLabel1.Margin = new Padding(5);
            guna2HtmlLabel1.Size = new Size(185, 52);
            guna2HtmlLabel1.Text = "Danh Sách";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Location = new Point(578, 85);
            guna2HtmlLabel2.Margin = new Padding(5);
            guna2HtmlLabel2.Size = new Size(105, 33);
            guna2HtmlLabel2.Text = "Tìm Kiếm";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(150, 64);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(172, 52);
            guna2HtmlLabel3.TabIndex = 6;
            guna2HtmlLabel3.Text = "Bán Hàng";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(60, 21);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(96, 94);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 7;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(96, 71, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvSr, dgvid, dgvDate, dgvCustomerID, dgvCustomer, dgvAmount, dgvCreatedBy, dgvAllInformation, dgvPrintInvoice });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(60, 244);
            guna2DataGridView1.Margin = new Padding(2);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 62;
            guna2DataGridView1.RowTemplate.Height = 33;
            guna2DataGridView1.Size = new Size(959, 404);
            guna2DataGridView1.TabIndex = 1;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 40;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 33;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick_2;
            // 
            // dgvSr
            // 
            dgvSr.FillWeight = 40F;
            dgvSr.HeaderText = "Sr";
            dgvSr.MinimumWidth = 50;
            dgvSr.Name = "dgvSr";
            dgvSr.ReadOnly = true;
            // 
            // dgvid
            // 
            dgvid.FillWeight = 101.980057F;
            dgvid.HeaderText = "Mã Đơn";
            dgvid.MinimumWidth = 100;
            dgvid.Name = "dgvid";
            dgvid.ReadOnly = true;
            // 
            // dgvDate
            // 
            dgvDate.FillWeight = 120F;
            dgvDate.HeaderText = "Ngày";
            dgvDate.MinimumWidth = 120;
            dgvDate.Name = "dgvDate";
            dgvDate.ReadOnly = true;
            // 
            // dgvCustomerID
            // 
            dgvCustomerID.HeaderText = "IdKhachHang";
            dgvCustomerID.MinimumWidth = 100;
            dgvCustomerID.Name = "dgvCustomerID";
            dgvCustomerID.ReadOnly = true;
            dgvCustomerID.Visible = false;
            // 
            // dgvCustomer
            // 
            dgvCustomer.FillWeight = 140F;
            dgvCustomer.HeaderText = "Khách Hàng";
            dgvCustomer.MinimumWidth = 140;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.ReadOnly = true;
            // 
            // dgvAmount
            // 
            dgvAmount.FillWeight = 140F;
            dgvAmount.HeaderText = "Tổng Tiền";
            dgvAmount.MinimumWidth = 140;
            dgvAmount.Name = "dgvAmount";
            dgvAmount.ReadOnly = true;
            // 
            // dgvCreatedBy
            // 
            dgvCreatedBy.FillWeight = 120F;
            dgvCreatedBy.HeaderText = "Người Bán";
            dgvCreatedBy.MinimumWidth = 120;
            dgvCreatedBy.Name = "dgvCreatedBy";
            dgvCreatedBy.ReadOnly = true;
            // 
            // dgvAllInformation
            // 
            dgvAllInformation.FillWeight = 101.980057F;
            dgvAllInformation.HeaderText = "";
            dgvAllInformation.MinimumWidth = 8;
            dgvAllInformation.Name = "dgvAllInformation";
            dgvAllInformation.ReadOnly = true;
            // 
            // dgvPrintInvoice
            // 
            dgvPrintInvoice.FillWeight = 90F;
            dgvPrintInvoice.HeaderText = "In";
            dgvPrintInvoice.Image = Properties.Resources.icons8_print_50;
            dgvPrintInvoice.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvPrintInvoice.MinimumWidth = 90;
            dgvPrintInvoice.Name = "dgvPrintInvoice";
            dgvPrintInvoice.ReadOnly = true;
            dgvPrintInvoice.Resizable = DataGridViewTriState.True;
            dgvPrintInvoice.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // SaleView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 653);
            Controls.Add(guna2DataGridView1);
            Name = "SaleView";
            Text = "SaleView";
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2DataGridView1, 0);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private DataGridViewTextBoxColumn dgvSr;
        private DataGridViewTextBoxColumn dgvid;
        private DataGridViewTextBoxColumn dgvDate;
        private DataGridViewTextBoxColumn dgvCustomerID;
        private DataGridViewTextBoxColumn dgvCustomer;
        private DataGridViewTextBoxColumn dgvAmount;
        private DataGridViewTextBoxColumn dgvCreatedBy;
        private DataGridViewTextBoxColumn dgvAllInformation;
        private DataGridViewImageColumn dgvPrintInvoice;
    }
}