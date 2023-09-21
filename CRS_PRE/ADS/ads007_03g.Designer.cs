namespace CRS_PRE
{
    partial class ads007_03g
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
            this.gb_pin_act = new System.Windows.Forms.GroupBox();
            this.tb_usr_reg = new System.Windows.Forms.TextBox();
            this.tb_fec_exp = new System.Windows.Forms.MaskedTextBox();
            this.tb_fec_reg = new System.Windows.Forms.MaskedTextBox();
            this.lb_fec_exp = new System.Windows.Forms.Label();
            this.lb_fec_reg = new System.Windows.Forms.Label();
            this.lb_usr_reg = new System.Windows.Forms.Label();
            this.lb_tit_ulo = new System.Windows.Forms.Label();
            this.lb_sub_tit = new System.Windows.Forms.Label();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_nom_usr = new System.Windows.Forms.TextBox();
            this.lb_nom_usr = new System.Windows.Forms.Label();
            this.lb_ide_usr = new System.Windows.Forms.Label();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_pin_act.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gb_pin_act);
            this.groupBox1.Controls.Add(this.lb_tit_ulo);
            this.groupBox1.Controls.Add(this.lb_sub_tit);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_ide_usr);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gb_pin_act
            // 
            this.gb_pin_act.Controls.Add(this.tb_usr_reg);
            this.gb_pin_act.Controls.Add(this.tb_fec_exp);
            this.gb_pin_act.Controls.Add(this.tb_fec_reg);
            this.gb_pin_act.Controls.Add(this.lb_fec_exp);
            this.gb_pin_act.Controls.Add(this.lb_fec_reg);
            this.gb_pin_act.Controls.Add(this.lb_usr_reg);
            this.gb_pin_act.Location = new System.Drawing.Point(7, 117);
            this.gb_pin_act.Name = "gb_pin_act";
            this.gb_pin_act.Size = new System.Drawing.Size(329, 91);
            this.gb_pin_act.TabIndex = 8;
            this.gb_pin_act.TabStop = false;
            // 
            // tb_usr_reg
            // 
            this.tb_usr_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_usr_reg.Location = new System.Drawing.Point(58, 14);
            this.tb_usr_reg.MaxLength = 30;
            this.tb_usr_reg.Multiline = true;
            this.tb_usr_reg.Name = "tb_usr_reg";
            this.tb_usr_reg.ReadOnly = true;
            this.tb_usr_reg.Size = new System.Drawing.Size(260, 18);
            this.tb_usr_reg.TabIndex = 1;
            this.tb_usr_reg.TabStop = false;
            this.tb_usr_reg.WordWrap = false;
            // 
            // tb_fec_exp
            // 
            this.tb_fec_exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_exp.Location = new System.Drawing.Point(133, 60);
            this.tb_fec_exp.Mask = "00/00/0000 00:00";
            this.tb_fec_exp.Name = "tb_fec_exp";
            this.tb_fec_exp.ReadOnly = true;
            this.tb_fec_exp.Size = new System.Drawing.Size(121, 20);
            this.tb_fec_exp.TabIndex = 5;
            this.tb_fec_exp.TabStop = false;
            this.tb_fec_exp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_exp.ValidatingType = typeof(System.DateTime);
            // 
            // tb_fec_reg
            // 
            this.tb_fec_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_reg.Location = new System.Drawing.Point(133, 36);
            this.tb_fec_reg.Mask = "00/00/0000 00:00";
            this.tb_fec_reg.Name = "tb_fec_reg";
            this.tb_fec_reg.ReadOnly = true;
            this.tb_fec_reg.Size = new System.Drawing.Size(121, 20);
            this.tb_fec_reg.TabIndex = 3;
            this.tb_fec_reg.TabStop = false;
            this.tb_fec_reg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_reg.ValidatingType = typeof(System.DateTime);
            // 
            // lb_fec_exp
            // 
            this.lb_fec_exp.AutoSize = true;
            this.lb_fec_exp.Location = new System.Drawing.Point(36, 63);
            this.lb_fec_exp.Name = "lb_fec_exp";
            this.lb_fec_exp.Size = new System.Drawing.Size(95, 13);
            this.lb_fec_exp.TabIndex = 4;
            this.lb_fec_exp.Text = "Fecha Expiración :";
            // 
            // lb_fec_reg
            // 
            this.lb_fec_reg.AutoSize = true;
            this.lb_fec_reg.Location = new System.Drawing.Point(7, 40);
            this.lb_fec_reg.Name = "lb_fec_reg";
            this.lb_fec_reg.Size = new System.Drawing.Size(124, 13);
            this.lb_fec_reg.TabIndex = 2;
            this.lb_fec_reg.Text = "Ultima vez que se Editó :";
            // 
            // lb_usr_reg
            // 
            this.lb_usr_reg.AutoSize = true;
            this.lb_usr_reg.Location = new System.Drawing.Point(4, 16);
            this.lb_usr_reg.Name = "lb_usr_reg";
            this.lb_usr_reg.Size = new System.Drawing.Size(52, 13);
            this.lb_usr_reg.TabIndex = 0;
            this.lb_usr_reg.Text = "Registro :";
            // 
            // lb_tit_ulo
            // 
            this.lb_tit_ulo.AutoSize = true;
            this.lb_tit_ulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_ulo.Location = new System.Drawing.Point(86, 14);
            this.lb_tit_ulo.Name = "lb_tit_ulo";
            this.lb_tit_ulo.Size = new System.Drawing.Size(166, 15);
            this.lb_tit_ulo.TabIndex = 0;
            this.lb_tit_ulo.Text = "Inicializa PIN de Usuario";
            // 
            // lb_sub_tit
            // 
            this.lb_sub_tit.AutoSize = true;
            this.lb_sub_tit.Location = new System.Drawing.Point(37, 36);
            this.lb_sub_tit.Name = "lb_sub_tit";
            this.lb_sub_tit.Size = new System.Drawing.Size(268, 26);
            this.lb_sub_tit.TabIndex = 1;
            this.lb_sub_tit.Text = "Esta opción inicializara el PIN del Usuario seleccionado\r\n¿Desea continuar?";
            this.lb_sub_tit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(184, 76);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 4;
            this.lb_est_ado.Text = "Estado";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(225, 72);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(100, 20);
            this.tb_est_ado.TabIndex = 5;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_nom_usr
            // 
            this.tb_nom_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_usr.Location = new System.Drawing.Point(53, 97);
            this.tb_nom_usr.MaxLength = 30;
            this.tb_nom_usr.Multiline = true;
            this.tb_nom_usr.Name = "tb_nom_usr";
            this.tb_nom_usr.ReadOnly = true;
            this.tb_nom_usr.Size = new System.Drawing.Size(272, 18);
            this.tb_nom_usr.TabIndex = 7;
            this.tb_nom_usr.TabStop = false;
            this.tb_nom_usr.WordWrap = false;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.Location = new System.Drawing.Point(7, 99);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(44, 13);
            this.lb_nom_usr.TabIndex = 6;
            this.lb_nom_usr.Text = "Nombre";
            // 
            // lb_ide_usr
            // 
            this.lb_ide_usr.AutoSize = true;
            this.lb_ide_usr.Location = new System.Drawing.Point(11, 77);
            this.lb_ide_usr.Name = "lb_ide_usr";
            this.lb_ide_usr.Size = new System.Drawing.Size(40, 13);
            this.lb_ide_usr.TabIndex = 2;
            this.lb_ide_usr.Text = "Codigo";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(53, 74);
            this.tb_ide_usr.MaxLength = 15;
            this.tb_ide_usr.Multiline = true;
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(95, 18);
            this.tb_ide_usr.TabIndex = 3;
            this.tb_ide_usr.TabStop = false;
            this.tb_ide_usr.WordWrap = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 204);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(343, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(183, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(262, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads007_03g
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 245);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads007_03g";
            this.Tag = "Inicializa PIN del Usuario";
            this.Text = "Inicializa PIN del Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_pin_act.ResumeLayout(false);
            this.gb_pin_act.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.TextBox tb_nom_usr;
        private System.Windows.Forms.Label lb_nom_usr;
        private System.Windows.Forms.Label lb_ide_usr;
        private System.Windows.Forms.TextBox tb_ide_usr;
        private System.Windows.Forms.Label lb_tit_ulo;
        private System.Windows.Forms.Label lb_sub_tit;
        private System.Windows.Forms.GroupBox gb_pin_act;
        private System.Windows.Forms.MaskedTextBox tb_fec_exp;
        private System.Windows.Forms.MaskedTextBox tb_fec_reg;
        private System.Windows.Forms.Label lb_fec_exp;
        private System.Windows.Forms.Label lb_fec_reg;
        private System.Windows.Forms.Label lb_usr_reg;
        private System.Windows.Forms.TextBox tb_usr_reg;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}