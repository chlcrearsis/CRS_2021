using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp017_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias

        adp017 o_adp017 = new adp017();
        DataTable Tabla = new DataTable();
        string Titulo = "Consulta Relación Contacto de Persona";

        public adp017_05(){
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos en Pantalla
            Fi_lim_pia();

            // Despliega Datos
            tb_ide_rel.Text = frm_dat.Rows[0]["va_ide_rel"].ToString();
            tb_nre_hom.Text = frm_dat.Rows[0]["va_nre_hom"].ToString();
            tb_nre_muj.Text = frm_dat.Rows[0]["va_nre_muj"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            tb_nre_hom.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_rel.Text = string.Empty;
            tb_nre_hom.Text = string.Empty;
            tb_nre_muj.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }      

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }            
    }
}
