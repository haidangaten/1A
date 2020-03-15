namespace QLTV_V1._0
{
    partial class frmThongTinDocGia
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataDG = new System.Windows.Forms.DataGridView();
            this.lblDongDL = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataDG)).BeginInit();
            this.lblDongDL.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(313, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "KẾT QUẢ TÌM KIẾM";
            // 
            // dataDG
            // 
            this.dataDG.AllowUserToAddRows = false;
            this.dataDG.AllowUserToDeleteRows = false;
            this.dataDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDG.Location = new System.Drawing.Point(13, 31);
            this.dataDG.Name = "dataDG";
            this.dataDG.RowHeadersVisible = false;
            this.dataDG.Size = new System.Drawing.Size(911, 485);
            this.dataDG.TabIndex = 1;
            // 
            // lblDongDL
            // 
            this.lblDongDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.lblDongDL.Location = new System.Drawing.Point(0, 514);
            this.lblDongDL.Name = "lblDongDL";
            this.lblDongDL.Size = new System.Drawing.Size(936, 22);
            this.lblDongDL.TabIndex = 2;
            this.lblDongDL.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // frmThongTinDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 536);
            this.Controls.Add(this.lblDongDL);
            this.Controls.Add(this.dataDG);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách độc giả";
            this.Load += new System.EventHandler(this.frmThongTinDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataDG)).EndInit();
            this.lblDongDL.ResumeLayout(false);
            this.lblDongDL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataDG;
        private System.Windows.Forms.StatusStrip lblDongDL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}