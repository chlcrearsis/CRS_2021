namespace CRS_PRE
{
    partial class adp010_03
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
            this.lb_por_con = new System.Windows.Forms.Label();
            this.lb_tip_fac = new System.Windows.Forms.Label();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.gb_dat_per = new System.Windows.Forms.GroupBox();
            this.tb_raz_soc = new System.Windows.Forms.TextBox();
            this.lb_cod_per = new System.Windows.Forms.Label();
            this.tb_cod_per = new System.Windows.Forms.TextBox();
            this.gb_dat_pri = new System.Windows.Forms.GroupBox();
            this.tb_por_cre = new System.Windows.Forms.TextBox();
            this.lb_por_cre = new System.Windows.Forms.Label();
            this.tb_por_con = new System.Windows.Forms.TextBox();
            this.cb_tip_ndv = new System.Windows.Forms.ComboBox();
            this.lb_tip_ndv = new System.Windows.Forms.Label();
            this.cb_tip_fac = new System.Windows.Forms.ComboBox();
            this.gb_ctr_btn.SuspendLayout();
            this.gb_dat_per.SuspendLayout();
            this.gb_dat_pri.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_por_con
            // 
            this.lb_por_con.AutoSize = true;
            this.lb_por_con.Location = new System.Drawing.Point(6, 47);
            this.lb_por_con.Name = "lb_por_con";
            this.lb_por_con.Size = new System.Drawing.Size(124, 13);
            this.lb_por_con.TabIndex = 3;
            this.lb_por_con.Text = "% Descuento p/Contado";
            // 
            // lb_tip_fac
            // 
            this.lb_tip_fac.AutoSize = true;
            this.lb_tip_fac.Location = new System.Drawing.Point(6, 16);
            this.lb_tip_fac.Name = "lb_tip_fac";
            this.lb_tip_fac.Size = new System.Drawing.Size(109, 13);
            this.lb_tip_fac.TabIndex = 0;
            this.lb_tip_fac.Text = "Descuento p/Factura";
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 104);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(386, 40);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(223, 9);
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
            this.bt_can_cel.Location = new System.Drawing.Point(302, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // gb_dat_per
            // 
            this.gb_dat_per.Controls.Add(this.tb_raz_soc);
            this.gb_dat_per.Controls.Add(this.lb_cod_per);
            this.gb_dat_per.Controls.Add(this.tb_cod_per);
            this.gb_dat_per.Location = new System.Drawing.Point(4, -4);
            this.gb_dat_per.Name = "gb_dat_per";
            this.gb_dat_per.Size = new System.Drawing.Size(386, 38);
            this.gb_dat_per.TabIndex = 0;
            this.gb_dat_per.TabStop = false;
            // 
            // tb_raz_soc
            // 
            this.tb_raz_soc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_raz_soc.Location = new System.Drawing.Point(110, 12);
            this.tb_raz_soc.MaxLength = 30;
            this.tb_raz_soc.Multiline = true;
            this.tb_raz_soc.Name = "tb_raz_soc";
            this.tb_raz_soc.ReadOnly = true;
            this.tb_raz_soc.Size = new System.Drawing.Size(264, 18);
            this.tb_raz_soc.TabIndex = 2;
            this.tb_raz_soc.TabStop = false;
            this.tb_raz_soc.WordWrap = false;
            // 
            // lb_cod_per
            // 
            this.lb_cod_per.AutoSize = true;
            this.lb_cod_per.Location = new System.Drawing.Point(4, 14);
            this.lb_cod_per.Name = "lb_cod_per";
            this.lb_cod_per.Size = new System.Drawing.Size(46, 13);
            this.lb_cod_per.TabIndex = 0;
            this.lb_cod_per.Text = "Persona";
            // 
            // tb_cod_per
            // 
            this.tb_cod_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_per.Location = new System.Drawing.Point(51, 12);
            this.tb_cod_per.MaxLength = 15;
            this.tb_cod_per.Multiline = true;
            this.tb_cod_per.Name = "tb_cod_per";
            this.tb_cod_per.ReadOnly = true;
            this.tb_cod_per.Size = new System.Drawing.Size(55, 18);
            this.tb_cod_per.TabIndex = 1;
            this.tb_cod_per.TabStop = false;
            this.tb_cod_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_cod_per.WordWrap = false;
            // 
            // gb_dat_pri
            // 
            this.gb_dat_pri.Controls.Add(this.tb_por_cre);
            this.gb_dat_pri.Controls.Add(this.lb_por_cre);
            this.gb_dat_pri.Controls.Add(this.tb_por_con);
            this.gb_dat_pri.Controls.Add(this.cb_tip_ndv);
            this.gb_dat_pri.Controls.Add(this.lb_tip_ndv);
            this.gb_dat_pri.Controls.Add(this.cb_tip_fac);
            this.gb_dat_pri.Controls.Add(this.lb_por_con);
            this.gb_dat_pri.Controls.Add(this.lb_tip_fac);
            this.gb_dat_pri.Location = new System.Drawing.Point(4, 28);
            this.gb_dat_pri.Name = "gb_dat_pri";
            this.gb_dat_pri.Size = new System.Drawing.Size(386, 82);
            this.gb_dat_pri.TabIndex = 1;
            this.gb_dat_pri.TabStop = false;
            // 
            // tb_por_cre
            // 
            this.tb_por_cre.Location = new System.Drawing.Point(329, 44);
            this.tb_por_cre.Name = "tb_por_cre";
            this.tb_por_cre.Size = new System.Drawing.Size(45, 20);
            this.tb_por_cre.TabIndex = 21;
            this.tb_por_cre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_por_cre.Validated += new System.EventHandler(this.tb_por_cre_Validated);
            // 
            // lb_por_cre
            // 
            this.lb_por_cre.AutoSize = true;
            this.lb_por_cre.Location = new System.Drawing.Point(210, 47);
            this.lb_por_cre.Name = "lb_por_cre";
            this.lb_por_cre.Size = new System.Drawing.Size(117, 13);
            this.lb_por_cre.TabIndex = 20;
            this.lb_por_cre.Text = "% Descuento p/Crédito";
            // 
            // tb_por_con
            // 
            this.tb_por_con.Location = new System.Drawing.Point(132, 44);
            this.tb_por_con.Name = "tb_por_con";
            this.tb_por_con.Size = new System.Drawing.Size(45, 20);
            this.tb_por_con.TabIndex = 19;
            this.tb_por_con.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_por_con.Validated += new System.EventHandler(this.tb_por_con_Validated);
            // 
            // cb_tip_ndv
            // 
            this.cb_tip_ndv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_ndv.FormattingEnabled = true;
            this.cb_tip_ndv.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cb_tip_ndv.Location = new System.Drawing.Point(333, 12);
            this.cb_tip_ndv.Name = "cb_tip_ndv";
            this.cb_tip_ndv.Size = new System.Drawing.Size(41, 21);
            this.cb_tip_ndv.TabIndex = 18;
            // 
            // lb_tip_ndv
            // 
            this.lb_tip_ndv.AutoSize = true;
            this.lb_tip_ndv.Location = new System.Drawing.Point(189, 16);
            this.lb_tip_ndv.Name = "lb_tip_ndv";
            this.lb_tip_ndv.Size = new System.Drawing.Size(142, 13);
            this.lb_tip_ndv.TabIndex = 17;
            this.lb_tip_ndv.Text = "Descuento p/Nota de Venta";
            // 
            // cb_tip_fac
            // 
            this.cb_tip_fac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_fac.FormattingEnabled = true;
            this.cb_tip_fac.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cb_tip_fac.Location = new System.Drawing.Point(117, 12);
            this.cb_tip_fac.Name = "cb_tip_fac";
            this.cb_tip_fac.Size = new System.Drawing.Size(41, 21);
            this.cb_tip_fac.TabIndex = 16;
            // 
            // adp010_03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(393, 147);
            this.ControlBox = false;
            this.Controls.Add(this.gb_dat_per);
            this.Controls.Add(this.gb_dat_pri);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp010_03";
            this.Tag = "Descuento General p/Persona";
            this.Text = "Descuento General p/Persona";
            this.Load += new System.EventHandler(this.frm_Load);
            this.gb_ctr_btn.ResumeLayout(false);
            this.gb_dat_per.ResumeLayout(false);
            this.gb_dat_per.PerformLayout();
            this.gb_dat_pri.ResumeLayout(false);
            this.gb_dat_pri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_tip_fac;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label lb_por_con;
        private System.Windows.Forms.GroupBox gb_dat_per;
        private System.Windows.Forms.TextBox tb_raz_soc;
        private System.Windows.Forms.Label lb_cod_per;
        private System.Windows.Forms.TextBox tb_cod_per;
        private System.Windows.Forms.GroupBox gb_dat_pri;
        private System.Windows.Forms.TextBox tb_por_cre;
        private System.Windows.Forms.Label lb_por_cre;
        private System.Windows.Forms.TextBox tb_por_con;
        private System.Windows.Forms.ComboBox cb_tip_ndv;
        private System.Windows.Forms.Label lb_tip_ndv;
        private System.Windows.Forms.ComboBox cb_tip_fac;
    }
}