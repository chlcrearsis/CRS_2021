namespace CRS_PRE
{
    partial class adp001_06
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
            this.lb_nom_gru = new System.Windows.Forms.Label();
            this.tb_nom_gru = new System.Windows.Forms.TextBox();
            this.lb_cod_gru = new System.Windows.Forms.Label();
            this.tb_cod_gru = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.lb_nom_gru);
            this.groupBox1.Controls.Add(this.tb_nom_gru);
            this.groupBox1.Controls.Add(this.lb_cod_gru);
            this.groupBox1.Controls.Add(this.tb_cod_gru);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(164, 25);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 2;
            this.lb_est_ado.Text = "Estado";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_est_ado.Location = new System.Drawing.Point(206, 22);
            this.tb_est_ado.MaxLength = 20;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(85, 20);
            this.tb_est_ado.TabIndex = 3;
            // 
            // lb_nom_gru
            // 
            this.lb_nom_gru.AutoSize = true;
            this.lb_nom_gru.Location = new System.Drawing.Point(42, 50);
            this.lb_nom_gru.Name = "lb_nom_gru";
            this.lb_nom_gru.Size = new System.Drawing.Size(44, 13);
            this.lb_nom_gru.TabIndex = 4;
            this.lb_nom_gru.Text = "Nombre";
            // 
            // tb_nom_gru
            // 
            this.tb_nom_gru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_gru.Location = new System.Drawing.Point(88, 47);
            this.tb_nom_gru.MaxLength = 50;
            this.tb_nom_gru.Name = "tb_nom_gru";
            this.tb_nom_gru.ReadOnly = true;
            this.tb_nom_gru.Size = new System.Drawing.Size(203, 20);
            this.tb_nom_gru.TabIndex = 5;
            // 
            // lb_cod_gru
            // 
            this.lb_cod_gru.AutoSize = true;
            this.lb_cod_gru.Location = new System.Drawing.Point(46, 24);
            this.lb_cod_gru.Name = "lb_cod_gru";
            this.lb_cod_gru.Size = new System.Drawing.Size(40, 13);
            this.lb_cod_gru.TabIndex = 0;
            this.lb_cod_gru.Text = "Código";
            // 
            // tb_cod_gru
            // 
            this.tb_cod_gru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_gru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_gru.Location = new System.Drawing.Point(88, 21);
            this.tb_cod_gru.MaxLength = 3;
            this.tb_cod_gru.Name = "tb_cod_gru";
            this.tb_cod_gru.ReadOnly = true;
            this.tb_cod_gru.Size = new System.Drawing.Size(45, 20);
            this.tb_cod_gru.TabIndex = 1;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 78);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(336, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(171, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(250, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp001_06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 121);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp001_06";
            this.Tag = "Habilita/Deshabilita Grupo de Persona";
            this.Text = "Habilita/Deshabilita Grupo de Persona";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.Label lb_nom_gru;
        private System.Windows.Forms.TextBox tb_nom_gru;
        private System.Windows.Forms.Label lb_cod_gru;
        private System.Windows.Forms.TextBox tb_cod_gru;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}