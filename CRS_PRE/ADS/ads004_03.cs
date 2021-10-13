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
    public partial class ads004_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ctb007 o_ctb007 = new ctb007();

        DataTable tabla = new DataTable();

        public ads004_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            cb_tip_tal.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_tal"].ToString());
            tb_for_mat.Text = frm_dat.Rows[0]["va_for_mat"].ToString();
            tb_nro_cop.Text = frm_dat.Rows[0]["va_nro_cop"].ToString();
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();
            cb_for_log.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_for_log"].ToString());

            tb_fir_ma1.Text = frm_dat.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = frm_dat.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = frm_dat.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = frm_dat.Rows[0]["va_fir_ma4"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_nom_doc.Text.Trim()=="")
            {
                tb_nom_doc.Focus();
                return "Debe proporcionar el nombre para el Documento";
            }

            tabla = new DataTable();
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (tabla.Rows.Count == 0)
            {
                return "EL documento no se encuentra en la base de datos";
            }

            tabla = new DataTable();
            tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                return "EL Talonario No se encuentra registrado";
            }

            return "";

        }






        private void Bt_bus_dos_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_dos();
        }
       
        private void Tb_nro_aut_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_dos();
            }
        }
        void Fi_abr_bus_dos()
        {
            ctb007_01 frm = new ctb007_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_nro_aut.Text = frm.tb_sel_ecc.Text;
               
            }
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Talonario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                o_ads004.Fe_edi_tal(tb_ide_doc.Text,int.Parse(tb_nro_tal.Text),tb_nom_tal.Text,cb_tip_tal.SelectedIndex,int.Parse(tb_nro_aut.Text),
                    int.Parse(tb_for_mat.Text),int.Parse(tb_nro_cop.Text),tb_fir_ma1.Text, tb_fir_ma2.Text,
                    tb_fir_ma3.Text, tb_fir_ma4.Text, cb_for_log.SelectedIndex);
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Documento", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
                cl_glo_frm.Cerrar(this);
            }

        }

        private void tb_nro_aut_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }



    }
}
