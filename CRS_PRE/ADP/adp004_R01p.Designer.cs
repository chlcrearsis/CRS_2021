﻿namespace CRS_PRE
{
    partial class adp004_R01p
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
            this.cb_est_ado = new System.Windows.Forms.ComboBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.lb_nta_fin = new System.Windows.Forms.Label();
            this.lb_nta_ini = new System.Windows.Forms.Label();
            this.gb_ord_por = new System.Windows.Forms.GroupBox();
            this.rb_ord_nom = new System.Windows.Forms.RadioButton();
            this.rb_ord_cod = new System.Windows.Forms.RadioButton();
            this.lb_tip_fin = new System.Windows.Forms.Label();
            this.tb_tip_fin = new System.Windows.Forms.TextBox();
            this.bt_tip_fin = new System.Windows.Forms.Button();
            this.lb_tip_ini = new System.Windows.Forms.Label();
            this.tb_tip_ini = new System.Windows.Forms.TextBox();
            this.bt_tip_ini = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ord_por.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_est_ado);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.lb_nta_fin);
            this.groupBox1.Controls.Add(this.lb_nta_ini);
            this.groupBox1.Controls.Add(this.gb_ord_por);
            this.groupBox1.Controls.Add(this.lb_tip_fin);
            this.groupBox1.Controls.Add(this.tb_tip_fin);
            this.groupBox1.Controls.Add(this.bt_tip_fin);
            this.groupBox1.Controls.Add(this.lb_tip_ini);
            this.groupBox1.Controls.Add(this.tb_tip_ini);
            this.groupBox1.Controls.Add(this.bt_tip_ini);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cb_est_ado
            // 
            this.cb_est_ado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_ado.FormattingEnabled = true;
            this.cb_est_ado.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_ado.Location = new System.Drawing.Point(144, 79);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(104, 21);
            this.cb_est_ado.TabIndex = 9;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(102, 82);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 8;
            this.lb_est_ado.Text = "Estado";
            // 
            // lb_nta_fin
            // 
            this.lb_nta_fin.AutoSize = true;
            this.lb_nta_fin.Location = new System.Drawing.Point(160, 49);
            this.lb_nta_fin.Name = "lb_nta_fin";
            this.lb_nta_fin.Size = new System.Drawing.Size(19, 13);
            this.lb_nta_fin.TabIndex = 7;
            this.lb_nta_fin.Text = "....";
            // 
            // lb_nta_ini
            // 
            this.lb_nta_ini.AutoSize = true;
            this.lb_nta_ini.Location = new System.Drawing.Point(160, 23);
            this.lb_nta_ini.Name = "lb_nta_ini";
            this.lb_nta_ini.Size = new System.Drawing.Size(19, 13);
            this.lb_nta_ini.TabIndex = 3;
            this.lb_nta_ini.Text = "....";
            // 
            // gb_ord_por
            // 
            this.gb_ord_por.Controls.Add(this.rb_ord_nom);
            this.gb_ord_por.Controls.Add(this.rb_ord_cod);
            this.gb_ord_por.Location = new System.Drawing.Point(11, 106);
            this.gb_ord_por.Name = "gb_ord_por";
            this.gb_ord_por.Size = new System.Drawing.Size(340, 41);
            this.gb_ord_por.TabIndex = 10;
            this.gb_ord_por.TabStop = false;
            this.gb_ord_por.Text = "Ordenado por";
            // 
            // rb_ord_nom
            // 
            this.rb_ord_nom.AutoSize = true;
            this.rb_ord_nom.Location = new System.Drawing.Point(179, 15);
            this.rb_ord_nom.Name = "rb_ord_nom";
            this.rb_ord_nom.Size = new System.Drawing.Size(62, 17);
            this.rb_ord_nom.TabIndex = 1;
            this.rb_ord_nom.TabStop = true;
            this.rb_ord_nom.Text = "Nombre";
            this.rb_ord_nom.UseVisualStyleBackColor = true;
            // 
            // rb_ord_cod
            // 
            this.rb_ord_cod.AutoSize = true;
            this.rb_ord_cod.Location = new System.Drawing.Point(85, 15);
            this.rb_ord_cod.Name = "rb_ord_cod";
            this.rb_ord_cod.Size = new System.Drawing.Size(58, 17);
            this.rb_ord_cod.TabIndex = 0;
            this.rb_ord_cod.TabStop = true;
            this.rb_ord_cod.Text = "Código";
            this.rb_ord_cod.UseVisualStyleBackColor = true;
            // 
            // lb_tip_fin
            // 
            this.lb_tip_fin.AutoSize = true;
            this.lb_tip_fin.Location = new System.Drawing.Point(13, 49);
            this.lb_tip_fin.Name = "lb_tip_fin";
            this.lb_tip_fin.Size = new System.Drawing.Size(92, 13);
            this.lb_tip_fin.TabIndex = 4;
            this.lb_tip_fin.Text = "Tipo Atributo Final";
            // 
            // tb_tip_fin
            // 
            this.tb_tip_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tip_fin.Location = new System.Drawing.Point(107, 45);
            this.tb_tip_fin.MaxLength = 3;
            this.tb_tip_fin.Name = "tb_tip_fin";
            this.tb_tip_fin.Size = new System.Drawing.Size(37, 20);
            this.tb_tip_fin.TabIndex = 5;
            this.tb_tip_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_tip_fin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_tip_fin_KeyDown);
            // 
            // bt_tip_fin
            // 
            this.bt_tip_fin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_tip_fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_tip_fin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_tip_fin.Location = new System.Drawing.Point(143, 44);
            this.bt_tip_fin.Name = "bt_tip_fin";
            this.bt_tip_fin.Size = new System.Drawing.Size(16, 22);
            this.bt_tip_fin.TabIndex = 6;
            this.bt_tip_fin.TabStop = false;
            this.bt_tip_fin.Text = "|";
            this.bt_tip_fin.UseVisualStyleBackColor = false;
            this.bt_tip_fin.Click += new System.EventHandler(this.bt_tip_fin_Click);
            // 
            // lb_tip_ini
            // 
            this.lb_tip_ini.AutoSize = true;
            this.lb_tip_ini.Location = new System.Drawing.Point(8, 23);
            this.lb_tip_ini.Name = "lb_tip_ini";
            this.lb_tip_ini.Size = new System.Drawing.Size(97, 13);
            this.lb_tip_ini.TabIndex = 0;
            this.lb_tip_ini.Text = "Tipo Atributo Inicial";
            // 
            // tb_tip_ini
            // 
            this.tb_tip_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_tip_ini.Location = new System.Drawing.Point(107, 19);
            this.tb_tip_ini.MaxLength = 3;
            this.tb_tip_ini.Name = "tb_tip_ini";
            this.tb_tip_ini.Size = new System.Drawing.Size(37, 20);
            this.tb_tip_ini.TabIndex = 1;
            this.tb_tip_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_tip_ini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_tip_ini_KeyDown);
            // 
            // bt_tip_ini
            // 
            this.bt_tip_ini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_tip_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_tip_ini.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_tip_ini.Location = new System.Drawing.Point(143, 18);
            this.bt_tip_ini.Name = "bt_tip_ini";
            this.bt_tip_ini.Size = new System.Drawing.Size(16, 22);
            this.bt_tip_ini.TabIndex = 2;
            this.bt_tip_ini.TabStop = false;
            this.bt_tip_ini.Text = "|";
            this.bt_tip_ini.UseVisualStyleBackColor = false;
            this.bt_tip_ini.Click += new System.EventHandler(this.bt_tip_ini_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 144);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(360, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(197, 10);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 0;
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
            this.bt_can_cel.Location = new System.Drawing.Point(276, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp004_R01p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 186);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp004_R01p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Definición de Atributos";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ord_por.ResumeLayout(false);
            this.gb_ord_por.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Label lb_tip_fin;
        private System.Windows.Forms.TextBox tb_tip_fin;
        private System.Windows.Forms.Button bt_tip_fin;
        private System.Windows.Forms.Label lb_tip_ini;
        private System.Windows.Forms.TextBox tb_tip_ini;
        private System.Windows.Forms.Button bt_tip_ini;
        private System.Windows.Forms.RadioButton rb_ord_nom;
        private System.Windows.Forms.RadioButton rb_ord_cod;
        private System.Windows.Forms.GroupBox gb_ord_por;
        private System.Windows.Forms.Label lb_nta_fin;
        private System.Windows.Forms.Label lb_nta_ini;
        private System.Windows.Forms.ComboBox cb_est_ado;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}