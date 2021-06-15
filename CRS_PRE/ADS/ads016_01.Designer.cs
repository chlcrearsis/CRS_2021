namespace CRS_PRE.ADS
{
    partial class ads016_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_cre_ar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ini_ges = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_sig_ges = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_nue_per = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_ges = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_ges = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_ges_tio = new System.Windows.Forms.ComboBox();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.lb_des_bus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sel_per = new System.Windows.Forms.TextBox();
            this.tb_sel_ges = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ges_tio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ges_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_ini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_fec_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_frm_hja
            // 
            this.m_frm_hja.Dock = System.Windows.Forms.DockStyle.None;
            this.m_frm_hja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_cre_ar,
            this.mn_edi_tar,
            this.mn_con_sul,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(268, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_cre_ar
            // 
            this.mn_cre_ar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_ini_ges,
            this.mn_sig_ges,
            this.mn_nue_per});
            this.mn_cre_ar.Name = "mn_cre_ar";
            this.mn_cre_ar.Size = new System.Drawing.Size(43, 20);
            this.mn_cre_ar.Text = "&Crea";
            // 
            // mn_ini_ges
            // 
            this.mn_ini_ges.Name = "mn_ini_ges";
            this.mn_ini_ges.Size = new System.Drawing.Size(207, 22);
            this.mn_ini_ges.Text = "Inicializa gestion";
            this.mn_ini_ges.Click += new System.EventHandler(this.Mn_ini_ges_Click);
            // 
            // mn_sig_ges
            // 
            this.mn_sig_ges.Name = "mn_sig_ges";
            this.mn_sig_ges.Size = new System.Drawing.Size(207, 22);
            this.mn_sig_ges.Text = "Prepara siguiente gestion";
            this.mn_sig_ges.Click += new System.EventHandler(this.Mn_sig_ges_Click);
            // 
            // mn_nue_per
            // 
            this.mn_nue_per.Name = "mn_nue_per";
            this.mn_nue_per.Size = new System.Drawing.Size(207, 22);
            this.mn_nue_per.Text = "Nuevo Periodo";
            this.mn_nue_per.Click += new System.EventHandler(this.Mn_nue_per_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi,
            this.mn_eli_min});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(121, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.Mn_mod_ifi_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(121, 22);
            this.mn_eli_min.Text = "E&limina";
            this.mn_eli_min.Click += new System.EventHandler(this.Mn_eli_min_Click);
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(66, 20);
            this.mn_con_sul.Text = "&Consulta";
            this.mn_con_sul.Click += new System.EventHandler(this.Mn_con_sul_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_per_ges,
            this.mn_lis_ges});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_per_ges
            // 
            this.mn_per_ges.Name = "mn_per_ges";
            this.mn_per_ges.Size = new System.Drawing.Size(201, 22);
            this.mn_per_ges.Text = "&Periodos de una gestion";
            this.mn_per_ges.Click += new System.EventHandler(this.Mn_per_ges_Click);
            // 
            // mn_lis_ges
            // 
            this.mn_lis_ges.Name = "mn_lis_ges";
            this.mn_lis_ges.Size = new System.Drawing.Size(201, 22);
            this.mn_lis_ges.Text = "&Gestiones";
            this.mn_lis_ges.Click += new System.EventHandler(this.Mn_lis_ges_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.Mn_cer_rar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ges_tio);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.lb_des_bus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_sel_per);
            this.groupBox1.Controls.Add(this.tb_sel_ges);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 59);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cb_ges_tio
            // 
            this.cb_ges_tio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ges_tio.FormattingEnabled = true;
            this.cb_ges_tio.Location = new System.Drawing.Point(350, 9);
            this.cb_ges_tio.MaxLength = 4;
            this.cb_ges_tio.Name = "cb_ges_tio";
            this.cb_ges_tio.Size = new System.Drawing.Size(75, 21);
            this.cb_ges_tio.TabIndex = 31;
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(350, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 30;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.Bt_bus_car_Click);
            // 
            // lb_des_bus
            // 
            this.lb_des_bus.Location = new System.Drawing.Point(95, 14);
            this.lb_des_bus.Name = "lb_des_bus";
            this.lb_des_bus.Size = new System.Drawing.Size(10, 13);
            this.lb_des_bus.TabIndex = 2;
            this.lb_des_bus.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestion";
            // 
            // tb_sel_per
            // 
            this.tb_sel_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_per.Location = new System.Drawing.Point(106, 12);
            this.tb_sel_per.MaxLength = 4;
            this.tb_sel_per.Multiline = true;
            this.tb_sel_per.Name = "tb_sel_per";
            this.tb_sel_per.Size = new System.Drawing.Size(25, 18);
            this.tb_sel_per.TabIndex = 10;
            this.tb_sel_per.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_per.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // tb_sel_ges
            // 
            this.tb_sel_ges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_ges.Location = new System.Drawing.Point(52, 12);
            this.tb_sel_ges.MaxLength = 4;
            this.tb_sel_ges.Multiline = true;
            this.tb_sel_ges.Name = "tb_sel_ges";
            this.tb_sel_ges.Size = new System.Drawing.Size(42, 18);
            this.tb_sel_ges.TabIndex = 10;
            this.tb_sel_ges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_ges.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 199);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_ges_tio,
            this.va_ges_per,
            this.va_nom_per,
            this.va_fec_ini,
            this.va_fec_fin});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.Location = new System.Drawing.Point(4, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(426, 187);
            this.dg_res_ult.TabIndex = 50;
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_ges_tio
            // 
            this.va_ges_tio.HeaderText = "Gestion";
            this.va_ges_tio.Name = "va_ges_tio";
            this.va_ges_tio.ReadOnly = true;
            this.va_ges_tio.Width = 60;
            // 
            // va_ges_per
            // 
            this.va_ges_per.HeaderText = "Periodo";
            this.va_ges_per.Name = "va_ges_per";
            this.va_ges_per.ReadOnly = true;
            this.va_ges_per.Width = 45;
            // 
            // va_nom_per
            // 
            this.va_nom_per.HeaderText = "Mes";
            this.va_nom_per.Name = "va_nom_per";
            this.va_nom_per.ReadOnly = true;
            this.va_nom_per.Width = 120;
            // 
            // va_fec_ini
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.va_fec_ini.DefaultCellStyle = dataGridViewCellStyle1;
            this.va_fec_ini.HeaderText = "Fecha inicial";
            this.va_fec_ini.Name = "va_fec_ini";
            this.va_fec_ini.ReadOnly = true;
            // 
            // va_fec_fin
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.va_fec_fin.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_fec_fin.HeaderText = "Fecha final";
            this.va_fec_fin.Name = "va_fec_fin";
            this.va_fec_fin.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 241);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(432, 34);
            this.gb_ctr_btn.TabIndex = 30;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(355, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 70;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(274, 7);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 60;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            // 
            // ads016_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 275);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads016_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busca Gestion/Periodo";
            this.Load += new System.EventHandler(this.ads007_01_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_bus_car;
        private System.Windows.Forms.Label lb_des_bus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sel_ges;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_cre_ar;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_per_ges;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        private System.Windows.Forms.TextBox tb_sel_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ges_tio;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ges_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_ini;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_fin;
        private System.Windows.Forms.ComboBox cb_ges_tio;
        private System.Windows.Forms.ToolStripMenuItem mn_ini_ges;
        private System.Windows.Forms.ToolStripMenuItem mn_sig_ges;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_per;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_ges;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
    }
}