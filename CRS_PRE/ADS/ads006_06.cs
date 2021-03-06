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
    public partial class ads006_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads006 o_ads006 = new ads006();

        DataTable tabla = new DataTable();


        public ads006_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tus.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
            tb_nom_tus.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            tb_des_tus.Text = frm_dat.Rows[0]["va_des_tus"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
            
            tb_ide_tus.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_ide_tus.Text.Trim() == "")
            {
                tb_ide_tus.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_ads006.Fe_con_tus(tb_ide_tus.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_ide_tus.Focus();
                return "El Tipo de usuario no se encuentra registrado";
            }
            if (tb_nom_tus.Text.Trim() == "")
            {
                tb_nom_tus.Focus();
                return "Debe proporcionar el Nombre";
            }

            
           return "";
        }

        private void Fi_lim_pia()
        {          
            tb_ide_tus.Clear(); 
            tb_nom_tus.Clear();
            tb_des_tus.Clear();
           
            tb_ide_tus.Focus();
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {

            try
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

                msg_res = MessageBox.Show("Esta seguro de Eliminar el Tipo de usuario?", "Elimina Tipo de usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               
                if (msg_res == DialogResult.OK)
                {
                    o_ads006.Fe_eli_tus(int.Parse(tb_ide_tus.Text));
                    
                    MessageBox.Show("Los datos se grabaron correctamente", "Elimina Tipo de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualiza ventana buscar
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tus.Text));

                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
