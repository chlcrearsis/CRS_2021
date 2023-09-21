namespace CRS_PRE
{
    partial class ads006_02
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
            this.lb_des_tus = new System.Windows.Forms.Label();
            this.tb_des_tus = new System.Windows.Forms.TextBox();
            this.lb_ide_tus = new System.Windows.Forms.Label();
            this.tb_nom_tus = new System.Windows.Forms.TextBox();
            this.tb_ide_tus = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_des_tus);
            this.groupBox1.Controls.Add(this.tb_des_tus);
            this.groupBox1.Controls.Add(this.lb_ide_tus);
            this.groupBox1.Controls.Add(this.tb_nom_tus);
            this.groupBox1.Controls.Add(this.tb_ide_tus);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_des_tus
            // 
            this.lb_des_tus.AutoSize = true;
            this.lb_des_tus.Location = new System.Drawing.Point(23, 46);
            this.lb_des_tus.Name = "lb_des_tus";
            this.lb_des_tus.Size = new System.Drawing.Size(63, 13);
            this.lb_des_tus.TabIndex = 3;
            this.lb_des_tus.Text = "Descripción";
            // 
            // tb_des_tus
            // 
            this.tb_des_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_des_tus.Location = new System.Drawing.Point(88, 43);
            this.tb_des_tus.MaxLength = 120;
            this.tb_des_tus.Name = "tb_des_tus";
            this.tb_des_tus.Size = new System.Drawing.Size(219, 20);
            this.tb_des_tus.TabIndex = 4;
            // 
            // lb_ide_tus
            // 
            this.lb_ide_tus.AutoSize = true;
            this.lb_ide_tus.Location = new System.Drawing.Point(4, 20);
            this.lb_ide_tus.Name = "lb_ide_tus";
            this.lb_ide_tus.Size = new System.Drawing.Size(82, 13);
            this.lb_ide_tus.TabIndex = 0;
            this.lb_ide_tus.Text = "Tipo de Usuario";
            // 
            // tb_nom_tus
            // 
            this.tb_nom_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_tus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nom_tus.Location = new System.Drawing.Point(139, 18);
            this.tb_nom_tus.MaxLength = 30;
            this.tb_nom_tus.Name = "tb_nom_tus";
            this.tb_nom_tus.Size = new System.Drawing.Size(168, 20);
            this.tb_nom_tus.TabIndex = 2;
            // 
            // tb_ide_tus
            // 
            this.tb_ide_tus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_tus.Location = new System.Drawing.Point(88, 17);
            this.tb_ide_tus.MaxLength = 2;
            this.tb_ide_tus.Name = "tb_ide_tus";
            this.tb_ide_tus.Size = new System.Drawing.Size(45, 20);
            this.tb_ide_tus.TabIndex = 1;
            this.tb_ide_tus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ide_tus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ide_tus_KeyPress);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 68);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(336, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(178, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(256, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads006_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 109);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads006_02";
            this.Tag = "Crea Tipo de Usuario";
            this.Text = "Crea Tipo de Usuario";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_tus;
        private System.Windows.Forms.TextBox tb_des_tus;
        private System.Windows.Forms.Label lb_ide_tus;
        private System.Windows.Forms.TextBox tb_nom_tus;
        private System.Windows.Forms.Label lb_des_tus;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}