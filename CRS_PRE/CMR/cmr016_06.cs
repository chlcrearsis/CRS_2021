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
    public partial class cmr016_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr016 o_cmr016 = new cmr016();

        DataTable tabla = new DataTable();


        public cmr016_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_act.Text = frm_dat.Rows[0]["va_cod_act"].ToString();
            tb_nom_act.Text = frm_dat.Rows[0]["va_nom_act"].ToString();

            tb_cod_act.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_act.Text.Trim() == "")
            {
                tb_cod_act.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_cmr016.Fe_con_act(tb_cod_act.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_act.Focus();
                return "La Actividad económica no se encuentra registrada";
            }
            if (tb_nom_act.Text.Trim() == "")
            {
                tb_nom_act.Focus();
                return "Debe proporcionar el Nombre";
            }

            
           return "";
        }

        private void Fi_lim_pia()
        {          
            tb_cod_act.Clear(); 
            tb_nom_act.Clear();
           
            tb_cod_act.Focus();
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

                msg_res = MessageBox.Show("Esta seguro de Eliminar el Actividad económica?", "Elimina Actividad económica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               
                if (msg_res == DialogResult.OK)
                {
                    o_cmr016.Fe_eli_act(int.Parse(tb_cod_act.Text));
                    
                    MessageBox.Show("Los datos se eliminaron correctamente", "Elimina Actividad económica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Actualiza ventana buscar
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_act.Text));

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
