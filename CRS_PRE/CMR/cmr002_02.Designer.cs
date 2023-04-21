namespace CRS_PRE
{
    partial class cmr002_02
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
            this.bt_bus_pro = new System.Windows.Forms.Button();
            this.lb_nom_pro = new System.Windows.Forms.Label();
            this.lb_nom_lis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_inc_max = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_pre_cio = new System.Windows.Forms.TextBox();
            this.tb_des_max = new System.Windows.Forms.TextBox();
            this.tb_cod_pro = new System.Windows.Forms.TextBox();
            this.tb_nro_lis = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_bus_pro);
            this.groupBox1.Controls.Add(this.lb_nom_pro);
            this.groupBox1.Controls.Add(this.lb_nom_lis);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_inc_max);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_pre_cio);
            this.groupBox1.Controls.Add(this.tb_des_max);
            this.groupBox1.Controls.Add(this.tb_cod_pro);
            this.groupBox1.Controls.Add(this.tb_nro_lis);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // bt_bus_pro
            // 
            this.bt_bus_pro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_pro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_pro.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_pro.Location = new System.Drawing.Point(146, 37);
            this.bt_bus_pro.Name = "bt_bus_pro";
            this.bt_bus_pro.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_pro.TabIndex = 15;
            this.bt_bus_pro.TabStop = false;
            this.bt_bus_pro.Text = "|";
            this.bt_bus_pro.UseVisualStyleBackColor = false;
            this.bt_bus_pro.Click += new System.EventHandler(this.Bt_bus_pro_Click);
            this.bt_bus_pro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_pro_KeyDown);
            // 
            // lb_nom_pro
            // 
            this.lb_nom_pro.Location = new System.Drawing.Point(168, 41);
            this.lb_nom_pro.Name = "lb_nom_pro";
            this.lb_nom_pro.Size = new System.Drawing.Size(221, 13);
            this.lb_nom_pro.TabIndex = 29;
            this.lb_nom_pro.Text = ".";
            // 
            // lb_nom_lis
            // 
            this.lb_nom_lis.Location = new System.Drawing.Point(89, 19);
            this.lb_nom_lis.Name = "lb_nom_lis";
            this.lb_nom_lis.Size = new System.Drawing.Size(298, 13);
            this.lb_nom_lis.TabIndex = 29;
            this.lb_nom_lis.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Precio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "% max. incremento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "% max. descuento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Producto";
            // 
            // tb_inc_max
            // 
            this.tb_inc_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_inc_max.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_inc_max.Location = new System.Drawing.Point(356, 63);
            this.tb_inc_max.MaxLength = 2;
            this.tb_inc_max.Name = "tb_inc_max";
            this.tb_inc_max.Size = new System.Drawing.Size(31, 20);
            this.tb_inc_max.TabIndex = 40;
            this.tb_inc_max.Validated += new System.EventHandler(this.tb_inc_max_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Lista";
            // 
            // tb_pre_cio
            // 
            this.tb_pre_cio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pre_cio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_pre_cio.Location = new System.Drawing.Point(52, 62);
            this.tb_pre_cio.MaxLength = 10;
            this.tb_pre_cio.Name = "tb_pre_cio";
            this.tb_pre_cio.Size = new System.Drawing.Size(57, 20);
            this.tb_pre_cio.TabIndex = 20;
            this.tb_pre_cio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_pre_cio.Validated += new System.EventHandler(this.tb_pre_cio_Validated);
            // 
            // tb_des_max
            // 
            this.tb_des_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_des_max.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_des_max.Location = new System.Drawing.Point(209, 63);
            this.tb_des_max.MaxLength = 2;
            this.tb_des_max.Name = "tb_des_max";
            this.tb_des_max.Size = new System.Drawing.Size(31, 20);
            this.tb_des_max.TabIndex = 30;
            this.tb_des_max.Validated += new System.EventHandler(this.tb_des_max_Validated);
            // 
            // tb_cod_pro
            // 
            this.tb_cod_pro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_pro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_pro.Location = new System.Drawing.Point(52, 38);
            this.tb_cod_pro.MaxLength = 15;
            this.tb_cod_pro.Name = "tb_cod_pro";
            this.tb_cod_pro.Size = new System.Drawing.Size(95, 20);
            this.tb_cod_pro.TabIndex = 10;
            this.tb_cod_pro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_pro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_cod_pro_KeyDown);
            this.tb_cod_pro.Validated += new System.EventHandler(this.Tb_cod_pro_Validated);
            // 
            // tb_nro_lis
            // 
            this.tb_nro_lis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_lis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nro_lis.Enabled = false;
            this.tb_nro_lis.Location = new System.Drawing.Point(52, 16);
            this.tb_nro_lis.MaxLength = 2;
            this.tb_nro_lis.Name = "tb_nro_lis";
            this.tb_nro_lis.Size = new System.Drawing.Size(31, 20);
            this.tb_nro_lis.TabIndex = 10;
            this.tb_nro_lis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 91);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(401, 35);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(306, 9);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(225, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // cmr002_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(409, 128);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr002_02";
            this.Tag = "Crea Precio";
            this.Text = "Crea Precio";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_nro_lis;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_des_max;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cod_pro;
        private System.Windows.Forms.Button bt_bus_pro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_inc_max;
        private System.Windows.Forms.Label lb_nom_pro;
        private System.Windows.Forms.Label lb_nom_lis;
        private System.Windows.Forms.TextBox tb_pre_cio;
    }
}