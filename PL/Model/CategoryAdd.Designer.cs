namespace PL.Model
{
    partial class CategoryAdd
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txt_Name = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2Panel1.Size = new Size(420, 169);
            guna2Panel1.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(63, 36);
            guna2HtmlLabel1.Size = new Size(181, 39);
            guna2HtmlLabel1.Text = "Category Add";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // btn_Close
            // 
            btn_Close.DialogResult = DialogResult.None;
            btn_Close.DisabledState.BorderColor = Color.DarkGray;
            btn_Close.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Close.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Close.Location = new Point(221, 34);
            btn_Close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Close.Click += btn_Close_Click_1;
            // 
            // btn_Save
            // 
            btn_Save.DialogResult = DialogResult.None;
            btn_Save.DisabledState.BorderColor = Color.DarkGray;
            btn_Save.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Save.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Save.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Save.Location = new Point(27, 34);
            btn_Save.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btn_Save.Size = new Size(161, 54);
            btn_Save.Click += btn_Save_Click;
            // 
            // guna2Panel2
            // 
            guna2Panel2.Location = new Point(0, 390);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(420, 131);
            // 
            // txt_Name
            // 
            txt_Name.AutoRoundedCorners = true;
            txt_Name.BorderRadius = 26;
            txt_Name.CustomizableEdges = customizableEdges5;
            txt_Name.DefaultText = "";
            txt_Name.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_Name.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_Name.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_Name.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_Name.FocusedState.BorderColor = Color.FromArgb(95, 71, 204);
            txt_Name.Font = new Font("Segoe UI", 9F);
            txt_Name.HoverState.BorderColor = Color.FromArgb(95, 71, 204);
            txt_Name.Location = new Point(45, 222);
            txt_Name.Margin = new Padding(3, 4, 3, 4);
            txt_Name.Name = "txt_Name";
            txt_Name.PasswordChar = '\0';
            txt_Name.PlaceholderText = "";
            txt_Name.SelectedText = "";
            txt_Name.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_Name.Size = new Size(313, 55);
            txt_Name.TabIndex = 0;
            txt_Name.Tag = "v";
            txt_Name.TextOffset = new Point(10, 0);
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(55, 188);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(43, 22);
            guna2HtmlLabel2.TabIndex = 8;
            guna2HtmlLabel2.Text = "Name";
            // 
            // CategoryAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 521);
            Controls.Add(txt_Name);
            Controls.Add(guna2HtmlLabel2);
            Name = "CategoryAdd";
            Text = "CategoryAdd";
            Load += CategoryAdd_Load;
            Controls.SetChildIndex(guna2Panel2, 0);
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2HtmlLabel2, 0);
            Controls.SetChildIndex(txt_Name, 0);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox txt_Name;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}