namespace CRS_PRE
{
    partial class adp012_02
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
            this.tb_nom_gru = new System.Windows.Forms.Label();
            this.bt_bus_gru = new System.Windows.Forms.Button();
            this.tb_raz_soc = new System.Windows.Forms.Label();
            this.tb_gru_emp = new System.Windows.Forms.TextBox();
            this.lb_gru_emp = new System.Windows.Forms.Label();
            this.lb_cod_per = new System.Windows.Forms.Label();
            this.tb_cod_per = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_nom_gru);
            this.groupBox1.Controls.Add(this.bt_bus_gru);
            this.groupBox1.Controls.Add(this.tb_raz_soc);
            this.groupBox1.Controls.Add(this.tb_gru_emp);
            this.groupBox1.Controls.Add(this.lb_gru_emp);
            this.groupBox1.Controls.Add(this.lb_cod_per);
            this.groupBox1.Controls.Add(this.tb_cod_per);
            this.groupBox1.Location = new System.Drawing.Point(4, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tb_nom_gru
            // 
            this.tb_nom_gru.AutoSize = true;
            this.tb_nom_gru.Location = new System.Drawing.Point(157, 51);
            this.tb_nom_gru.Name = "tb_nom_gru";
            this.tb_nom_gru.Size = new System.Drawing.Size(16, 13);
            this.tb_nom_gru.TabIndex = 10;
            this.tb_nom_gru.Text = "...";
            // 
            // bt_bus_gru
            // 
            this.bt_bus_gru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_bus_gru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_bus_gru.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_bus_gru.Location = new System.Drawing.Point(140, 46);
            this.bt_bus_gru.Name = "bt_bus_gru";
            this.bt_bus_gru.Size = new System.Drawing.Size(16, 22);
            this.bt_bus_gru.TabIndex = 9;
            this.bt_bus_gru.TabStop = false;
            this.bt_bus_gru.Text = "|";
            this.bt_bus_gru.UseVisualStyleBackColor = false;
            this.bt_bus_gru.Click += new System.EventHandler(this.bt_bus_gru_Click);
            // 
            // tb_raz_soc
            // 
            this.tb_raz_soc.AutoSize = true;
            this.tb_raz_soc.Location = new System.Drawing.Point(142, 24);
            this.tb_raz_soc.Name = "tb_raz_soc";
            this.tb_raz_soc.Size = new System.Drawing.Size(16, 13);
            this.tb_raz_soc.TabIndex = 6;
            this.tb_raz_soc.Text = "...";
            // 
            // tb_gru_emp
            // 
            this.tb_gru_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_gru_emp.Location = new System.Drawing.Point(100, 47);
            this.tb_gru_emp.MaxLength = 20;
            this.tb_gru_emp.Name = "tb_gru_emp";
            this.tb_gru_emp.Size = new System.Drawing.Size(40, 20);
            this.tb_gru_emp.TabIndex = 3;
            this.tb_gru_emp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_gru_emp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_gru_emp_KeyPress);
            this.tb_gru_emp.Validated += new System.EventHandler(this.tb_gru_emp_Validated);
            // 
            // lb_gru_emp
            // 
            this.lb_gru_emp.AutoSize = true;
            this.lb_gru_emp.Location = new System.Drawing.Point(5, 51);
            this.lb_gru_emp.Name = "lb_gru_emp";
            this.lb_gru_emp.Size = new System.Drawing.Size(93, 13);
            this.lb_gru_emp.TabIndex = 2;
            this.lb_gru_emp.Text = "Grupo Empresarial";
            // 
            // lb_cod_per
            // 
            this.lb_cod_per.AutoSize = true;
            this.lb_cod_per.Location = new System.Drawing.Point(54, 24);
            this.lb_cod_per.Name = "lb_cod_per";
            this.lb_cod_per.Size = new System.Drawing.Size(46, 13);
            this.lb_cod_per.TabIndex = 0;
            this.lb_cod_per.Text = "Persona";
            // 
            // tb_cod_per
            // 
            this.tb_cod_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_per.Location = new System.Drawing.Point(100, 21);
            this.tb_cod_per.MaxLength = 3;
            this.tb_cod_per.Name = "tb_cod_per";
            this.tb_cod_per.ReadOnly = true;
            this.tb_cod_per.Size = new System.Drawing.Size(40, 20);
            this.tb_cod_per.TabIndex = 1;
            this.tb_cod_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(4, 76);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(392, 40);
            this.gb_ctr_btn.TabIndex = 1;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(231, 10);
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
            this.bt_can_cel.Location = new System.Drawing.Point(310, 10);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 25);
            this.bt_can_cel.TabIndex = 1;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.bt_can_cel_Click);
            // 
            // adp012_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(400, 118);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adp012_02";
            this.Tag = "Asigna a Grupo Empresarial";
            this.Text = "Asigna a Grupo Empresarial";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_cod_per;
        private System.Windows.Forms.Button bt_can_cel;
        private System.Windows.Forms.Label lb_cod_per;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.TextBox tb_gru_emp;
        private System.Windows.Forms.Label lb_gru_emp;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label tb_raz_soc;
        private System.Windows.Forms.Label tb_nom_gru;
        private System.Windows.Forms.Button bt_bus_gru;
    }
}