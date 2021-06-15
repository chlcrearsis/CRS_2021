namespace CRS_PRE.INV
{
    partial class inv099_R02p
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_fec_exi = new System.Windows.Forms.DateTimePicker();
            this.tb_cod_bo2 = new System.Windows.Forms.TextBox();
            this.tb_cod_bo1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_nom_bo2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_nom_bo1 = new System.Windows.Forms.Label();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_fec_exi);
            this.groupBox1.Controls.Add(this.tb_cod_bo2);
            this.groupBox1.Controls.Add(this.tb_cod_bo1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_nom_bo2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lb_nom_bo1);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "A la fecha";
            // 
            // tb_fec_exi
            // 
            this.tb_fec_exi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_exi.Location = new System.Drawing.Point(90, 57);
            this.tb_fec_exi.Name = "tb_fec_exi";
            this.tb_fec_exi.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_exi.TabIndex = 60;
            // 
            // tb_cod_bo2
            // 
            this.tb_cod_bo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_bo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_bo2.Location = new System.Drawing.Point(90, 34);
            this.tb_cod_bo2.MaxLength = 5;
            this.tb_cod_bo2.Name = "tb_cod_bo2";
            this.tb_cod_bo2.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_bo2.TabIndex = 30;
            this.tb_cod_bo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_bo2.Enter += new System.EventHandler(this.tb_cod_bo2_Enter);
            this.tb_cod_bo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_bod_KeyDown);
            this.tb_cod_bo2.Validated += new System.EventHandler(this.Tb_cod_bod_Validated);
            // 
            // tb_cod_bo1
            // 
            this.tb_cod_bo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_bo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_bo1.Location = new System.Drawing.Point(90, 11);
            this.tb_cod_bo1.MaxLength = 5;
            this.tb_cod_bo1.Name = "tb_cod_bo1";
            this.tb_cod_bo1.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_bo1.TabIndex = 30;
            this.tb_cod_bo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_bo1.Enter += new System.EventHandler(this.tb_cod_bo1_Enter);
            this.tb_cod_bo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_bod_KeyDown);
            this.tb_cod_bo1.Validated += new System.EventHandler(this.Tb_cod_bod_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Bodega Final";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(150, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 22);
            this.button2.TabIndex = 40;
            this.button2.TabStop = false;
            this.button2.Text = "|";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Bt_bus_bo2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Bodega Inicial";
            // 
            // lb_nom_bo2
            // 
            this.lb_nom_bo2.Location = new System.Drawing.Point(169, 38);
            this.lb_nom_bo2.Name = "lb_nom_bo2";
            this.lb_nom_bo2.Size = new System.Drawing.Size(203, 13);
            this.lb_nom_bo2.TabIndex = 41;
            this.lb_nom_bo2.Text = ".";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(150, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 22);
            this.button1.TabIndex = 40;
            this.button1.TabStop = false;
            this.button1.Text = "|";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Bt_bus_bo1_Click);
            // 
            // lb_nom_bo1
            // 
            this.lb_nom_bo1.Location = new System.Drawing.Point(169, 15);
            this.lb_nom_bo1.Name = "lb_nom_bo1";
            this.lb_nom_bo1.Size = new System.Drawing.Size(203, 13);
            this.lb_nom_bo1.TabIndex = 41;
            this.lb_nom_bo1.Text = ".";
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 78);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(385, 35);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(301, 8);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(220, 8);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // inv099_R02p
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(392, 115);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inv099_R02p";
            this.Tag = "Existencia en bodegas a la fecha";
            this.Text = "Existencia en bodegas a la fecha";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker tb_fec_exi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox tb_cod_bo1;
        public System.Windows.Forms.Label lb_nom_bo1;
        public System.Windows.Forms.TextBox tb_cod_bo2;
        public System.Windows.Forms.Label lb_nom_bo2;
    }
}