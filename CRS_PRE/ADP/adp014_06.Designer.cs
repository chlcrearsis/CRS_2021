namespace CRS_PRE
{
    partial class adp014_06
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
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.lb_tip_atr = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_nom_tip = new System.Windows.Forms.TextBox();
            this.tb_ide_tip = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 74);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(344, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(173, 9);
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
            this.bt_can_cel.Location = new System.Drawing.Point(252, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.lb_tip_atr);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_tip);
            this.groupBox1.Controls.Add(this.tb_ide_tip);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(191, 26);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 2;
            this.lb_est_ado.Text = "Estado";
            // 
            // lb_tip_atr
            // 
            this.lb_tip_atr.AutoSize = true;
            this.lb_tip_atr.Location = new System.Drawing.Point(5, 26);
            this.lb_tip_atr.Name = "lb_tip_atr";
            this.lb_tip_atr.Size = new System.Drawing.Size(86, 13);
            this.lb_tip_atr.TabIndex = 0;
            this.lb_tip_atr.Text = "Tipo Documento";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(236, 23);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(80, 20);
            this.tb_est_ado.TabIndex = 3;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_nom_tip
            // 
            this.tb_nom_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_tip.Location = new System.Drawing.Point(93, 46);
            this.tb_nom_tip.MaxLength = 30;
            this.tb_nom_tip.Name = "tb_nom_tip";
            this.tb_nom_tip.ReadOnly = true;
            this.tb_nom_tip.Size = new System.Drawing.Size(223, 20);
            this.tb_nom_tip.TabIndex = 4;
            // 
            // tb_ide_tip
            // 
            this.tb_ide_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tip.Location = new System.Drawing.Point(93, 23);
            this.tb_ide_tip.MaxLength = 3;
            this.tb_ide_tip.Name = "tb_ide_tip";
            this.tb_ide_tip.ReadOnly = true;
            this.tb_ide_tip.Size = new System.Drawing.Size(40, 20);
            this.tb_ide_tip.TabIndex = 1;
            this.tb_ide_tip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adp014_06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 115);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp014_06";
            this.Tag = "Elimina Tipo de Documento";
            this.Text = "Elimina Tipo de Documento";
            this.Load += new System.EventHandler(this.frm_Load);
            this.gb_ctr_btn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Label lb_tip_atr;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.TextBox tb_nom_tip;
        private System.Windows.Forms.TextBox tb_ide_tip;
    }
}