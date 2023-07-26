namespace CRS_PRE
{
    partial class ads004_10
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_est_bus = new System.Windows.Forms.ComboBox();
            this.tb_ide_doc = new System.Windows.Forms.TextBox();
            this.lb_nom_doc = new System.Windows.Forms.Label();
            this.lb_nro_tal = new System.Windows.Forms.Label();
            this.lb_nom_tal = new System.Windows.Forms.Label();
            this.lb_ide_doc = new System.Windows.Forms.Label();
            this.tb_nro_tal = new System.Windows.Forms.TextBox();
            this.cb_sel_tod = new System.Windows.Forms.CheckBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_opc_sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_tod_mod = new System.Windows.Forms.Button();
            this.lb_nom_tus = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_est_bus);
            this.groupBox1.Controls.Add(this.tb_ide_doc);
            this.groupBox1.Controls.Add(this.lb_nom_doc);
            this.groupBox1.Controls.Add(this.lb_nro_tal);
            this.groupBox1.Controls.Add(this.lb_nom_tal);
            this.groupBox1.Controls.Add(this.lb_ide_doc);
            this.groupBox1.Controls.Add(this.tb_nro_tal);
            this.groupBox1.Controls.Add(this.cb_sel_tod);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 62);
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
            this.cb_est_bus.Location = new System.Drawing.Point(315, 12);
            this.cb_est_bus.Name = "cb_est_bus";
            this.cb_est_bus.Size = new System.Drawing.Size(97, 21);
            this.cb_est_bus.TabIndex = 6;
            this.cb_est_bus.SelectedIndexChanged += new System.EventHandler(this.cb_est_bus_SelectedIndexChanged);
            // 
            // tb_ide_doc
            // 
            this.tb_ide_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_doc.Location = new System.Drawing.Point(62, 12);
            this.tb_ide_doc.MaxLength = 3;
            this.tb_ide_doc.Name = "tb_ide_doc";
            this.tb_ide_doc.ReadOnly = true;
            this.tb_ide_doc.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_doc.TabIndex = 1;
            this.tb_ide_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_nom_doc
            // 
            this.lb_nom_doc.AutoSize = true;
            this.lb_nom_doc.Location = new System.Drawing.Point(94, 16);
            this.lb_nom_doc.Name = "lb_nom_doc";
            this.lb_nom_doc.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_doc.TabIndex = 2;
            this.lb_nom_doc.Text = "...";
            // 
            // lb_nro_tal
            // 
            this.lb_nro_tal.AutoSize = true;
            this.lb_nro_tal.Location = new System.Drawing.Point(11, 38);
            this.lb_nro_tal.Name = "lb_nro_tal";
            this.lb_nro_tal.Size = new System.Drawing.Size(51, 13);
            this.lb_nro_tal.TabIndex = 3;
            this.lb_nro_tal.Text = "Talonario";
            // 
            // lb_nom_tal
            // 
            this.lb_nom_tal.AutoSize = true;
            this.lb_nom_tal.Location = new System.Drawing.Point(94, 38);
            this.lb_nom_tal.Name = "lb_nom_tal";
            this.lb_nom_tal.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tal.TabIndex = 5;
            this.lb_nom_tal.Text = "...";
            // 
            // lb_ide_doc
            // 
            this.lb_ide_doc.AutoSize = true;
            this.lb_ide_doc.Location = new System.Drawing.Point(1, 15);
            this.lb_ide_doc.Name = "lb_ide_doc";
            this.lb_ide_doc.Size = new System.Drawing.Size(62, 13);
            this.lb_ide_doc.TabIndex = 0;
            this.lb_ide_doc.Text = "Documento";
            // 
            // tb_nro_tal
            // 
            this.tb_nro_tal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_tal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nro_tal.Location = new System.Drawing.Point(62, 35);
            this.tb_nro_tal.MaxLength = 3;
            this.tb_nro_tal.Name = "tb_nro_tal";
            this.tb_nro_tal.ReadOnly = true;
            this.tb_nro_tal.Size = new System.Drawing.Size(30, 20);
            this.tb_nro_tal.TabIndex = 4;
            this.tb_nro_tal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_sel_tod
            // 
            this.cb_sel_tod.AutoSize = true;
            this.cb_sel_tod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_sel_tod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sel_tod.Location = new System.Drawing.Point(327, 37);
            this.cb_sel_tod.Name = "cb_sel_tod";
            this.cb_sel_tod.Size = new System.Drawing.Size(61, 17);
            this.cb_sel_tod.TabIndex = 6;
            this.cb_sel_tod.Text = "Todos";
            this.cb_sel_tod.UseVisualStyleBackColor = true;
            this.cb_sel_tod.CheckedChanged += new System.EventHandler(this.cb_sel_tod_CheckedChanged);
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
            this.va_opc_sel});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(3, 10);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(418, 189);
            this.dg_res_ult.TabIndex = 1;
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            // 
            // va_ide_usr
            // 
            this.va_ide_usr.HeaderText = "ID. Usuario";
            this.va_ide_usr.Name = "va_ide_usr";
            this.va_ide_usr.ReadOnly = true;
            this.va_ide_usr.Width = 91;
            // 
            // va_nom_usr
            // 
            this.va_nom_usr.HeaderText = "Nombre";
            this.va_nom_usr.Name = "va_nom_usr";
            this.va_nom_usr.ReadOnly = true;
            this.va_nom_usr.Width = 265;
            // 
            // va_opc_sel
            // 
            this.va_opc_sel.FalseValue = "0";
            this.va_opc_sel.HeaderText = "Sel.";
            this.va_opc_sel.Name = "va_opc_sel";
            this.va_opc_sel.ReadOnly = true;
            this.va_opc_sel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.va_opc_sel.TrueValue = "1";
            this.va_opc_sel.Width = 40;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_tod_mod);
            this.gb_ctr_btn.Controls.Add(this.lb_nom_tus);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(1, 251);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(425, 40);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_tod_mod
            // 
            this.bt_tod_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_tod_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_tod_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_tod_mod.Location = new System.Drawing.Point(4, 10);
            this.bt_tod_mod.Name = "bt_tod_mod";
            this.bt_tod_mod.Size = new System.Drawing.Size(94, 25);
            this.bt_tod_mod.TabIndex = 2;
            this.bt_tod_mod.Text = "&Grupo Persona";
            this.bt_tod_mod.UseVisualStyleBackColor = false;
            this.bt_tod_mod.Click += new System.EventHandler(this.bt_tod_tus_Click);
            // 
            // lb_nom_tus
            // 
            this.lb_nom_tus.AutoSize = true;
            this.lb_nom_tus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_tus.Location = new System.Drawing.Point(99, 16);
            this.lb_nom_tus.Name = "lb_nom_tus";
            this.lb_nom_tus.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_tus.TabIndex = 0;
            this.lb_nom_tus.Text = "...";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(268, 10);
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
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(347, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 2;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 204);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // ads004_10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 292);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads004_10";
            this.Tag = "Autorización Talonario p/Usuario";
            this.Text = "Autorización Talonario p/Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.CheckBox cb_sel_tod;
        private System.Windows.Forms.TextBox tb_nro_tal;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.Label lb_nom_tal;
        private System.Windows.Forms.Label lb_ide_doc;
        private System.Windows.Forms.TextBox tb_ide_doc;
        private System.Windows.Forms.Button bt_tod_mod;
        public System.Windows.Forms.Label lb_nom_doc;
        private System.Windows.Forms.Label lb_nro_tal;
        private System.Windows.Forms.Label lb_nom_tus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_est_bus;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_usr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_opc_sel;
    }
}