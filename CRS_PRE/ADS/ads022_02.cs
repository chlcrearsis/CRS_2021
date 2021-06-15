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
using CRS_NEG.ADS;

namespace CRS_PRE.ADS
{
    public partial class ads022_02 : Form
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
        c_ads022 o_ads022 = new c_ads022();
        CRS_NEG.General o_glo_bal = new CRS_NEG.General();
    #endregion

      

    #region METODOS
        /// <summary>
        /// Funcion que verifica los datos antes de grabar
        /// </summary>
        DateTime Dtemp;
        public string fu_ver_dat()
        {
            if (DateTime.TryParse(tb_fec_tcm.Text, out Dtemp) == false)
            {
                tb_fec_tcm.Focus();
                return "La fecha es invalida";
            }

            decimal temp;
            if (decimal.TryParse(tb_val_tcm.Text, out temp) == false)
            {
                tb_val_tcm.Focus();
                return "Dato no valido, el T.C. debe ser numerico";
            }

            if (Convert.ToDecimal(tb_val_tcm.Text) <= 0 || Convert.ToDecimal(tb_val_tcm.Text) > 10)
            {
                return "Dato no valido, el T.C. debe ser menor que 10";
            }

            tab_ads022 = o_ads022.Fe_con_tic(tb_fec_tcm.Text);
            if (tab_ads022.Rows.Count != 0)  //--** si esa fecha ya tiene valor
            {               
                vv_ban_tcm = 1;
            }
            else  //--** si esa fecha aun no tiene valor
            {                
                vv_ban_tcm = 0;
            }



            return null;
        }

        #endregion

        #region EVENTOS
        public ads022_02()
        {
            InitializeComponent();
        }


        private void frm_Load(object sender, EventArgs e)
        {
            tb_fec_tcm.Value = o_glo_bal.Fe_fec_act();

            if (frm_dat.Rows.Count != 0)
            {
                tb_fec_tcm.Value = DateTime.Parse(frm_dat.Rows[0]["va_fec_tcm"].ToString());
                tb_val_tcm.Text = frm_dat.Rows[0]["va_val_tcm"].ToString();
            }

            tb_val_tcm.Focus();

           

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                err_msg = fu_ver_dat();
                if (err_msg != null)
                {
                    MessageBox.Show(err_msg, "Error Nuevo T.C. Bs./UsD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res_msg;

                if (vv_ban_tcm == 0)
                {
                    res_msg = MessageBox.Show("¿Estas seguro de grabar los datos ?", "Nuevo T.C. Bs./UsD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res_msg = MessageBox.Show("¿La fecha ya tiene tipo de cambio asignada, esta seguro de continuar ?", "Nuevo T.C. Bs./UsD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }


                if (res_msg == DialogResult.Cancel)
                {
                    return;
                }

                //grabar datos
                o_ads022.Fe_eli_tic(tb_fec_tcm.Text);

                if (tb_val_tcm.Text != null)
                {
                    o_ads022.Fe_reg_tic(Convert.ToDateTime(tb_fec_tcm.Text), tb_val_tcm.Text);
                }
                DateTime aux;
                aux = Convert.ToDateTime(tb_fec_tcm.Text);

                frm_pad.fu_bus_car(aux.Month.ToString(), Convert.ToInt32(aux.Year));

                MessageBox.Show("Operación completada exitosamente", "Nuevo T.C. Bs./UsD", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //tb_fec_tcm.Clear();
                tb_val_tcm.Clear();
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
