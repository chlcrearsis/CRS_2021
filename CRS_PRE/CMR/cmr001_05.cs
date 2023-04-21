﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr001_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr001 o_cmr001 = new cmr001();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr001_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();
            tb_nro_dec.Text = frm_dat.Rows[0]["va_nro_dec"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
            if (frm_dat.Rows[0]["va_mon_lis"].ToString() == "B")
                cb_mon_lis.SelectedIndex = 0;
            if (frm_dat.Rows[0]["va_mon_lis"].ToString() == "U")
                cb_mon_lis.SelectedIndex = 1;

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_bre.Focus();
        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        protected string Fi_val_dat()
        {
            
            //Verificar 
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio que desea crear ya NO se encuentra registrada";
            }
            if (tb_nom_bre.Text.Trim() == "")
            {
                tb_nom_bre.Focus();
                return "Debe proporcionar el Nombre para la Lista de Precio";
            }

            int val;
            int.TryParse(tb_nro_dec.Text, out val);
            if (tb_nro_dec.Text != "0")
            {
                if(val==0)
                {
                    tb_nro_dec.Focus();
                    return "El numero de decimales con el que trabajara la lista de precios es incorrecto";
                }
            }

            if (val < 1 || val > 4)
            {
                tb_nro_dec.Focus();
                return "El numero de decimales con el que trabajara la lista de precios debe estar entre 0-4";
            }

            if(tb_fec_ini.Value > tb_fec_fin.Value)
            {
                tb_fec_fin.Focus();
                return "La fecha final debe ser mayor igual a la fecha inicial";
            }


            return "";
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
