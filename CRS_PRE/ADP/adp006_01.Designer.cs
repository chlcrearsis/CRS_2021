namespace CRS_PRE
{
    partial class adp006_01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.mn_nue_reg = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_edi_tar = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ifi = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_eli_min = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_con_sul = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_cer_rar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_tip_doc = new System.Windows.Forms.TextBox();
            this.tb_ext_doc = new System.Windows.Forms.TextBox();
            this.tb_nro_doc = new System.Windows.Forms.TextBox();
            this.tb_raz_soc = new System.Windows.Forms.TextBox();
            this.lb_cod_per = new System.Windows.Forms.Label();
            this.tb_cod_per = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.pb_ima_per = new System.Windows.Forms.PictureBox();
            this.va_tam_arc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ext_arc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.m_frm_hja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_per)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
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
            // mn_cer_rar
            // 
            this.mn_cer_rar.Name = "mn_cer_rar";
            this.mn_cer_rar.Size = new System.Drawing.Size(46, 20);
            this.mn_cer_rar.Text = "&Atras";
            this.mn_cer_rar.Click += new System.EventHandler(this.mn_cer_rar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_tip_doc);
            this.groupBox1.Controls.Add(this.tb_ext_doc);
            this.groupBox1.Controls.Add(this.tb_nro_doc);
            this.groupBox1.Controls.Add(this.tb_raz_soc);
            this.groupBox1.Controls.Add(this.lb_cod_per);
            this.groupBox1.Controls.Add(this.tb_cod_per);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 38);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_tip_doc
            // 
            this.tb_tip_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tip_doc.Location = new System.Drawing.Point(399, 12);
            this.tb_tip_doc.MaxLength = 30;
            this.tb_tip_doc.Multiline = true;
            this.tb_tip_doc.Name = "tb_tip_doc";
            this.tb_tip_doc.ReadOnly = true;
            this.tb_tip_doc.Size = new System.Drawing.Size(34, 18);
            this.tb_tip_doc.TabIndex = 3;
            this.tb_tip_doc.TabStop = false;
            this.tb_tip_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_tip_doc.WordWrap = false;
            // 
            // tb_ext_doc
            // 
            this.tb_ext_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ext_doc.Location = new System.Drawing.Point(512, 12);
            this.tb_ext_doc.MaxLength = 30;
            this.tb_ext_doc.Multiline = true;
            this.tb_ext_doc.Name = "tb_ext_doc";
            this.tb_ext_doc.ReadOnly = true;
            this.tb_ext_doc.Size = new System.Drawing.Size(34, 18);
            this.tb_ext_doc.TabIndex = 5;
            this.tb_ext_doc.TabStop = false;
            this.tb_ext_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ext_doc.WordWrap = false;
            // 
            // tb_nro_doc
            // 
            this.tb_nro_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_doc.Location = new System.Drawing.Point(437, 12);
            this.tb_nro_doc.MaxLength = 30;
            this.tb_nro_doc.Multiline = true;
            this.tb_nro_doc.Name = "tb_nro_doc";
            this.tb_nro_doc.ReadOnly = true;
            this.tb_nro_doc.Size = new System.Drawing.Size(71, 18);
            this.tb_nro_doc.TabIndex = 4;
            this.tb_nro_doc.TabStop = false;
            this.tb_nro_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nro_doc.WordWrap = false;
            // 
            // tb_raz_soc
            // 
            this.tb_raz_soc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_raz_soc.Location = new System.Drawing.Point(110, 12);
            this.tb_raz_soc.MaxLength = 30;
            this.tb_raz_soc.Multiline = true;
            this.tb_raz_soc.Name = "tb_raz_soc";
            this.tb_raz_soc.ReadOnly = true;
            this.tb_raz_soc.Size = new System.Drawing.Size(268, 18);
            this.tb_raz_soc.TabIndex = 2;
            this.tb_raz_soc.TabStop = false;
            this.tb_raz_soc.WordWrap = false;
            // 
            // lb_cod_per
            // 
            this.lb_cod_per.AutoSize = true;
            this.lb_cod_per.Location = new System.Drawing.Point(4, 14);
            this.lb_cod_per.Name = "lb_cod_per";
            this.lb_cod_per.Size = new System.Drawing.Size(46, 13);
            this.lb_cod_per.TabIndex = 0;
            this.lb_cod_per.Text = "Persona";
            // 
            // tb_cod_per
            // 
            this.tb_cod_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_per.Location = new System.Drawing.Point(51, 12);
            this.tb_cod_per.MaxLength = 15;
            this.tb_cod_per.Multiline = true;
            this.tb_cod_per.Name = "tb_cod_per";
            this.tb_cod_per.ReadOnly = true;
            this.tb_cod_per.Size = new System.Drawing.Size(55, 18);
            this.tb_cod_per.TabIndex = 1;
            this.tb_cod_per.TabStop = false;
            this.tb_cod_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_cod_per.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_frm_hja);
            this.groupBox2.Controls.Add(this.pb_ima_per);
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 193);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 215);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(563, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(394, 11);
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
            this.bt_can_cel.Location = new System.Drawing.Point(473, 11);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // pb_ima_per
            // 
            this.pb_ima_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ima_per.Location = new System.Drawing.Point(380, 7);
            this.pb_ima_per.Name = "pb_ima_per";
            this.pb_ima_per.Size = new System.Drawing.Size(180, 180);
            this.pb_ima_per.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ima_per.TabIndex = 6;
            this.pb_ima_per.TabStop = false;
            // 
            // va_tam_arc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.va_tam_arc.DefaultCellStyle = dataGridViewCellStyle3;
            this.va_tam_arc.HeaderText = "Tamaño (KB)";
            this.va_tam_arc.Name = "va_tam_arc";
            this.va_tam_arc.ReadOnly = true;
            this.va_tam_arc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_tam_arc.Width = 103;
            // 
            // va_ext_arc
            // 
            this.va_ext_arc.HeaderText = "Ext.";
            this.va_ext_arc.Name = "va_ext_arc";
            this.va_ext_arc.ReadOnly = true;
            this.va_ext_arc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_ext_arc.Width = 45;
            // 
            // va_nom_tip
            // 
            this.va_nom_tip.HeaderText = "Descripción";
            this.va_nom_tip.Name = "va_nom_tip";
            this.va_nom_tip.ReadOnly = true;
            this.va_nom_tip.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_nom_tip.Width = 190;
            // 
            // va_ide_tip
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_ide_tip.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_ide_tip.HeaderText = "ID";
            this.va_ide_tip.Name = "va_ide_tip";
            this.va_ide_tip.ReadOnly = true;
            this.va_ide_tip.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_ide_tip.Width = 30;
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
            this.va_ide_tip,
            this.va_nom_tip,
            this.va_ext_arc,
            this.va_tam_arc});
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
            this.dg_res_ult.Size = new System.Drawing.Size(372, 180);
            this.dg_res_ult.TabIndex = 0;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            // 
            // adp006_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(568, 256);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_frm_hja;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp006_01";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Consulta Imagen Persona";
            this.Text = "Consulta Imagen Persona";
            this.Load += new System.EventHandler(this.frm_Load);
            this.m_frm_hja.ResumeLayout(false);
            this.m_frm_hja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_per)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.ToolStripMenuItem mn_nue_reg;
        private System.Windows.Forms.ToolStripMenuItem mn_edi_tar;
        private System.Windows.Forms.ToolStripMenuItem mn_cer_rar;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ifi;
        private System.Windows.Forms.ToolStripMenuItem mn_eli_min;
        private System.Windows.Forms.ToolStripMenuItem mn_con_sul;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.TextBox tb_nro_doc;
        private System.Windows.Forms.TextBox tb_raz_soc;
        private System.Windows.Forms.Label lb_cod_per;
        private System.Windows.Forms.TextBox tb_cod_per;
        private System.Windows.Forms.TextBox tb_tip_doc;
        private System.Windows.Forms.TextBox tb_ext_doc;
        private System.Windows.Forms.PictureBox pb_ima_per;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ext_arc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_tam_arc;
    }
}