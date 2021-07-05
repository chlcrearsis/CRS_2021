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

namespace CRS_PRE.ADS
{
    public partial class ads022_02b : Form
    {


     #region VARIABLES

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        string err_msg = "";
        DataTable tab_ads022;
        DataTable tabla;
        int vv_ban_tcm = 0;

    #endregion

        
    #region INSTANCIAS
        ads022 o_ads022 = new ads022();
        CRS_NEG.General o_glo_bal = new CRS_NEG.General();
    #endregion

      

    #region METODOS
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        DateTime Dtemp;
        public string fu_ver_dat()
        {
            decimal temp;
            if (decimal.TryParse(tb_val_tcm.Text, out temp) == false)
            {
                tb_val_tcm.Focus();
                return "Dato no valido, el T.C. debe ser numerico";
            }
            if (Convert.ToDecimal(tb_val_tcm.Text) < 0)
            {
                return "Dato no valido, el T.C. debe ser mayor a cero";
            }
            if (Convert.ToDecimal(tb_val_tcm.Text) > 10)
            {
                return "Dato no valido, el T.C. debe ser menor que 10";
            }

            DateTime Dtemp;
            if (DateTime.TryParse(tb_fec_ini.Text, out Dtemp) == false)
            {
                tb_fec_ini.Focus();
                return "La fecha es invalida";
            }
            if (DateTime.TryParse(tb_fec_fin.Text, out Dtemp) == false)
            {
                tb_fec_fin.Focus();
                return "La fecha es invalida";
            }

            if ((tb_fec_fin.Value - tb_fec_ini.Value).Days <= 0)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser menor a la fecha final";
            }

            return null;
        }

        #endregion

        #region EVENTOS
        public ads022_02b()
        {
            InitializeComponent();
        }
        private void frm_Load(object sender, EventArgs e)
        {
            tb_fec_ini.Value = o_glo_bal.Fe_fec_act();
            tb_val_tcm.Text = "0";


            tb_val_tcm.Focus();

           

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBox.Show(err_msg, "Error Nuevo T.C. Bs./UsD p/rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;

                res_msg = MessageBox.Show("¿Estas seguro de grabar los datos ?", "Nuevo T.C. Bs./UsD p/rango", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_ads022.Fe_eli_tic(tb_fec_ini.Value, tb_fec_fin.Value);
                o_ads022.Fe_reg_ran(tb_fec_ini.Value, tb_fec_fin.Value, tb_val_tcm.Text);

                DateTime aux;
                aux = Convert.ToDateTime(tb_fec_ini.Text);
                frm_pad.fu_bus_car(aux.Month.ToString(), aux.Year);

                //Selecciona el mes y el año de la fecha aux que va ser la fecha inicial
                //frm_pad.tb_val_año.Text = aux.Year.ToString();
                //frm_pad.cb_prm_bus.SelectedIndex = aux.Month - 1;

                MessageBox.Show("Operación completada exitosamente", "Nuevo T.C. Bs./UsD p/rango", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tb_val_tcm_TextChanged(object sender, EventArgs e)
        {
            if (tb_val_tcm.Text.Contains(","))
            {
                tb_val_tcm.Text = tb_val_tcm.Text.Replace(",", ".");

                //System.Media.SystemSounds.Beep.Play();

                //posiciona el cursor al final del texto
                tb_val_tcm.Select(tb_val_tcm.Text.Length, 0);
            }
        }
    #endregion



    }
}
