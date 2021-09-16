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
    public partial class ads010_04 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads010 o_ads010 = new ads010();
      

        DataTable tabla = new DataTable();


        public ads010_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();
            tb_ide_tab.Text = frm_dat.Rows[0]["va_ide_tab"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
            
            tb_ide_tip.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_ide_tip.Text.Trim() == "")
            {
                tb_ide_tip.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_ads010.Fe_con_mod(tb_ide_tip.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_ide_tip.Focus();
                return "El Tipo de Imagen no se encuentra registrado";
            }
           

            
           return "";
        }

        private void Fi_lim_pia()
        {          
            tb_ide_tip.Clear(); 
            tb_ide_tab.Clear();
            tb_nom_tip.Clear();
           
            tb_ide_tip.Focus();
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

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Tipo de Imagen?", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Esta seguro de Habilitar el Tipo de Imagen?", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK)
                {
                    if (tb_est_ado.Text == "Habilitado")
                        o_ads010.Fe_des_hab(int.Parse(tb_ide_tip.Text));
                    else
                        o_ads010.Fe_hab_ili(int.Parse(tb_ide_tip.Text));

                    MessageBox.Show("Los datos se grabaron correctamente", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualiza ventana buscar
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));

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
