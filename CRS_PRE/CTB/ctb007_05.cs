using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ctb007_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
      
        cmr003 o_cmr003 = new cmr003();
        cmr016 o_cmr016 = new cmr016();

        ctb006 o_ctb006 = new ctb006();
        ctb007 o_ctb007 = new ctb007();

        DataTable tabla = new DataTable();
        DataTable tab_prm = new DataTable();
     

        public ctb007_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_fac"].ToString()) - 1;

            tb_cod_act.Text = frm_dat.Rows[0]["va_cod_act"].ToString();
            Fi_obt_act();

            tb_ide_suc.Text = frm_dat.Rows[0]["va_cod_suc"].ToString();
            Fi_obt_suc();

            tb_nro_ini.Text = frm_dat.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = frm_dat.Rows[0]["va_nro_fin"].ToString();
            tb_con_tad.Text = frm_dat.Rows[0]["va_con_tad"].ToString();

            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();

            tb_cod_ley.Text = frm_dat.Rows[0]["va_cod_ley"].ToString();
            Fi_obt_ley();

            
        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        /// <summary>
        /// Obtiene ide y nombre de actividad economica para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_act()
        {
            // Obtiene ide y nombre 
            tabla = o_cmr016.Fe_con_act(tb_cod_act.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_act.Clear();
            }
            else
            {
                tb_cod_act.Text = tabla.Rows[0]["va_cod_act"].ToString();
                tb_nom_act.Text = tabla.Rows[0]["va_nom_act"].ToString();
            }
        }




        /// <summary>
        /// Obtiene ide y nombre de scursal para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_suc()
        {
            // Obtiene ide y nombre 
            tabla = o_cmr003.Fe_con_suc(tb_ide_suc.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_suc.Clear();
            }
            else
            {
                tb_ide_suc.Text = tabla.Rows[0]["va_ide_suc"].ToString();
                tb_nom_suc.Text = tabla.Rows[0]["va_nom_suc"].ToString();
            }
        }


       
        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_ley()
        {
            // Obtiene ide y nombre documento
            tabla = o_ctb006.Fe_con_ley(tb_cod_ley.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_ley.Clear();
            }
            else
            {
                tb_cod_ley.Text = tabla.Rows[0]["va_cod_ley"].ToString();
                tb_nom_ley.Text = tabla.Rows[0]["va_nom_ley"].ToString();
            }
        }

        private void tb_notNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

    }
}
