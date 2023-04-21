namespace CRS_PRE
{
    partial class ads004_R02w
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
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_imp_rim = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_exp_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_sep_uno = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_pri_pag = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ant_pag = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_sig_pag = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ult_pag = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_nro_pag = new System.Windows.Forms.ToolStripTextBox();
            this.mn_sep_dos = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_bus_car = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_rep = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_anc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_tod = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_075 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_zoo_025 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.cr_rep_ort = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ads004_R02 = new CRS_PRE.ADS.ads004_R02();
            this.m_frm_hja.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_frm_hja
            // 
            this.m_frm_hja.Dock = System.Windows.Forms.DockStyle.None;
            this.m_frm_hja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_imp_rim,
            this.mn_exp_ort,
            this.mn_sep_uno,
            this.mn_pri_pag,
            this.mn_ant_pag,
            this.mn_sig_pag,
            this.mn_ult_pag,
            this.mn_nro_pag,
            this.mn_sep_dos,
            this.mn_bus_car,
            this.mn_zoo_rep,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(90, 23);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(452, 27);
            this.m_frm_hja.TabIndex = 6;
            this.m_frm_hja.Visible = false;
            // 
            // mn_imp_rim
            // 
            this.mn_imp_rim.Name = "mn_imp_rim";
            this.mn_imp_rim.Size = new System.Drawing.Size(65, 23);
            this.mn_imp_rim.Text = "&Imprimir";
            this.mn_imp_rim.Click += new System.EventHandler(this.Mn_imp_rim_Click);
            // 
            // mn_exp_ort
            // 
            this.mn_exp_ort.Name = "mn_exp_ort";
            this.mn_exp_ort.Size = new System.Drawing.Size(63, 23);
            this.mn_exp_ort.Text = "&Exportar";
            this.mn_exp_ort.Click += new System.EventHandler(this.Mn_exp_ort_Click);
            // 
            // mn_sep_uno
            // 
            this.mn_sep_uno.Enabled = false;
            this.mn_sep_uno.Name = "mn_sep_uno";
            this.mn_sep_uno.Size = new System.Drawing.Size(22, 23);
            this.mn_sep_uno.Tag = "separador";
            this.mn_sep_uno.Text = "|";
            // 
            // mn_pri_pag
            // 
            this.mn_pri_pag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mn_pri_pag.Image = global::CRS_PRE.Properties.Resources.primero;
            this.mn_pri_pag.Name = "mn_pri_pag";
            this.mn_pri_pag.Size = new System.Drawing.Size(28, 23);
            this.mn_pri_pag.Text = "primero";
            this.mn_pri_pag.Click += new System.EventHandler(this.Mn_pri_pag_Click);
            // 
            // mn_ant_pag
            // 
            this.mn_ant_pag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mn_ant_pag.Image = global::CRS_PRE.Properties.Resources.anterior;
            this.mn_ant_pag.Name = "mn_ant_pag";
            this.mn_ant_pag.Size = new System.Drawing.Size(28, 23);
            this.mn_ant_pag.Text = "anterior";
            this.mn_ant_pag.Click += new System.EventHandler(this.Mn_ant_pag_Click);
            // 
            // mn_sig_pag
            // 
            this.mn_sig_pag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mn_sig_pag.Image = global::CRS_PRE.Properties.Resources.siguiente;
            this.mn_sig_pag.Name = "mn_sig_pag";
            this.mn_sig_pag.Size = new System.Drawing.Size(28, 23);
            this.mn_sig_pag.Text = "siguiente";
            this.mn_sig_pag.Click += new System.EventHandler(this.Mn_sig_pag_Click);
            // 
            // mn_ult_pag
            // 
            this.mn_ult_pag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mn_ult_pag.Image = global::CRS_PRE.Properties.Resources.ultimo;
            this.mn_ult_pag.Name = "mn_ult_pag";
            this.mn_ult_pag.Size = new System.Drawing.Size(28, 23);
            this.mn_ult_pag.Text = "ultima";
            this.mn_ult_pag.Click += new System.EventHandler(this.Mn_ult_pag_Click);
            // 
            // mn_nro_pag
            // 
            this.mn_nro_pag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mn_nro_pag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mn_nro_pag.MaxLength = 3;
            this.mn_nro_pag.Name = "mn_nro_pag";
            this.mn_nro_pag.Size = new System.Drawing.Size(30, 23);
            this.mn_nro_pag.Tag = "separador";
            this.mn_nro_pag.Text = "1";
            this.mn_nro_pag.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mn_nro_pag.Leave += new System.EventHandler(this.Mn_nro_pag_Leave);
            // 
            // mn_sep_dos
            // 
            this.mn_sep_dos.Enabled = false;
            this.mn_sep_dos.Name = "mn_sep_dos";
            this.mn_sep_dos.Size = new System.Drawing.Size(22, 23);
            this.mn_sep_dos.Tag = "separador";
            this.mn_sep_dos.Text = "|";
            // 
            // mn_bus_car
            // 
            this.mn_bus_car.Name = "mn_bus_car";
            this.mn_bus_car.Size = new System.Drawing.Size(54, 23);
            this.mn_bus_car.Text = "&Buscar";
            this.mn_bus_car.Click += new System.EventHandler(this.Mn_bus_car_Click);
            // 
            // mn_zoo_rep
            // 
            this.mn_zoo_rep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mn_zoo_rep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_zoo_anc,
            this.mn_zoo_tod,
            this.mn_zoo_200,
            this.mn_zoo_150,
            this.mn_zoo_100,
            this.mn_zoo_075,
            this.mn_zoo_025});
            this.mn_zoo_rep.Image = global::CRS_PRE.Properties.Resources.zoom;
            this.mn_zoo_rep.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mn_zoo_rep.Name = "mn_zoo_rep";
            this.mn_zoo_rep.Size = new System.Drawing.Size(28, 23);
            this.mn_zoo_rep.Text = "&Zoom";
            // 
            // mn_zoo_anc
            // 
            this.mn_zoo_anc.Name = "mn_zoo_anc";
            this.mn_zoo_anc.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_anc.Text = "&Ancho de pagina";
            this.mn_zoo_anc.Visible = false;
            this.mn_zoo_anc.Click += new System.EventHandler(this.Mn_zoo_anc_Click);
            // 
            // mn_zoo_tod
            // 
            this.mn_zoo_tod.Name = "mn_zoo_tod";
            this.mn_zoo_tod.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_tod.Text = "&Toda la pagina";
            this.mn_zoo_tod.Visible = false;
            this.mn_zoo_tod.Click += new System.EventHandler(this.Mn_zoo_tod_Click);
            // 
            // mn_zoo_200
            // 
            this.mn_zoo_200.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mn_zoo_200.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mn_zoo_200.Name = "mn_zoo_200";
            this.mn_zoo_200.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_200.Text = "200 %";
            this.mn_zoo_200.Click += new System.EventHandler(this.Mn_zoo_200_Click);
            // 
            // mn_zoo_150
            // 
            this.mn_zoo_150.Name = "mn_zoo_150";
            this.mn_zoo_150.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_150.Text = "150 %";
            this.mn_zoo_150.Click += new System.EventHandler(this.Mn_zoo_150_Click);
            // 
            // mn_zoo_100
            // 
            this.mn_zoo_100.Name = "mn_zoo_100";
            this.mn_zoo_100.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_100.Text = "100 %";
            this.mn_zoo_100.Click += new System.EventHandler(this.Mn_zoo_100_Click);
            // 
            // mn_zoo_075
            // 
            this.mn_zoo_075.Name = "mn_zoo_075";
            this.mn_zoo_075.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_075.Text = "75 %";
            this.mn_zoo_075.Click += new System.EventHandler(this.Mn_zoo_075_Click);
            // 
            // mn_zoo_025
            // 
            this.mn_zoo_025.Name = "mn_zoo_025";
            this.mn_zoo_025.Size = new System.Drawing.Size(164, 22);
            this.mn_zoo_025.Text = "25 %";
            this.mn_zoo_025.Click += new System.EventHandler(this.Mn_zoo_025_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 23);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.Mn_cer_rar_Click);
            // 
            // cr_rep_ort
            // 
            this.cr_rep_ort.ActiveViewIndex = 0;
            this.cr_rep_ort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cr_rep_ort.Cursor = System.Windows.Forms.Cursors.Default;
            this.cr_rep_ort.DisplayBackgroundEdge = false;
            this.cr_rep_ort.DisplayToolbar = false;
            this.cr_rep_ort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cr_rep_ort.Location = new System.Drawing.Point(0, 0);
            this.cr_rep_ort.Name = "cr_rep_ort";
            this.cr_rep_ort.ReportSource = this.ads004_R02;
            this.cr_rep_ort.ShowCloseButton = false;
            this.cr_rep_ort.ShowCopyButton = false;
            this.cr_rep_ort.ShowGroupTreeButton = false;
            this.cr_rep_ort.ShowLogo = false;
            this.cr_rep_ort.ShowParameterPanelButton = false;
            this.cr_rep_ort.ShowRefreshButton = false;
            this.cr_rep_ort.Size = new System.Drawing.Size(838, 450);
            this.cr_rep_ort.TabIndex = 0;
            this.cr_rep_ort.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ads004_R02w
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 450);
            this.Controls.Add(this.m_frm_hja);
            this.Controls.Add(this.cr_rep_ort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads004_R02w";
            this.Tag = "Informe Formato y Definición de Firmas";
            this.Text = "Informe Formato y Definición de Firmas";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cr_rep_ort;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_imp_rim;
        private System.Windows.Forms.ToolStripMenuItem mn_exp_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_bus_car;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_rep;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_200;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_150;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_100;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_075;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_025;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_anc;
        private System.Windows.Forms.ToolStripMenuItem mn_zoo_tod;
        private System.Windows.Forms.ToolStripMenuItem mn_pri_pag;
        private System.Windows.Forms.ToolStripMenuItem mn_ant_pag;
        private System.Windows.Forms.ToolStripMenuItem mn_sig_pag;
        private System.Windows.Forms.ToolStripMenuItem mn_ult_pag;
        private System.Windows.Forms.ToolStripMenuItem mn_sep_uno;
        private System.Windows.Forms.ToolStripMenuItem mn_sep_dos;
        private System.Windows.Forms.ToolStripTextBox mn_nro_pag;
        private ADS.ads004_R02 ads004_R02;
    }
}