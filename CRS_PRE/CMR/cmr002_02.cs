using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE
{
    public partial class cmr002_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr001 o_cmr001 = new cmr001();
        cmr002 o_cmr002 = new cmr002();

        inv004 o_inv004 = new inv004();


        DataTable tabla = new DataTable();
        int nro_dec = 0;

        /// <summary>
        /// Crea o Actualiza||  0 = Crea, 1= Actualiza
        /// </summary>
        int cre_act = 0; 
        public cmr002_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            lb_nom_lis.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();
            nro_dec = int.Parse(frm_dat.Rows[0]["va_nro_dec"].ToString() );
            tb_pre_cio.Text = "0";
            tb_des_max.Text = "0";
            tb_inc_max.Text = "0";

            tb_cod_pro.Focus();
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

      

        protected string Fi_val_dat()
        {
            //Verificar Lista de precio
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio NO se encuentra registrada";
            }

            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio se encuentra Deshabilitada";
            }

            //Verifica Producto
            if (tb_cod_pro.Text == "")
            {
                tb_cod_pro.Focus();
                return "Debe proporcionar el producto";
            }

            tabla = new DataTable();
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_pro.Focus();
                return "El producto no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_pro.Focus();
                return "El producto se encuentra Deshabilitado";
            }

            // Verifica que el precio no este registrado
            tabla = new DataTable();
            tabla = o_cmr002.Fe_con_pre(int.Parse(tb_nro_lis.Text),tb_cod_pro.Text);
            if (tabla.Rows.Count != 0)
            {
                //tb_cod_pro.Focus();
                cre_act = 1;
                //return "El producto Ya se encuentra registrado en la lista de precio";
            }
          

            decimal val = 0m;
            try
            {
                val = decimal.Parse(tb_pre_cio.Text);
            }
            catch (Exception)
            {
                tb_pre_cio.Focus();
                return "El precio proporcionado para el producto no es valido";
            }
            if(val <= 0m)
            {
                tb_pre_cio.Focus();
                return "El precio proporcionado para el producto debe ser mayor a cero (0)";
            }

            val = 0m;
            try
            {
                val = decimal.Parse(tb_des_max.Text);
            }
            catch (Exception)
            {
                tb_des_max.Focus();
                return "Debe proporcionar el % Maximo de descuento para el producto";
            }
            if (val < 0m || val > 50)
            {
                tb_des_max.Focus();
                return "El % Maximo de descuento para el producto debe estar entre 0 y 50";
            }


            //Verifica % Max incremento
            val = 0m;
            try
            {
                val = decimal.Parse(tb_inc_max.Text);
            }
            catch (Exception)
            {
                tb_inc_max.Focus();
                return "Debe proporcionar el % Maximo de incremento para el producto";
            }
            if (val < 0m || val > 100m)
            {
                tb_inc_max.Focus();
                return "El % Maximo de incremento para el producto debe estar entre 0 y 100";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            
            tb_cod_pro.Clear(); 
            lb_nom_pro.Text = "";
            tb_pre_cio.Text = "0";
            tb_des_max.Text = "0";
            tb_inc_max.Text = "0";

            Fi_for_dec();

            tb_cod_pro.Focus();
        }


        private void Bt_bus_pro_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_pro();
        }
        private void Tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_pro();
            }

        }

        void Fi_abr_bus_pro()
        {
            inv004_01 frm = new inv004_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_pro.Text = frm.tb_sel_ecc.Text;
                Fi_obt_pro();
            }
        }

        private void Tb_cod_pro_Validated(object sender, EventArgs e)
        {
            Fi_obt_pro();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_pro()
        {
            // Obtiene ide y nombre documento
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_pro.Text="";
            }
            else
            {
                tb_cod_pro.Text = tabla.Rows[0]["va_cod_pro"].ToString();
                lb_nom_pro.Text = tabla.Rows[0]["va_nom_pro"].ToString();
                Fi_obt_pre();
            }
        }

        /// <summary>
        /// Obtiene precio del producto si tuviese
        /// </summary>
        void Fi_obt_pre()
        {
            tabla = o_cmr002.Fe_con_pre(int.Parse(tb_nro_lis.Text), tb_cod_pro.Text);
            if(tabla.Rows.Count == 0)
            {
                tb_pre_cio.Text = "0";
                tb_des_max.Text = "0";
                tb_inc_max.Text = "0";
            }
            else
            {
                tb_pre_cio.Text = tabla.Rows[0]["va_pre_cio"].ToString();
                tb_des_max.Text = tabla.Rows[0]["va_pmx_des"].ToString();
                tb_inc_max.Text = tabla.Rows[0]["va_pmx_inc"].ToString();
                Fi_for_dec();
            }
        }

        void Fi_for_dec()
        {
            //Formatea decimales
                    tb_pre_cio.Text = decimal.Round(decimal.Parse(tb_pre_cio.Text), nro_dec).ToString();
            switch (nro_dec)
            {
                case 0:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N0");
                    break;

                case 1:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N1");
                    break;
                case 2:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N2");
                    break;
                case 3:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N3");
                    break;
                case 4:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N4");
                    break;
            }

            tb_des_max.Text = decimal.Round(decimal.Parse(tb_des_max.Text), 2).ToString();
            tb_des_max.Text = decimal.Parse(tb_des_max.Text).ToString("N2");

            tb_inc_max.Text = decimal.Round(decimal.Parse(tb_inc_max.Text), 2).ToString();
            tb_inc_max.Text = decimal.Parse(tb_inc_max.Text).ToString("N2");


            //tb_pre_cio.Text = tb_pre_cio.Text.Replace(".", ",");
            //tb_des_max.Text = tb_des_max.Text.Replace(".", ",");
            //tb_inc_max.Text = tb_des_max.Text.Replace(".", ",");


        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
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
                if (cre_act == 0)
                {
                    msg_res = MessageBox.Show("Esta seguro de crear el nuevo precio para el producto?", "Nuevo Precio", MessageBoxButtons.OKCancel);

                    //Registrar usuaprecioio
                    if (msg_res == DialogResult.OK)
                    {
                        
                        int nro_lis = int.Parse(tb_nro_lis.Text);
                        string cod_pro = tb_cod_pro.Text;
                        decimal pre_cio = decimal.Parse(tb_pre_cio.Text);
                        decimal des_max = decimal.Parse(tb_des_max.Text);
                        decimal inc_max = decimal.Parse(tb_inc_max.Text);

                        o_cmr002.Fe_crea(nro_lis, cod_pro, pre_cio, des_max, inc_max);

                        MessageBox.Show("Los datos se grabaron correctamente", "Define precio", MessageBoxButtons.OK);
                        Fi_lim_pia();
                    }
                } // insert into cmr002 values(10,'01','100.00','0.00','0.00')
                else
                {
                    msg_res = MessageBox.Show("Esta seguro de editar el precio para el producto?", "Edita Precio", MessageBoxButtons.OKCancel);

                    //Edita precio
                    if (msg_res == DialogResult.OK)
                    {
                        o_cmr002.Fe_edi_pre(int.Parse(tb_nro_lis.Text), tb_cod_pro.Text, decimal.Parse(tb_pre_cio.Text), decimal.Parse(tb_des_max.Text), decimal.Parse(tb_inc_max.Text));
                        MessageBox.Show("Los datos se grabaron correctamente", "Define precio", MessageBoxButtons.OK);
                        Fi_lim_pia();
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error precio", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void tb_pre_cio_Validated(object sender, EventArgs e)
        {
            Fi_for_dec();
        }

        private void tb_des_max_Validated(object sender, EventArgs e)
        {
            Fi_for_dec();
        }

        private void tb_inc_max_Validated(object sender, EventArgs e)
        {
            Fi_for_dec();
        }
    }
}
