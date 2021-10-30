namespace CRS_PRE
{
    partial class ecp001_05
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
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_nom_plg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_dia_ini = new System.Windows.Forms.TextBox();
            this.tb_int_dia = new System.Windows.Forms.TextBox();
            this.tb_nro_cuo = new System.Windows.Forms.TextBox();
            this.tb_cod_plg = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_plg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_dia_ini);
            this.groupBox1.Controls.Add(this.tb_int_dia);
            this.groupBox1.Controls.Add(this.tb_nro_cuo);
            this.groupBox1.Controls.Add(this.tb_cod_plg);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(276, 68);
            this.tb_est_ado.MaxLength = 30;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(112, 20);
            this.tb_est_ado.TabIndex = 51;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_nom_plg
            // 
            this.tb_nom_plg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_plg.Location = new System.Drawing.Point(125, 16);
            this.tb_nom_plg.MaxLength = 30;
            this.tb_nom_plg.Name = "tb_nom_plg";
            this.tb_nom_plg.ReadOnly = true;
            this.tb_nom_plg.Size = new System.Drawing.Size(263, 20);
            this.tb_nom_plg.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nro. dia inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Intervalo de dias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nro. Cuotas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Plan de pago";
            // 
            // tb_dia_ini
            // 
            this.tb_dia_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_dia_ini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_dia_ini.Location = new System.Drawing.Point(350, 42);
            this.tb_dia_ini.MaxLength = 3;
            this.tb_dia_ini.Name = "tb_dia_ini";
            this.tb_dia_ini.ReadOnly = true;
            this.tb_dia_ini.Size = new System.Drawing.Size(38, 20);
            this.tb_dia_ini.TabIndex = 50;
            this.tb_dia_ini.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_KeyPress);
            // 
            // tb_int_dia
            // 
            this.tb_int_dia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_int_dia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_int_dia.Location = new System.Drawing.Point(215, 42);
            this.tb_int_dia.MaxLength = 3;
            this.tb_int_dia.Name = "tb_int_dia";
            this.tb_int_dia.ReadOnly = true;
            this.tb_int_dia.Size = new System.Drawing.Size(38, 20);
            this.tb_int_dia.TabIndex = 40;
            this.tb_int_dia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_KeyPress);
            // 
            // tb_nro_cuo
            // 
            this.tb_nro_cuo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_cuo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nro_cuo.Location = new System.Drawing.Point(80, 42);
            this.tb_nro_cuo.MaxLength = 2;
            this.tb_nro_cuo.Name = "tb_nro_cuo";
            this.tb_nro_cuo.ReadOnly = true;
            this.tb_nro_cuo.Size = new System.Drawing.Size(38, 20);
            this.tb_nro_cuo.TabIndex = 30;
            this.tb_nro_cuo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_KeyPress);
            // 
            // tb_cod_plg
            // 
            this.tb_cod_plg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_plg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_plg.Location = new System.Drawing.Point(80, 16);
            this.tb_cod_plg.MaxLength = 4;
            this.tb_cod_plg.Name = "tb_cod_plg";
            this.tb_cod_plg.ReadOnly = true;
            this.tb_cod_plg.Size = new System.Drawing.Size(38, 20);
            this.tb_cod_plg.TabIndex = 10;
            this.tb_cod_plg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_cod_plg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_KeyPress);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 87);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(398, 42);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(303, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 26);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // ecp001_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(404, 133);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ecp001_05";
            this.Tag = "Consulta Plan de pago";
            this.Text = "Consulta Plan de pago";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_cod_plg;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.TextBox tb_nom_plg;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_nro_cuo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_dia_ini;
        private System.Windows.Forms.TextBox tb_int_dia;
        private System.Windows.Forms.TextBox tb_est_ado;
    }
}