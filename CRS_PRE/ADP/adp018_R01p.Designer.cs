namespace CRS_PRE
{
    partial class adp018_R01p
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
            this.cb_est_ado = new System.Windows.Forms.ComboBox();
            this.lb_est_ado = new System.Windows.Forms.Label();
            this.gb_ord_por = new System.Windows.Forms.GroupBox();
            this.rb_ord_des = new System.Windows.Forms.RadioButton();
            this.rb_ord_tip = new System.Windows.Forms.RadioButton();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.cb_ban_fac = new System.Windows.Forms.ComboBox();
            this.lb_ban_fac = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_ord_por.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ban_fac);
            this.groupBox1.Controls.Add(this.lb_ban_fac);
            this.groupBox1.Controls.Add(this.cb_est_ado);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.gb_ord_por);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cb_est_ado
            // 
            this.cb_est_ado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_est_ado.FormattingEnabled = true;
            this.cb_est_ado.Items.AddRange(new object[] {
            "Todos",
            "Habilitado",
            "Deshabilitado"});
            this.cb_est_ado.Location = new System.Drawing.Point(90, 22);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(105, 21);
            this.cb_est_ado.TabIndex = 1;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(48, 25);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 0;
            this.lb_est_ado.Text = "Estado";
            // 
            // gb_ord_por
            // 
            this.gb_ord_por.Controls.Add(this.rb_ord_des);
            this.gb_ord_por.Controls.Add(this.rb_ord_tip);
            this.gb_ord_por.Location = new System.Drawing.Point(11, 77);
            this.gb_ord_por.Name = "gb_ord_por";
            this.gb_ord_por.Size = new System.Drawing.Size(243, 41);
            this.gb_ord_por.TabIndex = 2;
            this.gb_ord_por.TabStop = false;
            this.gb_ord_por.Text = "Ordenado por";
            // 
            // rb_ord_des
            // 
            this.rb_ord_des.AutoSize = true;
            this.rb_ord_des.Location = new System.Drawing.Point(140, 15);
            this.rb_ord_des.Name = "rb_ord_des";
            this.rb_ord_des.Size = new System.Drawing.Size(81, 17);
            this.rb_ord_des.TabIndex = 1;
            this.rb_ord_des.TabStop = true;
            this.rb_ord_des.Text = "Descripción";
            this.rb_ord_des.UseVisualStyleBackColor = true;
            // 
            // rb_ord_tip
            // 
            this.rb_ord_tip.AutoSize = true;
            this.rb_ord_tip.Location = new System.Drawing.Point(28, 15);
            this.rb_ord_tip.Name = "rb_ord_tip";
            this.rb_ord_tip.Size = new System.Drawing.Size(104, 17);
            this.rb_ord_tip.TabIndex = 0;
            this.rb_ord_tip.TabStop = true;
            this.rb_ord_tip.Text = "Tipo Documento";
            this.rb_ord_tip.UseVisualStyleBackColor = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 116);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(267, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(101, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(180, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // cb_ban_fac
            // 
            this.cb_ban_fac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ban_fac.FormattingEnabled = true;
            this.cb_ban_fac.Location = new System.Drawing.Point(128, 51);
            this.cb_ban_fac.Name = "cb_ban_fac";
            this.cb_ban_fac.Size = new System.Drawing.Size(121, 21);
            this.cb_ban_fac.TabIndex = 8;
            // 
            // lb_ban_fac
            // 
            this.lb_ban_fac.AutoSize = true;
            this.lb_ban_fac.Location = new System.Drawing.Point(17, 54);
            this.lb_ban_fac.Name = "lb_ban_fac";
            this.lb_ban_fac.Size = new System.Drawing.Size(109, 13);
            this.lb_ban_fac.TabIndex = 7;
            this.lb_ban_fac.Text = "Datos de Facturación";
            // 
            // adp018_R01p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 158);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp018_R01p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Informe Grupo Empresarial";
            this.Text = "Informe Grupo Empresarial";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ord_por.ResumeLayout(false);
            this.gb_ord_por.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.RadioButton rb_ord_des;
        private System.Windows.Forms.RadioButton rb_ord_tip;
        private System.Windows.Forms.GroupBox gb_ord_por;
        private System.Windows.Forms.ComboBox cb_est_ado;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.ComboBox cb_ban_fac;
        private System.Windows.Forms.Label lb_ban_fac;
    }
}