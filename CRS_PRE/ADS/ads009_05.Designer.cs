namespace CRS_PRE
{
    partial class ads009_05
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
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.va_cod_bod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_bod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_ide_gru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_gru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_per_mis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nom_tus = new System.Windows.Forms.Label();
            this.lb_ide_tus = new System.Windows.Forms.Label();
            this.tb_ide_tus = new System.Windows.Forms.TextBox();
            this.ch_che_tod = new System.Windows.Forms.CheckBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_nom_gru = new System.Windows.Forms.Label();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_cam_gru = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.va_cod_bod,
            this.va_nom_bod,
            this.va_ide_gru,
            this.va_nom_gru,
            this.va_per_mis});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_res_ult.Location = new System.Drawing.Point(3, 40);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(500, 169);
            this.dg_res_ult.TabIndex = 1;
            this.dg_res_ult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellContentClick);
            // 
            // va_cod_bod
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_cod_bod.DefaultCellStyle = dataGridViewCellStyle2;
            this.va_cod_bod.HeaderText = "Código";
            this.va_cod_bod.Name = "va_cod_bod";
            this.va_cod_bod.ReadOnly = true;
            this.va_cod_bod.Width = 55;
            // 
            // va_nom_bod
            // 
            this.va_nom_bod.HeaderText = "Bodega";
            this.va_nom_bod.Name = "va_nom_bod";
            this.va_nom_bod.ReadOnly = true;
            this.va_nom_bod.Width = 200;
            // 
            // va_ide_gru
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.va_ide_gru.DefaultCellStyle = dataGridViewCellStyle3;
            this.va_ide_gru.HeaderText = "ID.";
            this.va_ide_gru.Name = "va_ide_gru";
            this.va_ide_gru.ReadOnly = true;
            this.va_ide_gru.Width = 35;
            // 
            // va_nom_gru
            // 
            this.va_nom_gru.HeaderText = "Grupo Bodega";
            this.va_nom_gru.Name = "va_nom_gru";
            this.va_nom_gru.ReadOnly = true;
            this.va_nom_gru.Width = 160;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nom_tus);
            this.groupBox1.Controls.Add(this.lb_ide_tus);
            this.groupBox1.Controls.Add(this.tb_ide_tus);
            this.groupBox1.Controls.Add(this.ch_che_tod);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_tus
            // 
            this.lb_nom_tus.AutoSize = true;
            this.lb_nom_tus.Location = new System.Drawing.Point(103, 17);
            this.lb_nom_tus.Name = "lb_nom_tus";
            this.lb_nom_tus.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tus.TabIndex = 2;
            this.lb_nom_tus.Text = "...";
            // 
            // lb_ide_tus
            // 
            this.lb_ide_tus.AutoSize = true;
            this.lb_ide_tus.Location = new System.Drawing.Point(4, 18);
            this.lb_ide_tus.Name = "lb_ide_tus";
            this.lb_ide_tus.Size = new System.Drawing.Size(67, 13);
            this.lb_ide_tus.TabIndex = 0;
            this.lb_ide_tus.Text = "Tipo Usuario";
            // 
            // tb_ide_tus
            // 
            this.tb_ide_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tus.Location = new System.Drawing.Point(71, 14);
            this.tb_ide_tus.Name = "tb_ide_tus";
            this.tb_ide_tus.ReadOnly = true;
            this.tb_ide_tus.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_tus.TabIndex = 1;
            this.tb_ide_tus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ch_che_tod
            // 
            this.ch_che_tod.AutoSize = true;
            this.ch_che_tod.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ch_che_tod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_che_tod.Location = new System.Drawing.Point(399, 14);
            this.ch_che_tod.Name = "ch_che_tod";
            this.ch_che_tod.Size = new System.Drawing.Size(72, 17);
            this.ch_che_tod.TabIndex = 3;
            this.ch_che_tod.Text = "Todos ?";
            this.ch_che_tod.UseVisualStyleBackColor = true;
            this.ch_che_tod.CheckedChanged += new System.EventHandler(this.ch_che_tod_CheckedChanged);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.lb_nom_gru);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(117, 205);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(386, 40);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_nom_gru
            // 
            this.lb_nom_gru.AutoSize = true;
            this.lb_nom_gru.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_gru.Location = new System.Drawing.Point(6, 15);
            this.lb_nom_gru.Name = "lb_nom_gru";
            this.lb_nom_gru.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_gru.TabIndex = 0;
            this.lb_nom_gru.Text = "...";
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(228, 10);
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
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(306, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 2;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_cam_gru);
            this.groupBox3.Location = new System.Drawing.Point(3, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // bt_cam_gru
            // 
            this.bt_cam_gru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_cam_gru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cam_gru.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_cam_gru.Location = new System.Drawing.Point(6, 10);
            this.bt_cam_gru.Name = "bt_cam_gru";
            this.bt_cam_gru.Size = new System.Drawing.Size(101, 23);
            this.bt_cam_gru.TabIndex = 0;
            this.bt_cam_gru.Text = "&Cambiar Grupo";
            this.bt_cam_gru.UseVisualStyleBackColor = false;
            this.bt_cam_gru.Click += new System.EventHandler(this.bt_cam_gru_Click);
            // 
            // ads009_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 246);
            this.ControlBox = false;
            this.Controls.Add(this.dg_res_ult);
            this.Controls.Add(this.gb_ctr_btn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads009_05";
            this.Tag = "Permiso de Bodega";
            this.Text = "Permiso de Bodega";
            this.Load += new System.EventHandler(this.frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_ctr_btn.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lb_nom_tus;
        private System.Windows.Forms.Label lb_ide_tus;
        public System.Windows.Forms.TextBox tb_ide_tus;
        private System.Windows.Forms.CheckBox ch_che_tod;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_nom_gru;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_cam_gru;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_bod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_bod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_ide_gru;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_gru;
        private System.Windows.Forms.DataGridViewCheckBoxColumn va_per_mis;
    }
}