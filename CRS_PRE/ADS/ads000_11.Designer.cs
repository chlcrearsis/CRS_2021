namespace CRS_PRE.ADS
{
    partial class ads000_11
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ide_doc = new System.Windows.Forms.Label();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_imp_rim = new System.Windows.Forms.Button();
            this.bt_ver_doc = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_ide_doc);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Se grabo el documento, que desea hacer ?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Documento:";
            // 
            // lb_ide_doc
            // 
            this.lb_ide_doc.AutoSize = true;
            this.lb_ide_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ide_doc.ForeColor = System.Drawing.Color.Navy;
            this.lb_ide_doc.Location = new System.Drawing.Point(125, 16);
            this.lb_ide_doc.Name = "lb_ide_doc";
            this.lb_ide_doc.Size = new System.Drawing.Size(149, 20);
            this.lb_ide_doc.TabIndex = 1;
            this.lb_ide_doc.Text = "FFA  005-000001";
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(227, 11);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(109, 23);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_imp_rim
            // 
            this.bt_imp_rim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_imp_rim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_imp_rim.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_imp_rim.Location = new System.Drawing.Point(5, 11);
            this.bt_imp_rim.Name = "bt_imp_rim";
            this.bt_imp_rim.Size = new System.Drawing.Size(97, 23);
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
            this.bt_ver_doc.Location = new System.Drawing.Point(113, 11);
            this.bt_ver_doc.Name = "bt_ver_doc";
            this.bt_ver_doc.Size = new System.Drawing.Size(102, 23);
            this.bt_ver_doc.TabIndex = 10;
            this.bt_ver_doc.Text = "&Ver documento";
            this.bt_ver_doc.UseVisualStyleBackColor = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_imp_rim);
            this.gb_ctr_btn.Controls.Add(this.bt_ver_doc);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 53);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(336, 41);
            this.gb_ctr_btn.TabIndex = 21;
            this.gb_ctr_btn.TabStop = false;
            // 
            // ads000_11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(344, 97);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads000_11";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
    }
}