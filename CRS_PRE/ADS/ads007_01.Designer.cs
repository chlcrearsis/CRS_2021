namespace CRS_PRE
{
    partial class ads007_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_hab_des = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ini_psw = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rei_per = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cam_tus = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_pin = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ini_pin = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_usr = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_usu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_tal = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_plv = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_plv_res = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_apl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_lis = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_tip_usu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nom_usr = new System.Windows.Forms.Label();
            this.lb_ide_usr = new System.Windows.Forms.Label();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_car_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_nom_tus = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_tip_usr = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.mn_per_usu,
            this.mn_tip_usu,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(25, 63);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(556, 24);
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
            this.mn_eli_min,
            this.mn_ini_psw,
            this.mn_rei_per,
            this.mn_cam_tus,
            this.mn_mod_pin,
            this.mn_ini_pin});
            this.mn_edi_tar.Name = "mn_edi_tar";
            this.mn_edi_tar.Size = new System.Drawing.Size(45, 20);
            this.mn_edi_tar.Text = "&Edita";
            // 
            // mn_mod_ifi
            // 
            this.mn_mod_ifi.Name = "mn_mod_ifi";
            this.mn_mod_ifi.Size = new System.Drawing.Size(261, 22);
            this.mn_mod_ifi.Text = "&Modifica";
            this.mn_mod_ifi.Click += new System.EventHandler(this.mn_mod_ifi_Click);
            // 
            // mn_hab_des
            // 
            this.mn_hab_des.Name = "mn_hab_des";
            this.mn_hab_des.Size = new System.Drawing.Size(261, 22);
            this.mn_hab_des.Text = "&Habilita/Deshabilita";
            this.mn_hab_des.Click += new System.EventHandler(this.mn_hab_des_Click);
            // 
            // mn_eli_min
            // 
            this.mn_eli_min.Name = "mn_eli_min";
            this.mn_eli_min.Size = new System.Drawing.Size(261, 22);
            this.mn_eli_min.Text = "&Elimina";
            this.mn_eli_min.Click += new System.EventHandler(this.mn_eli_min_Click);
            // 
            // mn_ini_psw
            // 
            this.mn_ini_psw.Name = "mn_ini_psw";
            this.mn_ini_psw.Size = new System.Drawing.Size(261, 22);
            this.mn_ini_psw.Text = "&Inicializa contraseña";
            this.mn_ini_psw.Click += new System.EventHandler(this.mn_ini_psw_Click);
            // 
            // mn_rei_per
            // 
            this.mn_rei_per.Name = "mn_rei_per";
            this.mn_rei_per.Size = new System.Drawing.Size(261, 22);
            this.mn_rei_per.Text = "&Reinicia Permisos";
            this.mn_rei_per.Click += new System.EventHandler(this.mn_rei_per_Click);
            // 
            // mn_cam_tus
            // 
            this.mn_cam_tus.Name = "mn_cam_tus";
            this.mn_cam_tus.Size = new System.Drawing.Size(261, 22);
            this.mn_cam_tus.Text = "Cambia Permisos s/&Tipo de Usuario";
            this.mn_cam_tus.Click += new System.EventHandler(this.mn_cam_tus_Click);
            // 
            // mn_mod_pin
            // 
            this.mn_mod_pin.Name = "mn_mod_pin";
            this.mn_mod_pin.Size = new System.Drawing.Size(261, 22);
            this.mn_mod_pin.Text = "Modifica &PIN";
            this.mn_mod_pin.Click += new System.EventHandler(this.mn_mod_pin_Click);
            // 
            // mn_ini_pin
            // 
            this.mn_ini_pin.Name = "mn_ini_pin";
            this.mn_ini_pin.Size = new System.Drawing.Size(261, 22);
            this.mn_ini_pin.Text = "Inicializa PIN";
            this.mn_ini_pin.Click += new System.EventHandler(this.mn_ini_pin_Click);
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
            this.mn_lis_usr});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(60, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_lis_usr
            // 
            this.mn_lis_usr.Name = "mn_lis_usr";
            this.mn_lis_usr.Size = new System.Drawing.Size(180, 22);
            this.mn_lis_usr.Text = "&Lista de usuarios";
            this.mn_lis_usr.Click += new System.EventHandler(this.mn_lis_usr_Click);
            // 
            // mn_per_usu
            // 
            this.mn_per_usu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_per_tal,
            this.mn_per_plv,
            this.mn_per_plv_res,
            this.mn_per_apl,
            this.mn_per_lis});
            this.mn_per_usu.Name = "mn_per_usu";
            this.mn_per_usu.Size = new System.Drawing.Size(67, 20);
            this.mn_per_usu.Text = "&Permisos";
            // 
            // mn_per_tal
            // 
            this.mn_per_tal.Name = "mn_per_tal";
            this.mn_per_tal.Size = new System.Drawing.Size(285, 22);
            this.mn_per_tal.Text = "Permiso de Talonaios";
            this.mn_per_tal.Click += new System.EventHandler(this.mn_per_tal_Click);
            // 
            // mn_per_plv
            // 
            this.mn_per_plv.Name = "mn_per_plv";
            this.mn_per_plv.Size = new System.Drawing.Size(285, 22);
            this.mn_per_plv.Text = "Permiso de Plantilla de Venta";
            this.mn_per_plv.Click += new System.EventHandler(this.mn_per_plv_Click);
            // 
            // mn_per_plv_res
            // 
            this.mn_per_plv_res.Name = "mn_per_plv_res";
            this.mn_per_plv_res.Size = new System.Drawing.Size(285, 22);
            this.mn_per_plv_res.Text = "Permiso de Plantilla de Venta Restaurant";
            this.mn_per_plv_res.Click += new System.EventHandler(this.mn_per_plv_res_Click);
            // 
            // mn_per_apl
            // 
            this.mn_per_apl.Name = "mn_per_apl";
            this.mn_per_apl.Size = new System.Drawing.Size(285, 22);
            this.mn_per_apl.Text = "Permiso de aplicaciones";
            this.mn_per_apl.Click += new System.EventHandler(this.mn_per_apl_Click);
            // 
            // mn_per_lis
            // 
            this.mn_per_lis.Name = "mn_per_lis";
            this.mn_per_lis.Size = new System.Drawing.Size(285, 22);
            this.mn_per_lis.Text = "S/Lista de precios";
            this.mn_per_lis.Click += new System.EventHandler(this.mn_per_lis_Click);
            // 
            // mn_tip_usu
            // 
            this.mn_tip_usu.Name = "mn_tip_usu";
            this.mn_tip_usu.Size = new System.Drawing.Size(101, 20);
            this.mn_tip_usu.Text = "&Tipo de Usuario";
            this.mn_tip_usu.Click += new System.EventHandler(this.mn_tip_usu_Click);
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
            this.groupBox1.Controls.Add(this.lb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_ide_usr);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 60);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.Location = new System.Drawing.Point(135, 13);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_usr.TabIndex = 32;
            this.lb_nom_usr.Text = "...";
            // 
            // lb_ide_usr
            // 
            this.lb_ide_usr.AutoSize = true;
            this.lb_ide_usr.Location = new System.Drawing.Point(6, 14);
            this.lb_ide_usr.Name = "lb_ide_usr";
            this.lb_ide_usr.Size = new System.Drawing.Size(43, 13);
            this.lb_ide_usr.TabIndex = 31;
            this.lb_ide_usr.Text = "Usuario";
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(492, 32);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 25);
            this.bt_bus_car.TabIndex = 30;
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
            this.cb_est_bus.Location = new System.Drawing.Point(375, 34);
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
            "Nombre",
            "Cargo"});
            this.cb_prm_bus.Location = new System.Drawing.Point(276, 34);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 20;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(4, 35);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(268, 20);
            this.tb_tex_bus.TabIndex = 15;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(51, 10);
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.Size = new System.Drawing.Size(82, 20);
            this.tb_ide_usr.TabIndex = 10;
            this.tb_ide_usr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_ide_usr.Validated += new System.EventHandler(this.tb_ide_usr_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 221);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.AllowUserToResizeRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_ide_usr,
            this.va_nom_usr,
            this.va_nom_tus,
            this.va_car_usr,
            this.va_est_ado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(4, 9);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(580, 207);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            this.dg_res_ult.Enter += new System.EventHandler(this.dg_res_ult_Enter);
            // 
            // va_ide_usr
            // 
            this.va_ide_usr.HeaderText = "Codigo";
            this.va_ide_usr.Name = "va_ide_usr";
            this.va_ide_usr.ReadOnly = true;
            this.va_ide_usr.Width = 80;
            // 
            // va_nom_usr
            // 
            this.va_nom_usr.HeaderText = "Nombre";
            this.va_nom_usr.Name = "va_nom_usr";
            this.va_nom_usr.ReadOnly = true;
            this.va_nom_usr.Width = 170;
            // 
            // va_nom_tus
            // 
            this.va_nom_tus.HeaderText = "Tip. Usuario";
            this.va_nom_tus.Name = "va_nom_tus";
            this.va_nom_tus.ReadOnly = true;
            this.va_nom_tus.Width = 110;
            // 
            // va_car_usr
            // 
            this.va_car_usr.HeaderText = "Cargo";
            this.va_car_usr.Name = "va_car_usr";
            this.va_car_usr.ReadOnly = true;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.lb_nom_tus);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(105, 267);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(484, 40);
            this.gb_ctr_btn.TabIndex = 32;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_nom_tus
            // 
            this.lb_nom_tus.AutoSize = true;
            this.lb_nom_tus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_tus.Location = new System.Drawing.Point(6, 16);
            this.lb_nom_tus.Name = "lb_nom_tus";
            this.lb_nom_tus.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_tus.TabIndex = 33;
            this.lb_nom_tus.Text = "...";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(329, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 46;
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
            this.bt_can_cel.Location = new System.Drawing.Point(407, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // bt_tip_usr
            // 
            this.bt_tip_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_tip_usr.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_tip_usr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_tip_usr.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_tip_usr.Location = new System.Drawing.Point(4, 10);
            this.bt_tip_usr.Name = "bt_tip_usr";
            this.bt_tip_usr.Size = new System.Drawing.Size(94, 25);
            this.bt_tip_usr.TabIndex = 9;
            this.bt_tip_usr.Text = "&Tipo Usuario";
            this.bt_tip_usr.UseVisualStyleBackColor = false;
            this.bt_tip_usr.Visible = false;
            this.bt_tip_usr.Click += new System.EventHandler(this.bt_tip_usr_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_tip_usr);
            this.groupBox3.Location = new System.Drawing.Point(2, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 40);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // ads007_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 308);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads007_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Usuario";
            this.Text = "Busca Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_bus_car;
        private System.Windows.Forms.ComboBox cb_est_bus;
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
        private System.Windows.Forms.ToolStripMenuItem mn_hab_des;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_usr;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        private System.Windows.Forms.ToolStripMenuItem mn_per_usu;
        private System.Windows.Forms.ToolStripMenuItem mn_per_tal;
        private System.Windows.Forms.ToolStripMenuItem mn_per_plv;
        private System.Windows.Forms.ToolStripMenuItem mn_per_plv_res;
        private System.Windows.Forms.ToolStripMenuItem mn_per_apl;
        private System.Windows.Forms.ToolStripMenuItem mn_per_lis;
        private System.Windows.Forms.ToolStripMenuItem mn_tip_usu;
        private System.Windows.Forms.ToolStripMenuItem mn_ini_psw;
        private System.Windows.Forms.ToolStripMenuItem mn_rei_per;
        private System.Windows.Forms.ToolStripMenuItem mn_cam_tus;
        public System.Windows.Forms.TextBox tb_ide_usr;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_pin;
        private System.Windows.Forms.ToolStripMenuItem mn_ini_pin;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nom_tus;
        private System.Windows.Forms.Button bt_tip_usr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lb_ide_usr;
        public System.Windows.Forms.Label lb_nom_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_car_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}