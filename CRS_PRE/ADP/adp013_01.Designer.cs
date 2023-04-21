namespace CRS_PRE
{
    partial class adp013_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_hab_des = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_raz_soc = new System.Windows.Forms.TextBox();
            this.lb_nom_con = new System.Windows.Forms.Label();
            this.lb_cod_per = new System.Windows.Forms.Label();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.tb_cod_per = new System.Windows.Forms.TextBox();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_cod_con = new System.Windows.Forms.Label();
            this.tb_cod_con = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_cod_con = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_bre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ape_pat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ape_mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_par_con = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nro_cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_tel_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cel_ula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ema_ail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_dir_ubi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_est_ado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
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
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(208, 24);
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
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(66, 20);
            this.mn_con_sul.Text = "&Consulta";
            this.mn_con_sul.Click += new System.EventHandler(this.mn_con_sul_Click);
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
            this.groupBox1.Controls.Add(this.tb_raz_soc);
            this.groupBox1.Controls.Add(this.lb_nom_con);
            this.groupBox1.Controls.Add(this.lb_cod_per);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.tb_cod_per);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_cod_con);
            this.groupBox1.Controls.Add(this.tb_cod_con);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_raz_soc
            // 
            this.tb_raz_soc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_raz_soc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_raz_soc.Location = new System.Drawing.Point(457, 11);
            this.tb_raz_soc.MaxLength = 2;
            this.tb_raz_soc.Name = "tb_raz_soc";
            this.tb_raz_soc.ReadOnly = true;
            this.tb_raz_soc.Size = new System.Drawing.Size(296, 20);
            this.tb_raz_soc.TabIndex = 5;
            // 
            // lb_nom_con
            // 
            this.lb_nom_con.AutoSize = true;
            this.lb_nom_con.Location = new System.Drawing.Point(101, 14);
            this.lb_nom_con.Name = "lb_nom_con";
            this.lb_nom_con.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_con.TabIndex = 2;
            this.lb_nom_con.Text = "....";
            // 
            // lb_cod_per
            // 
            this.lb_cod_per.AutoSize = true;
            this.lb_cod_per.Location = new System.Drawing.Point(361, 14);
            this.lb_cod_per.Name = "lb_cod_per";
            this.lb_cod_per.Size = new System.Drawing.Size(46, 13);
            this.lb_cod_per.TabIndex = 3;
            this.lb_cod_per.Text = "Persona";
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(679, 34);
            this.bt_bus_car.Name = "bt_bus_car";
            this.bt_bus_car.Size = new System.Drawing.Size(75, 23);
            this.bt_bus_car.TabIndex = 9;
            this.bt_bus_car.Text = "&Buscar";
            this.bt_bus_car.UseVisualStyleBackColor = false;
            this.bt_bus_car.Click += new System.EventHandler(this.bt_bus_car_Click);
            // 
            // tb_cod_per
            // 
            this.tb_cod_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_per.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_per.Location = new System.Drawing.Point(409, 11);
            this.tb_cod_per.MaxLength = 2;
            this.tb_cod_per.Name = "tb_cod_per";
            this.tb_cod_per.ReadOnly = true;
            this.tb_cod_per.Size = new System.Drawing.Size(45, 20);
            this.tb_cod_per.TabIndex = 4;
            this.tb_cod_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_est_bus
            // 
            this.cb_est_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_bus.FormattingEnabled = true;
            this.cb_est_bus.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_bus.Location = new System.Drawing.Point(570, 35);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(103, 21);
            this.cb_est_bus.TabIndex = 8;
            // 
            // cb_prm_bus
            // 
            this.cb_prm_bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prm_bus.FormattingEnabled = true;
            this.cb_prm_bus.Items.AddRange(new object[] {
            "Código",
            "Razon Social",
            "Nombre",
            "Ape. Paterno",
            "Ape. Materno",
            "NIT",
            "Documento",
            "Teléfono"});
            this.cb_prm_bus.Location = new System.Drawing.Point(458, 35);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(108, 21);
            this.cb_prm_bus.TabIndex = 7;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(7, 35);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(447, 20);
            this.tb_tex_bus.TabIndex = 6;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            // 
            // lb_cod_con
            // 
            this.lb_cod_con.AutoSize = true;
            this.lb_cod_con.Location = new System.Drawing.Point(5, 13);
            this.lb_cod_con.Name = "lb_cod_con";
            this.lb_cod_con.Size = new System.Drawing.Size(50, 13);
            this.lb_cod_con.TabIndex = 0;
            this.lb_cod_con.Text = "Contanto";
            // 
            // tb_cod_con
            // 
            this.tb_cod_con.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_con.Location = new System.Drawing.Point(56, 10);
            this.tb_cod_con.MaxLength = 6;
            this.tb_cod_con.Name = "tb_cod_con";
            this.tb_cod_con.Size = new System.Drawing.Size(42, 20);
            this.tb_cod_con.TabIndex = 1;
            this.tb_cod_con.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_cod_con.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_pre_tec_KeyDown);
            this.tb_cod_con.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_cod_con_KeyPress);
            this.tb_cod_con.Validated += new System.EventHandler(this.tb_cod_con_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 221);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_res_ult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_con,
            this.va_nom_bre,
            this.va_ape_pat,
            this.va_ape_mat,
            this.va_par_con,
            this.va_nro_cid,
            this.va_tel_per,
            this.va_cel_ula,
            this.va_ema_ail,
            this.va_dir_ubi,
            this.va_est_ado});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle6;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 11);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(747, 203);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            this.dg_res_ult.Enter += new System.EventHandler(this.dg_res_ult_Enter);
            // 
            // va_cod_con
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_cod_con.DefaultCellStyle = dataGridViewCellStyle5;
            this.va_cod_con.HeaderText = "Código";
            this.va_cod_con.Name = "va_cod_con";
            this.va_cod_con.ReadOnly = true;
            this.va_cod_con.Width = 55;
            // 
            // va_nom_bre
            // 
            this.va_nom_bre.HeaderText = "Nombre";
            this.va_nom_bre.Name = "va_nom_bre";
            this.va_nom_bre.ReadOnly = true;
            this.va_nom_bre.Width = 120;
            // 
            // va_ape_pat
            // 
            this.va_ape_pat.HeaderText = "Ape. Paterno";
            this.va_ape_pat.Name = "va_ape_pat";
            this.va_ape_pat.ReadOnly = true;
            this.va_ape_pat.Width = 110;
            // 
            // va_ape_mat
            // 
            this.va_ape_mat.HeaderText = "Ape. Materno";
            this.va_ape_mat.Name = "va_ape_mat";
            this.va_ape_mat.ReadOnly = true;
            this.va_ape_mat.Width = 110;
            // 
            // va_par_con
            // 
            this.va_par_con.HeaderText = "Parentesco";
            this.va_par_con.Name = "va_par_con";
            this.va_par_con.ReadOnly = true;
            this.va_par_con.Width = 120;
            // 
            // va_nro_cid
            // 
            this.va_nro_cid.HeaderText = "N° C.I.";
            this.va_nro_cid.Name = "va_nro_cid";
            this.va_nro_cid.ReadOnly = true;
            this.va_nro_cid.Width = 90;
            // 
            // va_tel_per
            // 
            this.va_tel_per.HeaderText = "Tel. Personal";
            this.va_tel_per.Name = "va_tel_per";
            this.va_tel_per.ReadOnly = true;
            this.va_tel_per.Width = 105;
            // 
            // va_cel_ula
            // 
            this.va_cel_ula.HeaderText = "Tel. Célular";
            this.va_cel_ula.Name = "va_cel_ula";
            this.va_cel_ula.ReadOnly = true;
            this.va_cel_ula.Width = 105;
            // 
            // va_ema_ail
            // 
            this.va_ema_ail.HeaderText = "Email";
            this.va_ema_ail.Name = "va_ema_ail";
            this.va_ema_ail.ReadOnly = true;
            this.va_ema_ail.Width = 120;
            // 
            // va_dir_ubi
            // 
            this.va_dir_ubi.HeaderText = "Dirección";
            this.va_dir_ubi.Name = "va_dir_ubi";
            this.va_dir_ubi.ReadOnly = true;
            this.va_dir_ubi.Width = 200;
            // 
            // va_est_ado
            // 
            this.va_est_ado.HeaderText = "Estado";
            this.va_est_ado.Name = "va_est_ado";
            this.va_est_ado.ReadOnly = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 269);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(759, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(602, 10);
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
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(679, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp013_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(764, 311);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp013_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Contacto p/Persona";
            this.Text = "Busca Contacto p/Persona";
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
        private System.Windows.Forms.Label lb_cod_con;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_hab_des;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.TextBox tb_cod_con;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_cod_per;
        private System.Windows.Forms.TextBox tb_cod_per;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.Label lb_nom_con;
        private System.Windows.Forms.TextBox tb_raz_soc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_con;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_bre;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ape_pat;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ape_mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_par_con;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nro_cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tel_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cel_ula;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ema_ail;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_dir_ubi;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
    }
}