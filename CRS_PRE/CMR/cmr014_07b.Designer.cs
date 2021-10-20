namespace CRS_PRE
{
    partial class cmr014_07b
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.gb_tip_com = new System.Windows.Forms.GroupBox();
            this.tb_cms_cre = new System.Windows.Forms.TextBox();
            this.lb_cms_cre = new System.Windows.Forms.Label();
            this.lb_cod_cob = new System.Windows.Forms.Label();
            this.tb_nom_cob = new System.Windows.Forms.TextBox();
            this.lb_nom_cob = new System.Windows.Forms.Label();
            this.tb_cod_cob = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_tip_com.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.MaximumSize = new System.Drawing.Size(210, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comisión p/Total Cobrado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.gb_tip_com);
            this.groupBox1.Controls.Add(this.lb_cod_cob);
            this.groupBox1.Controls.Add(this.tb_nom_cob);
            this.groupBox1.Controls.Add(this.lb_nom_cob);
            this.groupBox1.Controls.Add(this.tb_cod_cob);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(204, 20);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 2;
            this.lb_est_ado.Text = "Estado";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(246, 17);
            this.tb_est_ado.MaxLength = 3;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(83, 20);
            this.tb_est_ado.TabIndex = 3;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_tip_com
            // 
            this.gb_tip_com.Controls.Add(this.tb_cms_cre);
            this.gb_tip_com.Controls.Add(this.lb_cms_cre);
            this.gb_tip_com.Controls.Add(this.label1);
            this.gb_tip_com.Location = new System.Drawing.Point(9, 65);
            this.gb_tip_com.Name = "gb_tip_com";
            this.gb_tip_com.Size = new System.Drawing.Size(333, 41);
            this.gb_tip_com.TabIndex = 6;
            this.gb_tip_com.TabStop = false;
            // 
            // tb_cms_cre
            // 
            this.tb_cms_cre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cms_cre.Location = new System.Drawing.Point(280, 13);
            this.tb_cms_cre.MaxLength = 5;
            this.tb_cms_cre.Name = "tb_cms_cre";
            this.tb_cms_cre.Size = new System.Drawing.Size(40, 20);
            this.tb_cms_cre.TabIndex = 2;
            this.tb_cms_cre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_cms_cre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_cms_cre_KeyPress);
            this.tb_cms_cre.Validated += new System.EventHandler(this.tb_cms_cre_Validated);
            // 
            // lb_cms_cre
            // 
            this.lb_cms_cre.AutoSize = true;
            this.lb_cms_cre.Location = new System.Drawing.Point(181, 16);
            this.lb_cms_cre.Name = "lb_cms_cre";
            this.lb_cms_cre.Size = new System.Drawing.Size(96, 13);
            this.lb_cms_cre.TabIndex = 1;
            this.lb_cms_cre.Text = "% Comision Crédito";
            // 
            // lb_cod_cob
            // 
            this.lb_cod_cob.AutoSize = true;
            this.lb_cod_cob.Location = new System.Drawing.Point(29, 20);
            this.lb_cod_cob.Name = "lb_cod_cob";
            this.lb_cod_cob.Size = new System.Drawing.Size(40, 13);
            this.lb_cod_cob.TabIndex = 0;
            this.lb_cod_cob.Text = "Código";
            // 
            // tb_nom_cob
            // 
            this.tb_nom_cob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_cob.Location = new System.Drawing.Point(71, 41);
            this.tb_nom_cob.MaxLength = 30;
            this.tb_nom_cob.Name = "tb_nom_cob";
            this.tb_nom_cob.ReadOnly = true;
            this.tb_nom_cob.Size = new System.Drawing.Size(258, 20);
            this.tb_nom_cob.TabIndex = 5;
            // 
            // lb_nom_cob
            // 
            this.lb_nom_cob.AutoSize = true;
            this.lb_nom_cob.Location = new System.Drawing.Point(19, 45);
            this.lb_nom_cob.Name = "lb_nom_cob";
            this.lb_nom_cob.Size = new System.Drawing.Size(50, 13);
            this.lb_nom_cob.TabIndex = 4;
            this.lb_nom_cob.Text = "Cobrador";
            // 
            // tb_cod_cob
            // 
            this.tb_cod_cob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_cob.Location = new System.Drawing.Point(71, 17);
            this.tb_cod_cob.MaxLength = 3;
            this.tb_cod_cob.Name = "tb_cod_cob";
            this.tb_cod_cob.ReadOnly = true;
            this.tb_cod_cob.Size = new System.Drawing.Size(45, 20);
            this.tb_cod_cob.TabIndex = 1;
            this.tb_cod_cob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 102);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(351, 39);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(194, 9);
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
            this.bt_can_cel.Location = new System.Drawing.Point(271, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // cmr014_07b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 144);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr014_07b";
            this.Tag = "Comisión Cobrador";
            this.Text = "Comisión Cobrador";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_tip_com.ResumeLayout(false);
            this.gb_tip_com.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.GroupBox gb_tip_com;
        private System.Windows.Forms.TextBox tb_cms_cre;
        private System.Windows.Forms.Label lb_cms_cre;
        private System.Windows.Forms.Label lb_cod_cob;
        private System.Windows.Forms.TextBox tb_nom_cob;
        private System.Windows.Forms.Label lb_nom_cob;
        private System.Windows.Forms.TextBox tb_cod_cob;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}