namespace CRS_PRE
{
    partial class ads005_02
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
            this.lb_nom_tal = new System.Windows.Forms.Label();
            this.lb_nom_doc = new System.Windows.Forms.Label();
            this.tb_ges_tio = new System.Windows.Forms.TextBox();
            this.tb_fec_fin = new System.Windows.Forms.MaskedTextBox();
            this.tb_fec_ini = new System.Windows.Forms.MaskedTextBox();
            this.lb_con_act = new System.Windows.Forms.Label();
            this.lb_con_fin = new System.Windows.Forms.Label();
            this.tb_con_act = new System.Windows.Forms.TextBox();
            this.tb_con_fin = new System.Windows.Forms.TextBox();
            this.bt_bus_tal = new System.Windows.Forms.Button();
            this.lb_fec_fin = new System.Windows.Forms.Label();
            this.lb_fec_ini = new System.Windows.Forms.Label();
            this.lb_nro_tal = new System.Windows.Forms.Label();
            this.lb_ide_doc = new System.Windows.Forms.Label();
            this.lb_ges_tio = new System.Windows.Forms.Label();
            this.tb_nro_tal = new System.Windows.Forms.TextBox();
            this.tb_ide_doc = new System.Windows.Forms.TextBox();
            this.bt_bus_doc = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_nom_tal);
            this.groupBox1.Controls.Add(this.lb_nom_doc);
            this.groupBox1.Controls.Add(this.tb_ges_tio);
            this.groupBox1.Controls.Add(this.tb_fec_fin);
            this.groupBox1.Controls.Add(this.tb_fec_ini);
            this.groupBox1.Controls.Add(this.lb_con_act);
            this.groupBox1.Controls.Add(this.lb_con_fin);
            this.groupBox1.Controls.Add(this.tb_con_act);
            this.groupBox1.Controls.Add(this.tb_con_fin);
            this.groupBox1.Controls.Add(this.bt_bus_tal);
            this.groupBox1.Controls.Add(this.lb_fec_fin);
            this.groupBox1.Controls.Add(this.lb_fec_ini);
            this.groupBox1.Controls.Add(this.lb_nro_tal);
            this.groupBox1.Controls.Add(this.lb_ide_doc);
            this.groupBox1.Controls.Add(this.lb_ges_tio);
            this.groupBox1.Controls.Add(this.tb_nro_tal);
            this.groupBox1.Controls.Add(this.tb_ide_doc);
            this.groupBox1.Controls.Add(this.bt_bus_doc);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_nom_tal
            // 
            this.lb_nom_tal.AutoSize = true;
            this.lb_nom_tal.Location = new System.Drawing.Point(120, 48);
            this.lb_nom_tal.Name = "lb_nom_tal";
            this.lb_nom_tal.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_tal.TabIndex = 7;
            this.lb_nom_tal.Text = "...";
            // 
            // lb_nom_doc
            // 
            this.lb_nom_doc.AutoSize = true;
            this.lb_nom_doc.Location = new System.Drawing.Point(120, 22);
            this.lb_nom_doc.Name = "lb_nom_doc";
            this.lb_nom_doc.Size = new System.Drawing.Size(16, 13);
            this.lb_nom_doc.TabIndex = 3;
            this.lb_nom_doc.Text = "...";
            // 
            // tb_ges_tio
            // 
            this.tb_ges_tio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ges_tio.Location = new System.Drawing.Point(76, 73);
            this.tb_ges_tio.MaxLength = 5;
            this.tb_ges_tio.Name = "tb_ges_tio";
            this.tb_ges_tio.Size = new System.Drawing.Size(50, 20);
            this.tb_ges_tio.TabIndex = 9;
            this.tb_ges_tio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ges_tio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ges_tio_KeyPress);
            // 
            // tb_fec_fin
            // 
            this.tb_fec_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_fin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_fec_fin.Location = new System.Drawing.Point(280, 99);
            this.tb_fec_fin.Mask = "00/00/0000";
            this.tb_fec_fin.Name = "tb_fec_fin";
            this.tb_fec_fin.Size = new System.Drawing.Size(80, 20);
            this.tb_fec_fin.TabIndex = 17;
            this.tb_fec_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_fec_fin.ValidatingType = typeof(System.DateTime);
            // 
            // tb_fec_ini
            // 
            this.tb_fec_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_fec_ini.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tb_fec_ini.Location = new System.Drawing.Point(76, 101);
            this.tb_fec_ini.Mask = "00/00/0000";
            this.tb_fec_ini.Name = "tb_fec_ini";
            this.tb_fec_ini.Size = new System.Drawing.Size(80, 20);
            this.tb_fec_ini.TabIndex = 15;
            this.tb_fec_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_con_act
            // 
            this.lb_con_act.AutoSize = true;
            this.lb_con_act.Location = new System.Drawing.Point(134, 76);
            this.lb_con_act.Name = "lb_con_act";
            this.lb_con_act.Size = new System.Drawing.Size(60, 13);
            this.lb_con_act.TabIndex = 10;
            this.lb_con_act.Text = "Nro. Actual";
            // 
            // lb_con_fin
            // 
            this.lb_con_fin.AutoSize = true;
            this.lb_con_fin.Location = new System.Drawing.Point(256, 76);
            this.lb_con_fin.Name = "lb_con_fin";
            this.lb_con_fin.Size = new System.Drawing.Size(52, 13);
            this.lb_con_fin.TabIndex = 12;
            this.lb_con_fin.Text = "Nro. Final";
            // 
            // tb_con_act
            // 
            this.tb_con_act.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_con_act.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_con_act.Location = new System.Drawing.Point(196, 73);
            this.tb_con_act.MaxLength = 5;
            this.tb_con_act.Name = "tb_con_act";
            this.tb_con_act.Size = new System.Drawing.Size(50, 20);
            this.tb_con_act.TabIndex = 11;
            this.tb_con_act.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_con_act.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_con_act_KeyPress);
            // 
            // tb_con_fin
            // 
            this.tb_con_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_con_fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_con_fin.Location = new System.Drawing.Point(310, 73);
            this.tb_con_fin.MaxLength = 5;
            this.tb_con_fin.Name = "tb_con_fin";
            this.tb_con_fin.Size = new System.Drawing.Size(50, 20);
            this.tb_con_fin.TabIndex = 13;
            this.tb_con_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_con_fin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_con_fin_KeyPress);
            // 
            // bt_bus_tal
            // 
            this.bt_bus_tal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_tal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_tal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_tal.Location = new System.Drawing.Point(103, 44);
            this.bt_bus_tal.Name = "bt_bus_tal";
            this.bt_bus_tal.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_tal.TabIndex = 6;
            this.bt_bus_tal.TabStop = false;
            this.bt_bus_tal.Text = "|";
            this.bt_bus_tal.UseVisualStyleBackColor = false;
            this.bt_bus_tal.Click += new System.EventHandler(this.bt_bus_tal_Click);
            // 
            // lb_fec_fin
            // 
            this.lb_fec_fin.AutoSize = true;
            this.lb_fec_fin.Location = new System.Drawing.Point(216, 103);
            this.lb_fec_fin.Name = "lb_fec_fin";
            this.lb_fec_fin.Size = new System.Drawing.Size(62, 13);
            this.lb_fec_fin.TabIndex = 16;
            this.lb_fec_fin.Text = "Fecha Final";
            // 
            // lb_fec_ini
            // 
            this.lb_fec_ini.AutoSize = true;
            this.lb_fec_ini.Location = new System.Drawing.Point(7, 105);
            this.lb_fec_ini.Name = "lb_fec_ini";
            this.lb_fec_ini.Size = new System.Drawing.Size(67, 13);
            this.lb_fec_ini.TabIndex = 14;
            this.lb_fec_ini.Text = "Fecha Inicial";
            // 
            // lb_nro_tal
            // 
            this.lb_nro_tal.AutoSize = true;
            this.lb_nro_tal.Location = new System.Drawing.Point(22, 48);
            this.lb_nro_tal.Name = "lb_nro_tal";
            this.lb_nro_tal.Size = new System.Drawing.Size(51, 13);
            this.lb_nro_tal.TabIndex = 4;
            this.lb_nro_tal.Text = "Talonario";
            // 
            // lb_ide_doc
            // 
            this.lb_ide_doc.AutoSize = true;
            this.lb_ide_doc.Location = new System.Drawing.Point(11, 22);
            this.lb_ide_doc.Name = "lb_ide_doc";
            this.lb_ide_doc.Size = new System.Drawing.Size(62, 13);
            this.lb_ide_doc.TabIndex = 0;
            this.lb_ide_doc.Text = "Documento";
            // 
            // lb_ges_tio
            // 
            this.lb_ges_tio.AutoSize = true;
            this.lb_ges_tio.Location = new System.Drawing.Point(31, 76);
            this.lb_ges_tio.Name = "lb_ges_tio";
            this.lb_ges_tio.Size = new System.Drawing.Size(43, 13);
            this.lb_ges_tio.TabIndex = 8;
            this.lb_ges_tio.Text = "Gestión";
            // 
            // tb_nro_tal
            // 
            this.tb_nro_tal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_tal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nro_tal.Location = new System.Drawing.Point(75, 45);
            this.tb_nro_tal.MaxLength = 3;
            this.tb_nro_tal.Name = "tb_nro_tal";
            this.tb_nro_tal.Size = new System.Drawing.Size(29, 20);
            this.tb_nro_tal.TabIndex = 5;
            this.tb_nro_tal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_nro_tal_KeyDown);
            this.tb_nro_tal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_tal_KeyPress);
            this.tb_nro_tal.Validated += new System.EventHandler(this.tb_nro_tal_Validated);
            // 
            // tb_ide_doc
            // 
            this.tb_ide_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_doc.Location = new System.Drawing.Point(75, 19);
            this.tb_ide_doc.MaxLength = 3;
            this.tb_ide_doc.Name = "tb_ide_doc";
            this.tb_ide_doc.Size = new System.Drawing.Size(29, 20);
            this.tb_ide_doc.TabIndex = 1;
            this.tb_ide_doc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ide_doc_KeyDown);
            this.tb_ide_doc.Validated += new System.EventHandler(this.tb_ide_doc_Validated);
            // 
            // bt_bus_doc
            // 
            this.bt_bus_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_doc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_doc.Location = new System.Drawing.Point(103, 18);
            this.bt_bus_doc.Name = "bt_bus_doc";
            this.bt_bus_doc.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_doc.TabIndex = 2;
            this.bt_bus_doc.TabStop = false;
            this.bt_bus_doc.Text = "|";
            this.bt_bus_doc.UseVisualStyleBackColor = false;
            this.bt_bus_doc.Click += new System.EventHandler(this.bt_bus_doc_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 140);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(373, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(207, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(286, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads005_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 182);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads005_02";
            this.Tag = "Crea Numeración";
            this.Text = "Crea Numeración";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_doc;
        private System.Windows.Forms.Label lb_nro_tal;
        private System.Windows.Forms.Label lb_ide_doc;
        private System.Windows.Forms.TextBox tb_nro_tal;
        private System.Windows.Forms.Button bt_bus_doc;
        private System.Windows.Forms.Button bt_bus_tal;
        private System.Windows.Forms.Label lb_ges_tio;
        private System.Windows.Forms.Label lb_fec_ini;
        private System.Windows.Forms.Label lb_con_act;
        private System.Windows.Forms.Label lb_con_fin;
        private System.Windows.Forms.TextBox tb_con_act;
        private System.Windows.Forms.TextBox tb_con_fin;
        private System.Windows.Forms.Label lb_fec_fin;
        private System.Windows.Forms.MaskedTextBox tb_fec_fin;
        private System.Windows.Forms.MaskedTextBox tb_fec_ini;
        private System.Windows.Forms.TextBox tb_ges_tio;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_nom_tal;
        private System.Windows.Forms.Label lb_nom_doc;
    }
}