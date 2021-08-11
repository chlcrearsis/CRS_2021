using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE.CMR
{
    public partial class res001_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        cmr012 o_cmr012 = new cmr012();
        
        res001 o_res001 = new res001();

        DataTable tabla = new DataTable();

        public res001_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            
            tb_ide_vta.Text = frm_dat.Rows[0]["va_ide_vta"].ToString();

            tb_fec_vta.Text = DateTime.Parse(frm_dat.Rows[0]["va_fec_vta"].ToString()).ToString("dd/MM/yyyy");

            tb_ges_vta.Text = frm_dat.Rows[0]["va_ges_vta"].ToString();
            tb_cod_del.Text = frm_dat.Rows[0]["va_cod_del"].ToString();
            tb_nom_del.Text = frm_dat.Rows[0]["va_nom_del"].ToString();

            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_obs_vta.Text = frm_dat.Rows[0]["va_obs_vta"].ToString();
            tb_tot_bru.Text = frm_dat.Rows[0]["va_tot_bru"].ToString();
            tb_des_cue.Text = frm_dat.Rows[0]["va_des_cue"].ToString();
            tb_tot_net.Text = frm_dat.Rows[0]["va_tot_net"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "V")
                tb_est_ado.Text = "Valido";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Anulado";

            if (frm_dat.Rows[0]["va_vta_par"].ToString() == "M")
                tb_vta_par.Text = "Mesa";
            if (frm_dat.Rows[0]["va_vta_par"].ToString() == "L")
                tb_vta_par.Text = "Llevar";
            if (frm_dat.Rows[0]["va_vta_par"].ToString() == "D")
                tb_vta_par.Text = "Delivery";
        }





        protected string Fi_val_dat()
        {
           

            //Verificar Grupo de Documento
            tabla = new DataTable();
            
            tabla = new DataTable();
            tabla = o_res001.Fe_con_vta(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text));
            if (tabla.Rows.Count == 0)
            {
                return "El docuemnto que desea anular NO se encuentra registrado";
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

            if(frm_dat.Rows[0]["va_est_ado"].ToString()== "V")
            {
                msg_res = MessageBox.Show("Esta seguro de Anular a El docuemnto?", "Anula Documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    //Edita Documento
                    o_res001.Fe_anu_vta(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text));
                    MessageBox.Show("El docuemnto se Deshabilito correctamente", "Anula Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm_pad.Fe_act_frm(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            

        }
    }
}
