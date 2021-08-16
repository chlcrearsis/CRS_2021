namespace CRS_PRE.CMR
{
    partial class cmr007_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_anu_vta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_vta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_vta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_vta_del = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_res_vta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_cod_bod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_cod_per = new System.Windows.Forms.TextBox();
            this.bt_bus_per = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_fec_fin = new System.Windows.Forms.DateTimePicker();
            this.tb_fec_ini = new System.Windows.Forms.DateTimePicker();
            this.tb_sel_ide = new System.Windows.Forms.MaskedTextBox();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_ado = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.lb_nom_bod = new System.Windows.Forms.Label();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_raz_soc = new System.Windows.Forms.Label();
            this.lb_des_bus = new System.Windows.Forms.Label();
            this.tb_sel_ano = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_fec_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_doc_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cod_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_raz_soc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tot_vtB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_obs_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ges_ped = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.mn_edi_tar,
            this.mn_con_sul,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(215, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_edi_tar
            // 
            this.mn_edi_tar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ifi,
            this.mn_anu_vta,
            this.mn_eli_min});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(43, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(113, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.Mn_mod_ifi_Click);
            // 
            // mn_anu_vta
            // 
            this.mn_anu_vta.Name = "mn_anu_vta";
            this.mn_anu_vta.Size = new System.Drawing.Size(113, 22);
            this.mn_anu_vta.Text = "&Anula";
            this.mn_anu_vta.Click += new System.EventHandler(this.mn_anu_ped_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(113, 22);
            this.mn_eli_min.Text = "E&limina";
            this.mn_eli_min.Click += new System.EventHandler(this.Mn_eli_min_Click);
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_con_vta});
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(61, 20);
            this.mn_con_sul.Text = "&Consulta";
            // 
            // mn_con_vta
            // 
            this.mn_con_vta.Name = "mn_con_vta";
            this.mn_con_vta.Size = new System.Drawing.Size(147, 22);
            this.mn_con_vta.Text = "C&onsulta Venta";
            this.mn_con_vta.Click += new System.EventHandler(this.Mn_con_ped_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_lis_vta,
            this.mn_vta_del,
            this.mn_res_vta});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(58, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_vta
            // 
            this.mn_lis_vta.Name = "mn_lis_vta";
            this.mn_lis_vta.Size = new System.Drawing.Size(230, 22);
            this.mn_lis_vta.Text = "Lista de Ventas";
            this.mn_lis_vta.Click += new System.EventHandler(this.Mn_lis_ped_Click);
            // 
            // mn_vta_del
            // 
            this.mn_vta_del.Name = "mn_vta_del";
            this.mn_vta_del.Size = new System.Drawing.Size(230, 22);
            this.mn_vta_del.Text = "Ventas por Delivery";
            // 
            // mn_res_vta
            // 
            this.mn_res_vta.Name = "mn_res_vta";
            this.mn_res_vta.Size = new System.Drawing.Size(230, 22);
            this.mn_res_vta.Text = "Resumen de ventas por Delivery";
            // 
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(45, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.Mn_cer_rar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_cod_bod);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tb_cod_per);
            this.groupBox1.Controls.Add(this.bt_bus_per);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_fec_fin);
            this.groupBox1.Controls.Add(this.tb_fec_ini);
            this.groupBox1.Controls.Add(this.tb_sel_ide);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_ado);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.lb_nom_bod);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_raz_soc);
            this.groupBox1.Controls.Add(this.lb_des_bus);
            this.groupBox1.Controls.Add(this.tb_sel_ano);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tb_cod_bod
            // 
            this.tb_cod_bod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_bod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_bod.Location = new System.Drawing.Point(68, 57);
            this.tb_cod_bod.MaxLength = 5;
            this.tb_cod_bod.Name = "tb_cod_bod";
            this.tb_cod_bod.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_bod.TabIndex = 40;
            this.tb_cod_bod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_bod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_bod_KeyDown);
            this.tb_cod_bod.Validated += new System.EventHandler(this.Tb_cod_bod_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Doc.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Bodega";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Cliente";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(128, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 22);
            this.button1.TabIndex = 36;
            this.button1.TabStop = false;
            this.button1.Text = "|";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Bt_bus_bod_Click);
            // 
            // tb_cod_per
            // 
            this.tb_cod_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_per.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_per.Location = new System.Drawing.Point(68, 34);
            this.tb_cod_per.MaxLength = 6;
            this.tb_cod_per.Name = "tb_cod_per";
            this.tb_cod_per.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_per.TabIndex = 30;
            this.tb_cod_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_per.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_per_KeyDown);
            this.tb_cod_per.Validated += new System.EventHandler(this.Tb_cod_per_Validated);
            // 
            // bt_bus_per
            // 
            this.bt_bus_per.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_per.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_per.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_per.Location = new System.Drawing.Point(128, 33);
            this.bt_bus_per.Name = "bt_bus_per";
            this.bt_bus_per.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_per.TabIndex = 36;
            this.bt_bus_per.TabStop = false;
            this.bt_bus_per.Text = "|";
            this.bt_bus_per.UseVisualStyleBackColor = false;
            this.bt_bus_per.Click += new System.EventHandler(this.Bt_bus_per_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Del";
            // 
            // tb_fec_fin
            // 
            this.tb_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_fin.Location = new System.Drawing.Point(171, 83);
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_fin.TabIndex = 60;
            // 
            // tb_fec_ini
            // 
            this.tb_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_ini.Location = new System.Drawing.Point(38, 83);
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_ini.TabIndex = 50;
            // 
            // tb_sel_ide
            // 
            this.tb_sel_ide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_ide.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.tb_sel_ide.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_sel_ide.Location = new System.Drawing.Point(38, 10);
            this.tb_sel_ide.Mask = ">LLL-000-000000";
            this.tb_sel_ide.Name = "tb_sel_ide";
            this.tb_sel_ide.PromptChar = '0';
            this.tb_sel_ide.Size = new System.Drawing.Size(87, 20);
            this.tb_sel_ide.TabIndex = 10;
            this.tb_sel_ide.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.tb_sel_ide.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_ide.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(582, 106);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 100;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.Bt_bus_car_Click);
            // 
            // cb_est_ado
            // 
            this.cb_est_ado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_ado.FormattingEnabled = true;
            this.cb_est_ado.Items.AddRange(new object[] {
            "Todos",
            "Validos",
            "Anulados"});
            this.cb_est_ado.Location = new System.Drawing.Point(481, 107);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(95, 21);
            this.cb_est_ado.TabIndex = 90;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Observacion"});
            this.cb_prm_bus.Location = new System.Drawing.Point(379, 107);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 80;
            // 
            // lb_nom_bod
            // 
            this.lb_nom_bod.Location = new System.Drawing.Point(147, 61);
            this.lb_nom_bod.Name = "lb_nom_bod";
            this.lb_nom_bod.Size = new System.Drawing.Size(251, 13);
            this.lb_nom_bod.TabIndex = 2;
            this.lb_nom_bod.Text = ".";
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(10, 108);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(366, 20);
            this.tb_tex_bus.TabIndex = 70;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            // 
            // lb_raz_soc
            // 
            this.lb_raz_soc.Location = new System.Drawing.Point(147, 38);
            this.lb_raz_soc.Name = "lb_raz_soc";
            this.lb_raz_soc.Size = new System.Drawing.Size(251, 13);
            this.lb_raz_soc.TabIndex = 2;
            this.lb_raz_soc.Text = ".";
            // 
            // lb_des_bus
            // 
            this.lb_des_bus.Location = new System.Drawing.Point(170, 13);
            this.lb_des_bus.Name = "lb_des_bus";
            this.lb_des_bus.Size = new System.Drawing.Size(204, 13);
            this.lb_des_bus.TabIndex = 2;
            this.lb_des_bus.Text = ".";
            // 
            // tb_sel_ano
            // 
            this.tb_sel_ano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_ano.Location = new System.Drawing.Point(130, 10);
            this.tb_sel_ano.MaxLength = 4;
            this.tb_sel_ano.Name = "tb_sel_ano";
            this.tb_sel_ano.Size = new System.Drawing.Size(37, 20);
            this.tb_sel_ano.TabIndex = 20;
            this.tb_sel_ano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            this.tb_sel_ano.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 275);
            this.groupBox2.TabIndex = 5;
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
            this.va_fec_ped,
            this.va_doc_ped,
            this.va_ide_ped,
            this.va_nro_ped,
            this.va_est_ado,
            this.va_cod_per,
            this.va_raz_soc,
            this.va_tot_vtB,
            this.va_obs_ped,
            this.va_ges_ped});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(651, 268);
            this.dg_res_ult.TabIndex = 110;
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_fec_ped
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.va_fec_ped.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_fec_ped.HeaderText = "Fecha";
            this.va_fec_ped.Name = "va_fec_ped";
            this.va_fec_ped.ReadOnly = true;
            this.va_fec_ped.Width = 80;
            // 
            // va_doc_ped
            // 
            this.va_doc_ped.HeaderText = "Doc.";
            this.va_doc_ped.Name = "va_doc_ped";
            this.va_doc_ped.ReadOnly = true;
            this.va_doc_ped.Visible = false;
            this.va_doc_ped.Width = 40;
            // 
            // va_ide_ped
            // 
            this.va_ide_ped.HeaderText = "ID Pedido";
            this.va_ide_ped.Name = "va_ide_ped";
            this.va_ide_ped.ReadOnly = true;
            // 
            // va_nro_ped
            // 
            this.va_nro_ped.HeaderText = "Nro.";
            this.va_nro_ped.Name = "va_nro_ped";
            this.va_nro_ped.ReadOnly = true;
            this.va_nro_ped.Visible = false;
            this.va_nro_ped.Width = 75;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            this.va_est_ado.Width = 50;
            // 
            // va_cod_per
            // 
            this.va_cod_per.HeaderText = "Codigo";
            this.va_cod_per.Name = "va_cod_per";
            this.va_cod_per.ReadOnly = true;
            this.va_cod_per.Width = 80;
            // 
            // va_raz_soc
            // 
            this.va_raz_soc.HeaderText = "Cliente";
            this.va_raz_soc.Name = "va_raz_soc";
            this.va_raz_soc.ReadOnly = true;
            this.va_raz_soc.Width = 180;
            // 
            // va_tot_vtB
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.va_tot_vtB.DefaultCellStyle = dataGridViewCellStyle3;
            this.va_tot_vtB.HeaderText = "Total Neto";
            this.va_tot_vtB.Name = "va_tot_vtB";
            this.va_tot_vtB.ReadOnly = true;
            this.va_tot_vtB.Width = 80;
            // 
            // va_obs_ped
            // 
            this.va_obs_ped.HeaderText = "Observaciones";
            this.va_obs_ped.Name = "va_obs_ped";
            this.va_obs_ped.ReadOnly = true;
            this.va_obs_ped.Width = 180;
            // 
            // va_ges_ped
            // 
            this.va_ges_ped.HeaderText = "Gestion";
            this.va_ges_ped.Name = "va_ges_ped";
            this.va_ges_ped.ReadOnly = true;
            this.va_ges_ped.Visible = false;
            this.va_ges_ped.Width = 40;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 399);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(670, 34);
            this.gb_ctr_btn.TabIndex = 10;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(576, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(495, 7);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            // 
            // cmr007_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 435);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr007_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Pedidos";
            this.Text = "Busca Pedidos";
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
        private System.Windows.Forms.ComboBox cb_est_ado;
        private System.Windows.Forms.ComboBox cb_prm_bus;
        private System.Windows.Forms.TextBox tb_tex_bus;
        private System.Windows.Forms.Label lb_des_bus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_vta;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.TextBox tb_sel_ano;
        private System.Windows.Forms.MaskedTextBox tb_sel_ide;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tb_fec_fin;
        private System.Windows.Forms.DateTimePicker tb_fec_ini;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cod_per;
        private System.Windows.Forms.Button bt_bus_per;
        private System.Windows.Forms.Label lb_raz_soc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mn_con_vta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_nom_bod;
        private System.Windows.Forms.TextBox tb_cod_bod;
        private System.Windows.Forms.ToolStripMenuItem mn_anu_vta;
        private System.Windows.Forms.ToolStripMenuItem mn_vta_del;
        private System.Windows.Forms.ToolStripMenuItem mn_res_vta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_fec_ped;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_doc_ped;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_ped;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nro_ped;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_raz_soc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tot_vtB;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_obs_ped;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ges_ped;
    }
}