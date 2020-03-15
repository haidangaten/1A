namespace QLTV3Layers
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnTrịHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuThôngTinĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnTrịHệThốngToolStripMenuItem,
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem,
            this.quảnLýĐộcGiảToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnTrịHệThốngToolStripMenuItem
            // 
            this.quảnTrịHệThốngToolStripMenuItem.Name = "quảnTrịHệThốngToolStripMenuItem";
            this.quảnTrịHệThốngToolStripMenuItem.Size = new System.Drawing.Size(123, 21);
            this.quảnTrịHệThốngToolStripMenuItem.Text = "Quản trị hệ thống";
            // 
            // quảnLýTừĐiểnDữLiệuToolStripMenuItem
            // 
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nghềToolStripMenuItem});
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem.Name = "quảnLýTừĐiểnDữLiệuToolStripMenuItem";
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.quảnLýTừĐiểnDữLiệuToolStripMenuItem.Text = "Từ điển dữ liệu";
            // 
            // nghềToolStripMenuItem
            // 
            this.nghềToolStripMenuItem.Name = "nghềToolStripMenuItem";
            this.nghềToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nghềToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nghềToolStripMenuItem.Text = "Nghề";
            this.nghềToolStripMenuItem.Click += new System.EventHandler(this.nghềToolStripMenuItem_Click);
            // 
            // quảnLýĐộcGiảToolStripMenuItem
            // 
            this.quảnLýĐộcGiảToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traCứuThôngTinĐộcGiảToolStripMenuItem});
            this.quảnLýĐộcGiảToolStripMenuItem.Name = "quảnLýĐộcGiảToolStripMenuItem";
            this.quảnLýĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(112, 21);
            this.quảnLýĐộcGiảToolStripMenuItem.Text = "Quản lý độc giả";
            // 
            // traCứuThôngTinĐộcGiảToolStripMenuItem
            // 
            this.traCứuThôngTinĐộcGiảToolStripMenuItem.Name = "traCứuThôngTinĐộcGiảToolStripMenuItem";
            this.traCứuThôngTinĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.traCứuThôngTinĐộcGiảToolStripMenuItem.Text = "Tra cứu thông tin độc giả";
            this.traCứuThôngTinĐộcGiảToolStripMenuItem.Click += new System.EventHandler(this.traCứuThôngTinĐộcGiảToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Hệ thống quản lý thư viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnTrịHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTừĐiểnDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghềToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCứuThôngTinĐộcGiảToolStripMenuItem;
    }
}