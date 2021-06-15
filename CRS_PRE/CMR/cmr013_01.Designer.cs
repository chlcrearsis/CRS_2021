namespace CRS_PRE.CMR
{
    partial class cmr013_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_cre_ar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_hab_des = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_list_per = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_cod_gru = new System.Windows.Forms.TextBox();
            this.bt_bus_doc = new System.Windows.Forms.Button();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_nom_gru = new System.Windows.Forms.Label();
            this.lb_des_bus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sel_bus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_cod_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_raz_soc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nit_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_car_net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cod_gru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_gru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_dir_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tel_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cel_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.mn_cre_ar.Name = "mn_cre_ar";
            this.mn_cre_ar.Size = new System.Drawing.Size(43, 20);
            this.mn_cre_ar.Text = "&Crea";
            this.mn_cre_ar.Click += new System.EventHandler(this.Mn_cre_ar_Click);
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi,
            this.mn_hab_des,
            this.mn_eli_min});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(178, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.Mn_mod_ifi_Click);
            // 
            // mn_hab_des
            // 
            this.mn_hab_des.Name = "mn_hab_des";
            this.mn_hab_des.Size = new System.Drawing.Size(178, 22);
            this.mn_hab_des.Text = "&Habilita/Deshabilita";
            this.mn_hab_des.Click += new System.EventHandler(this.Mn_hab_des_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(178, 22);
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
            this.mn_list_per});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_list_per
            // 
            this.mn_list_per.Name = "mn_list_per";
            this.mn_list_per.Size = new System.Drawing.Size(162, 22);
            this.mn_list_per.Text = "&Lista de bodegas";
            this.mn_list_per.Click += new System.EventHandler(this.mn_list_per_Click);
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
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_cod_gru);
            this.groupBox1.Controls.Add(this.bt_bus_doc);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_nom_gru);
            this.groupBox1.Controls.Add(this.lb_des_bus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_sel_bus);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Grupo";
            // 
            // tb_cod_gru
            // 
            this.tb_cod_gru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_gru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_gru.Location = new System.Drawing.Point(437, 10);
            this.tb_cod_gru.MaxLength = 2;
            this.tb_cod_gru.Name = "tb_cod_gru";
            this.tb_cod_gru.Size = new System.Drawing.Size(29, 20);
            this.tb_cod_gru.TabIndex = 28;
            this.tb_cod_gru.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_gru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_gru_KeyDown);
            this.tb_cod_gru.Validated += new System.EventHandler(this.Tb_cod_gru_Validated);
            // 
            // bt_bus_doc
            // 
            this.bt_bus_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_doc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_doc.Location = new System.Drawing.Point(465, 9);
            this.bt_bus_doc.Name = "bt_bus_doc";
            this.bt_bus_doc.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_doc.TabIndex = 29;
            this.bt_bus_doc.TabStop = false;
            this.bt_bus_doc.Text = "|";
            this.bt_bus_doc.UseVisualStyleBackColor = false;
            this.bt_bus_doc.Click += new System.EventHandler(this.Bt_bus_gru_Click);
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(542, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 30;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.Bt_bus_car_Click);
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(427, 33);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(114, 21);
            this.cb_est_bus.TabIndex = 25;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Codigo",
            "Razon Social",
            "Nombre",
            "Nit",
            "C.I.",
            "Celular"});
            this.cb_prm_bus.Location = new System.Drawing.Point(326, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 20;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 34);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(311, 20);
            this.tb_tex_bus.TabIndex = 15;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            // 
            // lb_nom_gru
            // 
            this.lb_nom_gru.Location = new System.Drawing.Point(485, 13);
            this.lb_nom_gru.Name = "lb_nom_gru";
            this.lb_nom_gru.Size = new System.Drawing.Size(135, 13);
            this.lb_nom_gru.TabIndex = 2;
            this.lb_nom_gru.Text = ".";
            // 
            // lb_des_bus
            // 
            this.lb_des_bus.Location = new System.Drawing.Point(103, 13);
            this.lb_des_bus.Name = "lb_des_bus";
            this.lb_des_bus.Size = new System.Drawing.Size(279, 13);
            this.lb_des_bus.TabIndex = 2;
            this.lb_des_bus.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Persona";
            // 
            // tb_sel_bus
            // 
            this.tb_sel_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_bus.Location = new System.Drawing.Point(55, 10);
            this.tb_sel_bus.MaxLength = 6;
            this.tb_sel_bus.Name = "tb_sel_bus";
            this.tb_sel_bus.Size = new System.Drawing.Size(42, 20);
            this.tb_sel_bus.TabIndex = 10;
            this.tb_sel_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_bus.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 276);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_per,
            this.va_raz_soc,
            this.va_nit_per,
            this.va_car_net,
            this.va_cod_gru,
            this.va_nom_gru,
            this.va_nom_com,
            this.va_dir_per,
            this.va_tel_per,
            this.va_cel_per,
            this.va_est_ado});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle1;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(619, 264);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_cod_per
            // 
            this.va_cod_per.HeaderText = "Codigo";
            this.va_cod_per.Name = "va_cod_per";
            this.va_cod_per.ReadOnly = true;
            this.va_cod_per.Width = 60;
            // 
            // va_raz_soc
            // 
            this.va_raz_soc.HeaderText = "Razon Social";
            this.va_raz_soc.Name = "va_raz_soc";
            this.va_raz_soc.ReadOnly = true;
            this.va_raz_soc.Width = 200;
            // 
            // va_nit_per
            // 
            this.va_nit_per.HeaderText = "Nit";
            this.va_nit_per.Name = "va_nit_per";
            this.va_nit_per.ReadOnly = true;
            this.va_nit_per.Width = 70;
            // 
            // va_car_net
            // 
            this.va_car_net.HeaderText = "C.I.";
            this.va_car_net.Name = "va_car_net";
            this.va_car_net.ReadOnly = true;
            this.va_car_net.Width = 50;
            // 
            // va_cod_gru
            // 
            this.va_cod_gru.HeaderText = "Cod. Grup.";
            this.va_cod_gru.Name = "va_cod_gru";
            this.va_cod_gru.ReadOnly = true;
            this.va_cod_gru.Width = 35;
            // 
            // va_nom_gru
            // 
            this.va_nom_gru.HeaderText = "Grupo";
            this.va_nom_gru.Name = "va_nom_gru";
            this.va_nom_gru.ReadOnly = true;
            // 
            // va_nom_com
            // 
            this.va_nom_com.HeaderText = "Nombre";
            this.va_nom_com.Name = "va_nom_com";
            this.va_nom_com.ReadOnly = true;
            this.va_nom_com.Width = 200;
            // 
            // va_dir_per
            // 
            this.va_dir_per.HeaderText = "Direccion";
            this.va_dir_per.Name = "va_dir_per";
            this.va_dir_per.ReadOnly = true;
            this.va_dir_per.Width = 180;
            // 
            // va_tel_per
            // 
            this.va_tel_per.HeaderText = "Telefono";
            this.va_tel_per.Name = "va_tel_per";
            this.va_tel_per.ReadOnly = true;
            this.va_tel_per.Width = 70;
            // 
            // va_cel_per
            // 
            this.va_cel_per.HeaderText = "Celular";
            this.va_cel_per.Name = "va_cel_per";
            this.va_cel_per.ReadOnly = true;
            this.va_cel_per.Width = 70;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 320);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(631, 34);
            this.gb_ctr_btn.TabIndex = 8;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(542, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(461, 7);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // cmr013_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(637, 359);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr013_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Bodega";
            this.Text = "Busca Persona";
            this.Load += new System.EventHandler(this.frm_Load);
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
        private System.Windows.Forms.ComboBox cb_est_bus;
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ToolStripMenuItem mn_hab_des;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_list_per;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.TextBox tb_sel_bus;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_cod_gru;
        private System.Windows.Forms.Button bt_bus_doc;
        private System.Windows.Forms.Label lb_nom_gru;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_raz_soc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nit_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_car_net;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_gru;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_gru;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_com;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_dir_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tel_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cel_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        public System.Windows.Forms.Label lb_des_bus;
    }
}