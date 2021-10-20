using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();       
        DataTable Tabla = new DataTable();

        public cmr014_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();
            // Despliega Datos
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_tel_cel"].ToString();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString();
            tb_cms_con.Text = frm_dat.Rows[0]["va_cms_con"].ToString();
            tb_cms_cre.Text = frm_dat.Rows[0]["va_cms_cre"].ToString();

            if (frm_dat.Rows[0]["va_pro_ced"].ToString() == "1")
                tb_pro_ced.Text = "Interno";
            else
                tb_pro_ced.Text = "Externo";

            switch (frm_dat.Rows[0]["va_tip_cms"].ToString()) {
                case "0":
                    tb_tip_com.Text = "No Aplica";
                    break;
                case "1":
                    tb_tip_com.Text = "Ventas Generales";
                    break;
                case "2":
                    tb_tip_com.Text = "Familia Producto";
                    break;                    
                case "3":
                    tb_tip_com.Text = "Producto";
                    break;                    
            }

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_cod_ven.Text = string.Empty;
            tb_nom_ven.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_pro_ced.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_tip_com.Text = string.Empty;
            tb_cms_con.Text = string.Empty;
            tb_cms_cre.Text = string.Empty;
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
