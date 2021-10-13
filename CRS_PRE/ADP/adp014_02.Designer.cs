namespace CRS_PRE
{
    partial class adp014_02
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
            this.lb_des_tip = new System.Windows.Forms.Label();
            this.tb_des_tip = new System.Windows.Forms.TextBox();
            this.lb_tip_atr = new System.Windows.Forms.Label();
            this.tb_ide_tip = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.cb_ext_doc = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ext_doc);
            this.groupBox1.Controls.Add(this.lb_des_tip);
            this.groupBox1.Controls.Add(this.tb_des_tip);
            this.groupBox1.Controls.Add(this.lb_tip_atr);
            this.groupBox1.Controls.Add(this.tb_ide_tip);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lb_des_tip
            // 
            this.lb_des_tip.AutoSize = true;
            this.lb_des_tip.Location = new System.Drawing.Point(28, 49);
            this.lb_des_tip.Name = "lb_des_tip";
            this.lb_des_tip.Size = new System.Drawing.Size(63, 13);
            this.lb_des_tip.TabIndex = 7;
            this.lb_des_tip.Text = "Descripción";
            // 
            // tb_des_tip
            // 
            this.tb_des_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_des_tip.Location = new System.Drawing.Point(93, 46);
            this.tb_des_tip.MaxLength = 30;
            this.tb_des_tip.Name = "tb_des_tip";
            this.tb_des_tip.Size = new System.Drawing.Size(190, 20);
            this.tb_des_tip.TabIndex = 2;
            // 
            // lb_tip_atr
            // 
            this.lb_tip_atr.AutoSize = true;
            this.lb_tip_atr.Location = new System.Drawing.Point(5, 26);
            this.lb_tip_atr.Name = "lb_tip_atr";
            this.lb_tip_atr.Size = new System.Drawing.Size(86, 13);
            this.lb_tip_atr.TabIndex = 0;
            this.lb_tip_atr.Text = "Tipo Documento";
            // 
            // tb_ide_tip
            // 
            this.tb_ide_tip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ide_tip.Location = new System.Drawing.Point(93, 23);
            this.tb_ide_tip.MaxLength = 2;
            this.tb_ide_tip.Name = "tb_ide_tip";
            this.tb_ide_tip.Size = new System.Drawing.Size(40, 20);
            this.tb_ide_tip.TabIndex = 1;
            this.tb_ide_tip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 94);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(344, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(173, 9);
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
            this.bt_can_cel.Location = new System.Drawing.Point(252, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // cb_ext_doc
            // 
            this.cb_ext_doc.AutoSize = true;
            this.cb_ext_doc.Location = new System.Drawing.Point(122, 73);
            this.cb_ext_doc.Name = "cb_ext_doc";
            this.cb_ext_doc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_ext_doc.Size = new System.Drawing.Size(161, 17);
            this.cb_ext_doc.TabIndex = 9;
            this.cb_ext_doc.Text = "? Usa Extensión Documento";
            this.cb_ext_doc.UseVisualStyleBackColor = true;
            // 
            // adp014_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(349, 138);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp014_02";
            this.Tag = "Crea documento";
            this.Text = "Crea Tipo de Documento";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ide_tip;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.TextBox tb_des_tip;
        private System.Windows.Forms.Label lb_tip_atr;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label lb_des_tip;
        private System.Windows.Forms.CheckBox cb_ext_doc;
    }
}