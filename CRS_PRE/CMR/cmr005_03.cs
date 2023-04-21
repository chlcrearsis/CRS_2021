using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr005_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        //c_cmr012 o_cmr012 = new c_cmr012();
        
        cmr005 o_cmr005 = new cmr005();
        cmr015 o_cmr015 = new cmr015();

        DataTable tabla = new DataTable();

        public cmr005_03()
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
                cb_vta_par.SelectedIndex = 0;
            if (frm_dat.Rows[0]["va_vta_par"].ToString() == "L")
                cb_vta_par.SelectedIndex = 1;
            if (frm_dat.Rows[0]["va_vta_par"].ToString() == "D")
                cb_vta_par.SelectedIndex = 2;

            if (cb_vta_par.SelectedIndex == 2)
            {
                tb_cod_del.Visible = true;
                tb_nom_del.Visible = true;
                bt_bus_del.Visible = true;
                lb_del_ive .Visible = true;
            }
            else
            {
                tb_cod_del.Visible = false;
                tb_nom_del.Visible = false;
                bt_bus_del.Visible = false;
                lb_del_ive.Visible = false;
            }
        }





        protected string Fi_val_dat()
        {
            //Verificar Grupo de Documento
            tabla = new DataTable();
            
            tabla = new DataTable();
            tabla = o_cmr005.Fe_con_vta(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text));
            if (tabla.Rows.Count == 0)
            {
                return "El docuemnto que desea modificar NO se encuentra registrado";
            }

            // Verifica delivery
            int val = 0;

            if (cb_vta_par.SelectedIndex == 2)
            {
                try
                {

                    val = int.Parse(tb_cod_del.Text);
                }
                catch (Exception)
                {
                    return "Debe proporcionar un delivery valido";
                }

                tabla = new DataTable();
                tabla = o_cmr015.Fe_con_del(val);
                if (tabla.Rows.Count == 0)
                {
                    return "El ddelivery proporcionado NO se encuentra registrado";
                }
            }

            return "";

        }



        private void Bt_bus_del_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_del();
        }

        private void Tb_ide_del_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Bodega
                Fi_abr_bus_del();
            }

        }


        void Fi_abr_bus_del()
        {
            cmr015_01 frm = new cmr015_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_del.Text = frm.tb_sel_bus.Text;
                Fi_obt_del();
            }


        }


        private void Tb_cod_del_Validated(object sender, EventArgs e)
        {
            Fi_obt_del();
        }

        /// <summary>
        /// Obtiene codigo y nombre del delivery para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_del()
        {
            // Obtiene codigo y nobre del delivery
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nom_del.Clear();
            }
            else
            {
                tb_nom_del.Text = tabla.Rows[0]["va_nom_del"].ToString();
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

            msg_res = MessageBox.Show("Esta seguro de Modificar a la venta ?", "Modifica Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                string vta_par = "";
                int cod_del = 0;

                if (cb_vta_par.SelectedIndex == 0)
                    vta_par = "M";
                if (cb_vta_par.SelectedIndex == 1)
                    vta_par = "L";
                if (cb_vta_par.SelectedIndex ==2)
                    vta_par = "D";

                if (vta_par == "D")
                    cod_del = int.Parse(tb_cod_del.Text);
                if (vta_par != "D")
                    cod_del = 0;

                //Edita Documento
                o_cmr005.Fe_edi_vta(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text), vta_par , cod_del,tb_obs_vta.Text);
                MessageBox.Show("La venta se modifico correctamente", "Modifica Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(tb_ide_vta.Text, int.Parse(tb_ges_vta.Text));
                cl_glo_frm.Cerrar(this);
            }
       
        }

        private void cb_vta_par_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cb_vta_par.SelectedIndex== 2)
            {
                tb_cod_del.Visible = true;
                tb_nom_del.Visible = true;
                bt_bus_del.Visible = true;
            }else
            {
                tb_cod_del.Visible = false;
                tb_nom_del.Visible = false;
                bt_bus_del.Visible = false;
            }
        }
    }
}
