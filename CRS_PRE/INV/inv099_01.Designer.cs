namespace CRS_PRE.INV
{
    partial class inv099_01
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
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_pro = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_exi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_kar_pro = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_rep_ort = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_list_fam = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_bus_fam = new System.Windows.Forms.Button();
            this.lb_pro_sel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sel_ecc = new System.Windows.Forms.TextBox();
            this.tb_cod_fam_bus = new System.Windows.Forms.MaskedTextBox();
            this.bt_bus_car = new System.Windows.Forms.Button();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.cb_prm_bus = new System.Windows.Forms.ComboBox();
            this.tb_tex_bus = new System.Windows.Forms.TextBox();
            this.lb_fam_bus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_cod_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cod_umd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_mar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_cod_fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_und_cmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_und_vta = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.mn_con_sul,
            this.mn_rep_ort,
            this.mn_cer_rar});
            this.m_frm_hja.Location = new System.Drawing.Point(141, 49);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(172, 24);
            this.m_frm_hja.TabIndex = 5;
            this.m_frm_hja.Visible = false;
            // 
            // mn_con_sul
            // 
            this.mn_con_sul.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_con_pro,
            this.mn_con_exi,
            this.mn_kar_pro});
            this.mn_con_sul.Name = "mn_con_sul";
            this.mn_con_sul.Size = new System.Drawing.Size(61, 20);
            this.mn_con_sul.Text = "&Consulta";
            // 
            // mn_con_pro
            // 
            this.mn_con_pro.Name = "mn_con_pro";
            this.mn_con_pro.Size = new System.Drawing.Size(198, 22);
            this.mn_con_pro.Text = "Consulta &producto";
            this.mn_con_pro.Click += new System.EventHandler(this.Mn_con_pro_Click);
            // 
            // mn_con_exi
            // 
            this.mn_con_exi.Name = "mn_con_exi";
            this.mn_con_exi.Size = new System.Drawing.Size(198, 22);
            this.mn_con_exi.Text = "Existencia de un &producto";
            this.mn_con_exi.Click += new System.EventHandler(this.Mn_con_exi_Click);
            // 
            // mn_kar_pro
            // 
            this.mn_kar_pro.Name = "mn_kar_pro";
            this.mn_kar_pro.Size = new System.Drawing.Size(198, 22);
            this.mn_kar_pro.Text = "&Kardex de producto";
            this.mn_kar_pro.Click += new System.EventHandler(this.mn_kar_pro_Click);
            // 
            // mn_rep_ort
            // 
            this.mn_rep_ort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_list_fam});
            this.mn_rep_ort.Name = "mn_rep_ort";
            this.mn_rep_ort.Size = new System.Drawing.Size(58, 20);
            this.mn_rep_ort.Text = "&Reporte";
            // 
            // mn_list_fam
            // 
            this.mn_list_fam.Name = "mn_list_fam";
            this.mn_list_fam.Size = new System.Drawing.Size(231, 22);
            this.mn_list_fam.Text = "&Existencias en bodega a la fecha";
            this.mn_list_fam.Click += new System.EventHandler(this.Mn_list_fam_Click);
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
            this.groupBox1.Controls.Add(this.bt_bus_fam);
            this.groupBox1.Controls.Add(this.lb_pro_sel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_sel_ecc);
            this.groupBox1.Controls.Add(this.tb_cod_fam_bus);
            this.groupBox1.Controls.Add(this.bt_bus_car);
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.cb_prm_bus);
            this.groupBox1.Controls.Add(this.tb_tex_bus);
            this.groupBox1.Controls.Add(this.lb_fam_bus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // bt_bus_fam
            // 
            this.bt_bus_fam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_fam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_fam.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_fam.Location = new System.Drawing.Point(491, 10);
            this.bt_bus_fam.Name = "bt_bus_fam";
            this.bt_bus_fam.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_fam.TabIndex = 21;
            this.bt_bus_fam.TabStop = false;
            this.bt_bus_fam.Text = "|";
            this.bt_bus_fam.UseVisualStyleBackColor = false;
            this.bt_bus_fam.Click += new System.EventHandler(this.bt_bus_fam_Click);
            // 
            // lb_pro_sel
            // 
            this.lb_pro_sel.Location = new System.Drawing.Point(145, 15);
            this.lb_pro_sel.Name = "lb_pro_sel";
            this.lb_pro_sel.Size = new System.Drawing.Size(231, 13);
            this.lb_pro_sel.TabIndex = 33;
            this.lb_pro_sel.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Producto";
            // 
            // tb_sel_ecc
            // 
            this.tb_sel_ecc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sel_ecc.Location = new System.Drawing.Point(59, 12);
            this.tb_sel_ecc.MaxLength = 6;
            this.tb_sel_ecc.Name = "tb_sel_ecc";
            this.tb_sel_ecc.Size = new System.Drawing.Size(83, 20);
            this.tb_sel_ecc.TabIndex = 34;
            this.tb_sel_ecc.Validated += new System.EventHandler(this.Tb_sel_bus_Validated);
            // 
            // tb_cod_fam_bus
            // 
            this.tb_cod_fam_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_fam_bus.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_fam_bus.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_fam_bus.Location = new System.Drawing.Point(443, 11);
            this.tb_cod_fam_bus.Mask = "00-00-00";
            this.tb_cod_fam_bus.Name = "tb_cod_fam_bus";
            this.tb_cod_fam_bus.PromptChar = '0';
            this.tb_cod_fam_bus.Size = new System.Drawing.Size(52, 20);
            this.tb_cod_fam_bus.TabIndex = 31;
            this.tb_cod_fam_bus.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_fam_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_fam_KeyDown);
            this.tb_cod_fam_bus.Validated += new System.EventHandler(this.tb_cod_fam_bus_Validated);
            // 
            // bt_bus_car
            // 
            this.bt_bus_car.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_car.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_car.Location = new System.Drawing.Point(586, 32);
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
            this.cb_est_bus.Location = new System.Drawing.Point(471, 33);
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
            "Nombre"});
            this.cb_prm_bus.Location = new System.Drawing.Point(370, 33);
            this.cb_prm_bus.Name = "cb_prm_bus";
            this.cb_prm_bus.Size = new System.Drawing.Size(95, 21);
            this.cb_prm_bus.TabIndex = 20;
            // 
            // tb_tex_bus
            // 
            this.tb_tex_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tex_bus.Location = new System.Drawing.Point(9, 34);
            this.tb_tex_bus.Name = "tb_tex_bus";
            this.tb_tex_bus.Size = new System.Drawing.Size(355, 20);
            this.tb_tex_bus.TabIndex = 15;
            this.tb_tex_bus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fi_sub_baj_fil_KeyDown);
            // 
            // lb_fam_bus
            // 
            this.lb_fam_bus.Location = new System.Drawing.Point(509, 14);
            this.lb_fam_bus.Name = "lb_fam_bus";
            this.lb_fam_bus.Size = new System.Drawing.Size(156, 13);
            this.lb_fam_bus.TabIndex = 2;
            this.lb_fam_bus.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Familia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 325);
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
            this.va_cod_pro,
            this.va_nom_pro,
            this.va_cod_umd,
            this.va_nom_mar,
            this.va_cod_fam,
            this.va_nom_fam,
            this.va_und_cmp,
            this.va_und_vta,
            this.va_est_ado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(655, 314);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_cod_pro
            // 
            dataGridViewCellStyle2.Format = "00-00-00";
            dataGridViewCellStyle2.NullValue = null;
            this.va_cod_pro.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_cod_pro.HeaderText = "Codigo";
            this.va_cod_pro.Name = "va_cod_pro";
            this.va_cod_pro.ReadOnly = true;
            this.va_cod_pro.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_cod_pro.Width = 60;
            // 
            // va_nom_pro
            // 
            this.va_nom_pro.HeaderText = "Producto";
            this.va_nom_pro.Name = "va_nom_pro";
            this.va_nom_pro.ReadOnly = true;
            this.va_nom_pro.Width = 200;
            // 
            // va_cod_umd
            // 
            this.va_cod_umd.HeaderText = "Uni. Med.";
            this.va_cod_umd.Name = "va_cod_umd";
            this.va_cod_umd.ReadOnly = true;
            this.va_cod_umd.Width = 40;
            // 
            // va_nom_mar
            // 
            this.va_nom_mar.HeaderText = "Marca";
            this.va_nom_mar.Name = "va_nom_mar";
            this.va_nom_mar.ReadOnly = true;
            this.va_nom_mar.Width = 60;
            // 
            // va_cod_fam
            // 
            this.va_cod_fam.HeaderText = "Cod. Fam.";
            this.va_cod_fam.Name = "va_cod_fam";
            this.va_cod_fam.ReadOnly = true;
            this.va_cod_fam.Width = 80;
            // 
            // va_nom_fam
            // 
            this.va_nom_fam.HeaderText = "Familia";
            this.va_nom_fam.Name = "va_nom_fam";
            this.va_nom_fam.ReadOnly = true;
            // 
            // va_und_cmp
            // 
            this.va_und_cmp.HeaderText = "Uni. Comp.";
            this.va_und_cmp.Name = "va_und_cmp";
            this.va_und_cmp.ReadOnly = true;
            this.va_und_cmp.Width = 40;
            // 
            // va_und_vta
            // 
            this.va_und_vta.HeaderText = "Uni. Ven.";
            this.va_und_vta.Name = "va_und_vta";
            this.va_und_vta.ReadOnly = true;
            this.va_und_vta.Width = 40;
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
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 368);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(672, 34);
            this.gb_ctr_btn.TabIndex = 8;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(572, 7);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(491, 7);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // inv099_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(678, 405);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inv099_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Busca Productos";
            this.Text = "Busca Productos";
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
        private System.Windows.Forms.Label lb_fam_bus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_rep_ort;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_list_fam;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.MaskedTextBox tb_cod_fam_bus;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_sel_ecc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_umd;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_mar;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_und_cmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_und_vta;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_est_ado;
        private System.Windows.Forms.Button bt_bus_fam;
        public System.Windows.Forms.Label lb_pro_sel;
        private System.Windows.Forms.ToolStripMenuItem mn_con_pro;
        private System.Windows.Forms.ToolStripMenuItem mn_con_exi;
        private System.Windows.Forms.ToolStripMenuItem mn_kar_pro;
    }
}