﻿namespace CRS_PRE
{
    partial class ads200
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
            this.m_mod_ulo = new System.Windows.Forms.MenuStrip();
            this.mn_usu_ari = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ges_tio = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_doc_ume = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_tal_ona = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_num_era = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_def_par = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_par_inv = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_gru_bod = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_bod_ega = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_fam_pro = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_pro_duc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mar_ca = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_und_med = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_com_erc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_lis_pre = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_pre_cio = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_del_ive = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_ven_ded = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_pla_vta = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_son = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_gru_per = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_per_son1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_tip_bus = new System.Windows.Forms.ToolStripMenuItem();
            this.m_frm_hja = new System.Windows.Forms.MenuStrip();
            this.st_bar_pie = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_usr_usr = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_bas_dat = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_ide_app = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_rut_app = new System.Windows.Forms.ToolStripStatusLabel();
            this.mn_par_ame = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_mod_ulo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mod_ulo.SuspendLayout();
            this.st_bar_pie.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_mod_ulo
            // 
            this.m_mod_ulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_usu_ari,
            this.mn_ges_tio,
            this.controlToolStripMenuItem,
            this.mn_def_par});
            this.m_mod_ulo.Location = new System.Drawing.Point(0, 0);
            this.m_mod_ulo.Name = "m_mod_ulo";
            this.m_mod_ulo.Size = new System.Drawing.Size(886, 24);
            this.m_mod_ulo.TabIndex = 2;
            this.m_mod_ulo.Text = "menuStrip1";
            this.m_mod_ulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_ads100_ItemClicked);
            // 
            // mn_usu_ari
            // 
            this.mn_usu_ari.Name = "mn_usu_ari";
            this.mn_usu_ari.Size = new System.Drawing.Size(55, 20);
            this.mn_usu_ari.Text = "Usuario";
            // 
            // mn_ges_tio
            // 
            this.mn_ges_tio.Name = "mn_ges_tio";
            this.mn_ges_tio.Size = new System.Drawing.Size(55, 20);
            this.mn_ges_tio.Text = "Gestion";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_doc_ume,
            this.mn_tal_ona,
            this.mn_num_era});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.controlToolStripMenuItem.Text = "Control Documento";
            // 
            // mn_doc_ume
            // 
            this.mn_doc_ume.Name = "mn_doc_ume";
            this.mn_doc_ume.Size = new System.Drawing.Size(130, 22);
            this.mn_doc_ume.Text = "Documento";
            this.mn_doc_ume.Click += new System.EventHandler(this.Mn_doc_ume_Click);
            // 
            // mn_tal_ona
            // 
            this.mn_tal_ona.Name = "mn_tal_ona";
            this.mn_tal_ona.Size = new System.Drawing.Size(130, 22);
            this.mn_tal_ona.Text = "Talonario";
            this.mn_tal_ona.Click += new System.EventHandler(this.TalonarioToolStripMenuItem_Click);
            // 
            // mn_num_era
            // 
            this.mn_num_era.Name = "mn_num_era";
            this.mn_num_era.Size = new System.Drawing.Size(130, 22);
            this.mn_num_era.Text = "Numeracion";
            this.mn_num_era.Click += new System.EventHandler(this.Mn_num_era_Click);
            // 
            // mn_def_par
            // 
            this.mn_def_par.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_par_inv,
            this.mn_com_erc,
            this.mn_per_son,
            this.mn_tip_bus,
            this.mn_par_ame});
            this.mn_def_par.Name = "mn_def_par";
            this.mn_def_par.Size = new System.Drawing.Size(76, 20);
            this.mn_def_par.Text = "&Definiciones";
            // 
            // mn_par_inv
            // 
            this.mn_par_inv.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_gru_bod,
            this.mn_bod_ega,
            this.mn_fam_pro,
            this.mn_pro_duc,
            this.mn_mar_ca,
            this.mn_und_med});
            this.mn_par_inv.Name = "mn_par_inv";
            this.mn_par_inv.Size = new System.Drawing.Size(180, 22);
            this.mn_par_inv.Text = "&Inventario";
            // 
            // mn_gru_bod
            // 
            this.mn_gru_bod.Name = "mn_gru_bod";
            this.mn_gru_bod.Size = new System.Drawing.Size(180, 22);
            this.mn_gru_bod.Text = "&Grupo Bodegas";
            this.mn_gru_bod.Click += new System.EventHandler(this.mn_gru_bod_Click);
            // 
            // mn_bod_ega
            // 
            this.mn_bod_ega.Name = "mn_bod_ega";
            this.mn_bod_ega.Size = new System.Drawing.Size(180, 22);
            this.mn_bod_ega.Text = "&Bodegas";
            this.mn_bod_ega.Click += new System.EventHandler(this.mn_bod_ega_Click);
            // 
            // mn_fam_pro
            // 
            this.mn_fam_pro.Name = "mn_fam_pro";
            this.mn_fam_pro.Size = new System.Drawing.Size(180, 22);
            this.mn_fam_pro.Text = "&Familia Productos";
            this.mn_fam_pro.Click += new System.EventHandler(this.mn_fam_pro_Click);
            // 
            // mn_pro_duc
            // 
            this.mn_pro_duc.Name = "mn_pro_duc";
            this.mn_pro_duc.Size = new System.Drawing.Size(180, 22);
            this.mn_pro_duc.Text = "&Productos";
            this.mn_pro_duc.Click += new System.EventHandler(this.mn_pro_duc_Click);
            // 
            // mn_mar_ca
            // 
            this.mn_mar_ca.Name = "mn_mar_ca";
            this.mn_mar_ca.Size = new System.Drawing.Size(180, 22);
            this.mn_mar_ca.Text = "&Marca";
            this.mn_mar_ca.Click += new System.EventHandler(this.mn_mar_ca_Click);
            // 
            // mn_und_med
            // 
            this.mn_und_med.Name = "mn_und_med";
            this.mn_und_med.Size = new System.Drawing.Size(180, 22);
            this.mn_und_med.Text = "&Unidad de Medida";
            this.mn_und_med.Click += new System.EventHandler(this.mn_und_med_Click);
            // 
            // mn_com_erc
            // 
            this.mn_com_erc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_lis_pre,
            this.mn_pre_cio,
            this.mn_del_ive,
            this.mn_ven_ded,
            this.mn_pla_vta});
            this.mn_com_erc.Name = "mn_com_erc";
            this.mn_com_erc.Size = new System.Drawing.Size(180, 22);
            this.mn_com_erc.Text = "Comercializacion";
            // 
            // mn_lis_pre
            // 
            this.mn_lis_pre.Name = "mn_lis_pre";
            this.mn_lis_pre.Size = new System.Drawing.Size(180, 22);
            this.mn_lis_pre.Text = "Lista de Precios";
            this.mn_lis_pre.Click += new System.EventHandler(this.mn_lis_pre_Click);
            // 
            // mn_pre_cio
            // 
            this.mn_pre_cio.Name = "mn_pre_cio";
            this.mn_pre_cio.Size = new System.Drawing.Size(180, 22);
            this.mn_pre_cio.Text = "Precios";
            this.mn_pre_cio.Click += new System.EventHandler(this.mn_pre_cio_Click);
            // 
            // mn_del_ive
            // 
            this.mn_del_ive.Name = "mn_del_ive";
            this.mn_del_ive.Size = new System.Drawing.Size(180, 22);
            this.mn_del_ive.Text = "Delivery";
            this.mn_del_ive.Click += new System.EventHandler(this.mn_del_ive_Click);
            // 
            // mn_ven_ded
            // 
            this.mn_ven_ded.Name = "mn_ven_ded";
            this.mn_ven_ded.Size = new System.Drawing.Size(180, 22);
            this.mn_ven_ded.Text = "&Vendedor";
            this.mn_ven_ded.Click += new System.EventHandler(this.mn_ven_ded_Click);
            // 
            // mn_pla_vta
            // 
            this.mn_pla_vta.Name = "mn_pla_vta";
            this.mn_pla_vta.Size = new System.Drawing.Size(180, 22);
            this.mn_pla_vta.Text = "Plantilla de venta";
            this.mn_pla_vta.Click += new System.EventHandler(this.mn_pla_vta_Click);
            // 
            // mn_per_son
            // 
            this.mn_per_son.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_gru_per,
            this.mn_per_son1});
            this.mn_per_son.Name = "mn_per_son";
            this.mn_per_son.Size = new System.Drawing.Size(180, 22);
            this.mn_per_son.Text = "&Persona";
            // 
            // mn_gru_per
            // 
            this.mn_gru_per.Name = "mn_gru_per";
            this.mn_gru_per.Size = new System.Drawing.Size(180, 22);
            this.mn_gru_per.Text = "&Grupo de Persona";
            this.mn_gru_per.Click += new System.EventHandler(this.mn_gru_per_Click);
            // 
            // mn_per_son1
            // 
            this.mn_per_son1.Name = "mn_per_son1";
            this.mn_per_son1.Size = new System.Drawing.Size(180, 22);
            this.mn_per_son1.Text = "&Persona";
            this.mn_per_son1.Click += new System.EventHandler(this.mn_per_son1_Click);
            // 
            // mn_tip_bus
            // 
            this.mn_tip_bus.Name = "mn_tip_bus";
            this.mn_tip_bus.Size = new System.Drawing.Size(180, 22);
            this.mn_tip_bus.Text = "T.C. Bs/Us";
            this.mn_tip_bus.Click += new System.EventHandler(this.mn_tip_bus_Click);
            // 
            // m_frm_hja
            // 
            this.m_frm_hja.Location = new System.Drawing.Point(0, 0);
            this.m_frm_hja.Name = "m_frm_hja";
            this.m_frm_hja.Size = new System.Drawing.Size(886, 24);
            this.m_frm_hja.TabIndex = 4;
            this.m_frm_hja.Text = "menuStrip1";
            this.m_frm_hja.Visible = false;
            // 
            // st_bar_pie
            // 
            this.st_bar_pie.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ts_usr_usr,
            this.toolStripStatusLabel2,
            this.ts_bas_dat,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.ts_ide_app,
            this.toolStripStatusLabel4,
            this.ts_rut_app});
            this.st_bar_pie.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.st_bar_pie.Location = new System.Drawing.Point(0, 485);
            this.st_bar_pie.Name = "st_bar_pie";
            this.st_bar_pie.Size = new System.Drawing.Size(886, 18);
            this.st_bar_pie.TabIndex = 6;
            this.st_bar_pie.Tag = "Adminstracion y Seguridad";
            this.st_bar_pie.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 13);
            this.toolStripStatusLabel1.Text = "Usuario:";
            // 
            // ts_usr_usr
            // 
            this.ts_usr_usr.AutoSize = false;
            this.ts_usr_usr.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ts_usr_usr.Name = "ts_usr_usr";
            this.ts_usr_usr.Size = new System.Drawing.Size(55, 13);
            this.ts_usr_usr.Text = "...";
            this.ts_usr_usr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 13);
            this.toolStripStatusLabel2.Text = "BD:";
            // 
            // ts_bas_dat
            // 
            this.ts_bas_dat.AutoSize = false;
            this.ts_bas_dat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ts_bas_dat.Name = "ts_bas_dat";
            this.ts_bas_dat.Size = new System.Drawing.Size(60, 13);
            this.ts_bas_dat.Text = "...";
            this.ts_bas_dat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 13);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(32, 13);
            this.toolStripStatusLabel5.Text = "App:";
            // 
            // ts_ide_app
            // 
            this.ts_ide_app.AutoSize = false;
            this.ts_ide_app.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ts_ide_app.Name = "ts_ide_app";
            this.ts_ide_app.Size = new System.Drawing.Size(80, 13);
            this.ts_ide_app.Text = "...";
            this.ts_ide_app.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(34, 13);
            this.toolStripStatusLabel4.Text = "Ruta:";
            // 
            // ts_rut_app
            // 
            this.ts_rut_app.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ts_rut_app.Name = "ts_rut_app";
            this.ts_rut_app.Size = new System.Drawing.Size(16, 13);
            this.ts_rut_app.Text = "...";
            this.ts_rut_app.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mn_par_ame
            // 
            this.mn_par_ame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_mod_ulo});
            this.mn_par_ame.Name = "mn_par_ame";
            this.mn_par_ame.Size = new System.Drawing.Size(180, 22);
            this.mn_par_ame.Text = "&Parametros";
            // 
            // mn_mod_ulo
            // 
            this.mn_mod_ulo.Name = "mn_mod_ulo";
            this.mn_mod_ulo.Size = new System.Drawing.Size(180, 22);
            this.mn_mod_ulo.Text = "&Modulo";
            this.mn_mod_ulo.Click += new System.EventHandler(this.mn_mod_ulo_Click);
            // 
            // ads200
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.st_bar_pie);
            this.Controls.Add(this.m_mod_ulo);
            this.Controls.Add(this.m_frm_hja);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.m_frm_hja;
            this.Name = "ads200";
            this.Tag = "Administracion y Seguridad";
            this.Text = "Administracion y Seguridad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ads100_Load);
            this.MdiChildActivate += new System.EventHandler(this.Ads100_MdiChildActivate);
            this.m_mod_ulo.ResumeLayout(false);
            this.m_mod_ulo.PerformLayout();
            this.st_bar_pie.ResumeLayout(false);
            this.st_bar_pie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem mn_usu_ari;
        private System.Windows.Forms.ToolStripMenuItem mn_ges_tio;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_doc_ume;
        private System.Windows.Forms.ToolStripMenuItem mn_tal_ona;
        public System.Windows.Forms.MenuStrip m_mod_ulo;
        public System.Windows.Forms.MenuStrip m_frm_hja;
        private System.Windows.Forms.StatusStrip st_bar_pie;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ts_usr_usr;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ts_bas_dat;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel ts_ide_app;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel ts_rut_app;
        private System.Windows.Forms.ToolStripMenuItem mn_num_era;
        private System.Windows.Forms.ToolStripMenuItem mn_def_par;
        private System.Windows.Forms.ToolStripMenuItem mn_par_inv;
        private System.Windows.Forms.ToolStripMenuItem mn_gru_bod;
        private System.Windows.Forms.ToolStripMenuItem mn_bod_ega;
        private System.Windows.Forms.ToolStripMenuItem mn_fam_pro;
        private System.Windows.Forms.ToolStripMenuItem mn_pro_duc;
        private System.Windows.Forms.ToolStripMenuItem mn_com_erc;
        private System.Windows.Forms.ToolStripMenuItem mn_lis_pre;
        private System.Windows.Forms.ToolStripMenuItem mn_pre_cio;
        private System.Windows.Forms.ToolStripMenuItem mn_del_ive;
        private System.Windows.Forms.ToolStripMenuItem mn_mar_ca;
        private System.Windows.Forms.ToolStripMenuItem mn_und_med;
        private System.Windows.Forms.ToolStripMenuItem mn_ven_ded;
        private System.Windows.Forms.ToolStripMenuItem mn_per_son;
        private System.Windows.Forms.ToolStripMenuItem mn_gru_per;
        private System.Windows.Forms.ToolStripMenuItem mn_per_son1;
        private System.Windows.Forms.ToolStripMenuItem mn_pla_vta;
        private System.Windows.Forms.ToolStripMenuItem mn_tip_bus;
        private System.Windows.Forms.ToolStripMenuItem mn_par_ame;
        private System.Windows.Forms.ToolStripMenuItem mn_mod_ulo;
    }
}