using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp006_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp002 o_adp002 = new adp002();
        adp006 o_adp006 = new adp006();
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();
        General general = new General();
        string Titulo = "Elimina Imagen Persona";

        public adp006_05(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_ide_tip.Text = string.Empty;
            tb_nom_tip.Text = string.Empty;
            tb_ext_arc.Text = string.Empty;
            tb_tam_arc.Text = string.Empty;
            tb_tam_kbs.Text = string.Empty;
            tb_ide_usr.Text = string.Empty;
            tb_fec_reg.Text = string.Empty;
            tb_hor_reg.Text = string.Empty;
            tb_nom_equ.Text = string.Empty;
            pb_ima_per.Image = null;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {
            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();
            tb_ext_arc.Text = frm_dat.Rows[0]["va_ext_arc"].ToString();
            tb_tam_arc.Text = frm_dat.Rows[0]["va_tam_arc"].ToString();
            tb_tam_kbs.Text = "KB";
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_fec_reg.Text = frm_dat.Rows[0]["va_fec_reg"].ToString().Substring(0, 10);
            tb_hor_reg.Text = frm_dat.Rows[0]["va_fec_reg"].ToString().Substring(11, 8);
            tb_nom_equ.Text = frm_dat.Rows[0]["va_nom_equ"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            // Despliega la Imagen del Registro Seleccionado
            Tabla = new DataTable();
            Tabla = o_adp006.Fe_con_ima(int.Parse(tb_cod_per.Text), tb_ide_tip.Text);
            if (Tabla.Rows.Count > 0)
            {
                byte[] byt_ima = new byte[0];
                byt_ima = (byte[])Tabla.Rows[0]["va_img_arc"];
                MemoryStream men_str = new MemoryStream(byt_ima);
                pb_ima_per.Image = Image.FromStream(men_str);
            }
        }      

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        
    }
}
