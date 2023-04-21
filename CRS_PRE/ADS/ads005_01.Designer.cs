namespace CRS_PRE
{
    partial class ads005_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_nta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.tb_nro_tal = new System.Windows.Forms.TextBox();
            this.tb_ide_doc = new System.Windows.Forms.TextBox();
            this.lb_lin_sep = new System.Windows.Forms.Label();
            this.lb_nom_tal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ide_doc = new System.Windows.Forms.Label();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.tb_ges_tio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ges_tio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_tal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_tal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_cam_mod = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(268, 24);
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
            this.mn_mod_ifi.Click += new System.EventHandler(this.mn_mod_ifi_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(121, 22);
            this.mn_eli_min.Text = "E&limina";
            this.mn_eli_min.Click += new System.EventHandler(this.mn_eli_min_Click);
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(66, 20);
            this.mn_con_sul.Text = "&Consulta";
            this.mn_con_sul.Click += new System.EventHandler(this.mn_con_sul_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_lis_nta});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_nta
            // 
            this.mn_lis_nta.Name = "mn_lis_nta";
            this.mn_lis_nta.Size = new System.Drawing.Size(229, 22);
            this.mn_lis_nta.Text = "&Lista Numerador de Talonario";
            this.mn_lis_nta.Click += new System.EventHandler(this.mn_lis_nta_Click);
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.tb_nro_tal);
            this.groupBox1.Controls.Add(this.tb_ide_doc);
            this.groupBox1.Controls.Add(this.lb_lin_sep);
            this.groupBox1.Controls.Add(this.lb_nom_tal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_ide_doc);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.tb_ges_tio);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(403, 33);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(114, 21);
            this.cb_est_bus.TabIndex = 11;
            // 
            // tb_nro_tal
            // 
            this.tb_nro_tal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_tal.Location = new System.Drawing.Point(97, 10);
            this.tb_nro_tal.MaxLength = 3;
            this.tb_nro_tal.Name = "tb_nro_tal";
            this.tb_nro_tal.Size = new System.Drawing.Size(27, 20);
            this.tb_nro_tal.TabIndex = 3;
            this.tb_nro_tal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nro_tal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_nro_tal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_tal_KeyPress);
            this.tb_nro_tal.Validated += new System.EventHandler(this.tb_nro_tal_Validated);
            // 
            // tb_ide_doc
            // 
            this.tb_ide_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_doc.Location = new System.Drawing.Point(58, 10);
            this.tb_ide_doc.MaxLength = 3;
            this.tb_ide_doc.Name = "tb_ide_doc";
            this.tb_ide_doc.Size = new System.Drawing.Size(32, 20);
            this.tb_ide_doc.TabIndex = 1;
            this.tb_ide_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_doc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_ide_doc.Validated += new System.EventHandler(this.tb_ide_doc_Validated);
            // 
            // lb_lin_sep
            // 
            this.lb_lin_sep.AutoSize = true;
            this.lb_lin_sep.Location = new System.Drawing.Point(89, 14);
            this.lb_lin_sep.Name = "lb_lin_sep";
            this.lb_lin_sep.Size = new System.Drawing.Size(10, 13);
            this.lb_lin_sep.TabIndex = 2;
            this.lb_lin_sep.Text = "-";
            // 
            // lb_nom_tal
            // 
            this.lb_nom_tal.AutoSize = true;
            this.lb_nom_tal.Location = new System.Drawing.Point(126, 14);
            this.lb_nom_tal.Name = "lb_nom_tal";
            this.lb_nom_tal.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tal.TabIndex = 4;
            this.lb_nom_tal.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Talonario";
            // 
            // lb_ide_doc
            // 
            this.lb_ide_doc.AutoSize = true;
            this.lb_ide_doc.Location = new System.Drawing.Point(510, 13);
            this.lb_ide_doc.Name = "lb_ide_doc";
            this.lb_ide_doc.Size = new System.Drawing.Size(43, 13);
            this.lb_ide_doc.TabIndex = 5;
            this.lb_ide_doc.Text = "Gestión";
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(520, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 10;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.bt_bus_car_Click);
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Talonario",
            "Documento",
            "Cod. Documento"});
            this.cb_prm_bus.Location = new System.Drawing.Point(304, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 8;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(4, 34);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(296, 20);
            this.tb_tex_bus.TabIndex = 7;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // tb_ges_tio
            // 
            this.tb_ges_tio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ges_tio.Location = new System.Drawing.Point(555, 10);
            this.tb_ges_tio.MaxLength = 4;
            this.tb_ges_tio.Name = "tb_ges_tio";
            this.tb_ges_tio.Size = new System.Drawing.Size(39, 20);
            this.tb_ges_tio.TabIndex = 6;
            this.tb_ges_tio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ges_tio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_ges_tio.Validated += new System.EventHandler(this.tb_ges_tio_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 199);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_ges_tio,
            this.va_ide_doc,
            this.va_nom_doc,
            this.va_nro_tal,
            this.va_nom_tal,
            this.va_est_tal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.Location = new System.Drawing.Point(3, 9);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(593, 186);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            this.dg_res_ult.Enter += new System.EventHandler(this.dg_res_ult_Enter);
            // 
            // va_ges_tio
            // 
            this.va_ges_tio.HeaderText = "Gestion";
            this.va_ges_tio.Name = "va_ges_tio";
            this.va_ges_tio.Width = 50;
            // 
            // va_ide_doc
            // 
            this.va_ide_doc.HeaderText = "Codigo";
            this.va_ide_doc.Name = "va_ide_doc";
            this.va_ide_doc.Width = 50;
            // 
            // va_nom_doc
            // 
            this.va_nom_doc.HeaderText = "Documento";
            this.va_nom_doc.Name = "va_nom_doc";
            this.va_nom_doc.Width = 180;
            // 
            // va_nro_tal
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_nro_tal.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_nro_tal.HeaderText = "Nro";
            this.va_nro_tal.Name = "va_nro_tal";
            this.va_nro_tal.Width = 30;
            // 
            // va_nom_tal
            // 
            this.va_nom_tal.HeaderText = "Talonario";
            this.va_nom_tal.Name = "va_nom_tal";
            this.va_nom_tal.Width = 190;
            // 
            // va_est_tal
            // 
            this.va_est_tal.HeaderText = "Estado";
            this.va_est_tal.Name = "va_est_tal";
            this.va_est_tal.Width = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_cam_mod);
            this.groupBox3.Location = new System.Drawing.Point(2, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // bt_cam_mod
            // 
            this.bt_cam_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_cam_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cam_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_cam_mod.Location = new System.Drawing.Point(6, 10);
            this.bt_cam_mod.Name = "bt_cam_mod";
            this.bt_cam_mod.Size = new System.Drawing.Size(101, 23);
            this.bt_cam_mod.TabIndex = 0;
            this.bt_cam_mod.Text = "&Cambiar Módulo";
            this.bt_cam_mod.UseVisualStyleBackColor = false;
            this.bt_cam_mod.Click += new System.EventHandler(this.bt_cam_mod_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.lb_nom_mod);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(116, 242);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(485, 40);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_mod.Location = new System.Drawing.Point(6, 15);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_mod.TabIndex = 6;
            this.lb_nom_mod.Text = "...";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(327, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 0;
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
            this.bt_can_cel.Location = new System.Drawing.Point(405, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads005_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 283);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads005_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Numeración";
            this.Text = "Busca Numeración";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_bus_car;
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_nta;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        private System.Windows.Forms.TextBox tb_ges_tio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_cam_mod;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_ide_doc;
        public System.Windows.Forms.TextBox tb_nro_tal;
        private System.Windows.Forms.TextBox tb_ide_doc;
        public System.Windows.Forms.Label lb_lin_sep;
        public System.Windows.Forms.Label lb_nom_tal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_est_bus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ges_tio;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nro_tal;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tal;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_tal;
        private System.Windows.Forms.Label lb_nom_mod;
    }
}