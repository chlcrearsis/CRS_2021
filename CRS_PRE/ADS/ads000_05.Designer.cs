namespace CRS_PRE
{
    partial class ads000_05
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
            this.m_ads000_05 = new System.Windows.Forms.MenuStrip();
            this.mn_cre_ar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ads000_05.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ads000_05
            // 
            this.m_ads000_05.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_cre_ar,
            this.mn_edi_tar,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_ads000_05.Location = new System.Drawing.Point(0, 0);
            this.m_ads000_05.Name = "m_ads000_05";
            this.m_ads000_05.Size = new System.Drawing.Size(753, 24);
            this.m_ads000_05.TabIndex = 1;
            this.m_ads000_05.Visible = false;
            // 
            // mn_cre_ar
            // 
            this.mn_cre_ar.Name = "mn_cre_ar";
            this.mn_cre_ar.Size = new System.Drawing.Size(43, 20);
            this.mn_cre_ar.Text = "Crea";
            this.mn_cre_ar.Click += new System.EventHandler(this.mn_cre_ar_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "Edita";
            this.mn_edi_tar.Click += new System.EventHandler(this.mn_edi_tar_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "Reporte";
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // ads000_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 300);
            this.Controls.Add(this.m_ads000_05);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.m_ads000_05;
            this.Name = "ads000_05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu principal";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_ads000_05.ResumeLayout(false);
            this.m_ads000_05.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem mn_cre_ar;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        public System.Windows.Forms.MenuStrip m_ads000_05;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
    }
}