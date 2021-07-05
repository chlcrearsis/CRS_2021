using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;
using Microsoft.SqlServer.Types;

namespace CRS_PRE.CMR
{
    public partial class cmr013_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr013 o_cmr013 = new cmr013();
        cmr012 o_cmr012 = new cmr012();

        DataTable tabla = new DataTable();
        
        
        public cmr013_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_gru.Text = "0";
            Fi_obt_nro_per();

            tb_nit_per.Text = "0";
            tb_car_net.Text = "0";

            tb_nro_per.Focus();
        }
        
        private void Fi_obt_nro_per()
        {
            int val = 0;
            if(tb_cod_gru.Text.Trim()=="0" || tb_cod_gru.Text.Trim() == "00")
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                return;
            }

            int.TryParse(tb_cod_gru.Text, out val);
            if( val == 0)
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                return;
            }

            // Valida que el grupo exista
            tabla = new DataTable();
            tabla = o_cmr012.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if(tabla.Rows.Count == 0)
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                return;
            }
            // Obtiene ultimo numero para la persona en el grupo y le suma 1
            tb_nro_per.Text = (o_cmr013.Fe_obt_ult_nro(int.Parse(tb_cod_gru.Text)) + 1).ToString();
            Fi_obt_cod_per();

        }

        private void Fi_obt_cod_per()
        {
            int val = 0;
            if (tb_cod_gru.Text.Trim() == "0" || tb_cod_gru.Text.Trim() == "00")
            {
                
                tb_cod_per.Text = "0";
                return;
            }

            int.TryParse(tb_cod_gru.Text, out val);
            if (val == 0)
            {
                 
                tb_cod_per.Text = "0";
                return;
            }

            // Valida que el grupo exista
            tabla = new DataTable();
            tabla = o_cmr012.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                return;
            }



            val = 0;
            if (tb_nro_per.Text.Trim() == "0" || tb_nro_per.Text.Trim() == "00")
            {
                 
                tb_cod_per.Text = "0";
                return;
            }

            int.TryParse(tb_nro_per.Text, out val);
            if (val == 0)
            {
                
                tb_cod_per.Text = "0";
                return;
            }
           

            int nro_per = 0;
            nro_per = int.Parse(tb_cod_gru.Text) * 10000;
            nro_per = nro_per + int.Parse(tb_nro_per.Text);

            tb_cod_per.Text = nro_per.ToString();

        }

        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            if (tb_cod_gru.Text.Trim() == "0")
            {
                tb_cod_gru.Focus();
                return "El nro del Grupo de Persona debe ser distinto de Cero (0)";
            }
            int val = 0;
            decimal val_dec = 0;
            int.TryParse(tb_cod_gru.Text.Trim(), out val);
            if (val == 0)
            {
                tb_cod_gru.Focus();
                return "El codigo del Grupo de Persona debe ser numerico";
            }
            

            //Verificar Grupo de Persona
            tabla = new DataTable();
            tabla = o_cmr012.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if(tabla.Rows.Count==0)
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_gru.Focus();
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            //Verificar Persona
            if (tb_cod_per.Text.Trim() == "0")
            {
                tb_nro_per.Focus();
                return "Debe proporcionar el codigo de Persona";
            }

            tabla = new DataTable();
            tabla = o_cmr013.Fe_con_per(int.Parse(tb_cod_per.Text));
            if(tabla.Rows.Count > 0)
            {
                tb_nro_per.Focus();
                return "La Persona que desea crear ya se encuentra registrada";
            }
            if (tb_raz_soc.Text.Trim() == "")
            {
                tb_raz_soc.Focus();
                return "Debe proporcionar la razon social de la Persona";
            }
            if (tb_nom_com.Text.Trim() == "")
            {
                tb_nom_com.Focus();
                return "Debe proporcionar el Nombre comercial de la Persona";
            }

            // Verifica Nit
            try
            {
                val_dec = decimal.Parse(tb_nit_per.Text);
            }
            catch (Exception)
            {
                tb_nit_per.Focus();
                return "Debe proporcionar un Nit valido";
            }
            // Verifica Nit
            try
            {
                val_dec = decimal.Parse(tb_nit_per.Text);
            }
            catch (Exception)
            {
                tb_nit_per.Focus();
                return "El Nit de la Persona debe ser numerico";
            }

            //Verifica que no haya otra persona con ese nit
            if (decimal.Parse(tb_nit_per.Text.Trim()) != 0m)
            {
                tabla = new DataTable();
                tabla = o_cmr013.Fe_con_per_nit(int.Parse(tb_cod_per.Text), decimal.Parse(tb_nit_per.Text));
                if (tabla.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo Nit, desea editarla de todos modos ?", "Nueva Persona", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        tb_nit_per.Focus();
                        return "Revise el Nit por favor";
                    }
                }
            }

            // Verifica CI
            try
            {
                val = int.Parse(tb_car_net.Text);
            }
            catch (Exception)
            {
                tb_car_net.Focus();
                return "El C.I. de la Persona debe ser numerico";
            }

            //Verifica que no haya otra persona con ese CI
            if (int.Parse(tb_car_net.Text.Trim()) != 0)
            {
                tabla = new DataTable();
                tabla = o_cmr013.Fe_con_per_ci(int.Parse(tb_cod_per.Text), int.Parse(tb_car_net.Text));
                if (tabla.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo CI, desea editarla de todos modos ?", "Nueva Persona", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        tb_car_net.Focus();
                        return "Revise el CI por favor";
                    }
                }
            }

            return "";
        }

        private void Fi_lim_pia()
        {
            Fi_obt_nro_per();
            tb_raz_soc.Clear();
            tb_nom_com.Clear();
            tb_nit_per.Text = "0";
            tb_car_net.Text = "0";

            tb_dir_per.Clear();
            tb_tel_per.Clear();
            tb_cel_per.Clear();
            tb_ema_per.Clear();

            tb_raz_soc.Focus(); 
            
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

            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva Persona", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                SqlGeography ubi_per = SqlGeography.Null ;

                //Registrar Persona
                o_cmr013.Fe_crea(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_gru.Text), tb_raz_soc.Text, tb_nom_com.Text, decimal.Parse(tb_nit_per.Text),
                                 int.Parse(tb_car_net.Text), tb_dir_per.Text, tb_tel_per.Text, tb_cel_per.Text, tb_ema_per.Text, ubi_per, 1, 1);

                MessageBox.Show("Los datos se grabaron correctamente", "Nueva Persona", MessageBoxButtons.OK);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                Fi_lim_pia();
            }
        }

        private void Bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_gru();
        }
       
        private void Tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_gru();
            }

        }


        void Fi_abr_bus_gru()
        {
            cmr012_01 frm = new cmr012_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_cod_gru.Text = frm.tb_sel_bus.Text;
                Fi_obt_nro_per();
            }

           
        }

       
        private void Tb_cod_gru_Validated(object sender, EventArgs e)
        {
            Fi_obt_nro_per();
        }
     

        private void tb_nro_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_cod_per();
        }

        private void tb_raz_soc_Validated(object sender, EventArgs e)
        {
            tb_nom_com.Text = tb_raz_soc.Text;
        }
    }
}
