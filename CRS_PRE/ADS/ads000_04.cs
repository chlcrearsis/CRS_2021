using CRS_NEG;
using System;
using System.Windows.Forms;

namespace CRS_PRE.ADS
{
    public partial class ads000_04 : Form
    {

        General ObjGeneral = new General();
     
        public ads000_04()
        {
            InitializeComponent();
        }

        private void ads000_04_Load(object sender, EventArgs e)
        {
            lb_lic_mos.Text = ObjGeneral.Fu_obt_pin();
        }

        private void tb_cla_lic_Leave(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("") == 0) {
                tb_cla_lic.Text = "Llave123.";
            }
        }

        private void tb_cla_lic_Enter(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("Llave123.") == 0)
            {
                tb_cla_lic.Text = "";
                tb_cla_lic.Focus();
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string cla_pin = ObjGeneral.Fu_obt_pin();
            if (tb_cla_lic.Text == "Llave123.") {
                MessageBox.Show("NO ha digitado ninguna clave", "Error");
            }else if (tb_cla_lic.Text == cla_pin){
                ads000_05 frm = new ads000_05();
                frm.Show();
                Close();
            }else {
                MessageBox.Show("La clave digitada es incorrecta", "Error");
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
