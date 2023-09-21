namespace CRS_PRE
{
    partial class ads007_03f
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
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_exp_fec = new System.Windows.Forms.MaskedTextBox();
            this.tb_pin_rep = new System.Windows.Forms.TextBox();
            this.lb_exp_fec = new System.Windows.Forms.Label();
            this.lb_pin_rep = new System.Windows.Forms.Label();
            this.tb_pin_nue = new System.Windows.Forms.TextBox();
            this.lb_pin_nue = new System.Windows.Forms.Label();
            this.gb_pin_act = new System.Windows.Forms.GroupBox();
            this.tb_fec_exp = new System.Windows.Forms.MaskedTextBox();
            this.tb_fec_reg = new System.Windows.Forms.MaskedTextBox();
            this.lb_fec_exp = new System.Windows.Forms.Label();
            this.lb_fec_reg = new System.Windows.Forms.Label();
            this.tb_pin_act = new System.Windows.Forms.TextBox();
            this.lb_pin_act = new System.Windows.Forms.Label();
            this.tb_pas_usr = new System.Windows.Forms.TextBox();
            this.lb_pas_usr = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_exp_fec);
            this.groupBox1.Controls.Add(this.tb_pin_rep);
            this.groupBox1.Controls.Add(this.lb_exp_fec);
            this.groupBox1.Controls.Add(this.lb_pin_rep);
            this.groupBox1.Controls.Add(this.tb_pin_nue);
            this.groupBox1.Controls.Add(this.lb_pin_nue);
            this.groupBox1.Controls.Add(this.gb_pin_act);
            this.groupBox1.Controls.Add(this.tb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_nom_usr);
            this.groupBox1.Controls.Add(this.lb_ide_usr);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(186, 16);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 2;
            this.lb_est_ado.Text = "Estado";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(227, 12);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(100, 20);
            this.tb_est_ado.TabIndex = 3;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_exp_fec
            // 
            this.tb_exp_fec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_exp_fec.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_exp_fec.Location = new System.Drawing.Point(139, 216);
            this.tb_exp_fec.Mask = "00/00/0000 00:00";
            this.tb_exp_fec.Name = "tb_exp_fec";
            this.tb_exp_fec.Size = new System.Drawing.Size(105, 20);
            this.tb_exp_fec.TabIndex = 12;
            this.tb_exp_fec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_exp_fec.ValidatingType = typeof(System.DateTime);
            // 
            // tb_pin_rep
            // 
            this.tb_pin_rep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_rep.Location = new System.Drawing.Point(87, 191);
            this.tb_pin_rep.MaxLength = 4;
            this.tb_pin_rep.Name = "tb_pin_rep";
            this.tb_pin_rep.PasswordChar = '*';
            this.tb_pin_rep.Size = new System.Drawing.Size(240, 20);
            this.tb_pin_rep.TabIndex = 10;
            this.tb_pin_rep.Text = "Contraseña";
            this.tb_pin_rep.UseSystemPasswordChar = true;
            this.tb_pin_rep.WordWrap = false;
            this.tb_pin_rep.Enter += new System.EventHandler(this.tb_pin_rep_Enter);
            this.tb_pin_rep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_rep_KeyPress);
            this.tb_pin_rep.Validated += new System.EventHandler(this.tb_pin_rep_Validated);
            // 
            // lb_exp_fec
            // 
            this.lb_exp_fec.AutoSize = true;
            this.lb_exp_fec.Location = new System.Drawing.Point(43, 219);
            this.lb_exp_fec.Name = "lb_exp_fec";
            this.lb_exp_fec.Size = new System.Drawing.Size(94, 13);
            this.lb_exp_fec.TabIndex = 11;
            this.lb_exp_fec.Text = "Fecha expiración :";
            // 
            // lb_pin_rep
            // 
            this.lb_pin_rep.AutoSize = true;
            this.lb_pin_rep.Location = new System.Drawing.Point(10, 194);
            this.lb_pin_rep.Name = "lb_pin_rep";
            this.lb_pin_rep.Size = new System.Drawing.Size(75, 13);
            this.lb_pin_rep.TabIndex = 9;
            this.lb_pin_rep.Text = "Confirma PIN :";
            // 
            // tb_pin_nue
            // 
            this.tb_pin_nue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_nue.HideSelection = false;
            this.tb_pin_nue.Location = new System.Drawing.Point(87, 168);
            this.tb_pin_nue.MaxLength = 4;
            this.tb_pin_nue.Name = "tb_pin_nue";
            this.tb_pin_nue.PasswordChar = '*';
            this.tb_pin_nue.Size = new System.Drawing.Size(240, 20);
            this.tb_pin_nue.TabIndex = 8;
            this.tb_pin_nue.Text = "Contraseña";
            this.tb_pin_nue.UseSystemPasswordChar = true;
            this.tb_pin_nue.WordWrap = false;
            this.tb_pin_nue.Enter += new System.EventHandler(this.tb_pin_nue_Enter);
            this.tb_pin_nue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_nue_KeyPress);
            this.tb_pin_nue.Validated += new System.EventHandler(this.tb_pin_nue_Validated);
            // 
            // lb_pin_nue
            // 
            this.lb_pin_nue.AutoSize = true;
            this.lb_pin_nue.Location = new System.Drawing.Point(19, 170);
            this.lb_pin_nue.Name = "lb_pin_nue";
            this.lb_pin_nue.Size = new System.Drawing.Size(66, 13);
            this.lb_pin_nue.TabIndex = 7;
            this.lb_pin_nue.Text = "Nuevo PIN :";
            // 
            // gb_pin_act
            // 
            this.gb_pin_act.Controls.Add(this.tb_fec_exp);
            this.gb_pin_act.Controls.Add(this.tb_fec_reg);
            this.gb_pin_act.Controls.Add(this.lb_fec_exp);
            this.gb_pin_act.Controls.Add(this.lb_fec_reg);
            this.gb_pin_act.Controls.Add(this.tb_pin_act);
            this.gb_pin_act.Controls.Add(this.lb_pin_act);
            this.gb_pin_act.Controls.Add(this.tb_pas_usr);
            this.gb_pin_act.Controls.Add(this.lb_pas_usr);
            this.gb_pin_act.Location = new System.Drawing.Point(6, 56);
            this.gb_pin_act.Name = "gb_pin_act";
            this.gb_pin_act.Size = new System.Drawing.Size(335, 108);
            this.gb_pin_act.TabIndex = 6;
            this.gb_pin_act.TabStop = false;
            // 
            // tb_fec_exp
            // 
            this.tb_fec_exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_exp.Location = new System.Drawing.Point(133, 83);
            this.tb_fec_exp.Mask = "00/00/0000 00:00";
            this.tb_fec_exp.Name = "tb_fec_exp";
            this.tb_fec_exp.ReadOnly = true;
            this.tb_fec_exp.Size = new System.Drawing.Size(121, 20);
            this.tb_fec_exp.TabIndex = 7;
            this.tb_fec_exp.TabStop = false;
            this.tb_fec_exp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_exp.ValidatingType = typeof(System.DateTime);
            // 
            // tb_fec_reg
            // 
            this.tb_fec_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_reg.Location = new System.Drawing.Point(133, 59);
            this.tb_fec_reg.Mask = "00/00/0000 00:00";
            this.tb_fec_reg.Name = "tb_fec_reg";
            this.tb_fec_reg.ReadOnly = true;
            this.tb_fec_reg.Size = new System.Drawing.Size(121, 20);
            this.tb_fec_reg.TabIndex = 5;
            this.tb_fec_reg.TabStop = false;
            this.tb_fec_reg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_reg.ValidatingType = typeof(System.DateTime);
            // 
            // lb_fec_exp
            // 
            this.lb_fec_exp.AutoSize = true;
            this.lb_fec_exp.Location = new System.Drawing.Point(36, 86);
            this.lb_fec_exp.Name = "lb_fec_exp";
            this.lb_fec_exp.Size = new System.Drawing.Size(95, 13);
            this.lb_fec_exp.TabIndex = 6;
            this.lb_fec_exp.Text = "Fecha Expiración :";
            // 
            // lb_fec_reg
            // 
            this.lb_fec_reg.AutoSize = true;
            this.lb_fec_reg.Location = new System.Drawing.Point(7, 63);
            this.lb_fec_reg.Name = "lb_fec_reg";
            this.lb_fec_reg.Size = new System.Drawing.Size(124, 13);
            this.lb_fec_reg.TabIndex = 4;
            this.lb_fec_reg.Text = "Ultima vez que se Editó :";
            // 
            // tb_pin_act
            // 
            this.tb_pin_act.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_act.Location = new System.Drawing.Point(76, 36);
            this.tb_pin_act.MaxLength = 4;
            this.tb_pin_act.Name = "tb_pin_act";
            this.tb_pin_act.PasswordChar = '*';
            this.tb_pin_act.Size = new System.Drawing.Size(245, 20);
            this.tb_pin_act.TabIndex = 3;
            this.tb_pin_act.Text = "Contraseña";
            this.tb_pin_act.UseSystemPasswordChar = true;
            this.tb_pin_act.WordWrap = false;
            this.tb_pin_act.Enter += new System.EventHandler(this.tb_pin_act_Enter);
            this.tb_pin_act.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_act_KeyPress);
            this.tb_pin_act.Validated += new System.EventHandler(this.tb_pin_act_Validated);
            // 
            // lb_pin_act
            // 
            this.lb_pin_act.AutoSize = true;
            this.lb_pin_act.Location = new System.Drawing.Point(10, 39);
            this.lb_pin_act.Name = "lb_pin_act";
            this.lb_pin_act.Size = new System.Drawing.Size(64, 13);
            this.lb_pin_act.TabIndex = 2;
            this.lb_pin_act.Text = "PIN Actual :";
            // 
            // tb_pas_usr
            // 
            this.tb_pas_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pas_usr.HideSelection = false;
            this.tb_pas_usr.Location = new System.Drawing.Point(76, 13);
            this.tb_pas_usr.MaxLength = 30;
            this.tb_pas_usr.Name = "tb_pas_usr";
            this.tb_pas_usr.PasswordChar = '*';
            this.tb_pas_usr.Size = new System.Drawing.Size(245, 20);
            this.tb_pas_usr.TabIndex = 1;
            this.tb_pas_usr.Text = "Contraseña";
            this.tb_pas_usr.UseSystemPasswordChar = true;
            this.tb_pas_usr.WordWrap = false;
            this.tb_pas_usr.Enter += new System.EventHandler(this.tb_pas_usr_Enter);
            this.tb_pas_usr.Validated += new System.EventHandler(this.tb_pas_usr_Validated);
            // 
            // lb_pas_usr
            // 
            this.lb_pas_usr.AutoSize = true;
            this.lb_pas_usr.Location = new System.Drawing.Point(7, 17);
            this.lb_pas_usr.Name = "lb_pas_usr";
            this.lb_pas_usr.Size = new System.Drawing.Size(67, 13);
            this.lb_pas_usr.TabIndex = 0;
            this.lb_pas_usr.Text = "Contraseña :";
            // 
            // tb_nom_usr
            // 
            this.tb_nom_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_usr.Location = new System.Drawing.Point(55, 37);
            this.tb_nom_usr.MaxLength = 30;
            this.tb_nom_usr.Multiline = true;
            this.tb_nom_usr.Name = "tb_nom_usr";
            this.tb_nom_usr.ReadOnly = true;
            this.tb_nom_usr.Size = new System.Drawing.Size(272, 18);
            this.tb_nom_usr.TabIndex = 5;
            this.tb_nom_usr.TabStop = false;
            this.tb_nom_usr.WordWrap = false;
            // 
            // lb_nom_usr
            // 
            this.lb_nom_usr.AutoSize = true;
            this.lb_nom_usr.Location = new System.Drawing.Point(9, 39);
            this.lb_nom_usr.Name = "lb_nom_usr";
            this.lb_nom_usr.Size = new System.Drawing.Size(44, 13);
            this.lb_nom_usr.TabIndex = 4;
            this.lb_nom_usr.Text = "Nombre";
            // 
            // lb_ide_usr
            // 
            this.lb_ide_usr.AutoSize = true;
            this.lb_ide_usr.Location = new System.Drawing.Point(13, 17);
            this.lb_ide_usr.Name = "lb_ide_usr";
            this.lb_ide_usr.Size = new System.Drawing.Size(40, 13);
            this.lb_ide_usr.TabIndex = 0;
            this.lb_ide_usr.Text = "Codigo";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(55, 14);
            this.tb_ide_usr.MaxLength = 15;
            this.tb_ide_usr.Multiline = true;
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(95, 18);
            this.tb_ide_usr.TabIndex = 1;
            this.tb_ide_usr.TabStop = false;
            this.tb_ide_usr.WordWrap = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 233);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(347, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(187, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(266, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads007_03f
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 274);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads007_03f";
            this.Tag = "Edita PIN de Usuario";
            this.Text = "Edita PIN de Usuario";
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
        private System.Windows.Forms.Label lb_ide_usr;
        private System.Windows.Forms.TextBox tb_ide_usr;
        private System.Windows.Forms.TextBox tb_nom_usr;
        private System.Windows.Forms.Label lb_nom_usr;
        private System.Windows.Forms.TextBox tb_pin_rep;
        private System.Windows.Forms.Label lb_exp_fec;
        private System.Windows.Forms.Label lb_pin_rep;
        private System.Windows.Forms.TextBox tb_pin_nue;
        private System.Windows.Forms.Label lb_pin_nue;
        private System.Windows.Forms.GroupBox gb_pin_act;
        private System.Windows.Forms.Label lb_fec_exp;
        private System.Windows.Forms.Label lb_fec_reg;
        private System.Windows.Forms.TextBox tb_pin_act;
        private System.Windows.Forms.Label lb_pin_act;
        private System.Windows.Forms.TextBox tb_pas_usr;
        private System.Windows.Forms.Label lb_pas_usr;
        private System.Windows.Forms.MaskedTextBox tb_exp_fec;
        private System.Windows.Forms.MaskedTextBox tb_fec_exp;
        private System.Windows.Forms.MaskedTextBox tb_fec_reg;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_est_ado;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}