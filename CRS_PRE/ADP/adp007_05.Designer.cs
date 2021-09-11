namespace CRS_PRE
{
    partial class adp007_05
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
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.lb_nom_cor = new System.Windows.Forms.Label();
            this.lb_tip_rut = new System.Windows.Forms.Label();
            this.tb_nom_cor = new System.Windows.Forms.TextBox();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_nom_rut = new System.Windows.Forms.TextBox();
            this.tb_ide_rut = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 79);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(321, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(228, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 0;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.lb_nom_cor);
            this.groupBox1.Controls.Add(this.lb_tip_rut);
            this.groupBox1.Controls.Add(this.tb_nom_cor);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_rut);
            this.groupBox1.Controls.Add(this.tb_ide_rut);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(170, 55);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 5;
            this.lb_est_ado.Text = "Estado";
            // 
            // lb_nom_cor
            // 
            this.lb_nom_cor.AutoSize = true;
            this.lb_nom_cor.Location = new System.Drawing.Point(25, 55);
            this.lb_nom_cor.Name = "lb_nom_cor";
            this.lb_nom_cor.Size = new System.Drawing.Size(72, 13);
            this.lb_nom_cor.TabIndex = 3;
            this.lb_nom_cor.Text = "Nombre Corto";
            // 
            // lb_tip_rut
            // 
            this.lb_tip_rut.AutoSize = true;
            this.lb_tip_rut.Location = new System.Drawing.Point(25, 29);
            this.lb_tip_rut.Name = "lb_tip_rut";
            this.lb_tip_rut.Size = new System.Drawing.Size(30, 13);
            this.lb_tip_rut.TabIndex = 0;
            this.lb_tip_rut.Text = "Ruta";
            // 
            // tb_nom_cor
            // 
            this.tb_nom_cor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_cor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nom_cor.Location = new System.Drawing.Point(100, 52);
            this.tb_nom_cor.MaxLength = 15;
            this.tb_nom_cor.Name = "tb_nom_cor";
            this.tb_nom_cor.ReadOnly = true;
            this.tb_nom_cor.Size = new System.Drawing.Size(62, 20);
            this.tb_nom_cor.TabIndex = 4;
            this.tb_nom_cor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(212, 52);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(80, 20);
            this.tb_est_ado.TabIndex = 6;
            this.tb_est_ado.TabStop = false;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_nom_rut
            // 
            this.tb_nom_rut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_rut.Location = new System.Drawing.Point(100, 26);
            this.tb_nom_rut.MaxLength = 30;
            this.tb_nom_rut.Name = "tb_nom_rut";
            this.tb_nom_rut.ReadOnly = true;
            this.tb_nom_rut.Size = new System.Drawing.Size(192, 20);
            this.tb_nom_rut.TabIndex = 2;
            // 
            // tb_ide_rut
            // 
            this.tb_ide_rut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_rut.Location = new System.Drawing.Point(57, 26);
            this.tb_ide_rut.MaxLength = 4;
            this.tb_ide_rut.Name = "tb_ide_rut";
            this.tb_ide_rut.ReadOnly = true;
            this.tb_ide_rut.Size = new System.Drawing.Size(40, 20);
            this.tb_ide_rut.TabIndex = 1;
            this.tb_ide_rut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adp007_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 121);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp007_05";
            this.Tag = "Consulta Definición de Ruta";
            this.Text = "Consulta Definición de Ruta";
            this.Load += new System.EventHandler(this.frm_Load);
            this.gb_ctr_btn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Label lb_nom_cor;
        private System.Windows.Forms.Label lb_tip_rut;
        private System.Windows.Forms.TextBox tb_nom_cor;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.TextBox tb_nom_rut;
        private System.Windows.Forms.TextBox tb_ide_rut;
    }
}