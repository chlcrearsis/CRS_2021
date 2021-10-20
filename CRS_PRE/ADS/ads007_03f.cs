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
    public partial class ads007_03f : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads007 o_ads007 = new ads007();
        ads017 o_ads017 = new ads017();
        cl_glo_frm o_glo_frm = new cl_glo_frm();

        DataTable tabla = new DataTable();
        DataTable tab_ads017 = new DataTable();

        public ads007_03f()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
           
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";


            // Obtiene datos del pin del usuario
            tab_ads017 = o_ads017.Fe_con_pin(tb_ide_usr.Text);
            if(tab_ads017.Rows.Count > 0)
            {
                tb_fec_reg.Text = tab_ads017.Rows[0]["va_fec_reg"].ToString();
                tb_fec_exp.Text = tab_ads017.Rows[0]["va_fec_exp"].ToString();
            }else
            {
                tb_pin_act.Enabled = false;
                tb_fec_reg.Text = "01/01/1999 00:00";
                tb_fec_exp.Text = "01/01/1999 00:00";
            }

            tb_fec_exp2.Text = DateTime.Now.AddMonths(3).ToString(); //  DateTime.Now.ToString();
            //tb_hor_exp.Text = "23:59";

            tb_pas_usr.Focus();

        }




        protected string Fi_val_dat()
        {
            string msn_res = "";

            // Valida concurrencia del usuario en la base de datos
            msn_res = o_ads007.Fe_ver_edi(tb_ide_usr.Text);

            if (msn_res != "")
                return msn_res;


            // VALIDA LOGUIN DEL USUARIO
            if (tb_pas_usr.Text.Trim() == "")
            {
                tb_pas_usr.Focus();
                return "Debe proporcionar su contraseña.";
            }
            msn_res = o_ads007.Login_2(tb_ide_usr.Text, tb_pas_usr.Text);
            if (msn_res != "OK")
            {
                tb_pas_usr.Focus();
                return msn_res;
            }

            // VALIDA PIN ACTUAL
            if (tb_pin_new.Text.Trim() == "")
            {
                tb_pin_new.Focus();
                return "Debe proporcionar el nuevo PIN.";
            }

            tab_ads017 = o_ads017.Fe_con_pin(tb_ide_usr.Text);
            if(tab_ads017.Rows.Count > 0)
            {
                if(tb_pin_act.Text != tab_ads017.Rows[0]["va_pin_usr"].ToString() )
                {
                    tb_pin_act.Focus();
                    return "El PIN actual proporcionado es incorrecto.";
                }
            }

            // VALIDA NUEVO PIN
            if(tb_pin_new.Text != tb_pin_rep.Text)
            {
                tb_pin_rep.Focus();
                return "La confirmación del PIN no coincide con con el nuevo PIN proporcionado.";
            }

            // VALIDA FECHA Y HORA DE EXPIRACIÓN
            try
            {
                DateTime fec_hra = DateTime.Parse(tb_fec_exp2.Text);
            }
            catch (Exception )
            {
                tb_fec_exp2.Focus();
                return "La fecha y hora de expiracion proporcionada no es valida.";
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
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de Grabar los datos?", "PIN Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                if (tab_ads017.Rows.Count == 0)
                    o_ads017.Fe_crea(tb_ide_usr.Text, int.Parse(tb_pin_new.Text), o_glo_frm.fg_fec_act(), DateTime.Parse(tb_fec_exp2.Text), SystemInformation.ComputerName) ;
                else
                    o_ads017.Fe_edi_pin(tb_ide_usr.Text, int.Parse(tb_pin_new.Text), o_glo_frm.fg_fec_act(), DateTime.Parse(tb_fec_exp2.Text), SystemInformation.ComputerName);

                MessageBox.Show("Los datos se grabaron satisfactoriamente", "PIN Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cl_glo_frm.Cerrar(this);
            }

        }
        private void tb_pin_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);

        }
    }
}
