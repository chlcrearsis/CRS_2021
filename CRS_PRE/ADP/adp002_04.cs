using System;
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
    public partial class adp002_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp001 o_adp001 = new adp001();
        adp002 o_adp002 = new adp002();

        DataTable tabla = new DataTable();

        public adp002_04()
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

            if(frm_dat.Rows[0]["va_est_ado"].ToString()== "H")
            {
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar a la Persona?", "Deshabilita Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    //Edita persona
                    o_adp002.Fe_hab_des(int.Parse(tb_cod_per.Text),"N");
                    MessageBox.Show("La persona se Deshabilito correctamente", "Deshabilita Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
            {
                msg_res = MessageBox.Show("Esta seguro de Habilitar a la Persona?", "Habilita Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    //Edita persona
                    o_adp002.Fe_hab_des(int.Parse(tb_cod_per.Text), "H");
                    MessageBox.Show("La persona se Habilito correctamente", "Habilita Persona", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }

        }
    }
}
