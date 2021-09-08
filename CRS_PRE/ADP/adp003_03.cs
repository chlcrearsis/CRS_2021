using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp003_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();        
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Tipo de Atributo";

        public adp003_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString().Trim();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString().Trim();
            tb_ide_atr.Text = frm_dat.Rows[0]["va_atr_def"].ToString().Trim();
            lb_nom_atr.Text = frm_dat.Rows[0]["va_nom_atr"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Función: Obtiene el Atributo p/Defecto
        void Fi_obt_atr(int ide_tip, int ide_atr)
        {
            // Obtiene datos del atributo
            Tabla = o_adp004.Fe_con_atr(ide_tip, ide_atr);
            if (Tabla.Rows.Count == 0){
                tb_ide_atr.Text = "0";
                lb_nom_atr.Text = "S/N";
            }else{
                tb_ide_atr.Text = Tabla.Rows[0]["va_ide_atr"].ToString();
                lb_nom_atr.Text = Tabla.Rows[0]["va_nom_atr"].ToString();
            }
        }

        // Función Valida datos proporcionado
        protected string Fi_val_dat()
        {
            if (tb_nom_tip.Text.Trim()==""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar el nombre para el Tipo de Atributo";
            }

            if (tb_ide_atr.Text.Trim() == ""){
                tb_ide_atr.Focus();
                return "DEBE proporcionar el Atributo p/Defecto";
            }

            Tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text));
            if (Tabla.Rows.Count == 0){
                return "EL Tipo de Atributo NO se encuentra en la base de datos";
            }

            return "";
        }

        // Función: Buscar Atributo p/Defecto
        void Fi_bus_atr(){
            adp004_07 frm = new adp004_07();
            frm.vp_ide_tip = int.Parse(tb_ide_tip.Text.ToString());
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                Fi_obt_atr(Int32.Parse(tb_ide_tip.Text), Int32.Parse(frm.tb_ide_atr.Text));
            }
        }

        // Evento KeyDown : Buscar Atributo p/Defecto
        private void tb_ide_atr_KeyDown(object sender, KeyEventArgs e){
            Fi_bus_atr();
        }

        // Evento KeyUp : Buscar Atributo p/Defecto
        private void tb_ide_atr_KeyUp(object sender, KeyEventArgs e){
            Fi_bus_atr();
        }

        // Evento Click : Buscar Atributo p/Defecto
        private void bt_bus_atr_Click(object sender, EventArgs e){
            Fi_bus_atr();
        }

        // Evento Click: Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e){
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Tipo de Atributo
                    o_adp003.Fe_edi_tip(int.Parse(tb_ide_tip.Text), tb_nom_tip.Text, int.Parse(tb_ide_atr.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Evento Click: Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e){
            cl_glo_frm.Cerrar(this);
        }
       
    }
}
