﻿namespace CRS_PRE
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_nom_mod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nom_app = new System.Windows.Forms.TextBox();
            this.tb_ide_apl = new System.Windows.Forms.TextBox();
            this.tb_ide_mod = new System.Windows.Forms.TextBox();
            this.bt_bus_doc = new System.Windows.Forms.Button();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_nom_mod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_nom_app);
            this.groupBox1.Controls.Add(this.tb_ide_apl);
            this.groupBox1.Controls.Add(this.tb_ide_mod);
            this.groupBox1.Controls.Add(this.bt_bus_doc);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Aplicacion";
            // 
            // tb_nom_mod
            // 
            this.tb_nom_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_mod.Location = new System.Drawing.Point(116, 13);
            this.tb_nom_mod.MaxLength = 30;
            this.tb_nom_mod.Name = "tb_nom_mod";
            this.tb_nom_mod.Size = new System.Drawing.Size(277, 20);
            this.tb_nom_mod.TabIndex = 30;
            this.tb_nom_mod.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Modulo";
            // 
            // tb_nom_app
            // 
            this.tb_nom_app.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_app.Location = new System.Drawing.Point(151, 36);
            this.tb_nom_app.MaxLength = 120;
            this.tb_nom_app.Name = "tb_nom_app";
            this.tb_nom_app.Size = new System.Drawing.Size(242, 20);
            this.tb_nom_app.TabIndex = 50;
            // 
            // tb_ide_apl
            // 
            this.tb_ide_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_apl.Location = new System.Drawing.Point(70, 36);
            this.tb_ide_apl.MaxLength = 10;
            this.tb_ide_apl.Name = "tb_ide_apl";
            this.tb_ide_apl.Size = new System.Drawing.Size(75, 20);
            this.tb_ide_apl.TabIndex = 40;
            // 
            // tb_ide_mod
            // 
            this.tb_ide_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_mod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_mod.Location = new System.Drawing.Point(70, 13);
            this.tb_ide_mod.MaxLength = 3;
            this.tb_ide_mod.Name = "tb_ide_mod";
            this.tb_ide_mod.Size = new System.Drawing.Size(29, 20);
            this.tb_ide_mod.TabIndex = 10;
            this.tb_ide_mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_ide_mod_KeyDown);
            this.tb_ide_mod.Validated += new System.EventHandler(this.Tb_ide_mod_Validated);
            // 
            // bt_bus_doc
            // 
            this.bt_bus_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_doc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_doc.Location = new System.Drawing.Point(98, 12);
            this.bt_bus_doc.Name = "bt_bus_doc";
            this.bt_bus_doc.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_doc.TabIndex = 20;
            this.bt_bus_doc.TabStop = false;
            this.bt_bus_doc.Text = "|";
            this.bt_bus_doc.UseVisualStyleBackColor = false;
            this.bt_bus_doc.Click += new System.EventHandler(this.Bt_bus_mod_Click);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 61);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(398, 38);
            this.gb_ctr_btn.TabIndex = 3;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(310, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(229, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 25);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // ads002_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(405, 102);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads002_02";
            this.Tag = "Crea talonario";
            this.Text = "Crea talonario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_mod;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_nom_mod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nom_app;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.TextBox tb_ide_apl;
        private System.Windows.Forms.Button bt_bus_doc;
    }
}