namespace CRS_PRE.INV
{
    partial class inv099_05
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_res_ult = new System.Windows.Forms.DataGridView();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.tb_cod_fam = new System.Windows.Forms.MaskedTextBox();
            this.tb_nom_pro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_cod_umd = new System.Windows.Forms.TextBox();
            this.tb_cod_pro = new System.Windows.Forms.TextBox();
            this.tb_nom_fam = new System.Windows.Forms.TextBox();
            this.va_cod_bod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_nom_bod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.va_sal_can = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).BeginInit();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_cod_fam);
            this.groupBox1.Controls.Add(this.tb_nom_pro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_cod_umd);
            this.groupBox1.Controls.Add(this.tb_cod_pro);
            this.groupBox1.Controls.Add(this.tb_nom_fam);
            this.groupBox1.Location = new System.Drawing.Point(2, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 76);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_res_ult);
            this.groupBox2.Location = new System.Drawing.Point(2, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 168);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dg_res_ult
            // 
            this.dg_res_ult.AllowUserToAddRows = false;
            this.dg_res_ult.AllowUserToDeleteRows = false;
            this.dg_res_ult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_res_ult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_res_ult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_res_ult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.va_cod_bod,
            this.va_nom_bod,
            this.va_sal_can});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_res_ult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_res_ult.Location = new System.Drawing.Point(6, 7);
            this.dg_res_ult.MultiSelect = false;
            this.dg_res_ult.Name = "dg_res_ult";
            this.dg_res_ult.ReadOnly = true;
            this.dg_res_ult.RowHeadersVisible = false;
            this.dg_res_ult.RowTemplate.Height = 20;
            this.dg_res_ult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_res_ult.Size = new System.Drawing.Size(465, 156);
            this.dg_res_ult.TabIndex = 35;
            this.dg_res_ult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellClick);
            this.dg_res_ult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_res_ult_CellDoubleClick);
            this.dg_res_ult.SelectionChanged += new System.EventHandler(this.dg_res_ult_SelectionChanged);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 229);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(478, 34);
            this.gb_ctr_btn.TabIndex = 8;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(389, 7);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 45;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // tb_cod_fam
            // 
            this.tb_cod_fam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_fam.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tb_cod_fam.Enabled = false;
            this.tb_cod_fam.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_cod_fam.Location = new System.Drawing.Point(50, 43);
            this.tb_cod_fam.Mask = "00-00-00";
            this.tb_cod_fam.Name = "tb_cod_fam";
            this.tb_cod_fam.PromptChar = '0';
            this.tb_cod_fam.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_fam.TabIndex = 111;
            this.tb_cod_fam.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // tb_nom_pro
            // 
            this.tb_nom_pro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_pro.Location = new System.Drawing.Point(117, 20);
            this.tb_nom_pro.MaxLength = 80;
            this.tb_nom_pro.Name = "tb_nom_pro";
            this.tb_nom_pro.ReadOnly = true;
            this.tb_nom_pro.Size = new System.Drawing.Size(335, 20);
            this.tb_nom_pro.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Und. Med.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "Familia";
            // 
            // tb_cod_umd
            // 
            this.tb_cod_umd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_umd.Location = new System.Drawing.Point(414, 43);
            this.tb_cod_umd.MaxLength = 3;
            this.tb_cod_umd.Name = "tb_cod_umd";
            this.tb_cod_umd.ReadOnly = true;
            this.tb_cod_umd.Size = new System.Drawing.Size(38, 20);
            this.tb_cod_umd.TabIndex = 121;
            // 
            // tb_cod_pro
            // 
            this.tb_cod_pro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_pro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_pro.Location = new System.Drawing.Point(11, 20);
            this.tb_cod_pro.MaxLength = 15;
            this.tb_cod_pro.Name = "tb_cod_pro";
            this.tb_cod_pro.ReadOnly = true;
            this.tb_cod_pro.Size = new System.Drawing.Size(100, 20);
            this.tb_cod_pro.TabIndex = 117;
            // 
            // tb_nom_fam
            // 
            this.tb_nom_fam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_fam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nom_fam.Location = new System.Drawing.Point(117, 43);
            this.tb_nom_fam.MaxLength = 50;
            this.tb_nom_fam.Name = "tb_nom_fam";
            this.tb_nom_fam.ReadOnly = true;
            this.tb_nom_fam.Size = new System.Drawing.Size(234, 20);
            this.tb_nom_fam.TabIndex = 112;
            this.tb_nom_fam.TabStop = false;
            // 
            // va_cod_bod
            // 
            this.va_cod_bod.HeaderText = "Codigo";
            this.va_cod_bod.Name = "va_cod_bod";
            this.va_cod_bod.ReadOnly = true;
            this.va_cod_bod.Width = 60;
            // 
            // va_nom_bod
            // 
            this.va_nom_bod.HeaderText = "Bodega";
            this.va_nom_bod.Name = "va_nom_bod";
            this.va_nom_bod.ReadOnly = true;
            this.va_nom_bod.Width = 280;
            // 
            // va_sal_can
            // 
            this.va_sal_can.HeaderText = "Existencia";
            this.va_sal_can.Name = "va_sal_can";
            this.va_sal_can.ReadOnly = true;
            this.va_sal_can.Width = 120;
            // 
            // inv099_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(484, 265);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inv099_05";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Existencias de un producto";
            this.Text = "Existencias de un producto";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_res_ult)).EndInit();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dg_res_ult;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        public System.Windows.Forms.MaskedTextBox tb_cod_fam;
        private System.Windows.Forms.TextBox tb_nom_pro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_cod_umd;
        private System.Windows.Forms.TextBox tb_cod_pro;
        private System.Windows.Forms.TextBox tb_nom_fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_cod_bod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_nom_bod;
        private System.Windows.Forms.DataGridViewTextBoxColumn va_sal_can;
    }
}