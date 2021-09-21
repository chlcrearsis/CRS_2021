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
    public partial class adp002_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp001 o_adp001 = new adp001();
        adp002 o_adp002 = new adp002();
        cmr014 o_cmr014 = new cmr014();

        DataTable tabla = new DataTable();

        public adp002_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString();
            lb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_nom_com.Text = frm_dat.Rows[0]["va_nom_com"].ToString();
            tb_nit_per.Text = frm_dat.Rows[0]["va_nit_per"].ToString();
            tb_car_net.Text = frm_dat.Rows[0]["va_car_net"].ToString();
            tb_dir_per.Text = frm_dat.Rows[0]["va_dir_per"].ToString();
            tb_tel_per.Text = frm_dat.Rows[0]["va_tel_per"].ToString();
            tb_cel_per.Text = frm_dat.Rows[0]["va_cel_per"].ToString();
            tb_ema_per.Text = frm_dat.Rows[0]["va_ema_per"].ToString();

            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ven"].ToString();
            Fi_obt_ven();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            if (tb_cod_gru.Text.Trim() == "0")
            {
                tb_cod_gru.Focus();
                return "El nro del Grupo de Persona debe ser distinto de Cero (0)";
            }
            int val = 0;
            decimal val_dec = 0;

            int.TryParse(tb_cod_gru.Text.Trim(), out val);
            if (val == 0)
            {
                tb_cod_gru.Focus();
                return "El codigo del Grupo de Persona debe ser numerico";
            }


            //Verificar Grupo de Persona
            tabla = new DataTable();
            tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

           

            tabla = new DataTable();
            tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (tabla.Rows.Count == 0)
            {
                return "La Persona que desea editar NO se encuentra registrada";
            }
            if (tb_raz_soc.Text.Trim() == "")
            {
                tb_raz_soc.Focus();
                return "Debe proporcionar la razon social de la Persona";
            }
            if (tb_nom_com.Text.Trim() == "")
            {
                tb_nom_com.Focus();
                return "Debe proporcionar el Nombre comercial de la Persona";
            }



            // Verifica Nit
            try
            {
                val_dec = decimal.Parse(tb_nit_per.Text);
            }
            catch (Exception )
            {
                tb_nit_per.Focus();
                return "El Nit de la Persona debe ser numerico";
            }
             
            //Verifica que no haya otra persona con ese nit
            if(decimal.Parse(tb_nit_per.Text.Trim()) != 0m)
            {
                tabla = new DataTable();
                tabla = o_adp002.Fe_con_per_nit(int.Parse(tb_cod_per.Text), decimal.Parse(tb_nit_per.Text));
                if (tabla.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo Nit, desea editarla de todos modos ?", "Nueva Persona", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        tb_nit_per.Focus();
                        return "Revise el Nit por favor";
                    }
                }
            }

            // Verifica CI
            try
            {
                val = int.Parse(tb_car_net.Text);
            }
            catch (Exception)
            {
                tb_car_net.Focus();
                return "El C.I. de la Persona debe ser numerico";
            }
           
            //Verifica que no haya otra persona con ese CI
            if (int.Parse(tb_car_net.Text.Trim()) != 0)
            {
                tabla = new DataTable();
                tabla = o_adp002.Fe_con_per_ci(int.Parse(tb_cod_per.Text), int.Parse(tb_car_net.Text));
                if (tabla.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo CI, desea editarla de todos modos ?", "Nueva Persona", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        tb_car_net.Focus();
                        return "Revise el CI por favor";
                    }
                }
            }

            return "";

        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Persona", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita persona
                o_adp002.Fe_edi_per(int.Parse(tb_cod_per.Text),tb_raz_soc.Text, tb_nom_com.Text,decimal.Parse(tb_nit_per.Text), int.Parse(tb_car_net.Text),
                                    tb_dir_per.Text,tb_tel_per.Text,tb_cel_per.Text,tb_ema_per.Text, int.Parse(tb_cod_ven.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Persona", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                cl_glo_frm.Cerrar(this);
            }

        }



        //******* VENDEDOR *******\\
        private void Bt_bus_ven_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_ven();
        }
        private void Tb_cod_ven_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_ven();
            }
        }
        void Fi_abr_bus_ven()
        {
            cmr014_01 frm = new cmr014_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_ven.Text = frm.tb_sel_bus.Text;
                Fi_obt_ven();
            }
        }
        private void Tb_cod_ven_Validated(object sender, EventArgs e)
        {
            Fi_obt_ven();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_ven()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_ven.Text);
            }
            catch (Exception)
            {
                lb_nom_ven.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_ven.Text = "";
            }
            else
            {
                tb_cod_ven.Text = tabla.Rows[0]["va_cod_ide"].ToString();
                lb_nom_ven.Text = tabla.Rows[0]["va_nom_bre"].ToString();
            }
        }

    }
}
