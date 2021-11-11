namespace CRS_PRE
{
    partial class ecp002_02
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
            this.cb_mon_lib = new System.Windows.Forms.ComboBox();
            this.cb_tip_lib = new System.Windows.Forms.ComboBox();
            this.tb_nom_lib = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_cod_lib = new System.Windows.Forms.TextBox();
            this.tb_nro_lib = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_mon_lib);
            this.groupBox1.Controls.Add(this.cb_tip_lib);
            this.groupBox1.Controls.Add(this.tb_nom_lib);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_cod_lib);
            this.groupBox1.Controls.Add(this.tb_nro_lib);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cb_mon_lib
            // 
            this.cb_mon_lib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mon_lib.FormattingEnabled = true;
            this.cb_mon_lib.Items.AddRange(new object[] {
            "Bs.",
            "Us."});
            this.cb_mon_lib.Location = new System.Drawing.Point(218, 15);
            this.cb_mon_lib.Name = "cb_mon_lib";
            this.cb_mon_lib.Size = new System.Drawing.Size(71, 21);
            this.cb_mon_lib.TabIndex = 20;
            this.cb_mon_lib.SelectedIndexChanged += new System.EventHandler(this.cb_mon_lib_SelectedIndexChanged);
            // 
            // cb_tip_lib
            // 
            this.cb_tip_lib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip_lib.FormattingEnabled = true;
            this.cb_tip_lib.Items.AddRange(new object[] {
            "Ctas. x Cob.",
            "Ctas. x Pag."});
            this.cb_tip_lib.Location = new System.Drawing.Point(43, 15);
            this.cb_tip_lib.Name = "cb_tip_lib";
            this.cb_tip_lib.Size = new System.Drawing.Size(117, 21);
            this.cb_tip_lib.TabIndex = 10;
            this.cb_tip_lib.SelectedIndexChanged += new System.EventHandler(this.cb_tip_lib_SelectedIndexChanged);
            // 
            // tb_nom_lib
            // 
            this.tb_nom_lib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_lib.Location = new System.Drawing.Point(93, 45);
            this.tb_nom_lib.MaxLength = 30;
            this.tb_nom_lib.Name = "tb_nom_lib";
            this.tb_nom_lib.Size = new System.Drawing.Size(295, 20);
            this.tb_nom_lib.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Libreta";
            // 
            // tb_cod_lib
            // 
            this.tb_cod_lib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_lib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod_lib.Location = new System.Drawing.Point(311, 15);
            this.tb_cod_lib.MaxLength = 4;
            this.tb_cod_lib.Name = "tb_cod_lib";
            this.tb_cod_lib.ReadOnly = true;
            this.tb_cod_lib.Size = new System.Drawing.Size(77, 20);
            this.tb_cod_lib.TabIndex = 10;
            this.tb_cod_lib.TabStop = false;
            this.tb_cod_lib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_nro_lib
            // 
            this.tb_nro_lib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nro_lib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_nro_lib.Location = new System.Drawing.Point(50, 45);
            this.tb_nro_lib.MaxLength = 3;
            this.tb_nro_lib.Name = "tb_nro_lib";
            this.tb_nro_lib.Size = new System.Drawing.Size(37, 20);
            this.tb_nro_lib.TabIndex = 30;
            this.tb_nro_lib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_nro_lib.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nro_lib_KeyPress);
            this.tb_nro_lib.Validated += new System.EventHandler(this.tb_nro_lib_Validated);
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 77);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(398, 42);
            this.gb_ctr_btn.TabIndex = 4;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(303, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 26);
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
            this.bt_ace_pta.Location = new System.Drawing.Point(215, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 26);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.Bt_ace_pta_Click);
            // 
            // ecp002_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 125);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ecp002_02";
            this.Tag = "Crea Libreta Cta. x Cobrar/Pagar";
            this.Text = "Crea Libreta Cta. x Cobrar/Pagar";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_nom_lib;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nro_lib;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.ComboBox cb_mon_lib;
        private System.Windows.Forms.ComboBox cb_tip_lib;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_cod_lib;
    }
}