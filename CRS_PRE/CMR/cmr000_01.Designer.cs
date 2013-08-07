namespace CRS_PRE.CMR
{
    partial class cmr000_01
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_bus_imp = new System.Windows.Forms.Button();
            this.lb_nom_imp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_tit_ope = new System.Windows.Forms.Label();
            this.lb_ide_doc = new System.Windows.Forms.Label();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_imp_rim = new System.Windows.Forms.Button();
            this.bt_ver_doc = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.lb_nro_fac = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nro_fac);
            this.groupBox1.Controls.Add(this.bt_bus_imp);
            this.groupBox1.Controls.Add(this.lb_nom_imp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_tit_ope);
            this.groupBox1.Controls.Add(this.lb_ide_doc);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // bt_bus_imp
            // 
            this.bt_bus_imp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_imp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_bus_imp.Location = new System.Drawing.Point(31, 57);
            this.bt_bus_imp.Name = "bt_bus_imp";
            this.bt_bus_imp.Size = new System.Drawing.Size(97, 25);
            this.bt_bus_imp.TabIndex = 40;
            this.bt_bus_imp.Text = "Se imprimira en:";
            this.bt_bus_imp.UseVisualStyleBackColor = false;
            this.bt_bus_imp.Click += new System.EventHandler(this.bt_bus_imp_Click);
            // 
            // lb_nom_imp
            // 
            this.lb_nom_imp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom_imp.ForeColor = System.Drawing.Color.Navy;
            this.lb_nom_imp.Location = new System.Drawing.Point(134, 63);
            this.lb_nom_imp.Name = "lb_nom_imp";
            this.lb_nom_imp.Size = new System.Drawing.Size(258, 18);
            this.lb_nom_imp.TabIndex = 22;
            this.lb_nom_imp.Text = "Impresora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Se grabo el documento exitosamente ¿Que desea realizar?";
            // 
            // lb_tit_ope
            // 
            this.lb_tit_ope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_ope.Location = new System.Drawing.Point(36, 18);
            this.lb_tit_ope.Name = "lb_tit_ope";
            this.lb_tit_ope.Size = new System.Drawing.Size(118, 14);
            this.lb_tit_ope.TabIndex = 21;
            this.lb_tit_ope.Text = "Documento:";
            this.lb_tit_ope.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_ide_doc
            // 
            this.lb_ide_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ide_doc.ForeColor = System.Drawing.Color.Navy;
            this.lb_ide_doc.Location = new System.Drawing.Point(153, 13);
            this.lb_ide_doc.Name = "lb_ide_doc";
            this.lb_ide_doc.Size = new System.Drawing.Size(148, 20);
            this.lb_ide_doc.TabIndex = 1;
            this.lb_ide_doc.Text = "FFA-005-000001";
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(273, 14);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(109, 28);
            this.bt_can_cel.TabIndex = 30;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_imp_rim
            // 
            this.bt_imp_rim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_imp_rim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_imp_rim.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_imp_rim.Location = new System.Drawing.Point(16, 14);
            this.bt_imp_rim.Name = "bt_imp_rim";
            this.bt_imp_rim.Size = new System.Drawing.Size(97, 28);
            this.bt_imp_rim.TabIndex = 10;
            this.bt_imp_rim.Text = "&Imprimir";
            this.bt_imp_rim.UseVisualStyleBackColor = false;
            this.bt_imp_rim.Click += new System.EventHandler(this.bt_imp_rim_Click);
            // 
            // bt_ver_doc
            // 
            this.bt_ver_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ver_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ver_doc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ver_doc.Location = new System.Drawing.Point(144, 14);
            this.bt_ver_doc.Name = "bt_ver_doc";
            this.bt_ver_doc.Size = new System.Drawing.Size(102, 28);
            this.bt_ver_doc.TabIndex = 20;
            this.bt_ver_doc.Text = "&Ver documento";
            this.bt_ver_doc.UseVisualStyleBackColor = false;
            this.bt_ver_doc.Click += new System.EventHandler(this.bt_ver_doc_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_imp_rim);
            this.gb_ctr_btn.Controls.Add(this.bt_ver_doc);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 87);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(401, 49);
            this.gb_ctr_btn.TabIndex = 21;
            this.gb_ctr_btn.TabStop = false;
            // 
            // lb_nro_fac
            // 
            this.lb_nro_fac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nro_fac.ForeColor = System.Drawing.Color.Navy;
            this.lb_nro_fac.Location = new System.Drawing.Point(308, 13);
            this.lb_nro_fac.Name = "lb_nro_fac";
            this.lb_nro_fac.Size = new System.Drawing.Size(85, 20);
            this.lb_nro_fac.TabIndex = 41;
            this.lb_nro_fac.Text = "# 7895";
            // 
            // cmr000_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(407, 139);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr000_01";
            this.Text = "Caja de impresion";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_ide_doc;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_imp_rim;
        private System.Windows.Forms.Button bt_ver_doc;
        private System.Windows.Forms.Label lb_tit_ope;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_nom_imp;
        private System.Windows.Forms.Button bt_bus_imp;
        private System.Windows.Forms.Label lb_nro_fac;
    }
}