using CRS_NEG;
using System;
using System.Windows.Forms;

namespace CRS_PRE.ADS
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000_04 - Clave Licencia                            */
    /* Descripción: Licencia del Sistema                                  */
    /*       Autor: JEJR - Crearsis             Fecha: 23-03-2021         */
    /**********************************************************************/
    public partial class ads000_04 : Form
    {

        General ob_gen_ral = new General();
     
        public ads000_04()
        {
            InitializeComponent();
        }

        private void ads000_04_Load(object sender, EventArgs e)
        {
            lb_lic_mos.Text = ob_gen_ral.Fu_obt_pin();
        }

        // Evento Leave: Clave Licencia
        private void tb_cla_lic_Leave(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("") == 0)
                tb_cla_lic.Text = "Llave123.";            
        }

        // Evento Enter: Clave Licencia
        private void tb_cla_lic_Enter(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("Llave123.") == 0){
                tb_cla_lic.Text = "";
                tb_cla_lic.Focus();
            }
        }

        // Evento KeyPress: Clave Licencia
        private void tb_cla_lic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Enter){
                string cla_pin = ob_gen_ral.Fu_obt_pin();
                if (tb_cla_lic.Text == "Llave123."){
                    MessageBox.Show("NO ha digitado ninguna clave", "Error");
                }else if (tb_cla_lic.Text == cla_pin){
                    DialogResult = DialogResult.OK;
                }else{
                    MessageBox.Show("La clave digitada es incorrecta", "Error");
                }
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string cla_pin = ob_gen_ral.Fu_obt_pin();
            if (tb_cla_lic.Text == "Llave123.") {
                MessageBox.Show("NO ha digitado ninguna clave", "Error");
            }else if (tb_cla_lic.Text == cla_pin){
                DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("La clave digitada es incorrecta", "Error");
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }        
    }
}
