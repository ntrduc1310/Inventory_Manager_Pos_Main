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
            dgvEdit = new DataGridViewImageColumn();
            dgvDel = new DataGridViewImageColumn();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Margin = new Padding(5, 5, 5, 5);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2Panel1.Size = new Size(1314, 260);
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // btnAdd1
            // 
            btnAdd1.DialogResult = DialogResult.None;
            btnAdd1.DisabledState.BorderColor = Color.DarkGray;
            btnAdd1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd1.Location = new Point(79, 155);
            btnAdd1.Margin = new Padding(5, 5, 5, 5);
            btnAdd1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd1.Click += btnAdd1_Click_1;
            // 
            // txtsearch
            // 
            txtsearch.BorderRadius = 39;
            txtsearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtsearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtsearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.Location = new Point(722, 154);
            txtsearch.Margin = new Padding(5, 6, 5, 6);
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtsearch.Size = new Size(520, 80);
            txtsearch.TextChanged += txtsearch_TextChanged_1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(79, 72);
            guna2HtmlLabel1.Margin = new Padding(6, 6, 6, 6);
            guna2HtmlLabel1.Size = new Size(251, 62);
            guna2HtmlLabel1.Text = "Product List";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Location = new Point(722, 106);
            guna2HtmlLabel2.Margin = new Padding(2);
            guna2HtmlLabel2.Size = new Size(90, 40);
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvSr, dgvid, dgvName, dgvcatID, dgvCategory, dgvBarcode, dgvCost, dgvSalePrice, dgvQuantityInStock, dgvDiscount, dgvSupplierID, dgvSupplier, dgvDescription, dgvImage, dgvImageShow, dgvCreateDate, dgvUpdateDate, dgvActive, dgvEdit, dgvDel });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(79, 286);
            guna2DataGridView1.Margin = new Padding(4, 4, 4, 4);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 100;
            guna2DataGridView1.RowTemplate.Height = 35;
            guna2DataGridView1.ScrollBars = ScrollBars.Horizontal;
            guna2DataGridView1.Size = new Size(1162, 491);
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
            dgvName.MinimumWidth = 70;
            dgvName.Name = "dgvName";
            dgvName.ReadOnly = true;
            dgvName.Width = 93;
            // 
            // dgvcatID
            // 
            dgvcatID.FillWeight = 70F;
            dgvcatID.HeaderText = "catID";
            dgvcatID.MinimumWidth = 70;
            dgvcatID.Name = "dgvcatID";
            dgvcatID.ReadOnly = true;
            dgvcatID.Visible = false;
            dgvcatID.Width = 71;
            // 
            // dgvCategory
            // 
            dgvCategory.FillWeight = 70F;
            dgvCategory.Frozen = true;
            dgvCategory.HeaderText = "Category";
            dgvCategory.MinimumWidth = 70;
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dgvCategory.Width = 118;
            // 
            // dgvBarcode
            // 
            dgvBarcode.FillWeight = 70F;
            dgvBarcode.Frozen = true;
            dgvBarcode.HeaderText = "Barcode";
            dgvBarcode.MinimumWidth = 70;
            dgvBarcode.Name = "dgvBarcode";
            dgvBarcode.ReadOnly = true;
            dgvBarcode.Width = 110;
            // 
            // dgvCost
            // 
            dgvCost.FillWeight = 70F;
            dgvCost.Frozen = true;
            dgvCost.HeaderText = "Cost";
            dgvCost.MinimumWidth = 70;
            dgvCost.Name = "dgvCost";
            dgvCost.ReadOnly = true;
            dgvCost.Width = 82;
            // 
            // dgvSalePrice
            // 
            dgvSalePrice.FillWeight = 70F;
            dgvSalePrice.Frozen = true;
            dgvSalePrice.HeaderText = "SalePrice";
            dgvSalePrice.MinimumWidth = 70;
            dgvSalePrice.Name = "dgvSalePrice";
            dgvSalePrice.ReadOnly = true;
            dgvSalePrice.Width = 115;
            // 
            // dgvQuantityInStock
            // 
            dgvQuantityInStock.FillWeight = 70F;
            dgvQuantityInStock.HeaderText = "Quantity";
            dgvQuantityInStock.MinimumWidth = 70;
            dgvQuantityInStock.Name = "dgvQuantityInStock";
            dgvQuantityInStock.ReadOnly = true;
            dgvQuantityInStock.Width = 114;
            // 
            // dgvDiscount
            // 
            dgvDiscount.FillWeight = 70F;
            dgvDiscount.HeaderText = "Discount";
            dgvDiscount.MinimumWidth = 70;
            dgvDiscount.Name = "dgvDiscount";
            dgvDiscount.ReadOnly = true;
            dgvDiscount.Width = 116;
            // 
            // dgvSupplierID
            // 
            dgvSupplierID.HeaderText = "SupplierID";
            dgvSupplierID.MinimumWidth = 8;
            dgvSupplierID.Name = "dgvSupplierID";
            dgvSupplierID.ReadOnly = true;
            dgvSupplierID.Visible = false;
            dgvSupplierID.Width = 106;
            // 
            // dgvSupplier
            // 
            dgvSupplier.FillWeight = 70F;
            dgvSupplier.HeaderText = "Supplier";
            dgvSupplier.MinimumWidth = 70;
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.ReadOnly = true;
            dgvSupplier.Width = 111;
            // 
            // dgvDescription
            // 
            dgvDescription.FillWeight = 70F;
            dgvDescription.HeaderText = "Description";
            dgvDescription.MinimumWidth = 70;
            dgvDescription.Name = "dgvDescription";
            dgvDescription.ReadOnly = true;
            dgvDescription.Width = 136;
            // 
            // dgvImage
            // 
            dgvImage.HeaderText = "Image";
            dgvImage.MinimumWidth = 8;
            dgvImage.Name = "dgvImage";
            dgvImage.ReadOnly = true;
            dgvImage.Visible = false;
            dgvImage.Width = 78;
            // 
            // dgvImageShow
            // 
            dgvImageShow.HeaderText = "Image";
            dgvImageShow.Image = Properties.Resources.woman_bag;
            dgvImageShow.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvImageShow.MinimumWidth = 8;
            dgvImageShow.Name = "dgvImageShow";
            dgvImageShow.ReadOnly = true;
            dgvImageShow.Width = 66;
            // 
            // dgvCreateDate
            // 
            dgvCreateDate.HeaderText = "CreateDate";
            dgvCreateDate.MinimumWidth = 8;
            dgvCreateDate.Name = "dgvCreateDate";
            dgvCreateDate.ReadOnly = true;
            dgvCreateDate.Width = 133;
            // 
            // dgvUpdateDate
            // 
            dgvUpdateDate.HeaderText = "UpdateDate";
            dgvUpdateDate.MinimumWidth = 8;
            dgvUpdateDate.Name = "dgvUpdateDate";
            dgvUpdateDate.ReadOnly = true;
            dgvUpdateDate.Width = 141;
            // 
            // dgvActive
            // 
            dgvActive.HeaderText = "Active";
            dgvActive.MinimumWidth = 8;
            dgvActive.Name = "dgvActive";
            dgvActive.ReadOnly = true;
            dgvActive.Visible = false;
            dgvActive.Width = 77;
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
            dgvEdit.Width = 50;
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
            dgvDel.Width = 50;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 816);
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
        private DataGridViewImageColumn dgvEdit;
        private DataGridViewImageColumn dgvDel;
    }
}