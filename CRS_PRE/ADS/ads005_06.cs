using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads005_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads005 o_ads005 = new ads005();
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads005_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            lb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            lb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ges_tio.Text = frm_dat.Rows[0]["va_ges_tio"].ToString();
            tb_con_act.Text = frm_dat.Rows[0]["va_con_act"].ToString();
            tb_con_fin.Text = frm_dat.Rows[0]["va_con_fin"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            lb_nom_doc.Text = string.Empty;
            tb_nro_tal.Text = string.Empty;
            lb_nom_tal.Text = string.Empty;
            tb_ges_tio.Text = string.Empty;
            tb_con_act.Text = string.Empty;
            tb_con_fin.Text = string.Empty;
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
        }

        /// <summary>
        /// Valida los datos proporcionados en Pantalla
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            // Verificar Documento
            if (tb_ide_doc.Text.Trim().CompareTo("") == 0)
                return "DEBE proporcionar el Documento";            

            // Valida que el Documento este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0)
                return "El Documento NO se encuentra registrado";            

            // Verificar el Nro. de Talonario
            if (tb_nro_tal.Text.Trim().CompareTo("") == 0)
                return "DEBE proporcionar el Nro. de Talonario";            

            // Verifica que el Nro. de Talonario sea numerico
            if (!cl_glo_bal.IsNumeric(tb_nro_tal.Text.Trim()))
                return "El Nro. de Talonario DEBE ser Numerico";            

            // Valida que el Nro. de Talonario este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count == 0)
                return "El Talonario NO se encuentra registrado";

            // Verificar el Nro. de Talonario
            if (tb_ges_tio.Text.Trim().CompareTo("") == 0)
                return "DEBE proporcionar la Gestión";

            // Verifica que el Nro. de Talonario sea numerico
            if (!cl_glo_bal.IsNumeric(tb_ges_tio.Text.Trim()))
                return "La Gestión DEBE ser Numerico";

            // Valida que la Gestión este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
            if (Tabla.Rows.Count == 0)
                return "La Gestión NO se encuentra registrado";
           
            return "OK";
        }
       
       
        // Evento Click: Button Aceptar    
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Tipo de Atributo
                    o_ads005.Fe_eli_min(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
