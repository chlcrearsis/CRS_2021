namespace CRS_PRE
{
    partial class ads002_02
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
            this.lb_nom_mod = new System.Windows.Forms.Label();
            this.lb_ide_apl = new System.Windows.Forms.Label();
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_nom_apl = new System.Windows.Forms.TextBox();
            this.tb_ide_apl = new System.Windows.Forms.TextBox();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.bt_bus_mod = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.lb_ide_apl);
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_nom_apl);
            this.groupBox1.Controls.Add(this.tb_ide_apl);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Controls.Add(this.bt_bus_mod);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(110, 17);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_mod.TabIndex = 3;
            this.lb_nom_mod.Text = "...";
            // 
            // lb_ide_apl
            // 
            this.lb_ide_apl.AutoSize = true;
            this.lb_ide_apl.Location = new System.Drawing.Point(8, 41);
            this.lb_ide_apl.Name = "lb_ide_apl";
            this.lb_ide_apl.Size = new System.Drawing.Size(56, 13);
            this.lb_ide_apl.TabIndex = 4;
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
            // tb_nom_apl
            // 
            this.tb_nom_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_apl.Location = new System.Drawing.Point(117, 38);
            this.tb_nom_apl.MaxLength = 30;
            this.tb_nom_apl.Name = "tb_nom_apl";
            this.tb_nom_apl.Size = new System.Drawing.Size(232, 20);
            this.tb_nom_apl.TabIndex = 6;
            // 
            // tb_ide_apl
            // 
            this.tb_ide_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_apl.Location = new System.Drawing.Point(66, 38);
            this.tb_ide_apl.MaxLength = 6;
            this.tb_ide_apl.Name = "tb_ide_apl";
            this.tb_ide_apl.Size = new System.Drawing.Size(47, 20);
            this.tb_ide_apl.TabIndex = 5;
            this.tb_ide_apl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(66, 13);
            this.tb_ide_mod.MaxLength = 2;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(30, 20);
            this.tb_ide_mod.TabIndex = 1;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_ide_mod_KeyDown);
            this.tb_ide_mod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_mod_KeyPress);
            this.tb_ide_mod.Validated += new System.EventHandler(this.tb_ide_mod_Validated);
            // 
            // bt_bus_mod
            // 
            this.bt_bus_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_mod.Location = new System.Drawing.Point(95, 12);
            this.bt_bus_mod.Name = "bt_bus_mod";
            this.bt_bus_mod.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_mod.TabIndex = 2;
            this.bt_bus_mod.TabStop = false;
            this.bt_bus_mod.Text = "|";
            this.bt_bus_mod.UseVisualStyleBackColor = false;
            this.bt_bus_mod.Click += new System.EventHandler(this.bt_bus_mod_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 60);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(361, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(202, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(281, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads002_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 102);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads002_02";
            this.Tag = "Crea Aplicación";
            this.Text = "Crea Aplicación";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Label lb_ide_apl;
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_nom_apl;
        private System.Windows.Forms.TextBox tb_ide_apl;
        private System.Windows.Forms.Button bt_bus_mod;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nom_mod;
    }
}