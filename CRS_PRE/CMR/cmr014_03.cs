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
    public partial class cmr014_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr014_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_ven"].ToString();
            tb_por_cms.Text = frm_dat.Rows[0]["va_por_cms"].ToString();

            cb_tip_cms.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_cms"].ToString());

            tb_nom_ven.Focus(); frm_dat.Rows[0]["va_por_cms"].ToString();
        }


      

        protected string Fi_val_dat()
        {
            //if (tb_ide_doc.Text.Trim()=="")
            //{
            //    tb_ide_doc.Focus();
            //    return "Debe proporcionar el Codigo de la Lista de Precio";
            //}

            //Verificar 
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_cod_ven.Focus();
                return "El Vendedor que desea crear ya NO se encuentra registrado";
            }
            if (tb_nom_ven.Text.Trim() == "")
            {
                tb_nom_ven.Focus();
                return "Debe proporcionar el Nombre";
            }

            double val;
            double.TryParse(tb_por_cms.Text, out val);
            if (double.Parse(tb_por_cms.Text) != 0 )
            {
                if(val==0)
                {
                    tb_por_cms.Focus();
                    return "El porcentaje es incorrecto";
                }
            }

            if (val <0 || val > 30)
            {
                tb_por_cms.Focus();
                return "El porcentaje debe estar entre 0-30";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_cod_ven.Clear(); 
            tb_nom_ven.Clear();
            //tb_des_cri.Clear();
           

            tb_cod_ven.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Vendedor", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr014.Fe_edi_ven(int.Parse(tb_cod_ven.Text), tb_nom_ven.Text, decimal.Parse(tb_por_cms.Text),cb_tip_cms.SelectedIndex);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Edita Vendedor", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
