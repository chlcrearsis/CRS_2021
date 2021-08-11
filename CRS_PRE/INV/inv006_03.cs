using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv006_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        inv006 o_inv006 = new inv006();

        DataTable tabla = new DataTable();


        public inv006_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_mar.Text = frm_dat.Rows[0]["va_cod_mar"].ToString();
            tb_nom_mar.Text = frm_dat.Rows[0]["va_nom_mar"].ToString();
            tb_cod_mar.Focus();
        }


        protected string Fi_val_dat()
        {
            
            if (tb_cod_mar.Text.Trim()=="")
            {
                tb_cod_mar.Focus();
                return "Debe proporcionar el codigo";
            }
 
            //Verificar 
            tabla = o_inv006.Fe_con_mar(int.Parse(tb_cod_mar.Text ));
            if(tabla.Rows.Count == 0)
            {
                tb_cod_mar.Focus();
                return "La Marca que desea Editar NO se encuentra registrada";
            }
            

            return "";
        }
 
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
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
            msg_res = MessageBox.Show("Esta seguro de Editar la informacion?", "Edita Marca", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar
                o_inv006.Fe_edi_mar(int.Parse(tb_cod_mar.Text),tb_nom_mar.Text);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_mar.Text));
                cl_glo_frm.Cerrar(this);

            }
        }
    }
}
