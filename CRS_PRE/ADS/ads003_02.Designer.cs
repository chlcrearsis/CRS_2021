namespace CRS_PRE
{
    partial class ads003_02
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
            this.tb_nom_bre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_des_cri = new System.Windows.Forms.TextBox();
            this.tb_ide_doc = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.cb_mod_ulo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_mod_ulo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_nom_bre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_des_cri);
            this.groupBox1.Controls.Add(this.tb_ide_doc);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Descripcion";
            // 
            // tb_nom_bre
            // 
            this.tb_nom_bre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_bre.Location = new System.Drawing.Point(124, 44);
            this.tb_nom_bre.MaxLength = 30;
            this.tb_nom_bre.Name = "tb_nom_bre";
            this.tb_nom_bre.Size = new System.Drawing.Size(203, 20);
            this.tb_nom_bre.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modulo";
            // 
            // tb_des_cri
            // 
            this.tb_des_cri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_des_cri.Location = new System.Drawing.Point(79, 70);
            this.tb_des_cri.MaxLength = 120;
            this.tb_des_cri.Name = "tb_des_cri";
            this.tb_des_cri.Size = new System.Drawing.Size(248, 20);
            this.tb_des_cri.TabIndex = 40;
            // 
            // tb_ide_doc
            // 
            this.tb_ide_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ide_doc.Location = new System.Drawing.Point(79, 44);
            this.tb_ide_doc.MaxLength = 3;
            this.tb_ide_doc.Name = "tb_ide_doc";
            this.tb_ide_doc.Size = new System.Drawing.Size(39, 20);
            this.tb_ide_doc.TabIndex = 20;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 89);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(336, 35);
            this.gb_ctr_btn.TabIndex = 2;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(234, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(153, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // cb_mod_ulo
            // 
            this.cb_mod_ulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mod_ulo.FormattingEnabled = true;
            this.cb_mod_ulo.Items.AddRange(new object[] {
            "Seleccionar..."});
            this.cb_mod_ulo.Location = new System.Drawing.Point(79, 19);
            this.cb_mod_ulo.Name = "cb_mod_ulo";
            this.cb_mod_ulo.Size = new System.Drawing.Size(188, 21);
            this.cb_mod_ulo.TabIndex = 41;
            // 
            // ads003_02
            // 
            this.AcceptButton = this.bt_ace_pta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(344, 125);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads003_02";
            this.Tag = "Crea documento";
            this.Text = "Crea documento";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ide_doc;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_nom_bre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_des_cri;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.ComboBox cb_mod_ulo;
    }
}