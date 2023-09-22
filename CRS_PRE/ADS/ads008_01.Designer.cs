namespace CRS_PRE
{
    partial class ads008_01
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
            this.ch_che_tod = new System.Windows.Forms.CheckBox();
            this.tb_nom_usr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_ide_apl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_apl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_des_apl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_per_mis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ch_che_tod);
            this.groupBox1.Controls.Add(this.tb_nom_usr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 57);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // ch_che_tod
            // 
            this.ch_che_tod.AutoSize = true;
            this.ch_che_tod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ch_che_tod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_che_tod.Location = new System.Drawing.Point(361, 36);
            this.ch_che_tod.Name = "ch_che_tod";
            this.ch_che_tod.Size = new System.Drawing.Size(72, 17);
            this.ch_che_tod.TabIndex = 52;
            this.ch_che_tod.Text = "Todos ?";
            this.ch_che_tod.UseVisualStyleBackColor = true;
            this.ch_che_tod.CheckedChanged += new System.EventHandler(this.ch_che_tod_CheckedChanged);
            // 
            // tb_nom_usr
            // 
            this.tb_nom_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_usr.Location = new System.Drawing.Point(157, 10);
            this.tb_nom_usr.MaxLength = 30;
            this.tb_nom_usr.Multiline = true;
            this.tb_nom_usr.Name = "tb_nom_usr";
            this.tb_nom_usr.ReadOnly = true;
            this.tb_nom_usr.Size = new System.Drawing.Size(283, 18);
            this.tb_nom_usr.TabIndex = 20;
            this.tb_nom_usr.TabStop = false;
            this.tb_nom_usr.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(61, 10);
            this.tb_ide_usr.MaxLength = 15;
            this.tb_ide_usr.Multiline = true;
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(95, 18);
            this.tb_ide_usr.TabIndex = 10;
            this.tb_ide_usr.TabStop = false;
            this.tb_ide_usr.WordWrap = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.label3);
            this.gb_ctr_btn.Controls.Add(this.label2);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 399);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(447, 53);
            this.gb_ctr_btn.TabIndex = 20;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(357, 16);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 80;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(259, 16);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 70;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
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
            this.va_ide_apl,
            this.va_nom_apl,
            this.va_des_apl,
            this.va_per_mis});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(2, 55);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(447, 347);
            this.dg_res_ult.TabIndex = 51;
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            this.dg_res_ult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_RowEnter);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // va_ide_apl
            // 
            this.va_ide_apl.HeaderText = "ID.";
            this.va_ide_apl.Name = "va_ide_apl";
            this.va_ide_apl.ReadOnly = true;
            this.va_ide_apl.Width = 65;
            // 
            // va_nom_apl
            // 
            this.va_nom_apl.HeaderText = "Aplicacion";
            this.va_nom_apl.Name = "va_nom_apl";
            this.va_nom_apl.ReadOnly = true;
            this.va_nom_apl.Width = 145;
            // 
            // va_des_apl
            // 
            this.va_des_apl.HeaderText = "Descripcion";
            this.va_des_apl.Name = "va_des_apl";
            this.va_des_apl.ReadOnly = true;
            this.va_des_apl.Width = 200;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Aplicaciones habilitadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Aplicaciones deshabilitadas";
            // 
            // ads008_01
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(451, 455);
            this.ControlBox = false;
            this.Controls.Add(this.dg_res_ult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads008_01";
            this.Tag = "Permiso sobre Plantilla de ventas Restaurant";
            this.Text = "Permiso sobre Aplicaciones";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ide_usr;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.TextBox tb_nom_usr;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.CheckBox ch_che_tod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_apl;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_apl;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_des_apl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_per_mis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}