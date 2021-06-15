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
using CRS_NEG.INV;

namespace CRS_PRE.INV
{
    public partial class inv002_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_inv002 o_inv002 = new c_inv002();
        c_inv001 o_inv001 = new c_inv001();

        DataTable tabla = new DataTable();


        public inv002_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_gru.Text = "0";
            tb_nro_bod.Text = "0";
            Fi_obt_cod();

            cb_mon_inv.SelectedIndex = 0;
            tb_ide_gru.Focus();
        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }


        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            if (tb_ide_gru.Text.Trim() == "0")
            {
                tb_ide_gru.Focus();
                return "El nro del Grupo de Bodega debe ser distinto de Cero (0)";
            }
            int val = 0;
            int.TryParse(tb_ide_gru.Text.Trim(), out val);
            if (val == 0)
            {
                tb_ide_gru.Focus();
                return "El nro del Grupo Bodega debe ser numerico";
            }
            

            //Verificar Grupo de Bodega
            if (tb_ide_gru.Text.Trim()=="")
            {
                tb_ide_gru.Focus();
                return "Debe proporcionar el grupo de Bodega";
            }
 
            tabla = new DataTable();
            tabla = o_inv001.Fe_con_gru(int.Parse(tb_ide_gru.Text));
            if(tabla.Rows.Count==0)
            {
                tb_ide_gru.Focus();
                return "El Grupo de bodega no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_gru.Focus();
                return "El Grupo de bodega se encuentra Deshabilitado";
            }

            //Verificar Bodega
            if (tb_nro_bod.Text.Trim() == "")
            {
                tb_nro_bod.Focus();
                return "Debe proporcionar el nro de Bodega";
            }

            if (tb_nro_bod.Text.Trim() == "0")
            {
                tb_nro_bod.Focus();
                return "El nro de Bodega debe ser distinto de Cero (0)";
            }
            val = 0;
            int.TryParse(tb_nro_bod.Text.Trim(), out val);
            if (val == 0)
            {
                tb_nro_bod.Focus();
                return "El nro de Bodega debe ser numerico";
            }
            
            tabla = new DataTable();
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if(tabla.Rows.Count > 0)
            {
                tb_nro_bod.Focus();
                return "La Bodega que desea crear ya se encuentra registrada";
            }
            if (tb_des_bod.Text.Trim() == "")
            {
                tb_des_bod.Focus();
                return "Debe proporcionar el Nombre para la Bodega";
            }

            return "";
        }

        private void Fi_lim_pia()
        {
            tb_nro_bod.Text = "0";
            tb_nom_bod.Clear();
            tb_des_bod.Clear();
            tb_nom_ecg.Clear();
            tb_tlf_ecg.Clear();
            tb_dir_ecg.Clear();

            Fi_obt_cod();
            tb_nro_bod.Focus();
            
        }

        private void Fi_obt_cod()
        {
           
            int cod_bod = 0;

            

            cod_bod = int.Parse(tb_ide_gru.Text) * 1000;
            cod_bod = cod_bod + int.Parse(tb_nro_bod.Text);
            tb_cod_bod.Text = cod_bod.ToString();

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

            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva Bodega", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                string mon_inv = "";
                if (cb_mon_inv.SelectedIndex == 0)
                    mon_inv = "B";
                else
                    mon_inv = "U";

                //Registrar Bodega
                o_inv002.Fe_crea(int.Parse(tb_ide_gru.Text), int.Parse(tb_cod_bod.Text), tb_nom_bod.Text, tb_des_bod.Text,
                                 tb_dir_bod.Text, DateTime.Parse("01/01/1990"), mon_inv, "P", 
                                 tb_nom_ecg.Text, tb_tlf_ecg.Text, tb_dir_ecg.Text);

                MessageBox.Show("Los datos se grabaron correctamente", "Nueva Bodega", MessageBoxButtons.OK);
                Fi_lim_pia();
                frm_pad.Fe_act_frm(int.Parse(tb_ide_gru.Text), int.Parse(tb_cod_bod.Text));
            }
        }

        private void Bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_gru();
        }
       
        private void Tb_ide_gru_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Bodega
                Fi_abr_bus_gru();
            }

        }


        void Fi_abr_bus_gru()
        {
            inv001_01 frm = new inv001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_ide_gru.Text = frm.tb_sel_bus.Text;
                Fi_obt_gru();
            }

           
        }

       
        private void Tb_ide_gru_Validated(object sender, EventArgs e)
        {
            Fi_obt_gru();
        }

        /// <summary>
        /// Obtiene ide y nombre Bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_gru()
        {
            // Obtiene ide y nombre Bodega
            tabla = o_inv001.Fe_con_gru(int.Parse(tb_ide_gru.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nom_bod.Clear();
            }
            else
            {
                tb_ide_gru.Text = tabla.Rows[0]["va_ide_gru"].ToString();
            }

            Fi_obt_cod();
        }

        private void tb_nro_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_cod();
        }
    }
}
