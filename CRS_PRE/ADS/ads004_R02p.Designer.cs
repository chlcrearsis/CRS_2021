namespace CRS_PRE
{
    partial class ads004_R02p
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
            this.lb_ide_mod = new System.Windows.Forms.Label();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.bt_bus_mod = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.lb_ndo_fin = new System.Windows.Forms.Label();
            this.lb_ndo_ini = new System.Windows.Forms.Label();
            this.lb_doc_fin = new System.Windows.Forms.Label();
            this.tb_doc_fin = new System.Windows.Forms.TextBox();
            this.bt_doc_fin = new System.Windows.Forms.Button();
            this.lb_doc_ini = new System.Windows.Forms.Label();
            this.tb_doc_ini = new System.Windows.Forms.TextBox();
            this.bt_doc_ini = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_ndo_fin);
            this.groupBox1.Controls.Add(this.lb_ndo_ini);
            this.groupBox1.Controls.Add(this.lb_doc_fin);
            this.groupBox1.Controls.Add(this.tb_doc_fin);
            this.groupBox1.Controls.Add(this.bt_doc_fin);
            this.groupBox1.Controls.Add(this.lb_doc_ini);
            this.groupBox1.Controls.Add(this.tb_doc_ini);
            this.groupBox1.Controls.Add(this.bt_doc_ini);
            this.groupBox1.Controls.Add(this.lb_nom_mod);
            this.groupBox1.Controls.Add(this.lb_ide_mod);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Controls.Add(this.bt_bus_mod);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_mod
            // 
            this.lb_nom_mod.AutoSize = true;
            this.lb_nom_mod.Location = new System.Drawing.Point(153, 21);
            this.lb_nom_mod.Name = "lb_nom_mod";
            this.lb_nom_mod.Size = new System.Drawing.Size(19, 13);
            this.lb_nom_mod.TabIndex = 3;
            this.lb_nom_mod.Text = "....";
            // 
            // lb_ide_mod
            // 
            this.lb_ide_mod.AutoSize = true;
            this.lb_ide_mod.Location = new System.Drawing.Point(56, 20);
            this.lb_ide_mod.Name = "lb_ide_mod";
            this.lb_ide_mod.Size = new System.Drawing.Size(42, 13);
            this.lb_ide_mod.TabIndex = 0;
            this.lb_ide_mod.Text = "Módulo";
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.Location = new System.Drawing.Point(100, 17);
            this.tb_ide_mod.MaxLength = 3;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(37, 20);
            this.tb_ide_mod.TabIndex = 1;
            this.tb_ide_mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_mod_KeyDown);
            this.tb_ide_mod.Leave += new System.EventHandler(this.tb_ide_mod_Leave);
            // 
            // bt_bus_mod
            // 
            this.bt_bus_mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_mod.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_mod.Location = new System.Drawing.Point(136, 16);
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
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 96);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(342, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(182, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(261, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // lb_ndo_fin
            // 
            this.lb_ndo_fin.AutoSize = true;
            this.lb_ndo_fin.Location = new System.Drawing.Point(153, 73);
            this.lb_ndo_fin.Name = "lb_ndo_fin";
            this.lb_ndo_fin.Size = new System.Drawing.Size(19, 13);
            this.lb_ndo_fin.TabIndex = 11;
            this.lb_ndo_fin.Text = "....";
            // 
            // lb_ndo_ini
            // 
            this.lb_ndo_ini.AutoSize = true;
            this.lb_ndo_ini.Location = new System.Drawing.Point(153, 47);
            this.lb_ndo_ini.Name = "lb_ndo_ini";
            this.lb_ndo_ini.Size = new System.Drawing.Size(19, 13);
            this.lb_ndo_ini.TabIndex = 7;
            this.lb_ndo_ini.Text = "....";
            // 
            // lb_doc_fin
            // 
            this.lb_doc_fin.AutoSize = true;
            this.lb_doc_fin.Location = new System.Drawing.Point(11, 73);
            this.lb_doc_fin.Name = "lb_doc_fin";
            this.lb_doc_fin.Size = new System.Drawing.Size(87, 13);
            this.lb_doc_fin.TabIndex = 8;
            this.lb_doc_fin.Text = "Documento Final";
            // 
            // tb_doc_fin
            // 
            this.tb_doc_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_doc_fin.Location = new System.Drawing.Point(100, 69);
            this.tb_doc_fin.MaxLength = 3;
            this.tb_doc_fin.Name = "tb_doc_fin";
            this.tb_doc_fin.Size = new System.Drawing.Size(37, 20);
            this.tb_doc_fin.TabIndex = 9;
            this.tb_doc_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_doc_fin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_doc_fin_KeyDown);
            this.tb_doc_fin.Leave += new System.EventHandler(this.tb_doc_fin_Leave);
            // 
            // bt_doc_fin
            // 
            this.bt_doc_fin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_doc_fin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_doc_fin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_doc_fin.Location = new System.Drawing.Point(136, 68);
            this.bt_doc_fin.Name = "bt_doc_fin";
            this.bt_doc_fin.Size = new System.Drawing.Size(16, 22);
            this.bt_doc_fin.TabIndex = 10;
            this.bt_doc_fin.TabStop = false;
            this.bt_doc_fin.Text = "|";
            this.bt_doc_fin.UseVisualStyleBackColor = false;
            this.bt_doc_fin.Click += new System.EventHandler(this.bt_doc_fin_Click);
            // 
            // lb_doc_ini
            // 
            this.lb_doc_ini.AutoSize = true;
            this.lb_doc_ini.Location = new System.Drawing.Point(6, 47);
            this.lb_doc_ini.Name = "lb_doc_ini";
            this.lb_doc_ini.Size = new System.Drawing.Size(92, 13);
            this.lb_doc_ini.TabIndex = 4;
            this.lb_doc_ini.Text = "Documento Inicial";
            // 
            // tb_doc_ini
            // 
            this.tb_doc_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_doc_ini.Location = new System.Drawing.Point(100, 43);
            this.tb_doc_ini.MaxLength = 3;
            this.tb_doc_ini.Name = "tb_doc_ini";
            this.tb_doc_ini.Size = new System.Drawing.Size(37, 20);
            this.tb_doc_ini.TabIndex = 5;
            this.tb_doc_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_doc_ini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_doc_ini_KeyDown);
            this.tb_doc_ini.Leave += new System.EventHandler(this.tb_doc_ini_Leave);
            // 
            // bt_doc_ini
            // 
            this.bt_doc_ini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_doc_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_doc_ini.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_doc_ini.Location = new System.Drawing.Point(136, 42);
            this.bt_doc_ini.Name = "bt_doc_ini";
            this.bt_doc_ini.Size = new System.Drawing.Size(16, 22);
            this.bt_doc_ini.TabIndex = 6;
            this.bt_doc_ini.TabStop = false;
            this.bt_doc_ini.Text = "|";
            this.bt_doc_ini.UseVisualStyleBackColor = false;
            this.bt_doc_ini.Click += new System.EventHandler(this.bt_doc_ini_Click);
            // 
            // ads004_R02p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 138);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads004_R02p";
            this.Text = "Formato y Definición de Firma";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nom_mod;
        private System.Windows.Forms.Label lb_ide_mod;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Button bt_bus_mod;
        private System.Windows.Forms.Label lb_ndo_fin;
        private System.Windows.Forms.Label lb_ndo_ini;
        private System.Windows.Forms.Label lb_doc_fin;
        private System.Windows.Forms.TextBox tb_doc_fin;
        private System.Windows.Forms.Button bt_doc_fin;
        private System.Windows.Forms.Label lb_doc_ini;
        private System.Windows.Forms.TextBox tb_doc_ini;
        private System.Windows.Forms.Button bt_doc_ini;
    }
}