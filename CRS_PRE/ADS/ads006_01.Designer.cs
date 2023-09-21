namespace CRS_PRE
{
    partial class ads006_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_hab_des = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_tus = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_gdp = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_ven = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_cob = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_gdb = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_bod = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_lis = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_plv = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_tal = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_apl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_tus = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_atu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nom_tus = new System.Windows.Forms.Label();
            this.tb_ide_tus = new System.Windows.Forms.TextBox();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_ide_tus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_tus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_des_tus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_tod_tus = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.mn_con_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_per = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mn_nue_reg,
            this.mn_edi_tar,
            this.mn_con_sul,
            this.mn_per_tus,
            this.mn_rep_ort,
            this.mn_cer_rar,
            this.toolStripMenuItem1});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(467, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_nue_reg
            // 
            this.mn_nue_reg.Name = "mn_nue_reg";
            this.mn_nue_reg.Size = new System.Drawing.Size(43, 20);
            this.mn_nue_reg.Text = "&Crea";
            this.mn_nue_reg.Click += new System.EventHandler(this.mn_nue_reg_Click);
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
            this.mn_mod_ifi.Click += new System.EventHandler(this.mn_mod_ifi_Click);
            // 
            // mn_hab_des
            // 
            this.mn_hab_des.Name = "mn_hab_des";
            this.mn_hab_des.Size = new System.Drawing.Size(178, 22);
            this.mn_hab_des.Text = "&Habilita/Deshabilita";
            this.mn_hab_des.Click += new System.EventHandler(this.mn_hab_des_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(178, 22);
            this.mn_eli_min.Text = "E&limina";
            this.mn_eli_min.Click += new System.EventHandler(this.mn_eli_min_Click);
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_con_reg,
            this.mn_con_per});
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(66, 20);
            this.mn_con_sul.Text = "&Consulta";
            // 
            // mn_per_tus
            // 
            this.mn_per_tus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_per_gdp,
            this.mn_per_ven,
            this.mn_per_cob,
            this.mn_per_gdb,
            this.mn_per_bod,
            this.mn_per_lis,
            this.mn_per_plv,
            this.mn_per_tal,
            this.mn_per_apl});
            this.mn_per_tus.Name = "mn_per_tus";
            this.mn_per_tus.Size = new System.Drawing.Size(67, 20);
            this.mn_per_tus.Text = "&Permisos";
            // 
            // mn_per_gdp
            // 
            this.mn_per_gdp.Name = "mn_per_gdp";
            this.mn_per_gdp.Size = new System.Drawing.Size(230, 22);
            this.mn_per_gdp.Text = "Permiso de Grupo de Persona";
            this.mn_per_gdp.Click += new System.EventHandler(this.mn_per_gdp_Click);
            // 
            // mn_per_ven
            // 
            this.mn_per_ven.Name = "mn_per_ven";
            this.mn_per_ven.Size = new System.Drawing.Size(230, 22);
            this.mn_per_ven.Text = "Permiso de Vendedor";
            this.mn_per_ven.Click += new System.EventHandler(this.mn_per_ven_Click);
            // 
            // mn_per_cob
            // 
            this.mn_per_cob.Name = "mn_per_cob";
            this.mn_per_cob.Size = new System.Drawing.Size(230, 22);
            this.mn_per_cob.Text = "Permiso de Cobradores";
            this.mn_per_cob.Click += new System.EventHandler(this.mn_per_cob_Click);
            // 
            // mn_per_gdb
            // 
            this.mn_per_gdb.Name = "mn_per_gdb";
            this.mn_per_gdb.Size = new System.Drawing.Size(230, 22);
            this.mn_per_gdb.Text = "Permiso de Grupo de Bodega";
            this.mn_per_gdb.Click += new System.EventHandler(this.mn_per_gdb_Click);
            // 
            // mn_per_bod
            // 
            this.mn_per_bod.Name = "mn_per_bod";
            this.mn_per_bod.Size = new System.Drawing.Size(230, 22);
            this.mn_per_bod.Text = "Permiso de Bodega";
            this.mn_per_bod.Click += new System.EventHandler(this.mn_per_bod_Click);
            // 
            // mn_per_lis
            // 
            this.mn_per_lis.Name = "mn_per_lis";
            this.mn_per_lis.Size = new System.Drawing.Size(230, 22);
            this.mn_per_lis.Text = "Permiso de Lista de Precios";
            this.mn_per_lis.Click += new System.EventHandler(this.mn_per_lis_Click);
            // 
            // mn_per_plv
            // 
            this.mn_per_plv.Name = "mn_per_plv";
            this.mn_per_plv.Size = new System.Drawing.Size(230, 22);
            this.mn_per_plv.Text = "Permiso de Plantilla de Venta";
            this.mn_per_plv.Click += new System.EventHandler(this.mn_per_plv_Click);
            // 
            // mn_per_tal
            // 
            this.mn_per_tal.Name = "mn_per_tal";
            this.mn_per_tal.Size = new System.Drawing.Size(230, 22);
            this.mn_per_tal.Text = "Permiso de Talonaios";
            this.mn_per_tal.Click += new System.EventHandler(this.mn_per_tal_Click);
            // 
            // mn_per_apl
            // 
            this.mn_per_apl.Name = "mn_per_apl";
            this.mn_per_apl.Size = new System.Drawing.Size(230, 22);
            this.mn_per_apl.Text = "Permiso de Aplicaciones";
            this.mn_per_apl.Click += new System.EventHandler(this.mn_per_apl_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_lis_tus,
            this.mn_lis_atu});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_tus
            // 
            this.mn_lis_tus.Name = "mn_lis_tus";
            this.mn_lis_tus.ShortcutKeyDisplayString = "(ads006_R01)";
            this.mn_lis_tus.Size = new System.Drawing.Size(331, 22);
            this.mn_lis_tus.Text = "&Lista Tipo de Usuario";
            this.mn_lis_tus.Click += new System.EventHandler(this.mn_lis_tus_Click);
            // 
            // mn_lis_atu
            // 
            this.mn_lis_atu.Name = "mn_lis_atu";
            this.mn_lis_atu.ShortcutKeyDisplayString = "(ads006_R03)";
            this.mn_lis_atu.Size = new System.Drawing.Size(331, 22);
            this.mn_lis_atu.Text = "Autorizaciones del Tipo de Usuario";
            this.mn_lis_atu.Click += new System.EventHandler(this.mn_lis_atu_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nom_tus);
            this.groupBox1.Controls.Add(this.tb_ide_tus);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_ide_tus);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_tus
            // 
            this.lb_nom_tus.AutoSize = true;
            this.lb_nom_tus.Location = new System.Drawing.Point(108, 14);
            this.lb_nom_tus.Name = "lb_nom_tus";
            this.lb_nom_tus.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tus.TabIndex = 2;
            this.lb_nom_tus.Text = "...";
            // 
            // tb_ide_tus
            // 
            this.tb_ide_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tus.Location = new System.Drawing.Point(76, 10);
            this.tb_ide_tus.MaxLength = 3;
            this.tb_ide_tus.Name = "tb_ide_tus";
            this.tb_ide_tus.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_tus.TabIndex = 1;
            this.tb_ide_tus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_ide_tus.Validated += new System.EventHandler(this.tb_ide_tus_Validated);
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(493, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 6;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.bt_bus_car_Click);
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(378, 33);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(114, 21);
            this.cb_est_bus.TabIndex = 5;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Codigo",
            "Nombre",
            "Abreviación"});
            this.cb_prm_bus.Location = new System.Drawing.Point(277, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 4;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 33);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(264, 20);
            this.tb_tex_bus.TabIndex = 3;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // lb_ide_tus
            // 
            this.lb_ide_tus.AutoSize = true;
            this.lb_ide_tus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ide_tus.Location = new System.Drawing.Point(9, 13);
            this.lb_ide_tus.Name = "lb_ide_tus";
            this.lb_ide_tus.Size = new System.Drawing.Size(67, 13);
            this.lb_ide_tus.TabIndex = 0;
            this.lb_ide_tus.Text = "Tipo Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 199);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_ide_tus,
            this.va_nom_tus,
            this.va_des_tus,
            this.va_est_ado});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle6;
            this.dg_res_ult.Location = new System.Drawing.Point(8, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(560, 187);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_ide_tus
            // 
            this.va_ide_tus.HeaderText = "ID.";
            this.va_ide_tus.Name = "va_ide_tus";
            this.va_ide_tus.ReadOnly = true;
            this.va_ide_tus.Width = 40;
            // 
            // va_nom_tus
            // 
            this.va_nom_tus.HeaderText = "Nombre";
            this.va_nom_tus.Name = "va_nom_tus";
            this.va_nom_tus.ReadOnly = true;
            this.va_nom_tus.Width = 150;
            // 
            // va_des_tus
            // 
            this.va_des_tus.HeaderText = "Descripción";
            this.va_des_tus.Name = "va_des_tus";
            this.va_des_tus.ReadOnly = true;
            this.va_des_tus.Width = 250;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_tod_tus);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 243);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(572, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_tod_tus
            // 
            this.bt_tod_tus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_tod_tus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_tod_tus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_tod_tus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_tod_tus.Location = new System.Drawing.Point(6, 10);
            this.bt_tod_tus.Name = "bt_tod_tus";
            this.bt_tod_tus.Size = new System.Drawing.Size(75, 25);
            this.bt_tod_tus.TabIndex = 0;
            this.bt_tod_tus.Text = "&Todos";
            this.bt_tod_tus.UseVisualStyleBackColor = false;
            this.bt_tod_tus.Visible = false;
            this.bt_tod_tus.Click += new System.EventHandler(this.bt_tod_tus_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(415, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 1;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(493, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 2;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // mn_con_reg
            // 
            this.mn_con_reg.Name = "mn_con_reg";
            this.mn_con_reg.Size = new System.Drawing.Size(245, 22);
            this.mn_con_reg.Text = "Con&sulta Registro";
            this.mn_con_reg.Click += new System.EventHandler(this.mn_con_reg_Click);
            // 
            // mn_con_per
            // 
            this.mn_con_per.Name = "mn_con_per";
            this.mn_con_per.Size = new System.Drawing.Size(245, 22);
            this.mn_con_per.Text = "Consulta &Autorizaciones Usuario";
            this.mn_con_per.Click += new System.EventHandler(this.mn_con_per_Click);
            // 
            // ads006_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(577, 284);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads006_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Tipo de Usuario";
            this.Text = "Busca Tipo de Usuario";
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
        private System.Windows.Forms.Label lb_ide_tus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_hab_des;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_tus;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.TextBox tb_ide_tus;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.Label lb_nom_tus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_tus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_des_tus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        private System.Windows.Forms.Button bt_tod_tus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mn_per_tus;
        private System.Windows.Forms.ToolStripMenuItem mn_per_tal;
        private System.Windows.Forms.ToolStripMenuItem mn_per_plv;
        private System.Windows.Forms.ToolStripMenuItem mn_per_apl;
        private System.Windows.Forms.ToolStripMenuItem mn_per_lis;
        private System.Windows.Forms.ToolStripMenuItem mn_per_bod;
        private System.Windows.Forms.ToolStripMenuItem mn_per_gdp;
        private System.Windows.Forms.ToolStripMenuItem mn_per_ven;
        private System.Windows.Forms.ToolStripMenuItem mn_per_cob;
        private System.Windows.Forms.ToolStripMenuItem mn_per_gdb;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_atu;
        private System.Windows.Forms.ToolStripMenuItem mn_con_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_con_per;
    }
}