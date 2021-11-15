using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp018_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias        

        public adp018_05(){
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos en Pantalla
            Fi_lim_pia();

            // Despliega Datos
            tb_gru_emp.Text = frm_dat.Rows[0]["va_gru_emp"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_nom_fac.Text = frm_dat.Rows[0]["va_nom_fac"].ToString();
            tb_dir_ent.Text = frm_dat.Rows[0]["va_dir_ent"].ToString();

            if (frm_dat.Rows[0]["va_ruc_nit"].ToString().CompareTo("0") != 0)
                tb_ruc_nit.Text = frm_dat.Rows[0]["va_ruc_nit"].ToString();

            if (frm_dat.Rows[0]["va_ide_ban"].ToString() == "0")
                tb_ban_fac.Text = "Cliente";
            else
                tb_ban_fac.Text = "Grupo Empresarial";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";



            tb_nom_gru.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_gru_emp.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
            tb_ruc_nit.Text = string.Empty;
            tb_nom_fac.Text = string.Empty;
            tb_dir_ent.Text = string.Empty;
        }             

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
            
    }
}
