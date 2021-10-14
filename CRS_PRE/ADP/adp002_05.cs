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
    public partial class adp002_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp005 o_adp005 = new adp005();
        adp014 o_adp014 = new adp014();
        DataTable Tabla = new DataTable();

        public adp002_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los datos en Pantalla
            Fi_lim_cam();

            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString().Trim();
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString().Trim();
            lb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString().Trim();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString().Trim();
            tb_nom_fac.Text = frm_dat.Rows[0]["va_nom_fac"].ToString().Trim();
            tb_ruc_nit.Text = frm_dat.Rows[0]["va_ruc_nit"].ToString().Trim();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_bre"].ToString().Trim();
            tb_ape_pat.Text = frm_dat.Rows[0]["va_ape_pat"].ToString().Trim();
            tb_ape_mat.Text = frm_dat.Rows[0]["va_ape_mat"].ToString().Trim();
            tb_tip_doc.Text = frm_dat.Rows[0]["va_tip_doc"].ToString().Trim();
            tb_nro_doc.Text = frm_dat.Rows[0]["va_nro_doc"].ToString().Trim();
            tb_nro_doc.Text = frm_dat.Rows[0]["va_nro_doc"].ToString().Trim();
            tb_ext_doc.Text = frm_dat.Rows[0]["va_ext_doc"].ToString().Trim();
            tb_tel_per.Text = frm_dat.Rows[0]["va_tel_per"].ToString().Trim();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_cel_ula"].ToString().Trim();
            tb_tel_fij.Text = frm_dat.Rows[0]["va_tel_fij"].ToString().Trim();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString().Trim();
            tb_dir_pri.Text = frm_dat.Rows[0]["va_dir_pri"].ToString().Trim();
            tb_dir_ent.Text = frm_dat.Rows[0]["va_dir_ent"].ToString().Trim();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_ven"].ToString().Trim();
            tb_nom_cob.Text = frm_dat.Rows[0]["va_nom_cob"].ToString().Trim();

            if (frm_dat.Rows[0]["va_tip_per"].ToString() == "P")
                tb_tip_per.Text = "Particular";
            if (frm_dat.Rows[0]["va_tip_per"].ToString() == "E")
                tb_tip_per.Text = "Empresa";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            if (frm_dat.Rows[0]["va_fec_nac"].ToString() != "")
                tb_fec_nac.Text = frm_dat.Rows[0]["va_fec_nac"].ToString().Substring(0, 10);

            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "H")
                tb_sex_per.Text = "Hombre";
            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "M")
                tb_sex_per.Text = "Hombre";

            // Habilita o Deshabilita la extension del documento dependiendo de su definición
            if (tb_tip_doc.Text.CompareTo("") == 0)
            {
                Tabla = new DataTable();
                Tabla = o_adp014.Fe_con_tip(tb_tip_doc.Text);
                if (Tabla.Rows.Count > 0)
                {
                    tb_tip_doc.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                    if (Tabla.Rows[0]["va_ext_doc"].ToString().CompareTo("S") == 0)
                        tb_ext_doc.Visible = true;
                    else
                        tb_ext_doc.Visible = false;
                }
            }

            Fi_des_atr();
        }

        /// <summary>
        /// Limpia los Campos en pantalla
        /// </summary>
        private void Fi_lim_cam()
        {
            tb_cod_per.Text = string.Empty;
            tb_cod_gru.Text = string.Empty;
            tb_tip_per.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_nom_fac.Text = string.Empty;
            tb_ruc_nit.Text = string.Empty;
            tb_nom_bre.Text = string.Empty;
            tb_ape_pat.Text = string.Empty;
            tb_ape_mat.Text = string.Empty;
            tb_tip_doc.Text = string.Empty;
            tb_nro_doc.Text = string.Empty;
            tb_fec_nac.Text = string.Empty;
            tb_tel_per.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_tel_fij.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_dir_pri.Text = string.Empty;
            tb_dir_ent.Text = string.Empty;
            tb_nom_ven.Text = string.Empty;
            tb_nom_cob.Text = string.Empty;
        }

        /// <summary>
        /// Desplega Atributos de Persona
        /// </summary>
        private void Fi_des_atr()
        {
            string nom_tip;
            string nom_atr;

            dg_atr_per.Rows.Clear();

            // Obtiene definiciones de Tipo Atributos
            Tabla = new DataTable();
            Tabla = o_adp005.Fe_lis_per(int.Parse(tb_cod_per.Text));

            //Recorre del primer elemento hasta el ultimo elemento
            for (int i = 0; i < Tabla.Rows.Count; i++){
                // Obtiene Datos del Atributo Persona
                nom_tip = Tabla.Rows[i]["va_nom_tip"].ToString().Trim();
                nom_atr = Tabla.Rows[i]["va_nom_atr"].ToString().Trim();

                // Adiciona un nueva fila
                dg_atr_per.Rows.Add();

                // Carga el tipo atributo en el datagrib
                dg_atr_per.Rows[i].Cells["va_nom_tip"].Value = nom_tip;
                dg_atr_per.Rows[i].Cells["va_nom_atr"].Value = nom_atr;
            }
        }


        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
