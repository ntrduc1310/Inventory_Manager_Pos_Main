namespace PL.View
{
    partial class ProductView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            dgvSr = new DataGridViewTextBoxColumn();
            dgvid = new DataGridViewTextBoxColumn();
            dgvName = new DataGridViewTextBoxColumn();
            dgvcatID = new DataGridViewTextBoxColumn();
            dgvCategory = new DataGridViewTextBoxColumn();
            dgvBarcode = new DataGridViewTextBoxColumn();
            dgvCost = new DataGridViewTextBoxColumn();
            dgvSalePrice = new DataGridViewTextBoxColumn();
            dgvQuantityInStock = new DataGridViewTextBoxColumn();
            dgvDiscount = new DataGridViewTextBoxColumn();
            dgvSupplierID = new DataGridViewTextBoxColumn();
            dgvSupplier = new DataGridViewTextBoxColumn();
            dgvDescription = new DataGridViewTextBoxColumn();
            dgvImage = new DataGridViewTextBoxColumn();
            dgvImageShow = new DataGridViewImageColumn();
            dgvCreateDate = new DataGridViewTextBoxColumn();
            dgvUpdateDate = new DataGridViewTextBoxColumn();
            dgvActive = new DataGridViewTextBoxColumn();
            dgvAllInformation = new DataGridViewImageColumn();
            dgvEdit = new DataGridViewImageColumn();
            dgvDel = new DataGridViewImageColumn();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            usermanual = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usermanual).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(usermanual);
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.Controls.Add(guna2HtmlLabel3);
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Panel1.Size = new Size(1051, 208);
            guna2Panel1.Paint += guna2Panel1_Paint;
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel1, 0);
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel2, 0);
            guna2Panel1.Controls.SetChildIndex(btnAdd1, 0);
            guna2Panel1.Controls.SetChildIndex(txtsearch, 0);
            guna2Panel1.Controls.SetChildIndex(guna2HtmlLabel3, 0);
            guna2Panel1.Controls.SetChildIndex(guna2PictureBox1, 0);
            guna2Panel1.Controls.SetChildIndex(usermanual, 0);
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
            btnAdd1.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            txtsearch.PlaceholderText = "Nhập Vào Tìm Kiếm";
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtsearch.Size = new Size(416, 64);
            txtsearch.TextChanged += txtsearch_TextChanged_1;
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
            guna2HtmlLabel2.Margin = new Padding(2);
            guna2HtmlLabel2.Size = new Size(105, 33);
            guna2HtmlLabel2.Text = "Tìm Kiếm";
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2DataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(96, 71, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvSr, dgvid, dgvName, dgvcatID, dgvCategory, dgvBarcode, dgvCost, dgvSalePrice, dgvQuantityInStock, dgvDiscount, dgvSupplierID, dgvSupplier, dgvDescription, dgvImage, dgvImageShow, dgvCreateDate, dgvUpdateDate, dgvActive, dgvAllInformation, dgvEdit, dgvDel });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(63, 233);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            guna2DataGridView1.RowTemplate.Height = 35;
            guna2DataGridView1.ScrollBars = ScrollBars.Horizontal;
            guna2DataGridView1.Size = new Size(931, 393);
            guna2DataGridView1.TabIndex = 4;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 40;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 35;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick_1;
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // dgvSr
            // 
            dgvSr.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSr.FillWeight = 60F;
            dgvSr.HeaderText = "Sr#";
            dgvSr.MinimumWidth = 60;
            dgvSr.Name = "dgvSr";
            dgvSr.ReadOnly = true;
            dgvSr.Width = 60;
            // 
            // dgvid
            // 
            dgvid.FillWeight = 80F;
            dgvid.HeaderText = "id";
            dgvid.MinimumWidth = 80;
            dgvid.Name = "dgvid";
            dgvid.ReadOnly = true;
            dgvid.Visible = false;
            // 
            // dgvName
            // 
            dgvName.FillWeight = 140F;
            dgvName.HeaderText = "Tên Sản Phẩm";
            dgvName.MinimumWidth = 140;
            dgvName.Name = "dgvName";
            dgvName.ReadOnly = true;
            // 
            // dgvcatID
            // 
            dgvcatID.FillWeight = 70F;
            dgvcatID.HeaderText = "catID";
            dgvcatID.MinimumWidth = 70;
            dgvcatID.Name = "dgvcatID";
            dgvcatID.ReadOnly = true;
            dgvcatID.Visible = false;
            // 
            // dgvCategory
            // 
            dgvCategory.HeaderText = "Loại";
            dgvCategory.MinimumWidth = 150;
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            // 
            // dgvBarcode
            // 
            dgvBarcode.FillWeight = 120F;
            dgvBarcode.HeaderText = "Barcode";
            dgvBarcode.MinimumWidth = 120;
            dgvBarcode.Name = "dgvBarcode";
            dgvBarcode.ReadOnly = true;
            // 
            // dgvCost
            // 
            dgvCost.HeaderText = "Giá";
            dgvCost.MinimumWidth = 100;
            dgvCost.Name = "dgvCost";
            dgvCost.ReadOnly = true;
            dgvCost.Visible = false;
            // 
            // dgvSalePrice
            // 
            dgvSalePrice.HeaderText = "Giá Bán";
            dgvSalePrice.MinimumWidth = 100;
            dgvSalePrice.Name = "dgvSalePrice";
            dgvSalePrice.ReadOnly = true;
            dgvSalePrice.Visible = false;
            // 
            // dgvQuantityInStock
            // 
            dgvQuantityInStock.HeaderText = "Số Lượng";
            dgvQuantityInStock.MinimumWidth = 100;
            dgvQuantityInStock.Name = "dgvQuantityInStock";
            dgvQuantityInStock.ReadOnly = true;
            // 
            // dgvDiscount
            // 
            dgvDiscount.HeaderText = "Giảm Giá ";
            dgvDiscount.MinimumWidth = 100;
            dgvDiscount.Name = "dgvDiscount";
            dgvDiscount.ReadOnly = true;
            dgvDiscount.Visible = false;
            // 
            // dgvSupplierID
            // 
            dgvSupplierID.HeaderText = "SupplierID";
            dgvSupplierID.MinimumWidth = 8;
            dgvSupplierID.Name = "dgvSupplierID";
            dgvSupplierID.ReadOnly = true;
            dgvSupplierID.Visible = false;
            // 
            // dgvSupplier
            // 
            dgvSupplier.FillWeight = 120F;
            dgvSupplier.HeaderText = "Supplier";
            dgvSupplier.MinimumWidth = 120;
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.ReadOnly = true;
            // 
            // dgvDescription
            // 
            dgvDescription.FillWeight = 110F;
            dgvDescription.HeaderText = "Description";
            dgvDescription.MinimumWidth = 110;
            dgvDescription.Name = "dgvDescription";
            dgvDescription.ReadOnly = true;
            dgvDescription.Visible = false;
            // 
            // dgvImage
            // 
            dgvImage.HeaderText = "Image";
            dgvImage.MinimumWidth = 100;
            dgvImage.Name = "dgvImage";
            dgvImage.ReadOnly = true;
            dgvImage.Visible = false;
            // 
            // dgvImageShow
            // 
            dgvImageShow.FillWeight = 120F;
            dgvImageShow.HeaderText = "Hình SP";
            dgvImageShow.Image = Properties.Resources.woman_bag;
            dgvImageShow.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvImageShow.MinimumWidth = 120;
            dgvImageShow.Name = "dgvImageShow";
            dgvImageShow.ReadOnly = true;
            // 
            // dgvCreateDate
            // 
            dgvCreateDate.HeaderText = "CreateDate";
            dgvCreateDate.MinimumWidth = 120;
            dgvCreateDate.Name = "dgvCreateDate";
            dgvCreateDate.ReadOnly = true;
            dgvCreateDate.Visible = false;
            // 
            // dgvUpdateDate
            // 
            dgvUpdateDate.HeaderText = "UpdateDate";
            dgvUpdateDate.MinimumWidth = 140;
            dgvUpdateDate.Name = "dgvUpdateDate";
            dgvUpdateDate.ReadOnly = true;
            dgvUpdateDate.Visible = false;
            // 
            // dgvActive
            // 
            dgvActive.HeaderText = "Active";
            dgvActive.MinimumWidth = 100;
            dgvActive.Name = "dgvActive";
            dgvActive.ReadOnly = true;
            dgvActive.Visible = false;
            // 
            // dgvAllInformation
            // 
            dgvAllInformation.HeaderText = "";
            dgvAllInformation.Image = (Image)resources.GetObject("dgvAllInformation.Image");
            dgvAllInformation.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvAllInformation.MinimumWidth = 100;
            dgvAllInformation.Name = "dgvAllInformation";
            dgvAllInformation.ReadOnly = true;
            dgvAllInformation.Resizable = DataGridViewTriState.True;
            dgvAllInformation.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dgvEdit
            // 
            dgvEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEdit.HeaderText = "";
            dgvEdit.Image = Properties.Resources.nib;
            dgvEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvEdit.MinimumWidth = 100;
            dgvEdit.Name = "dgvEdit";
            dgvEdit.ReadOnly = true;
            dgvEdit.Width = 125;
            // 
            // dgvDel
            // 
            dgvDel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDel.HeaderText = "";
            dgvDel.Image = Properties.Resources.delete;
            dgvDel.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvDel.MinimumWidth = 100;
            dgvDel.Name = "dgvDel";
            dgvDel.ReadOnly = true;
            dgvDel.Width = 125;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(150, 66);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(175, 52);
            guna2HtmlLabel3.TabIndex = 6;
            guna2HtmlLabel3.Text = "Sản Phẩm";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(60, 21);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(96, 94);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 7;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            // 
            // usermanual
            // 
            usermanual.CustomizableEdges = customizableEdges1;
            usermanual.Image = (Image)resources.GetObject("usermanual.Image");
            usermanual.ImageRotate = 0F;
            usermanual.Location = new Point(1003, 132);
            usermanual.Name = "usermanual";
            usermanual.ShadowDecoration.CustomizableEdges = customizableEdges2;
            usermanual.Size = new Size(48, 46);
            usermanual.SizeMode = PictureBoxSizeMode.StretchImage;
            usermanual.TabIndex = 9;
            usermanual.TabStop = false;
            usermanual.Click += usermanual_Click;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 653);
            Controls.Add(guna2DataGridView1);
            Name = "ProductView";
            Text = "ProductView";
            Load += ProductView_Load;
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2DataGridView1, 0);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)usermanual).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private DataGridViewTextBoxColumn dgvSr;
        private DataGridViewTextBoxColumn dgvid;
        private DataGridViewTextBoxColumn dgvName;
        private DataGridViewTextBoxColumn dgvcatID;
        private DataGridViewTextBoxColumn dgvCategory;
        private DataGridViewTextBoxColumn dgvBarcode;
        private DataGridViewTextBoxColumn dgvCost;
        private DataGridViewTextBoxColumn dgvSalePrice;
        private DataGridViewTextBoxColumn dgvQuantityInStock;
        private DataGridViewTextBoxColumn dgvDiscount;
        private DataGridViewTextBoxColumn dgvSupplierID;
        private DataGridViewTextBoxColumn dgvSupplier;
        private DataGridViewTextBoxColumn dgvDescription;
        private DataGridViewTextBoxColumn dgvImage;
        private DataGridViewImageColumn dgvImageShow;
        private DataGridViewTextBoxColumn dgvCreateDate;
        private DataGridViewTextBoxColumn dgvUpdateDate;
        private DataGridViewTextBoxColumn dgvActive;
        private DataGridViewImageColumn dgvAllInformation;
        private DataGridViewImageColumn dgvEdit;
        private DataGridViewImageColumn dgvDel;
        private Guna.UI2.WinForms.Guna2PictureBox usermanual;
    }
}