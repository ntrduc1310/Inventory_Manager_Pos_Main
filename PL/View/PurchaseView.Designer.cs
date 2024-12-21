namespace PL.View
{
    partial class PurchaseView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            dgvSr = new DataGridViewTextBoxColumn();
            dgvid = new DataGridViewTextBoxColumn();
            dgvDate = new DataGridViewTextBoxColumn();
            dgvSupplier = new DataGridViewTextBoxColumn();
            dgvSupID = new DataGridViewTextBoxColumn();
            dgvAmount = new DataGridViewTextBoxColumn();
            dgvCreatedBy = new DataGridViewTextBoxColumn();
            dgvStatus = new DataGridViewTextBoxColumn();
            dgvAllInformation = new DataGridViewImageColumn();
            dgvAccepted = new DataGridViewImageColumn();
            dgvDontAccepted = new DataGridViewImageColumn();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
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
            txtsearch.PlaceholderText = "Nhập Vào Tìm Kiếm";
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtsearch.Size = new Size(416, 64);
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(150, 21);
            guna2HtmlLabel1.Margin = new Padding(2);
            guna2HtmlLabel1.Size = new Size(185, 52);
            guna2HtmlLabel1.Text = "Danh Sách ";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Location = new Point(578, 85);
            guna2HtmlLabel2.Margin = new Padding(5);
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(96, 71, 204);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvSr, dgvid, dgvDate, dgvSupplier, dgvSupID, dgvAmount, dgvCreatedBy, dgvStatus, dgvAllInformation, dgvAccepted, dgvDontAccepted });
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
            guna2DataGridView1.RowHeadersWidth = 51;
            guna2DataGridView1.RowTemplate.Height = 35;
            guna2DataGridView1.Size = new Size(931, 393);
            guna2DataGridView1.TabIndex = 3;
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
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 35;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // dgvSr
            // 
            dgvSr.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSr.FillWeight = 1F;
            dgvSr.Frozen = true;
            dgvSr.HeaderText = "Sr#";
            dgvSr.MinimumWidth = 70;
            dgvSr.Name = "dgvSr";
            dgvSr.ReadOnly = true;
            dgvSr.Width = 70;
            // 
            // dgvid
            // 
            dgvid.FillWeight = 1F;
            dgvid.HeaderText = "id";
            dgvid.MinimumWidth = 70;
            dgvid.Name = "dgvid";
            dgvid.ReadOnly = true;
            dgvid.Visible = false;
            // 
            // dgvDate
            // 
            dgvDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDate.FillWeight = 20F;
            dgvDate.Frozen = true;
            dgvDate.HeaderText = "Ngày";
            dgvDate.MinimumWidth = 70;
            dgvDate.Name = "dgvDate";
            dgvDate.ReadOnly = true;
            dgvDate.Width = 125;
            // 
            // dgvSupplier
            // 
            dgvSupplier.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSupplier.FillWeight = 20F;
            dgvSupplier.HeaderText = "Nhà cung cấp";
            dgvSupplier.MinimumWidth = 70;
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.ReadOnly = true;
            dgvSupplier.Width = 125;
            // 
            // dgvSupID
            // 
            dgvSupID.FillWeight = 1F;
            dgvSupID.HeaderText = "SupID";
            dgvSupID.MinimumWidth = 70;
            dgvSupID.Name = "dgvSupID";
            dgvSupID.ReadOnly = true;
            dgvSupID.Visible = false;
            // 
            // dgvAmount
            // 
            dgvAmount.FillWeight = 20F;
            dgvAmount.HeaderText = "Tổng tiền";
            dgvAmount.MinimumWidth = 125;
            dgvAmount.Name = "dgvAmount";
            dgvAmount.ReadOnly = true;
            // 
            // dgvCreatedBy
            // 
            dgvCreatedBy.FillWeight = 20F;
            dgvCreatedBy.HeaderText = "Người tạo";
            dgvCreatedBy.MinimumWidth = 130;
            dgvCreatedBy.Name = "dgvCreatedBy";
            dgvCreatedBy.ReadOnly = true;
            // 
            // dgvStatus
            // 
            dgvStatus.FillWeight = 20F;
            dgvStatus.HeaderText = "Trạng thái";
            dgvStatus.MinimumWidth = 125;
            dgvStatus.Name = "dgvStatus";
            dgvStatus.ReadOnly = true;
            // 
            // dgvAllInformation
            // 
            dgvAllInformation.FillWeight = 1F;
            dgvAllInformation.HeaderText = "";
            dgvAllInformation.Image = (Image)resources.GetObject("dgvAllInformation.Image");
            dgvAllInformation.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvAllInformation.MinimumWidth = 79;
            dgvAllInformation.Name = "dgvAllInformation";
            dgvAllInformation.ReadOnly = true;
            dgvAllInformation.Resizable = DataGridViewTriState.True;
            dgvAllInformation.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dgvAccepted
            // 
            dgvAccepted.FillWeight = 1F;
            dgvAccepted.HeaderText = "";
            dgvAccepted.Image = Properties.Resources.icons8_task_completed_50;
            dgvAccepted.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvAccepted.MinimumWidth = 70;
            dgvAccepted.Name = "dgvAccepted";
            dgvAccepted.ReadOnly = true;
            // 
            // dgvDontAccepted
            // 
            dgvDontAccepted.FillWeight = 1F;
            dgvDontAccepted.HeaderText = "";
            dgvDontAccepted.Image = Properties.Resources.icons8_no_50;
            dgvDontAccepted.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvDontAccepted.MinimumWidth = 70;
            dgvDontAccepted.Name = "dgvDontAccepted";
            dgvDontAccepted.ReadOnly = true;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(150, 66);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(200, 52);
            guna2HtmlLabel3.TabIndex = 7;
            guna2HtmlLabel3.Text = "Nhập Hàng ";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(52, 19);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(96, 94);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 8;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            // 
            // PurchaseView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 653);
            Controls.Add(guna2DataGridView1);
            Name = "PurchaseView";
            Text = "PurchaseView";
            Load += PurchaseView_Load;
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2DataGridView1, 0);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private DataGridViewTextBoxColumn dgvSr;
        private DataGridViewTextBoxColumn dgvid;
        private DataGridViewTextBoxColumn dgvDate;
        private DataGridViewTextBoxColumn dgvSupplier;
        private DataGridViewTextBoxColumn dgvSupID;
        private DataGridViewTextBoxColumn dgvAmount;
        private DataGridViewTextBoxColumn dgvCreatedBy;
        private DataGridViewTextBoxColumn dgvStatus;
        private DataGridViewImageColumn dgvAllInformation;
        private DataGridViewImageColumn dgvAccepted;
        private DataGridViewImageColumn dgvDontAccepted;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}