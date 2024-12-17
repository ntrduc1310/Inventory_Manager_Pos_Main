namespace PL.Model
{
    partial class PurchaseAdd
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
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Margin = new Padding(5);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2Panel1.Size = new Size(1286, 159);
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(79, 45);
            guna2HtmlLabel1.Margin = new Padding(6);
            guna2HtmlLabel1.Size = new Size(248, 47);
            guna2HtmlLabel1.Text = "Purchase Details";
            // 
            // btn_Close
            // 
            btn_Close.DialogResult = DialogResult.None;
            btn_Close.DisabledState.BorderColor = Color.DarkGray;
            btn_Close.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Close.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Close.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Close.ShadowDecoration.CustomizableEdges = customizableEdges2;
            // 
            // btn_Save
            // 
            btn_Save.DialogResult = DialogResult.None;
            btn_Save.DisabledState.BorderColor = Color.DarkGray;
            btn_Save.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Save.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Save.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Save.ShadowDecoration.CustomizableEdges = customizableEdges3;
            // 
            // guna2Panel2
            // 
            guna2Panel2.Location = new Point(0, 814);
            guna2Panel2.Margin = new Padding(5);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(1286, 152);
            // 
            // guna2Panel3
            // 
            guna2Panel3.CustomizableEdges = customizableEdges5;
            guna2Panel3.Location = new Point(1, 167);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel3.Size = new Size(927, 646);
            guna2Panel3.TabIndex = 2;
            guna2Panel3.Paint += guna2Panel3_Paint;
            // 
            // PurchaseAdd
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 966);
            Controls.Add(guna2Panel3);
            Name = "PurchaseAdd";
            Text = "PurchaseAdd";
            Load += PurchaseAdd_Load;
            Controls.SetChildIndex(guna2Panel2, 0);
            Controls.SetChildIndex(guna2Panel1, 0);
            Controls.SetChildIndex(guna2Panel3, 0);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
    }
}