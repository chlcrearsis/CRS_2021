﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Módulo del Sistema                           */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 18-08-2022         */
    /**********************************************************************/
    public partial class ads001_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;       

        public ads001_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_abr_mod.Text = frm_dat.Rows[0]["va_abr_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            tb_abr_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
