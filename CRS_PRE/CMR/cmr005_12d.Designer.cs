namespace CRS_PRE
{
    partial class cmr005_12d
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
            this.tb_obs_vta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_cam_bio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_mto_can = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_pre_tot = new System.Windows.Forms.TextBox();
            this.gb_ctr_btn = new System.Windows.Forms.GroupBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.bt_can_cel = new System.Windows.Forms.Button();
            this.tb_raz_soc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_ctr_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_obs_vta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_cam_bio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_mto_can);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_pre_tot);
            this.groupBox1.Location = new System.Drawing.Point(7, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 233);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // tb_obs_vta
            // 
            this.tb_obs_vta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_obs_vta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_obs_vta.Location = new System.Drawing.Point(9, 138);
            this.tb_obs_vta.Multiline = true;
            this.tb_obs_vta.Name = "tb_obs_vta";
            this.tb_obs_vta.Size = new System.Drawing.Size(405, 89);
            this.tb_obs_vta.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cambio";
            // 
            // tb_cam_bio
            // 
            this.tb_cam_bio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.tb_cam_bio.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cam_bio.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_cam_bio.Location = new System.Drawing.Point(294, 94);
            this.tb_cam_bio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_cam_bio.Multiline = true;
            this.tb_cam_bio.Name = "tb_cam_bio";
            this.tb_cam_bio.ReadOnly = true;
            this.tb_cam_bio.Size = new System.Drawing.Size(120, 37);
            this.tb_cam_bio.TabIndex = 5;
            this.tb_cam_bio.TabStop = false;
            this.tb_cam_bio.Text = "888.00";
            this.tb_cam_bio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monto cancelado";
            // 
            // tb_mto_can
            // 
            this.tb_mto_can.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_mto_can.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mto_can.ForeColor = System.Drawing.Color.Black;
            this.tb_mto_can.Location = new System.Drawing.Point(294, 52);
            this.tb_mto_can.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_mto_can.Multiline = true;
            this.tb_mto_can.Name = "tb_mto_can";
            this.tb_mto_can.Size = new System.Drawing.Size(120, 37);
            this.tb_mto_can.TabIndex = 20;
            this.tb_mto_can.Text = "888.00";
            this.tb_mto_can.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_mto_can.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_mto_can_KeyPress);
            this.tb_mto_can.Validated += new System.EventHandler(this.tb_mto_can_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total a cancelar";
            // 
            // tb_pre_tot
            // 
            this.tb_pre_tot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.tb_pre_tot.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pre_tot.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_pre_tot.Location = new System.Drawing.Point(294, 12);
            this.tb_pre_tot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_pre_tot.Multiline = true;
            this.tb_pre_tot.Name = "tb_pre_tot";
            this.tb_pre_tot.ReadOnly = true;
            this.tb_pre_tot.Size = new System.Drawing.Size(120, 37);
            this.tb_pre_tot.TabIndex = 1;
            this.tb_pre_tot.TabStop = false;
            this.tb_pre_tot.Text = "888.00";
            this.tb_pre_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gb_ctr_btn
            // 
            this.gb_ctr_btn.Controls.Add(this.bt_ace_pta);
            this.gb_ctr_btn.Controls.Add(this.bt_can_cel);
            this.gb_ctr_btn.Enabled = false;
            this.gb_ctr_btn.Location = new System.Drawing.Point(7, 273);
            this.gb_ctr_btn.Name = "gb_ctr_btn";
            this.gb_ctr_btn.Size = new System.Drawing.Size(427, 56);
            this.gb_ctr_btn.TabIndex = 20;
            this.gb_ctr_btn.TabStop = false;
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ace_pta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_ace_pta.Location = new System.Drawing.Point(180, 12);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(107, 37);
            this.bt_ace_pta.TabIndex = 10;
            this.bt_ace_pta.Text = "&Aceptar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // bt_can_cel
            // 
            this.bt_can_cel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(76)))));
            this.bt_can_cel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_can_cel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_can_cel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_can_cel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_can_cel.Location = new System.Drawing.Point(309, 12);
            this.bt_can_cel.Name = "bt_can_cel";
            this.bt_can_cel.Size = new System.Drawing.Size(107, 37);
            this.bt_can_cel.TabIndex = 20;
            this.bt_can_cel.Text = "&Cancelar";
            this.bt_can_cel.UseVisualStyleBackColor = false;
            this.bt_can_cel.Click += new System.EventHandler(this.Bt_can_cel_Click);
            // 
            // tb_raz_soc
            // 
            this.tb_raz_soc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_raz_soc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_raz_soc.Location = new System.Drawing.Point(87, 7);
            this.tb_raz_soc.MaxLength = 30;
            this.tb_raz_soc.Name = "tb_raz_soc";
            this.tb_raz_soc.Size = new System.Drawing.Size(347, 30);
            this.tb_raz_soc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Raz. Social";
            // 
            // res001_02d
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_can_cel;
            this.ClientSize = new System.Drawing.Size(441, 332);
            this.ControlBox = false;
            this.Controls.Add(this.tb_raz_soc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ctr_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "res001_02d";
            this.Text = "Completa Nota de Venta";
            this.Load += new System.EventHandler(this.frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ctr_btn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_can_cel;
        public System.Windows.Forms.GroupBox gb_ctr_btn;
        private System.Windows.Forms.Button bt_ace_pta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tb_cam_bio;
        public System.Windows.Forms.TextBox tb_mto_can;
        public System.Windows.Forms.TextBox tb_pre_tot;
        public System.Windows.Forms.TextBox tb_obs_vta;
        public System.Windows.Forms.TextBox tb_raz_soc;
    }
}