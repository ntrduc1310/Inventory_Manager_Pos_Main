namespace PL.View
{
    partial class Report
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cb_chooseDate = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lbl_Quantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbl_TotalCostPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbl_turnover = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lbl_Profit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            gunaLineDataset1 = new Guna.Charts.WinForms.GunaLineDataset();
            listBox1 = new ListBox();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(168, 15);
            guna2HtmlLabel1.Margin = new Padding(4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(180, 67);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Báo cáo";
            // 
            // cb_chooseDate
            // 
            cb_chooseDate.BackColor = Color.WhiteSmoke;
            cb_chooseDate.BorderColor = Color.Transparent;
            cb_chooseDate.BorderThickness = 0;
            cb_chooseDate.CustomizableEdges = customizableEdges1;
            cb_chooseDate.DrawMode = DrawMode.OwnerDrawFixed;
            cb_chooseDate.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_chooseDate.FillColor = SystemColors.Control;
            cb_chooseDate.FocusedColor = Color.FromArgb(94, 148, 255);
            cb_chooseDate.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cb_chooseDate.Font = new Font("Segoe UI", 10F);
            cb_chooseDate.ForeColor = Color.FromArgb(68, 88, 112);
            cb_chooseDate.ItemHeight = 30;
            cb_chooseDate.Location = new Point(443, 120);
            cb_chooseDate.Name = "cb_chooseDate";
            cb_chooseDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cb_chooseDate.Size = new Size(291, 36);
            cb_chooseDate.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.WhiteSmoke;
            guna2Panel1.BackgroundImageLayout = ImageLayout.Center;
            guna2Panel1.BorderColor = Color.Gray;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(lbl_Quantity);
            guna2Panel1.Controls.Add(lbl_TotalCostPrice);
            guna2Panel1.Controls.Add(lbl_turnover);
            guna2Panel1.Controls.Add(lbl_Profit);
            guna2Panel1.Controls.Add(guna2HtmlLabel7);
            guna2Panel1.Controls.Add(guna2HtmlLabel6);
            guna2Panel1.Controls.Add(guna2HtmlLabel5);
            guna2Panel1.Controls.Add(guna2HtmlLabel4);
            guna2Panel1.Controls.Add(guna2HtmlLabel3);
            guna2Panel1.Controls.Add(guna2HtmlLabel2);
            guna2Panel1.CustomBorderColor = Color.Silver;
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(152, 220);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(868, 486);
            guna2Panel1.TabIndex = 3;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // lbl_Quantity
            // 
            lbl_Quantity.BackColor = Color.Transparent;
            lbl_Quantity.Location = new Point(558, 327);
            lbl_Quantity.Name = "lbl_Quantity";
            lbl_Quantity.Size = new Size(37, 27);
            lbl_Quantity.TabIndex = 13;
            lbl_Quantity.Text = "0.00";
            // 
            // lbl_TotalCostPrice
            // 
            lbl_TotalCostPrice.BackColor = Color.Transparent;
            lbl_TotalCostPrice.Location = new Point(558, 208);
            lbl_TotalCostPrice.Name = "lbl_TotalCostPrice";
            lbl_TotalCostPrice.Size = new Size(37, 27);
            lbl_TotalCostPrice.TabIndex = 12;
            lbl_TotalCostPrice.Text = "0.00";
            // 
            // lbl_turnover
            // 
            lbl_turnover.BackColor = Color.Transparent;
            lbl_turnover.Location = new Point(558, 148);
            lbl_turnover.Name = "lbl_turnover";
            lbl_turnover.Size = new Size(37, 27);
            lbl_turnover.TabIndex = 11;
            lbl_turnover.Text = "0.00";
            // 
            // lbl_Profit
            // 
            lbl_Profit.BackColor = Color.Transparent;
            lbl_Profit.Location = new Point(416, 65);
            lbl_Profit.Name = "lbl_Profit";
            lbl_Profit.Size = new Size(37, 27);
            lbl_Profit.TabIndex = 10;
            lbl_Profit.Text = "0.00";
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Location = new Point(179, 327);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(106, 27);
            guna2HtmlLabel7.TabIndex = 8;
            guna2HtmlLabel7.Text = "Số đơn hàng";
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.AutoSize = false;
            guna2HtmlLabel6.BackColor = Color.LightGray;
            guna2HtmlLabel6.Location = new Point(179, 293);
            guna2HtmlLabel6.MaximumSize = new Size(0, 2);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(518, 2);
            guna2HtmlLabel6.TabIndex = 7;
            guna2HtmlLabel6.Text = "Lợi nhuận";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.AutoSize = false;
            guna2HtmlLabel5.BackColor = Color.LightGray;
            guna2HtmlLabel5.Location = new Point(179, 120);
            guna2HtmlLabel5.MaximumSize = new Size(0, 2);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(518, 2);
            guna2HtmlLabel5.TabIndex = 4;
            guna2HtmlLabel5.Text = "Lợi nhuận";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Location = new Point(179, 208);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(35, 27);
            guna2HtmlLabel4.TabIndex = 3;
            guna2HtmlLabel4.Text = "Vốn";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Location = new Point(179, 148);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(87, 27);
            guna2HtmlLabel3.TabIndex = 2;
            guna2HtmlLabel3.Text = "Doanh thu";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(399, 32);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(80, 27);
            guna2HtmlLabel2.TabIndex = 0;
            guna2HtmlLabel2.Text = "Lợi nhuận";
            // 
            // gunaLineDataset1
            // 
            gunaLineDataset1.BorderColor = Color.Empty;
            gunaLineDataset1.FillColor = Color.Empty;
            gunaLineDataset1.Label = "Line1";
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(154, 745);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(788, 129);
            listBox1.TabIndex = 4;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 931);
            Controls.Add(listBox1);
            Controls.Add(guna2Panel1);
            Controls.Add(cb_chooseDate);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Report";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report";
            Load += Report_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cb_chooseDate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.Charts.WinForms.GunaLineDataset gunaLineDataset1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Quantity;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_TotalCostPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_turnover;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Profit;
        private ListBox listBox1;
    }
}