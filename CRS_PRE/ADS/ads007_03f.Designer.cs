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
            this.tb_fec_exp2 = new System.Windows.Forms.MaskedTextBox();
            this.tb_pin_rep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_pin_new = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_fec_exp = new System.Windows.Forms.MaskedTextBox();
            this.tb_fec_reg = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_pin_act = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_pas_usr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_nom_usr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_fec_exp2);
            this.groupBox1.Controls.Add(this.tb_pin_rep);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_pin_new);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_usr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_ide_usr);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 242);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // tb_fec_exp2
            // 
            this.tb_fec_exp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_exp2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_fec_exp2.Location = new System.Drawing.Point(135, 215);
            this.tb_fec_exp2.Mask = "00/00/0000 00:00";
            this.tb_fec_exp2.Name = "tb_fec_exp2";
            this.tb_fec_exp2.Size = new System.Drawing.Size(95, 20);
            this.tb_fec_exp2.TabIndex = 80;
            this.tb_fec_exp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_exp2.ValidatingType = typeof(System.DateTime);
            // 
            // tb_pin_rep
            // 
            this.tb_pin_rep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_rep.Location = new System.Drawing.Point(87, 191);
            this.tb_pin_rep.MaxLength = 4;
            this.tb_pin_rep.Name = "tb_pin_rep";
            this.tb_pin_rep.PasswordChar = '*';
            this.tb_pin_rep.Size = new System.Drawing.Size(240, 20);
            this.tb_pin_rep.TabIndex = 70;
            this.tb_pin_rep.UseSystemPasswordChar = true;
            this.tb_pin_rep.WordWrap = false;
            this.tb_pin_rep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Fecha expiración :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Confirma PIN :";
            // 
            // tb_pin_new
            // 
            this.tb_pin_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_new.Location = new System.Drawing.Point(87, 168);
            this.tb_pin_new.MaxLength = 4;
            this.tb_pin_new.Name = "tb_pin_new";
            this.tb_pin_new.PasswordChar = '*';
            this.tb_pin_new.Size = new System.Drawing.Size(240, 20);
            this.tb_pin_new.TabIndex = 60;
            this.tb_pin_new.UseSystemPasswordChar = true;
            this.tb_pin_new.WordWrap = false;
            this.tb_pin_new.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Nuevo PIN :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_fec_exp);
            this.groupBox2.Controls.Add(this.tb_fec_reg);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_pin_act);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_pas_usr);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 108);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // tb_fec_exp
            // 
            this.tb_fec_exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_exp.Location = new System.Drawing.Point(133, 83);
            this.tb_fec_exp.Mask = "00/00/0000 00:00";
            this.tb_fec_exp.Name = "tb_fec_exp";
            this.tb_fec_exp.ReadOnly = true;
            this.tb_fec_exp.Size = new System.Drawing.Size(121, 20);
            this.tb_fec_exp.TabIndex = 40;
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
            this.tb_fec_reg.TabIndex = 40;
            this.tb_fec_reg.TabStop = false;
            this.tb_fec_reg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_reg.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Fecha expiración :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Ultima vez que se editó :";
            // 
            // tb_pin_act
            // 
            this.tb_pin_act.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pin_act.Location = new System.Drawing.Point(76, 36);
            this.tb_pin_act.MaxLength = 4;
            this.tb_pin_act.Name = "tb_pin_act";
            this.tb_pin_act.PasswordChar = '*';
            this.tb_pin_act.Size = new System.Drawing.Size(245, 20);
            this.tb_pin_act.TabIndex = 50;
            this.tb_pin_act.UseSystemPasswordChar = true;
            this.tb_pin_act.WordWrap = false;
            this.tb_pin_act.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pin_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "PIN Actual :";
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
            this.tb_pas_usr.TabIndex = 40;
            this.tb_pas_usr.UseSystemPasswordChar = true;
            this.tb_pas_usr.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Contraseña :";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(247, 15);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Multiline = true;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(80, 18);
            this.tb_est_ado.TabIndex = 30;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_est_ado.WordWrap = false;
            // 
            // tb_nom_usr
            // 
            this.tb_nom_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_usr.Location = new System.Drawing.Point(66, 36);
            this.tb_nom_usr.MaxLength = 30;
            this.tb_nom_usr.Multiline = true;
            this.tb_nom_usr.Name = "tb_nom_usr";
            this.tb_nom_usr.ReadOnly = true;
            this.tb_nom_usr.Size = new System.Drawing.Size(261, 18);
            this.tb_nom_usr.TabIndex = 20;
            this.tb_nom_usr.TabStop = false;
            this.tb_nom_usr.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_usr.Location = new System.Drawing.Point(66, 15);
            this.tb_ide_usr.MaxLength = 15;
            this.tb_ide_usr.Multiline = true;
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.ReadOnly = true;
            this.tb_ide_usr.Size = new System.Drawing.Size(95, 18);
            this.tb_ide_usr.TabIndex = 10;
            this.tb_ide_usr.TabStop = false;
            this.tb_ide_usr.WordWrap = false;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 238);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(347, 40);
            this.gb_ctr_btn.TabIndex = 20;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(254, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 26);
            this.bt_can_cel.TabIndex = 80;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(170, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 26);
            this.bt_ace_pta.TabIndex = 70;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // ads007_03f
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(350, 282);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads007_03f";
            this.Tag = "Edita pin de usuario";
            this.Text = "Edita pin de usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ide_usr;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.TextBox tb_nom_usr;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.TextBox tb_pin_rep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_pin_new;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_pin_act;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_pas_usr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tb_fec_exp2;
        private System.Windows.Forms.MaskedTextBox tb_fec_exp;
        private System.Windows.Forms.MaskedTextBox tb_fec_reg;
    }
}