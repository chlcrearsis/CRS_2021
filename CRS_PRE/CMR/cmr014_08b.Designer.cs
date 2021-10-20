namespace CRS_PRE
{
    partial class cmr014_08b
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ch_che_tod = new System.Windows.Forms.CheckBox();
            this.tb_nom_cob = new System.Windows.Forms.TextBox();
            this.lb_cod_cob = new System.Windows.Forms.Label();
            this.tb_cod_cob = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_per_mis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ch_che_tod);
            this.groupBox1.Controls.Add(this.tb_nom_cob);
            this.groupBox1.Controls.Add(this.lb_cod_cob);
            this.groupBox1.Controls.Add(this.tb_cod_cob);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 34);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // ch_che_tod
            // 
            this.ch_che_tod.AutoSize = true;
            this.ch_che_tod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ch_che_tod.Location = new System.Drawing.Point(376, 11);
            this.ch_che_tod.Name = "ch_che_tod";
            this.ch_che_tod.Size = new System.Drawing.Size(65, 17);
            this.ch_che_tod.TabIndex = 52;
            this.ch_che_tod.Text = "Todos ?";
            this.ch_che_tod.UseVisualStyleBackColor = true;
            this.ch_che_tod.CheckedChanged += new System.EventHandler(this.ch_che_tod_CheckedChanged);
            // 
            // tb_nom_cob
            // 
            this.tb_nom_cob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_cob.Location = new System.Drawing.Point(100, 10);
            this.tb_nom_cob.MaxLength = 30;
            this.tb_nom_cob.Multiline = true;
            this.tb_nom_cob.Name = "tb_nom_cob";
            this.tb_nom_cob.ReadOnly = true;
            this.tb_nom_cob.Size = new System.Drawing.Size(270, 18);
            this.tb_nom_cob.TabIndex = 20;
            this.tb_nom_cob.TabStop = false;
            this.tb_nom_cob.WordWrap = false;
            // 
            // lb_cod_cob
            // 
            this.lb_cod_cob.AutoSize = true;
            this.lb_cod_cob.Location = new System.Drawing.Point(10, 12);
            this.lb_cod_cob.Name = "lb_cod_cob";
            this.lb_cod_cob.Size = new System.Drawing.Size(50, 13);
            this.lb_cod_cob.TabIndex = 1;
            this.lb_cod_cob.Text = "Cobrador";
            // 
            // tb_cod_cob
            // 
            this.tb_cod_cob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_cob.Location = new System.Drawing.Point(62, 10);
            this.tb_cod_cob.MaxLength = 15;
            this.tb_cod_cob.Multiline = true;
            this.tb_cod_cob.Name = "tb_cod_cob";
            this.tb_cod_cob.ReadOnly = true;
            this.tb_cod_cob.Size = new System.Drawing.Size(35, 18);
            this.tb_cod_cob.TabIndex = 10;
            this.tb_cod_cob.TabStop = false;
            this.tb_cod_cob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_cod_cob.WordWrap = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 377);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(447, 41);
            this.gb_ctr_btn.TabIndex = 20;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(289, 11);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 83;
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
            this.bt_can_cel.Location = new System.Drawing.Point(366, 11);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 84;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
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
            this.va_ide_usr,
            this.va_nom_usr,
            this.va_nom_tip,
            this.va_per_mis});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_res_ult.Location = new System.Drawing.Point(2, 33);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(447, 347);
            this.dg_res_ult.TabIndex = 51;
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            // 
            // va_ide_usr
            // 
            this.va_ide_usr.HeaderText = "Usuario";
            this.va_ide_usr.Name = "va_ide_usr";
            this.va_ide_usr.ReadOnly = true;
            this.va_ide_usr.Width = 95;
            // 
            // va_nom_usr
            // 
            this.va_nom_usr.HeaderText = "Nombre";
            this.va_nom_usr.Name = "va_nom_usr";
            this.va_nom_usr.ReadOnly = true;
            this.va_nom_usr.Width = 200;
            // 
            // va_nom_tip
            // 
            this.va_nom_tip.HeaderText = "Tip. Usuario";
            this.va_nom_tip.Name = "va_nom_tip";
            this.va_nom_tip.ReadOnly = true;
            // 
            // va_per_mis
            // 
            this.va_per_mis.FalseValue = "0";
            this.va_per_mis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.va_per_mis.HeaderText = "✓";
            this.va_per_mis.Name = "va_per_mis";
            this.va_per_mis.ReadOnly = true;
            this.va_per_mis.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.va_per_mis.TrueValue = "1";
            this.va_per_mis.Width = 30;
            // 
            // cmr014_08b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 421);
            this.ControlBox = false;
            this.Controls.Add(this.dg_res_ult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr014_08b";
            this.Tag = "Permiso Usuario p/Cobrador";
            this.Text = "Permiso Usuario p/Cobrador";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_cod_cob;
        private System.Windows.Forms.TextBox tb_cod_cob;
        private System.Windows.Forms.TextBox tb_nom_cob;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.CheckBox ch_che_tod;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_usr;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_tip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_per_mis;
    }
}