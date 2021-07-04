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
using CRS_NEG.ADS;
using CRS_NEG;

namespace CRS_PRE.ADS
{
    public partial class ads004_02b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_ads003 o_ads003 = new c_ads003();
        c_ads004 o_ads004 = new c_ads004();
        c_ads001 o_ads001 = new c_ads001();
        c_ads016 o_ads016 = new c_ads016();

        DataTable tabla = new DataTable();


        public ads004_02b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // obtiene Gestiones
            cb_ges_tio.DataSource = o_ads016.Fe_obt_ges();
            cb_ges_tio.ValueMember = "va_ges_tio";
            cb_ges_tio.DisplayMember = "va_ges_tio";

            cb_tip_tal.SelectedIndex = 0;
            cb_for_log.SelectedIndex = 0;
            cb_anu_mes.SelectedIndex = 0;
            cb_ges_tio.SelectedIndex = 0;

            tb_for_mat.Text = "0";
            tb_nro_cop.Text = "0";

            tb_ide_doc.Focus();
           
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

        private void Cb_ini_ses_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
            
        }

        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            int val = 0;

            //Verificar Documento
            if (tb_ide_doc.Text.Trim()=="")
            {
                tb_ide_doc.Focus();
                return "Debe proporcionar el Documento";
            }
 
            tabla = new DataTable();
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if(tabla.Rows.Count==0)
            {
                tb_ide_doc.Focus();
                return "El Documento no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_doc.Focus();
                return "El Documento se encuentra Deshabilitado";
            }

            //Verificar Talonario
            if (tb_nro_tal.Text.Trim() == "")
            {
                tb_nro_tal.Focus();
                return "Debe proporcionar el nro de talonario";
            }

            val = 0;
            if (tb_nro_tal.Text.Trim() != "0")
            {
                int.TryParse(tb_nro_tal.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_nro_tal.Focus();
                    return "El nro de talonario debe ser numerico";
                }
            }

            tabla = new DataTable();
            tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if(tabla.Rows.Count > 0)
            {
                tb_nro_tal.Focus();
                return "El Talonario que desea crear ya se encuentra registrado";
            }
            if (tb_nom_tal.Text.Trim() == "")
            {
                tb_nom_tal.Focus();
                return "Debe proporcionar el Nombre para el Talonario";
            }

            // Verifica Formato
            if (tb_for_mat.Text.Trim() == "")
            {
                tb_for_mat.Focus();
                return "Debe proporcionar el nro de formato";
            }

            val = 0;
            if(tb_for_mat.Text.Trim() != "0")
            { 
                int.TryParse(tb_for_mat.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_for_mat.Focus();
                    return "El nro de formato debe ser numerico";
                }
            }
            // Verifica Nro de Copias
            if (tb_nro_cop.Text.Trim() == "")
            {
                tb_nro_cop.Focus();
                return "Debe proporcionar el nro de copia(s)";
            }

            val = 0;
            if (tb_nro_cop.Text.Trim() != "0")
            {
                int.TryParse(tb_nro_cop.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_nro_cop.Focus();
                    return "El nro de copia(s) debe ser numerico";
                }
            }
            return "";
        }

        private void Fi_lim_pia()
        {
            tb_nro_tal.Focus();
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
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Talonario y Numeración", MessageBoxButtons.OKCancel);
                    if (msg_res == DialogResult.OK)
                {
                    //Registrar Talonario
                    o_ads004.Fe_cre_tal_num(tb_ide_doc.Text,int.Parse(tb_nro_tal.Text),tb_nom_tal.Text,cb_tip_tal.SelectedIndex,
                        0,int.Parse(tb_for_mat.Text), int.Parse(tb_nro_cop.Text),
                        tb_fir_ma1.Text,tb_fir_ma2.Text,tb_fir_ma3.Text, tb_fir_ma4.Text, cb_for_log.SelectedIndex,
                        int.Parse(cb_ges_tio.Text), cb_anu_mes.SelectedIndex);

                    MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Talonario y Numeración", MessageBoxButtons.OK);
                    Fi_lim_pia();
                    frm_pad.Fe_act_frm(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_doc();
        }
        private void Tb_ide_doc_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_doc();
            }
                
        }

        void Fi_abr_bus_doc()
        {
            ads003_01 frm = new ads003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_ide_doc.Text = frm.tb_sel_bus.Text;
                Fi_obt_doc();
            }

           
        }

        private void Tb_ide_doc_Validated(object sender, EventArgs e)
        {
            Fi_obt_doc();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_doc()
        {
            // Obtiene ide y nombre documento
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_doc.Clear();
            }
            else
            {
                tb_ide_doc.Text = tabla.Rows[0]["va_ide_doc"].ToString();
                tb_nom_doc.Text = tabla.Rows[0]["va_nom_doc"].ToString();
            }
        }
    }
}
