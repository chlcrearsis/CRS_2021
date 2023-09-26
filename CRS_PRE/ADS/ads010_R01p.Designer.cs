namespace CRS_PRE
{
    partial class ads010_R01p
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
            this.rb_ord_cod = new System.Windows.Forms.RadioButton();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ord_por.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_est_ado);
            this.groupBox1.Controls.Add(this.lb_est_ado);
            this.groupBox1.Controls.Add(this.gb_ord_por);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 101);
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
            this.cb_est_ado.Location = new System.Drawing.Point(90, 24);
            this.cb_est_ado.Name = "cb_est_ado";
            this.cb_est_ado.Size = new System.Drawing.Size(105, 21);
            this.cb_est_ado.TabIndex = 1;
            // 
            // lb_est_ado
            // 
            this.lb_est_ado.AutoSize = true;
            this.lb_est_ado.Location = new System.Drawing.Point(48, 27);
            this.lb_est_ado.Name = "lb_est_ado";
            this.lb_est_ado.Size = new System.Drawing.Size(40, 13);
            this.lb_est_ado.TabIndex = 0;
            this.lb_est_ado.Text = "Estado";
            // 
            // gb_ord_por
            // 
            this.gb_ord_por.Controls.Add(this.rb_ord_des);
            this.gb_ord_por.Controls.Add(this.rb_ord_cod);
            this.gb_ord_por.Location = new System.Drawing.Point(11, 54);
            this.gb_ord_por.Name = "gb_ord_por";
            this.gb_ord_por.Size = new System.Drawing.Size(243, 41);
            this.gb_ord_por.TabIndex = 2;
            this.gb_ord_por.TabStop = false;
            this.gb_ord_por.Text = "Ordenado por";
            // 
            // rb_ord_des
            // 
            this.rb_ord_des.AutoSize = true;
            this.rb_ord_des.Location = new System.Drawing.Point(134, 15);
            this.rb_ord_des.Name = "rb_ord_des";
            this.rb_ord_des.Size = new System.Drawing.Size(81, 17);
            this.rb_ord_des.TabIndex = 1;
            this.rb_ord_des.TabStop = true;
            this.rb_ord_des.Text = "Descripción";
            this.rb_ord_des.UseVisualStyleBackColor = true;
            // 
            // rb_ord_cod
            // 
            this.rb_ord_cod.AutoSize = true;
            this.rb_ord_cod.Location = new System.Drawing.Point(51, 15);
            this.rb_ord_cod.Name = "rb_ord_cod";
            this.rb_ord_cod.Size = new System.Drawing.Size(58, 17);
            this.rb_ord_cod.TabIndex = 0;
            this.rb_ord_cod.TabStop = true;
            this.rb_ord_cod.Text = "Código";
            this.rb_ord_cod.UseVisualStyleBackColor = true;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(3, 91);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(267, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(108, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(187, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // ads010_R01p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 132);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ads010_R01p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Informe Módulo del Sistema";
            this.Text = "Informe Tipos de Imagen";
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
        private System.Windows.Forms.RadioButton rb_ord_cod;
        private System.Windows.Forms.GroupBox gb_ord_por;
        private System.Windows.Forms.ComboBox cb_est_ado;
        private System.Windows.Forms.Label lb_est_ado;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Button bt_can_cel;
    }
}