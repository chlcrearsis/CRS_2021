namespace CRS_PRE
{
    partial class ads001_05
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
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.tb_abr_mod = new System.Windows.Forms.TextBox();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.tb_nom_mod = new System.Windows.Forms.TextBox();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.gb_ctr_btn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 69);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(336, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(250, 10);
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
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.tb_abr_mod);
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.tb_nom_mod);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_ide_mod
            // 
            this.lb_ide_mod.AutoSize = true;
            this.lb_ide_mod.Location = new System.Drawing.Point(40, 20);
            this.lb_ide_mod.Name = "lb_ide_mod";
            this.lb_ide_mod.Size = new System.Drawing.Size(40, 13);
            this.lb_ide_mod.TabIndex = 0;
            this.lb_ide_mod.Text = "Código";
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(217, 17);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(80, 20);
            this.tb_est_ado.TabIndex = 3;
            // 
            // tb_abr_mod
            // 
            this.tb_abr_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_abr_mod.Location = new System.Drawing.Point(82, 43);
            this.tb_abr_mod.MaxLength = 3;
            this.tb_abr_mod.Name = "tb_abr_mod";
            this.tb_abr_mod.ReadOnly = true;
            this.tb_abr_mod.Size = new System.Drawing.Size(47, 20);
            this.tb_abr_mod.TabIndex = 5;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(38, 46);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(42, 13);
            this.lb_nom_mod.TabIndex = 4;
            this.lb_nom_mod.Text = "Módulo";
            // 
            // tb_nom_mod
            // 
            this.tb_nom_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_mod.Location = new System.Drawing.Point(132, 43);
            this.tb_nom_mod.MaxLength = 30;
            this.tb_nom_mod.Name = "tb_nom_mod";
            this.tb_nom_mod.ReadOnly = true;
            this.tb_nom_mod.Size = new System.Drawing.Size(166, 20);
            this.tb_nom_mod.TabIndex = 6;
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(82, 17);
            this.tb_ide_mod.MaxLength = 2;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.ReadOnly = true;
            this.tb_ide_mod.Size = new System.Drawing.Size(45, 20);
            this.tb_ide_mod.TabIndex = 1;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(175, 20);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 2;
            this.lb_est_ado.Text = "Estado";
            // 
            // ads001_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 111);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads001_05";
            this.Tag = "Consulta Módulo";
            this.Text = "Consulta Módulo";
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
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.TextBox tb_abr_mod;
        private System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.TextBox tb_nom_mod;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Label lb_est_ado;
    }
}