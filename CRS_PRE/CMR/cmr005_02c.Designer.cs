namespace CRS_PRE
{
    partial class cmr005_02c
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
            this.tb_cod_pro = new System.Windows.Forms.TextBox();
            this.tb_nom_pro = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_des_cri = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_cod_pro);
            this.groupBox1.Controls.Add(this.tb_nom_pro);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tb_cod_pro
            // 
            this.tb_cod_pro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_cod_pro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cod_pro.Location = new System.Drawing.Point(13, 13);
            this.tb_cod_pro.MaxLength = 15;
            this.tb_cod_pro.Name = "tb_cod_pro";
            this.tb_cod_pro.ReadOnly = true;
            this.tb_cod_pro.Size = new System.Drawing.Size(100, 19);
            this.tb_cod_pro.TabIndex = 10;
            this.tb_cod_pro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_nom_pro
            // 
            this.tb_nom_pro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nom_pro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nom_pro.Location = new System.Drawing.Point(115, 13);
            this.tb_nom_pro.MaxLength = 30;
            this.tb_nom_pro.Name = "tb_nom_pro";
            this.tb_nom_pro.ReadOnly = true;
            this.tb_nom_pro.Size = new System.Drawing.Size(355, 19);
            this.tb_nom_pro.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_des_cri);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(6, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 144);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // tb_des_cri
            // 
            this.tb_des_cri.AcceptsReturn = true;
            this.tb_des_cri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_des_cri.Location = new System.Drawing.Point(8, 22);
            this.tb_des_cri.MaxLength = 200;
            this.tb_des_cri.Multiline = true;
            this.tb_des_cri.Name = "tb_des_cri";
            this.tb_des_cri.Size = new System.Drawing.Size(462, 116);
            this.tb_des_cri.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 13);
            this.label15.TabIndex = 82;
            this.label15.Text = "Descipción de producto/servicio";
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(2, 167);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(482, 35);
            this.gb_ctr_btn.TabIndex = 20;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(312, 9);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(75, 23);
            this.bt_ace_pta.TabIndex = 130;
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
            this.bt_can_cel.Location = new System.Drawing.Point(395, 9);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(75, 23);
            this.bt_can_cel.TabIndex = 135;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // cmr005_02c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 204);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmr005_02c";
            this.Text = "Descripción de producto/servicio";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox tb_cod_pro;
        public System.Windows.Forms.TextBox tb_nom_pro;
        public System.Windows.Forms.TextBox tb_des_cri;
    }
}