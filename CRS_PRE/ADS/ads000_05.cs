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
    public partial class ads000_05 : Form
    {
        ads013 o_ads013 = new ads013();
        General o_general = new General();
        DataTable Tabla = new DataTable();
        string Titulo = "Licencia Sistema";

        public ads000_05()
        {
            InitializeComponent();
        }

        // Limpia los campos de la pantalla
        private void fi_lim_cam() {
            lb_nom_equ.Text = string.Empty;
            tb_mom_ser.Text = string.Empty;
            tb_nom_bda.Text = string.Empty;
            tb_nro_usr.Text = string.Empty;
            tb_fec_exp.Text = string.Empty;
            cb_lic_adm.Checked = false;
            cb_lic_inv.Checked = false;
            cb_lic_com.Checked = false;
            cb_lic_res.Checked = false;
        }

        private bool fi_val_dat() {            
            DateTime fec_act = o_general.Fe_fec_act();
              string fec_exp = tb_fec_exp.Text;
              string nro_usr = tb_nro_usr.Text;

            // Valida los datos del Nro. de Usuario
            if (nro_usr.CompareTo("") == 0){
                MessageBox.Show("DEBE establecer el Nro. de Usuario Concurrentes que ingresaran al sistema", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Int32.Parse(nro_usr) <= 0) {
                MessageBox.Show("El Nro. de Usuario tiene que ser mayor a cero", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // Valida la fecha limite de expiración
            if (tb_fec_exp.Text.CompareTo("  /  /") == 0){
                MessageBox.Show("Tiene que establecer datos en la fecha Límite", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Parse(fec_exp) <= fec_act) {
                MessageBox.Show("La fecha Límite tiene que ser MAYOR a la fecha actual", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ads000_05_Load(object sender, EventArgs e)
        {
            try { 
                // Limpia los campos
                fi_lim_cam();

                // Despliega el nombre del Equipo
                lb_nom_equ.Text = SystemInformation.ComputerName;

                // Lee datos de la licencia
                Tabla = new DataTable();
                Tabla = o_ads013.Fe_obt_lic();
                if (Tabla.Rows.Count > 0) {
                    tb_mom_ser.Text = Tabla.Rows[0]["va_nom_ser"].ToString().Trim();
                    tb_nom_bda.Text = Tabla.Rows[0]["va_nom_bda"].ToString().Trim();
                    tb_nro_usr.Text = Tabla.Rows[0]["va_nro_usr"].ToString().Trim();
                    tb_fec_exp.Text = Tabla.Rows[0]["va_fec_exp"].ToString().Trim();

                    if (Tabla.Rows[0]["va_mod_adm"].ToString() == "S") {
                        cb_lic_adm.Checked = true;
                    }

                    if (Tabla.Rows[0]["va_mod_inv"].ToString() == "S")
                    {
                        cb_lic_inv.Checked = true;
                    }

                    if (Tabla.Rows[0]["va_mod_com"].ToString() == "S")
                    {
                        cb_lic_com.Checked = true;
                    }

                    if (Tabla.Rows[0]["va_mod_res"].ToString() == "S")
                    {
                        cb_lic_res.Checked = true;
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}

        private void tb_nro_usr_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string nro_usr = "";    // Nro. de Usuario
            string fec_exp = "";    // Fecha de Expiración
            string mod_adm = "";    // Modulo de ADM
            string mod_inv = "";    // Modulo de INV
            string mod_com = "";    // Modulo de COM
            string mod_res = "";    // Modulo de RES

            try
            {               
                nro_usr = tb_nro_usr.Text.ToString();
                fec_exp = tb_fec_exp.Text.ToString();
                if (cb_lic_adm.Checked == true){
                    mod_adm = "S";
                }else{
                    mod_adm = "N";
                }

                if (cb_lic_inv.Checked == true){
                    mod_inv = "S";
                }else{
                    mod_inv = "N";
                }

                if (cb_lic_com.Checked == true){
                    mod_com = "S";
                }else{
                    mod_com = "N";
                }

                if (cb_lic_res.Checked == true){
                    mod_res = "S";
                }else{
                    mod_res = "N";
                }

                if (fi_val_dat() == true){
                    if (MessageBox.Show("Está seguro de registrar la licencia?", Titulo, MessageBoxButtons.OKCancel) == DialogResult.OK){
                        o_ads013.Fe_gra_lic(Int32.Parse(nro_usr), fec_exp, mod_adm, mod_inv, mod_com, mod_res);
                        DialogResult = DialogResult.OK;
                    }
                }
            }catch (Exception ex) {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
