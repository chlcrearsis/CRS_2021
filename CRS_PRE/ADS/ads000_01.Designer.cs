namespace CRS_PRE.ADS
{
    partial class ads000_01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ads000_01));
            this.rs_sel_pas = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rs_sel_usr = new System.Windows.Forms.Panel();
            this.cb_nom_bda = new System.Windows.Forms.ComboBox();
            this.bt_ace_pta = new System.Windows.Forms.Button();
            this.tb_ide_usr = new System.Windows.Forms.TextBox();
            this.tb_pas_usr = new System.Windows.Forms.TextBox();
            this.pn_sel_usr = new System.Windows.Forms.Panel();
            this.pn_sel_pas = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lb_ver_sis = new System.Windows.Forms.Label();
            this.lk_fan_pag = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_cer_apl = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_ima_usu = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.pb_ima_pas = new System.Windows.Forms.PictureBox();
            this.pb_log_sis = new System.Windows.Forms.PictureBox();
            this.pb_ver_pss = new System.Windows.Forms.PictureBox();
            this.rs_sel_pas.SuspendLayout();
            this.pn_sel_pas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_usu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_pas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_log_sis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ver_pss)).BeginInit();
            this.SuspendLayout();
            // 
            // rs_sel_pas
            // 
            this.rs_sel_pas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.rs_sel_pas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rs_sel_pas.Controls.Add(this.panel2);
            this.rs_sel_pas.Location = new System.Drawing.Point(-12, 234);
            this.rs_sel_pas.Name = "rs_sel_pas";
            this.rs_sel_pas.Size = new System.Drawing.Size(11, 50);
            this.rs_sel_pas.TabIndex = 86;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 50);
            this.panel2.TabIndex = 87;
            // 
            // rs_sel_usr
            // 
            this.rs_sel_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.rs_sel_usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rs_sel_usr.Location = new System.Drawing.Point(-12, 174);
            this.rs_sel_usr.Name = "rs_sel_usr";
            this.rs_sel_usr.Size = new System.Drawing.Size(11, 50);
            this.rs_sel_usr.TabIndex = 87;
            // 
            // cb_nom_bda
            // 
            this.cb_nom_bda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.cb_nom_bda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nom_bda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_nom_bda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nom_bda.FormattingEnabled = true;
            this.cb_nom_bda.Location = new System.Drawing.Point(61, 310);
            this.cb_nom_bda.Name = "cb_nom_bda";
            this.cb_nom_bda.Size = new System.Drawing.Size(251, 24);
            this.cb_nom_bda.TabIndex = 30;
            this.cb_nom_bda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_ide_usr_KeyPress);
            // 
            // bt_ace_pta
            // 
            this.bt_ace_pta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.bt_ace_pta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ace_pta.FlatAppearance.BorderSize = 0;
            this.bt_ace_pta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ace_pta.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.bt_ace_pta.ForeColor = System.Drawing.Color.White;
            this.bt_ace_pta.Location = new System.Drawing.Point(18, 359);
            this.bt_ace_pta.Name = "bt_ace_pta";
            this.bt_ace_pta.Size = new System.Drawing.Size(311, 47);
            this.bt_ace_pta.TabIndex = 40;
            this.bt_ace_pta.Text = "Ingresar";
            this.bt_ace_pta.UseVisualStyleBackColor = false;
            this.bt_ace_pta.Click += new System.EventHandler(this.bt_ace_pta_Click);
            // 
            // tb_ide_usr
            // 
            this.tb_ide_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tb_ide_usr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ide_usr.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ide_usr.ForeColor = System.Drawing.Color.DarkGray;
            this.tb_ide_usr.Location = new System.Drawing.Point(61, 186);
            this.tb_ide_usr.Name = "tb_ide_usr";
            this.tb_ide_usr.Size = new System.Drawing.Size(253, 26);
            this.tb_ide_usr.TabIndex = 10;
            this.tb_ide_usr.Text = "Usuario";
            this.tb_ide_usr.Enter += new System.EventHandler(this.tb_ide_usr_Enter);
            this.tb_ide_usr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_ide_usr_KeyPress);
            this.tb_ide_usr.Validated += new System.EventHandler(this.tb_ide_usr_Validated);
            // 
            // tb_pas_usr
            // 
            this.tb_pas_usr.AccessibleDescription = "";
            this.tb_pas_usr.AccessibleName = "";
            this.tb_pas_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tb_pas_usr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pas_usr.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pas_usr.ForeColor = System.Drawing.Color.DarkGray;
            this.tb_pas_usr.Location = new System.Drawing.Point(61, 247);
            this.tb_pas_usr.Name = "tb_pas_usr";
            this.tb_pas_usr.Size = new System.Drawing.Size(235, 26);
            this.tb_pas_usr.TabIndex = 20;
            this.tb_pas_usr.Text = "Contraseña";
            this.tb_pas_usr.UseSystemPasswordChar = true;
            this.tb_pas_usr.Enter += new System.EventHandler(this.tb_pas_usr_Enter);
            this.tb_pas_usr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_ide_usr_KeyPress);
            this.tb_pas_usr.Validated += new System.EventHandler(this.tb_pas_usr_Validated);
            // 
            // pn_sel_usr
            // 
            this.pn_sel_usr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pn_sel_usr.Location = new System.Drawing.Point(16, 175);
            this.pn_sel_usr.Name = "pn_sel_usr";
            this.pn_sel_usr.Size = new System.Drawing.Size(312, 50);
            this.pn_sel_usr.TabIndex = 44;
            // 
            // pn_sel_pas
            // 
            this.pn_sel_pas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pn_sel_pas.Controls.Add(this.pb_ver_pss);
            this.pn_sel_pas.Location = new System.Drawing.Point(16, 234);
            this.pn_sel_pas.Name = "pn_sel_pas";
            this.pn_sel_pas.Size = new System.Drawing.Size(312, 50);
            this.pn_sel_pas.TabIndex = 45;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Panel1.Location = new System.Drawing.Point(16, 296);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(312, 50);
            this.Panel1.TabIndex = 46;
            // 
            // lb_ver_sis
            // 
            this.lb_ver_sis.AutoSize = true;
            this.lb_ver_sis.BackColor = System.Drawing.Color.Transparent;
            this.lb_ver_sis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ver_sis.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lb_ver_sis.Location = new System.Drawing.Point(229, 153);
            this.lb_ver_sis.Name = "lb_ver_sis";
            this.lb_ver_sis.Size = new System.Drawing.Size(99, 13);
            this.lb_ver_sis.TabIndex = 88;
            this.lb_ver_sis.Text = "VERSION. 1.0.1";
            // 
            // lk_fan_pag
            // 
            this.lk_fan_pag.ActiveLinkColor = System.Drawing.Color.RosyBrown;
            this.lk_fan_pag.AutoSize = true;
            this.lk_fan_pag.BackColor = System.Drawing.Color.Transparent;
            this.lk_fan_pag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lk_fan_pag.ForeColor = System.Drawing.Color.Black;
            this.lk_fan_pag.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lk_fan_pag.Location = new System.Drawing.Point(15, 153);
            this.lk_fan_pag.Name = "lk_fan_pag";
            this.lk_fan_pag.Size = new System.Drawing.Size(126, 13);
            this.lk_fan_pag.TabIndex = 89;
            this.lk_fan_pag.TabStop = true;
            this.lk_fan_pag.Text = "@Visitanos en Facebook";
            this.lk_fan_pag.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_fan_pag_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(248, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 26);
            this.label2.TabIndex = 90;
            this.label2.Text = "Soporte\r\nTelf: 999 99999";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_cer_apl
            // 
            this.bt_cer_apl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_cer_apl.FlatAppearance.BorderSize = 0;
            this.bt_cer_apl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cer_apl.Image = ((System.Drawing.Image)(resources.GetObject("bt_cer_apl.Image")));
            this.bt_cer_apl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_cer_apl.Location = new System.Drawing.Point(315, 1);
            this.bt_cer_apl.Name = "bt_cer_apl";
            this.bt_cer_apl.Size = new System.Drawing.Size(37, 29);
            this.bt_cer_apl.TabIndex = 17;
            this.bt_cer_apl.TabStop = false;
            this.bt_cer_apl.UseVisualStyleBackColor = true;
            this.bt_cer_apl.Click += new System.EventHandler(this.bt_cer_apl_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.ForeColor = System.Drawing.Color.Black;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(92, 8);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(152, 138);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 85;
            this.PictureBox1.TabStop = false;
            // 
            // pb_ima_usu
            // 
            this.pb_ima_usu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pb_ima_usu.Image = ((System.Drawing.Image)(resources.GetObject("pb_ima_usu.Image")));
            this.pb_ima_usu.Location = new System.Drawing.Point(20, 185);
            this.pb_ima_usu.Name = "pb_ima_usu";
            this.pb_ima_usu.Size = new System.Drawing.Size(28, 28);
            this.pb_ima_usu.TabIndex = 38;
            this.pb_ima_usu.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(20, 309);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(28, 28);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 42;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pb_ima_pas
            // 
            this.pb_ima_pas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pb_ima_pas.Image = ((System.Drawing.Image)(resources.GetObject("pb_ima_pas.Image")));
            this.pb_ima_pas.Location = new System.Drawing.Point(20, 245);
            this.pb_ima_pas.Name = "pb_ima_pas";
            this.pb_ima_pas.Size = new System.Drawing.Size(28, 28);
            this.pb_ima_pas.TabIndex = 40;
            this.pb_ima_pas.TabStop = false;
            this.pb_ima_pas.Click += new System.EventHandler(this.pb_ima_pas_Click);
            // 
            // pb_log_sis
            // 
            this.pb_log_sis.Location = new System.Drawing.Point(92, 8);
            this.pb_log_sis.Name = "pb_log_sis";
            this.pb_log_sis.Size = new System.Drawing.Size(152, 138);
            this.pb_log_sis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_log_sis.TabIndex = 36;
            this.pb_log_sis.TabStop = false;
            // 
            // pb_ver_pss
            // 
            this.pb_ver_pss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pb_ver_pss.Image = ((System.Drawing.Image)(resources.GetObject("pb_ver_pss.Image")));
            this.pb_ver_pss.Location = new System.Drawing.Point(281, 11);
            this.pb_ver_pss.Name = "pb_ver_pss";
            this.pb_ver_pss.Size = new System.Drawing.Size(26, 28);
            this.pb_ver_pss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ver_pss.TabIndex = 91;
            this.pb_ver_pss.TabStop = false;
            this.pb_ver_pss.MouseLeave += new System.EventHandler(this.pb_ver_pss_MouseLeave);
            this.pb_ver_pss.MouseHover += new System.EventHandler(this.pb_ver_pss_MouseHover);
            // 
            // ads000_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(350, 431);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lk_fan_pag);
            this.Controls.Add(this.lb_ver_sis);
            this.Controls.Add(this.rs_sel_pas);
            this.Controls.Add(this.rs_sel_usr);
            this.Controls.Add(this.bt_cer_apl);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.cb_nom_bda);
            this.Controls.Add(this.pb_ima_usu);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.tb_pas_usr);
            this.Controls.Add(this.bt_ace_pta);
            this.Controls.Add(this.tb_ide_usr);
            this.Controls.Add(this.pb_ima_pas);
            this.Controls.Add(this.pb_log_sis);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.pn_sel_pas);
            this.Controls.Add(this.pn_sel_usr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ads000_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO DE SESION USUARIO";
            this.Load += new System.EventHandler(this.ads000_01_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ads000_01_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ads000_01_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ads000_01_MouseUp);
            this.rs_sel_pas.ResumeLayout(false);
            this.pn_sel_pas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_usu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ima_pas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_log_sis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ver_pss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button bt_cer_apl;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.PictureBox pb_log_sis;
        internal System.Windows.Forms.ComboBox cb_nom_bda;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Button bt_ace_pta;
        internal System.Windows.Forms.PictureBox pb_ima_pas;
        internal System.Windows.Forms.TextBox tb_ide_usr;
        internal System.Windows.Forms.TextBox tb_pas_usr;
        internal System.Windows.Forms.PictureBox pb_ima_usu;
        internal System.Windows.Forms.Panel pn_sel_usr;
        internal System.Windows.Forms.Panel pn_sel_pas;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel rs_sel_pas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel rs_sel_usr;
        internal System.Windows.Forms.Label lb_ver_sis;
        private System.Windows.Forms.LinkLabel lk_fan_pag;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.PictureBox pb_ver_pss;
    }
}