namespace CRS_PRE.CMR
{
    partial class res001_R02p
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_fec_fin = new System.Windows.Forms.DateTimePicker();
            this.tb_fec_ini = new System.Windows.Forms.DateTimePicker();
            this.tb_cod_bod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_nom_bod = new System.Windows.Forms.Label();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.lb_nom_del = new System.Windows.Forms.Label();
            this.bt_bus_del = new System.Windows.Forms.Button();
            this.tb_cod_del = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_fec_fin);
            this.groupBox1.Controls.Add(this.tb_fec_ini);
            this.groupBox1.Controls.Add(this.tb_cod_del);
            this.groupBox1.Controls.Add(this.tb_cod_bod);
            this.groupBox1.Controls.Add(this.bt_bus_del);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_nom_del);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lb_nom_bod);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Delivery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Al";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Del";
            // 
            // tb_fec_fin
            // 
            this.tb_fec_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_fin.Location = new System.Drawing.Point(195, 60);
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_fin.TabIndex = 40;
            // 
            // tb_fec_ini
            // 
            this.tb_fec_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_fec_ini.Location = new System.Drawing.Point(62, 60);
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_ini.TabIndex = 30;
            // 
            // tb_cod_bod
            // 
            this.tb_cod_bod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_bod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_bod.Location = new System.Drawing.Point(62, 15);
            this.tb_cod_bod.MaxLength = 5;
            this.tb_cod_bod.Name = "tb_cod_bod";
            this.tb_cod_bod.Size = new System.Drawing.Size(61, 20);
            this.tb_cod_bod.TabIndex = 10;
            this.tb_cod_bod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_bod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_bod_KeyDown);
            this.tb_cod_bod.Validated += new System.EventHandler(this.Tb_cod_bod_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Bodega";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(122, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 22);
            this.button1.TabIndex = 42;
            this.button1.TabStop = false;
            this.button1.Text = "|";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Bt_bus_bod_Click);
            // 
            // lb_nom_bod
            // 
            this.lb_nom_bod.Location = new System.Drawing.Point(141, 19);
            this.lb_nom_bod.Name = "lb_nom_bod";
            this.lb_nom_bod.Size = new System.Drawing.Size(304, 13);
            this.lb_nom_bod.TabIndex = 41;
            this.lb_nom_bod.Text = ".";
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 83);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(465, 35);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(370, 8);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(289, 8);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // lb_nom_del
            // 
            this.lb_nom_del.Location = new System.Drawing.Point(104, 41);
            this.lb_nom_del.Name = "lb_nom_del";
            this.lb_nom_del.Size = new System.Drawing.Size(304, 13);
            this.lb_nom_del.TabIndex = 41;
            this.lb_nom_del.Text = ".";
            // 
            // bt_bus_del
            // 
            this.bt_bus_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_del.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_del.Location = new System.Drawing.Point(85, 36);
            this.bt_bus_del.Name = "bt_bus_del";
            this.bt_bus_del.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_del.TabIndex = 42;
            this.bt_bus_del.TabStop = false;
            this.bt_bus_del.Text = "|";
            this.bt_bus_del.UseVisualStyleBackColor = false;
            this.bt_bus_del.Click += new System.EventHandler(this.Bt_bus_del_Click);
            // 
            // tb_cod_del
            // 
            this.tb_cod_del.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_del.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_del.Location = new System.Drawing.Point(62, 37);
            this.tb_cod_del.MaxLength = 5;
            this.tb_cod_del.Name = "tb_cod_del";
            this.tb_cod_del.Size = new System.Drawing.Size(24, 20);
            this.tb_cod_del.TabIndex = 20;
            this.tb_cod_del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_del.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_del_KeyDown);
            this.tb_cod_del.Validated += new System.EventHandler(this.Tb_cod_del_Validated);
            // 
            // res001_R02p
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(474, 121);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "res001_R02p";
            this.Tag = "Ventas por Delivery";
            this.Text = "Ventas por Delivery";
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
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tb_cod_bod;
        public System.Windows.Forms.Label lb_nom_bod;
        public System.Windows.Forms.DateTimePicker tb_fec_fin;
        public System.Windows.Forms.DateTimePicker tb_fec_ini;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_cod_del;
        private System.Windows.Forms.Button bt_bus_del;
        public System.Windows.Forms.Label lb_nom_del;
    }
}