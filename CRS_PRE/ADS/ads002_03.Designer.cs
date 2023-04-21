namespace CRS_PRE
{
    partial class ads002_03
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
            this.tb_est_ado = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_ide_apl = new System.Windows.Forms.Label();
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.tb_nom_apl = new System.Windows.Forms.TextBox();
            this.tb_ide_apl = new System.Windows.Forms.TextBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_est_ado
            // 
            this.tb_est_ado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_est_ado.Location = new System.Drawing.Point(269, 65);
            this.tb_est_ado.MaxLength = 15;
            this.tb_est_ado.Name = "tb_est_ado";
            this.tb_est_ado.ReadOnly = true;
            this.tb_est_ado.Size = new System.Drawing.Size(80, 20);
            this.tb_est_ado.TabIndex = 7;
            this.tb_est_ado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.tb_nom_apl);
            this.groupBox1.Controls.Add(this.tb_ide_apl);
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.lb_ide_apl);
            this.groupBox1.Controls.Add(this.tb_est_ado);
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_ide_apl
            // 
            this.lb_ide_apl.AutoSize = true;
            this.lb_ide_apl.Location = new System.Drawing.Point(8, 42);
            this.lb_ide_apl.Name = "lb_ide_apl";
            this.lb_ide_apl.Size = new System.Drawing.Size(56, 13);
            this.lb_ide_apl.TabIndex = 3;
            this.lb_ide_apl.Text = "Aplicación";
            // 
            // lb_ide_mod
            // 
            this.lb_ide_mod.AutoSize = true;
            this.lb_ide_mod.Location = new System.Drawing.Point(22, 16);
            this.lb_ide_mod.Name = "lb_ide_mod";
            this.lb_ide_mod.Size = new System.Drawing.Size(42, 13);
            this.lb_ide_mod.TabIndex = 0;
            this.lb_ide_mod.Text = "Módulo";
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(66, 13);
            this.tb_ide_mod.MaxLength = 2;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.ReadOnly = true;
            this.tb_ide_mod.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_mod.TabIndex = 1;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 94);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(366, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(198, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(277, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(98, 17);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_mod.TabIndex = 2;
            this.lb_nom_mod.Text = "...";
            // 
            // tb_nom_apl
            // 
            this.tb_nom_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_apl.Location = new System.Drawing.Point(117, 39);
            this.tb_nom_apl.MaxLength = 30;
            this.tb_nom_apl.Name = "tb_nom_apl";
            this.tb_nom_apl.Size = new System.Drawing.Size(232, 20);
            this.tb_nom_apl.TabIndex = 5;
            // 
            // tb_ide_apl
            // 
            this.tb_ide_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_apl.Location = new System.Drawing.Point(66, 39);
            this.tb_ide_apl.MaxLength = 6;
            this.tb_ide_apl.Name = "tb_ide_apl";
            this.tb_ide_apl.ReadOnly = true;
            this.tb_ide_apl.Size = new System.Drawing.Size(47, 20);
            this.tb_ide_apl.TabIndex = 4;
            this.tb_ide_apl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(227, 68);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 6;
            this.lb_est_ado.Text = "Estado";
            // 
            // ads002_03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 137);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads002_03";
            this.Tag = "Edita Aplicación";
            this.Text = "Edita Aplicación";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_est_ado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_ide_apl;
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_ide_mod;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.TextBox tb_nom_apl;
        private System.Windows.Forms.TextBox tb_ide_apl;
    }
}