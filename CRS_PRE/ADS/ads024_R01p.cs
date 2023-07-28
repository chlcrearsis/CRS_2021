using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads024_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        General general = new General();
        ads007 o_ads007 = new ads007();
        ads016 o_ads016 = new ads016();
        DataTable tabla = new DataTable();


        public ads024_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Declaración de Variables
            DateTime fec_fin = general.Fe_fec_act();
            DateTime fec_ini = fec_fin.AddDays(-15);

            // Desplega Información inicial
            tb_usr_ini.Text = "aaaaa";
            tb_usr_fin.Text = "zzzzz";
            lb_nus_ini.Text = "";
            lb_nus_fin.Text = "";
            tb_fec_ini.Text = fec_ini.ToString().Substring(0, 10);
            tb_fec_fin.Text = fec_fin.ToString().Substring(0, 10);
            rb_ord_fec.Checked = true;
            rb_ord_usr.Checked = false;
        }

        protected string Fi_val_dat()
        {
            try
            {
                if (tb_usr_ini.Text == ""){
                    return "Debe proporcionar el Usuario Inicial";
                }
                if (tb_usr_fin.Text == ""){
                    return "Debe proporcionar el Usuario Final";
                }
                if (tb_fec_ini.Text == "  /  /"){
                    return "Debe proporcionar la Fecha Inicial";
                }
                if (tb_fec_fin.Text == "  /  /"){
                    return "Debe proporcionar la Fecha Final";
                }
                if (DateTime.Parse(tb_fec_fin.Text) < DateTime.Parse(tb_fec_ini.Text)){
                    return "La fecha Final tiene que ser MAYOR a la fecha inicial";
                }
                if (rb_ord_fec.Checked == false && rb_ord_usr.Checked == false) {
                    return "Tiene que establecer un tipo de ordenamiento para general el informe";
                }

                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }
      
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            //Registrar usuario
            /*tabla = new DataTable();
            tabla = o_ads016.Fe_ads016_R01(int.Parse(tb_ges_tio.Text));
            ads016_R01w frm = new ads016_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);*/
        }

        /// <summary>
        /// Obtiene ide y nombre del usuario
        /// </summary>
        void Fi_obt_usr(int ini_fin, string ide_usr)
        {
            // Obtiene ide y nombre del usuario
            tabla = o_ads007.Fe_con_ide(ide_usr);
            if (tabla.Rows.Count == 0)
            {
                if (ini_fin == 1)
                    lb_nus_ini.Text = "";
                else
                    lb_nus_fin.Text = "";
            }
            else
            {
                if (ini_fin == 1){
                    lb_nus_ini.Text = tabla.Rows[0]["va_nom_usr"].ToString();
                }else{
                    lb_nus_fin.Text = tabla.Rows[0]["va_nom_usr"].ToString();
                }

            }
        }

        private void bt_usr_ini_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_usr(1);
        }

        private void bt_usr_fin_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_usr(2);
        }


        void Fi_abr_bus_usr(int ini_fin)
        {
            ads007_01 frm = new ads007_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (ini_fin == 1)
                {
                    tb_usr_ini.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(1, tb_usr_ini.Text);
                }
                else
                {
                    tb_usr_fin.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(2, tb_usr_fin.Text);
                }
            }
        }

        private void tb_usr_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_abr_bus_usr(1);
            }
        }

        private void tb_usr_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_abr_bus_usr(2);
            }
        }

        
    }
}
