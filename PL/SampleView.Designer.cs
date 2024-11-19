namespace PL
{
    partial class SampleView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdd1 = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(txtsearch);
            guna2Panel1.Controls.Add(btnAdd1);
            guna2Panel1.Controls.Add(guna2HtmlLabel2);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(975, 208);
            guna2Panel1.TabIndex = 0;
            // 
            // txtsearch
            // 
            txtsearch.AutoRoundedCorners = true;
            txtsearch.BorderRadius = 24;
            txtsearch.CustomizableEdges = customizableEdges1;
            txtsearch.DefaultText = "";
            txtsearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtsearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtsearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtsearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.Font = new Font("Segoe UI", 9F);
            txtsearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsearch.IconLeft = (Image)resources.GetObject("txtsearch.IconLeft");
            txtsearch.IconLeftOffset = new Point(2, 0);
            txtsearch.IconLeftSize = new Size(30, 30);
            txtsearch.Location = new Point(589, 115);
            txtsearch.Margin = new Padding(3, 4, 3, 4);
            txtsearch.Name = "txtsearch";
            txtsearch.PasswordChar = '\0';
            txtsearch.PlaceholderText = "Search Here";
            txtsearch.SelectedText = "";
            txtsearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtsearch.Size = new Size(333, 51);
            txtsearch.TabIndex = 3;
            txtsearch.TextOffset = new Point(10, 0);
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // btnAdd1
            // 
            btnAdd1.Animated = true;
            btnAdd1.AutoRoundedCorners = true;
            btnAdd1.BorderRadius = 34;
            btnAdd1.CustomizableEdges = customizableEdges3;
            btnAdd1.DisabledState.BorderColor = Color.DarkGray;
            btnAdd1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd1.FillColor = Color.FromArgb(95, 71, 204);
            btnAdd1.Font = new Font("Segoe UI", 9F);
            btnAdd1.ForeColor = Color.White;
            btnAdd1.Image = (Image)resources.GetObject("btnAdd1.Image");
            btnAdd1.ImageOffset = new Point(-2, 0);
            btnAdd1.ImageSize = new Size(30, 30);
            btnAdd1.Location = new Point(12, 105);
            btnAdd1.Name = "btnAdd1";
            btnAdd1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAdd1.Size = new Size(207, 70);
            btnAdd1.TabIndex = 2;
            btnAdd1.Text = "Add New";
            btnAdd1.Click += btnAdd1_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(589, 83);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(54, 25);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Search ";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.ActiveCaptionText;
            guna2HtmlLabel1.Location = new Point(38, 27);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(159, 33);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Sample Header";
            // 
            // SampleView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 622);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SampleView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SampleView";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Guna.UI2.WinForms.Guna2Button btnAdd1;
        public Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}