using CRS_NEG;
using CRS_NEG;
using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.INV
{
    public partial class inv003_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads001 o_ads001 = new ads001();
        inv003 o_inv003 = new inv003();

        DataTable tabla = new DataTable();


        public inv003_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_fam.Focus();
            cb_tip_fam.SelectedIndex = 0;
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

        private void Cb_ini_ses_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
            
        }

        protected string Fi_val_dat()
        {

            string[] va_mat_cod;
            int va_niv_lin = 0;
            string err_msg = "";
            int val = 0;

            if (tb_cod_fam.Text.Trim()=="")
            {
                tb_cod_fam.Focus();
                return "Debe proporcionar el codigo de la Familia";
            }

            if (tb_nom_fam.Text.Trim() == "")
            {
                tb_cod_fam.Focus();
                return "Debe proporcionar el nombre de la Familia";
            }


            //int.TryParse(tb_cod_fam.Text, out val);
            //if (val == 0)
            //{
            //    tb_cod_fam.Focus();
            //    return "codigo de la Familia no es valido";
            //}

            // Verifica familia
            string val_cod = "";

            // aumentar guion 
            val_cod = (tb_cod_fam.Text.Substring(0, 2) + "-" + tb_cod_fam.Text.Substring(2, 2) + "-" + tb_cod_fam.Text.Substring(4, 2));
            //val_cod = tb_cod_fam.Text;
            va_mat_cod = val_cod.Split('-');
            // 
            if (va_mat_cod[0] == "00")
            {
                tb_cod_fam.Focus();
                err_msg = "La Familia de Producto a primer nivel debe ser diferente de \"00\"";
                return err_msg;
            }

            if ((va_mat_cod[1] == "00") && (int.Parse(va_mat_cod[2]) > 0))
            {
                tb_cod_fam.Focus();
                err_msg = "La Familia de Producto a segundo nivel no puede ser \"00\"";
                return err_msg;
            }

            // identificar el nivel de la familia de productos a crear'
            for (int i = 0; (i <= (va_mat_cod.Length - 1)); i++)
            {
                if (int.Parse(va_mat_cod[i]) > 0)
                {
                    va_niv_lin++;
                }
            }

            //  Identifica el nivel de la familia
            // Verificar que el tipo de la familia sea coherente con el nivel a crear
            switch (va_niv_lin)
            {
                case 1:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fam.SelectedIndex != 0)
                    {
                        err_msg = "La familia de producto debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia no existe
                    tabla = o_inv003.Fe_con_fam( tb_cod_fam.Text);
                    if (tabla.Rows.Count != 0)
                    {
                        err_msg = "La familia de producto ya se encuentra registrada";
                        return err_msg;
                    }

                    break;
                case 2:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fam.SelectedIndex != 0)
                    {
                        err_msg = "La familia de producto debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia al primer nivel si existe
                    tabla = o_inv003.Fe_con_fam(va_mat_cod[0]+"0000");
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto a primer nivel no se encuentra registrada.";
                        return err_msg;
                    }

                    if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        err_msg = "La familia de producto a primer nivel se encuentra Deshabilitada.";
                        return err_msg;
                    }

                    // verifica que la familia al segundo nivel no existe
                    tabla = o_inv003.Fe_con_fam((va_mat_cod[0] + va_mat_cod[1]) + "00");
                    if (tabla.Rows.Count != 0)
                    {
                        err_msg = "La familia de producto ya se encuentra registrada.";
                        return err_msg;
                    }

                    break;
                case 3:
                    // verifica que el tipo sea matriz
                    if (cb_tip_fam.SelectedIndex == 0)
                    {
                        err_msg = "La familia de producto no debe ser matriz.";
                        return err_msg;
                    }

                    // verifica que la familia al primer nivel si existe
                    tabla = o_inv003.Fe_con_fam(va_mat_cod[0] + "0000");
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto a primer nivel no se encuentra registrada.";
                        return err_msg;
                    }
                    if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        err_msg = "La familia de producto a primer nivel se encuentra Deshabilitada.";
                        return err_msg;
                    }

                    // verifica que la familia al segundo nivel si existe
                    tabla = o_inv003.Fe_con_fam((va_mat_cod[0] + va_mat_cod[1]) + "00");
                    if (tabla.Rows.Count == 0)
                    {
                        err_msg = "La familia de producto al segundo nivel no se encuentra registrada.";
                        return err_msg;
                    }
                    if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        err_msg = "La familia de producto a segundo nivel se encuentra Deshabilitada.";
                        return err_msg;
                    }

                    // verifica que la familia al tercer nivel no existe
                    tabla = o_inv003.Fe_con_fam(va_mat_cod[0] + (va_mat_cod[1] + va_mat_cod[2]));
                    if (tabla.Rows.Count != 0)
                    {
                        err_msg = "La familia de producto se encuentra registrada.";
                        return err_msg;
                    }

                    break;
            }





            return err_msg;
        }

        private void Fi_lim_pia()
        {
            tb_cod_fam.Clear(); 
            tb_nom_fam.Clear();
          

            tb_cod_fam.Focus();
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva famamilia", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar
                string tip_fam = "";

                if (cb_tip_fam.SelectedIndex == 0)
                    tip_fam = "M";
                if (cb_tip_fam.SelectedIndex == 1)
                    tip_fam = "D";
                if (cb_tip_fam.SelectedIndex == 2)
                    tip_fam = "S";
                if (cb_tip_fam.SelectedIndex == 3)
                    tip_fam = "C";


                o_inv003.Fe_crea(tb_cod_fam.Text, tb_nom_fam.Text,tip_fam ,"H");
                frm_pad.Fe_act_frm(tb_cod_fam.Text);
                Fi_lim_pia();
            }

        }
    }
}
