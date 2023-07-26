namespace CRS_PRE
{
    partial class ads004_02c
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
            this.label3 = new System.Windows.Forms.Label();
            this.cb_tod_año = new System.Windows.Forms.CheckBox();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.bt_bus_mod = new System.Windows.Forms.Button();
            this.cb_tod_mes = new System.Windows.Forms.CheckBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_sel_año = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.va_sel_mes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_des_año = new System.Windows.Forms.Label();
            this.lb_des_mes = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_tod_año);
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Controls.Add(this.bt_bus_mod);
            this.groupBox1.Controls.Add(this.cb_tod_mes);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "REGISTRA TALONARIO AUTOMATICO";
            // 
            // cb_tod_año
            // 
            this.cb_tod_año.AutoSize = true;
            this.cb_tod_año.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_tod_año.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tod_año.Location = new System.Drawing.Point(251, 48);
            this.cb_tod_año.Name = "cb_tod_año";
            this.cb_tod_año.Size = new System.Drawing.Size(44, 17);
            this.cb_tod_año.TabIndex = 5;
            this.cb_tod_año.Text = "Sel";
            this.cb_tod_año.UseVisualStyleBackColor = true;
            this.cb_tod_año.CheckedChanged += new System.EventHandler(this.cb_tod_año_CheckedChanged);
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(94, 48);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_mod.TabIndex = 4;
            this.lb_nom_mod.Text = "...";
            // 
            // lb_ide_mod
            // 
            this.lb_ide_mod.AutoSize = true;
            this.lb_ide_mod.Location = new System.Drawing.Point(5, 47);
            this.lb_ide_mod.Name = "lb_ide_mod";
            this.lb_ide_mod.Size = new System.Drawing.Size(42, 13);
            this.lb_ide_mod.TabIndex = 1;
            this.lb_ide_mod.Text = "Módulo";
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(49, 44);
            this.tb_ide_mod.MaxLength = 3;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(29, 20);
            this.tb_ide_mod.TabIndex = 2;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_mod_KeyDown);
            this.tb_ide_mod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_mod_KeyPress);
            this.tb_ide_mod.Validated += new System.EventHandler(this.tb_ide_mod_Validated);
            // 
            // bt_bus_mod
            // 
            this.bt_bus_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_mod.Location = new System.Drawing.Point(77, 43);
            this.bt_bus_mod.Name = "bt_bus_mod";
            this.bt_bus_mod.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_mod.TabIndex = 3;
            this.bt_bus_mod.TabStop = false;
            this.bt_bus_mod.Text = "|";
            this.bt_bus_mod.UseVisualStyleBackColor = false;
            this.bt_bus_mod.Click += new System.EventHandler(this.bt_bus_mod_Click);
            // 
            // cb_tod_mes
            // 
            this.cb_tod_mes.AutoSize = true;
            this.cb_tod_mes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_tod_mes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tod_mes.Location = new System.Drawing.Point(301, 48);
            this.cb_tod_mes.Name = "cb_tod_mes";
            this.cb_tod_mes.Size = new System.Drawing.Size(44, 17);
            this.cb_tod_mes.TabIndex = 6;
            this.cb_tod_mes.Text = "Sel";
            this.cb_tod_mes.UseVisualStyleBackColor = true;
            this.cb_tod_mes.CheckedChanged += new System.EventHandler(this.cb_tod_mes_CheckedChanged);
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
            this.va_ide_doc,
            this.va_nom_doc,
            this.va_sel_año,
            this.va_sel_mes});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(2, 67);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(383, 330);
            this.dg_res_ult.TabIndex = 1;
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            // 
            // va_ide_doc
            // 
            this.va_ide_doc.HeaderText = "Código";
            this.va_ide_doc.Name = "va_ide_doc";
            this.va_ide_doc.ReadOnly = true;
            this.va_ide_doc.Width = 60;
            // 
            // va_nom_doc
            // 
            this.va_nom_doc.HeaderText = "Documento";
            this.va_nom_doc.Name = "va_nom_doc";
            this.va_nom_doc.ReadOnly = true;
            this.va_nom_doc.Width = 200;
            // 
            // va_sel_año
            // 
            this.va_sel_año.FalseValue = "0";
            this.va_sel_año.HeaderText = "Año";
            this.va_sel_año.Name = "va_sel_año";
            this.va_sel_año.ReadOnly = true;
            this.va_sel_año.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.va_sel_año.TrueValue = "1";
            this.va_sel_año.Width = 50;
            // 
            // va_sel_mes
            // 
            this.va_sel_mes.FalseValue = "0";
            this.va_sel_mes.HeaderText = "Mes";
            this.va_sel_mes.Name = "va_sel_mes";
            this.va_sel_mes.ReadOnly = true;
            this.va_sel_mes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.va_sel_mes.TrueValue = "1";
            this.va_sel_mes.Width = 50;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.lb_des_año);
            this.gb_ctr_btn.Controls.Add(this.lb_des_mes);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 393);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(383, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_des_año
            // 
            this.lb_des_año.AutoSize = true;
            this.lb_des_año.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_des_año.Location = new System.Drawing.Point(6, 8);
            this.lb_des_año.Name = "lb_des_año";
            this.lb_des_año.Size = new System.Drawing.Size(127, 13);
            this.lb_des_año.TabIndex = 0;
            this.lb_des_año.Text = "Año = Talonario Anual (0)";
            // 
            // lb_des_mes
            // 
            this.lb_des_mes.AutoSize = true;
            this.lb_des_mes.Location = new System.Drawing.Point(5, 23);
            this.lb_des_mes.Name = "lb_des_mes";
            this.lb_des_mes.Size = new System.Drawing.Size(156, 13);
            this.lb_des_mes.TabIndex = 1;
            this.lb_des_mes.Text = "Mes = Talonario Mensual (1-12)";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(224, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 2;
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
            this.bt_can_cel.Location = new System.Drawing.Point(303, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 3;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads004_02c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 434);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dg_res_ult);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads004_02c";
            this.Tag = "Crea Talonario Automático";
            this.Text = "Crea Talonario Automático";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.CheckBox cb_tod_mes;
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Button bt_bus_mod;
        public System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.CheckBox cb_tod_año;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lb_des_año;
        public System.Windows.Forms.Label lb_des_mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_doc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_sel_año;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_sel_mes;
    }
}