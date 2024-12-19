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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2Panel1.Size = new Size(1051, 208);
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // btnAdd1
            // 
            btnAdd1.DialogResult = DialogResult.None;
            btnAdd1.DisabledState.BorderColor = Color.DarkGray;
            btnAdd1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd1.Location = new Point(63, 123);
            btnAdd1.Margin = new Padding(4);
            btnAdd1.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtsearch.Size = new Size(416, 64);
            txtsearch.TextChanged += txtsearch_TextChanged_1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(63, 63);
            guna2HtmlLabel1.Margin = new Padding(5);
            guna2HtmlLabel1.Size = new Size(211, 52);
            guna2HtmlLabel1.Text = "Product List";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Location = new Point(578, 85);
            guna2HtmlLabel2.Margin = new Padding(2);
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(96, 71, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvSr, dgvid, dgvName, dgvcatID, dgvCategory, dgvBarcode, dgvCost, dgvSalePrice, dgvQuantityInStock, dgvDiscount, dgvSupplierID, dgvSupplier, dgvDescription, dgvImage, dgvImageShow, dgvCreateDate, dgvUpdateDate, dgvActive, dgvAllInformation, dgvEdit, dgvDel });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(63, 229);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            guna2DataGridView1.RowTemplate.Height = 35;
            guna2DataGridView1.ScrollBars = ScrollBars.Horizontal;
            guna2DataGridView1.Size = new Size(930, 393);
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
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
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
            dgvSr.FillWeight = 70F;
            dgvSr.Frozen = true;
            dgvSr.HeaderText = "Sr#";
            dgvSr.MinimumWidth = 70;
            dgvSr.Name = "dgvSr";
            dgvSr.ReadOnly = true;
            dgvSr.Width = 70;
            // 
            // dgvid
            // 
            dgvid.FillWeight = 70F;
            dgvid.HeaderText = "id";
            dgvid.MinimumWidth = 70;
            dgvid.Name = "dgvid";
            dgvid.ReadOnly = true;
            dgvid.Visible = false;
            dgvid.Width = 70;
            // 
            // dgvName
            // 
            dgvName.FillWeight = 70F;
            dgvName.Frozen = true;
            dgvName.HeaderText = "Name";
            dgvName.MinimumWidth = 100;
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
            dgvcatID.Width = 87;
            // 
            // dgvCategory
            // 
            dgvCategory.FillWeight = 70F;
            dgvCategory.Frozen = true;
            dgvCategory.HeaderText = "Category";
            dgvCategory.MinimumWidth = 120;
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dgvCategory.Width = 120;
            // 
            // dgvBarcode
            // 
            dgvBarcode.FillWeight = 70F;
            dgvBarcode.Frozen = true;
            dgvBarcode.HeaderText = "Barcode";
            dgvBarcode.MinimumWidth = 70;
            dgvBarcode.Name = "dgvBarcode";
            dgvBarcode.ReadOnly = true;
            dgvBarcode.Width = 91;
            // 
            // dgvCost
            // 
            dgvCost.FillWeight = 70F;
            dgvCost.Frozen = true;
            dgvCost.HeaderText = "Cost";
            dgvCost.MinimumWidth = 70;
            dgvCost.Name = "dgvCost";
            dgvCost.ReadOnly = true;
            dgvCost.Width = 70;
            // 
            // dgvSalePrice
            // 
            dgvSalePrice.FillWeight = 70F;
            dgvSalePrice.Frozen = true;
            dgvSalePrice.HeaderText = "SalePrice";
            dgvSalePrice.MinimumWidth = 70;
            dgvSalePrice.Name = "dgvSalePrice";
            dgvSalePrice.ReadOnly = true;
            dgvSalePrice.Width = 96;
            // 
            // dgvQuantityInStock
            // 
            dgvQuantityInStock.FillWeight = 40F;
            dgvQuantityInStock.HeaderText = "Quantity";
            dgvQuantityInStock.MinimumWidth = 40;
            dgvQuantityInStock.Name = "dgvQuantityInStock";
            dgvQuantityInStock.ReadOnly = true;
            dgvQuantityInStock.Width = 92;
            // 
            // dgvDiscount
            // 
            dgvDiscount.FillWeight = 70F;
            dgvDiscount.HeaderText = "Discount";
            dgvDiscount.MinimumWidth = 70;
            dgvDiscount.Name = "dgvDiscount";
            dgvDiscount.ReadOnly = true;
            dgvDiscount.Width = 94;
            // 
            // dgvSupplierID
            // 
            dgvSupplierID.HeaderText = "SupplierID";
            dgvSupplierID.MinimumWidth = 8;
            dgvSupplierID.Name = "dgvSupplierID";
            dgvSupplierID.ReadOnly = true;
            dgvSupplierID.Visible = false;
            dgvSupplierID.Width = 129;
            // 
            // dgvSupplier
            // 
            dgvSupplier.FillWeight = 70F;
            dgvSupplier.HeaderText = "Supplier";
            dgvSupplier.MinimumWidth = 70;
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.ReadOnly = true;
            dgvSupplier.Width = 91;
            // 
            // dgvDescription
            // 
            dgvDescription.FillWeight = 90F;
            dgvDescription.HeaderText = "Description";
            dgvDescription.MinimumWidth = 120;
            dgvDescription.Name = "dgvDescription";
            dgvDescription.ReadOnly = true;
            dgvDescription.Width = 120;
            // 
            // dgvImage
            // 
            dgvImage.HeaderText = "Image";
            dgvImage.MinimumWidth = 8;
            dgvImage.Name = "dgvImage";
            dgvImage.ReadOnly = true;
            dgvImage.Visible = false;
            dgvImage.Width = 96;
            // 
            // dgvImageShow
            // 
            dgvImageShow.HeaderText = "Image";
            dgvImageShow.Image = Properties.Resources.woman_bag;
            dgvImageShow.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvImageShow.MinimumWidth = 70;
            dgvImageShow.Name = "dgvImageShow";
            dgvImageShow.ReadOnly = true;
            dgvImageShow.Width = 70;
            // 
            // dgvCreateDate
            // 
            dgvCreateDate.HeaderText = "CreateDate";
            dgvCreateDate.MinimumWidth = 140;
            dgvCreateDate.Name = "dgvCreateDate";
            dgvCreateDate.ReadOnly = true;
            dgvCreateDate.Width = 140;
            // 
            // dgvUpdateDate
            // 
            dgvUpdateDate.HeaderText = "UpdateDate";
            dgvUpdateDate.MinimumWidth = 140;
            dgvUpdateDate.Name = "dgvUpdateDate";
            dgvUpdateDate.ReadOnly = true;
            dgvUpdateDate.Width = 140;
            // 
            // dgvActive
            // 
            dgvActive.HeaderText = "Active";
            dgvActive.MinimumWidth = 8;
            dgvActive.Name = "dgvActive";
            dgvActive.ReadOnly = true;
            dgvActive.Visible = false;
            dgvActive.Width = 94;
            // 
            // dgvAllInformation
            // 
            dgvAllInformation.HeaderText = "";
            dgvAllInformation.Image = Properties.Resources.z6133017756528_ce527a37a62d001048a21291b92bdd101;
            dgvAllInformation.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvAllInformation.MinimumWidth = 8;
            dgvAllInformation.Name = "dgvAllInformation";
            dgvAllInformation.ReadOnly = true;
            dgvAllInformation.Resizable = DataGridViewTriState.True;
            dgvAllInformation.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAllInformation.Width = 27;
            // 
            // dgvEdit
            // 
            dgvEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvEdit.FillWeight = 50F;
            dgvEdit.HeaderText = "";
            dgvEdit.Image = Properties.Resources.nib;
            dgvEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvEdit.MinimumWidth = 50;
            dgvEdit.Name = "dgvEdit";
            dgvEdit.ReadOnly = true;
            dgvEdit.Width = 70;
            // 
            // dgvDel
            // 
            dgvDel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDel.FillWeight = 50F;
            dgvDel.HeaderText = "";
            dgvDel.Image = Properties.Resources.delete;
            dgvDel.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvDel.MinimumWidth = 50;
            dgvDel.Name = "dgvDel";
            dgvDel.ReadOnly = true;
            dgvDel.Width = 70;
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
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
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
    }
}