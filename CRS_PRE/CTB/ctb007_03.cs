using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ctb007_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
      
        cmr003 o_cmr003 = new cmr003();
        cmr016 o_cmr016 = new cmr016();

        ctb006 o_ctb006 = new ctb006();
        ctb007 o_ctb007 = new ctb007();

        DataTable tabla = new DataTable();
        DataTable tab_prm = new DataTable();
     

        public ctb007_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();
            cb_tip_fac.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_fac"].ToString()) - 1;

            tb_cod_act.Text = frm_dat.Rows[0]["va_cod_act"].ToString();
            Fi_obt_act();

            tb_ide_suc.Text = frm_dat.Rows[0]["va_cod_suc"].ToString();
            Fi_obt_suc();

            tb_nro_ini.Text = frm_dat.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = frm_dat.Rows[0]["va_nro_fin"].ToString();
            tb_con_tad.Text = frm_dat.Rows[0]["va_con_tad"].ToString();

            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();

            tb_cod_ley.Text = frm_dat.Rows[0]["va_cod_ley"].ToString();
            Fi_obt_ley();

            cb_tip_fac.Focus();
        }

        private void fi_ini_frm()
        {
            tb_nro_ini.Text = "0";
            tb_nro_fin.Text = "0";
            tb_con_tad.Text = "0";
        }

        protected string Fi_val_dat()
        {
            // Verifica campo nro autorizacion
            if (tb_nro_aut.Text.Trim() == "")
            {
                tb_nro_aut.Focus();
                return "Debe proporcionar el numero de autorización";
            }
            if (cl_glo_bal.IsDecimal(tb_nro_aut.Text)==false)
            {
                tb_nro_aut.Focus();
                return "El numero de autorización no es valido";
            }
            tabla = new DataTable();
            tabla = o_ctb007.Fe_con_sul(long.Parse(tb_nro_aut.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nro_aut.Focus();
                return "La información a cambiado, el numero de autorización no se encuentra registrado";
            }

            // Verifica actividad economica
            if (!cl_glo_bal.IsNumeric(tb_cod_act.Text.Trim()))
            {
                tb_cod_act.Focus();
                return "La Actividad económica no es valida";
            }

            if( o_cmr016.Fe_ver_exi(tb_cod_act.Text) == false)
            {
                tb_cod_act.Focus();
                return "La Actividad económica no existe";
            }


            //Verifica Sucursal
            if (tb_ide_suc.Text.Trim()=="")
            {
                tb_ide_suc.Focus();
                return "Debe proporcionar la sucursal";
            }
            
            if (!cl_glo_bal.IsNumeric(tb_ide_suc.Text.Trim()))
            {
                tb_ide_suc.Focus();
                return "La Sucursal no es valida";
            }
            tabla = new DataTable();
            tabla = o_cmr003.Fe_con_suc(tb_ide_suc.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_ide_suc.Focus();
                return "La Sucursal no se encuentra registrada";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_suc.Focus();
                return "La Sucursal se encuentra Deshabilitada";
            }


            //Verifica Leyenda
            if (tb_cod_ley.Text.Trim() == "")
            {
                tb_cod_ley.Focus();
                return "Debe proporcionar la Leyenda";
            }

            if (!cl_glo_bal.IsNumeric(tb_cod_ley.Text.Trim()))
            {
                tb_cod_ley.Focus();
                return "La Leyenda no es valida";
            }
            //tabla = new DataTable();
            if (o_ctb006.Fe_ver_exi(tb_cod_ley.Text) == false)
            {
                tb_cod_ley.Focus();
                return "La Leyenda no se encuentra registrada";
            }
           

            // Verifica numero inicial y final
            if (!cl_glo_bal.IsNumeric(tb_nro_ini.Text.Trim()))
            {
                tb_nro_ini.Focus();
                return "El numero inicial debe ser numerico";
            }
            if (!cl_glo_bal.IsNumeric(tb_nro_fin.Text.Trim()))
            {
                tb_nro_fin.Focus();
                return "El numero final debe ser numerico";
            }


            if(int.Parse(tb_nro_ini.Text) > int.Parse(tb_nro_fin.Text))
            {
                tb_nro_ini.Focus();
                return "El Numero inicial debe ser menor al numero final";
            }

            if (!cl_glo_bal.IsNumeric(tb_con_tad.Text.Trim()))
            {
                tb_con_tad.Focus();
                return "El contador debe ser numerico";
            }


            if(DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text))
            {
                tb_fec_ini.Focus();
                return "La fecha inicial debe ser mayor a la fecha final";
            }
           

            return "";
        }

        private void Fi_lim_pia()
        {
            fi_ini_frm();
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita dosificación", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                o_ctb007.Fe_edi_tar(long.Parse(tb_nro_aut.Text), cb_tip_fac.SelectedIndex + 1, int.Parse(tb_ide_suc.Text), int.Parse(tb_cod_act.Text),
                    int.Parse(tb_nro_ini.Text), int.Parse(tb_nro_fin.Text), int.Parse(tb_con_tad.Text), DateTime.Parse(tb_fec_ini.Text), DateTime.Parse(tb_fec_fin.Text),
                    int.Parse(tb_cod_ley.Text));

                //MessageBox.Show("Los datos se grabaron correctamente", "Edita dosificación", MessageBoxButtons.OK);
                
                frm_pad.Fe_act_frm(long.Parse(tb_nro_aut.Text));
                cl_glo_frm.Cerrar(this);
            }
        }







        private void Bt_bus_act_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_act();
        }
        private void Tb_cod_act_Validated(object sender, EventArgs e)
        {
            Fi_obt_act();
        }
        private void Tb_cod_act_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_act();
            }
        }
        void Fi_abr_bus_act()
        {
            cmr016_01 frm = new cmr016_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_act.Text = frm.tb_sel_bus.Text;
                Fi_obt_act();
            }
        }
        /// <summary>
        /// Obtiene ide y nombre de actividad economica para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_act()
        {
            // Obtiene ide y nombre 
            tabla = o_cmr016.Fe_con_act(tb_cod_act.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_act.Clear();
            }
            else
            {
                tb_cod_act.Text = tabla.Rows[0]["va_cod_act"].ToString();
                tb_nom_act.Text = tabla.Rows[0]["va_nom_act"].ToString();
            }
        }





        private void Bt_bus_suc_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_suc();
        }
        private void Tb_ide_suc_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_suc();
            }
        }
        private void Tb_ide_suc_Validated(object sender, EventArgs e)
        {
             Fi_obt_suc();
        }
        void Fi_abr_bus_suc()
        {
            cmr003_01 frm = new cmr003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_ide_suc.Text = frm.tb_sel_bus.Text;
                Fi_obt_suc();
            }
        }

        /// <summary>
        /// Obtiene ide y nombre de scursal para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_suc()
        {
            // Obtiene ide y nombre 
            tabla = o_cmr003.Fe_con_suc(tb_ide_suc.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_suc.Clear();
            }
            else
            {
                tb_ide_suc.Text = tabla.Rows[0]["va_ide_suc"].ToString();
                tb_nom_suc.Text = tabla.Rows[0]["va_nom_suc"].ToString();
            }
        }




        private void Bt_bus_ley_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_ley();
        }

        private void Tb_cod_ley_Validated(object sender, EventArgs e)
        {
            Fi_obt_ley();
        }
        private void Tb_cod_ley_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Talonario
                Fi_abr_bus_ley();
            }
        }
        void Fi_abr_bus_ley()
        {
          
            ctb006_01 frm = new ctb006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_ley.Text = frm.tb_sel_bus.Text;
                Fi_obt_ley();
            }
        }
       
        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_ley()
        {
            // Obtiene ide y nombre documento
            tabla = o_ctb006.Fe_con_ley(tb_cod_ley.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_ley.Clear();
            }
            else
            {
                tb_cod_ley.Text = tabla.Rows[0]["va_cod_ley"].ToString();
                tb_nom_ley.Text = tabla.Rows[0]["va_nom_ley"].ToString();
            }
        }

        private void tb_notNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

    }
}
