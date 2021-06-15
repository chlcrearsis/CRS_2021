using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Runtime.InteropServices;
using System.Threading;
using CRS_NEG.ADS;
using CRS_PRE.Properties;
using CRS_PRE.INV;
using CRS_PRE.CMR;

namespace CRS_PRE.ADS
{
    public partial class ads000_02 : Form
    {

        DataTable tab_ads007 = new DataTable();
        DataTable tab_ads008 = new DataTable();
        DataTable tab_ads013 = new DataTable();

        c_ads007 o_ads007 = new c_ads007();
        c_ads013 o_ads013 = new c_ads013();
        c_ads008 o_ads008 = new c_ads008();


        string nom_emp = "";
        private void mt_ads200_Click(object sender, EventArgs e)
        {
            tab_ads007 = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);//Program.gl_usr_usr);
            if (Convert.ToInt32(tab_ads007.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            fh_ads100();
        }

        //procedimiento para que la aplicación arranque desde aquí(adm000)
        [STAThread()]
        public static void fh_ads100()
        {
            //Crea el hilo del menu administrador
            Thread h_ads100 = new Thread(Fu_run_ads200);
            h_ads100.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_ads100.Start();

        }
        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA (adm000)
        public static void Fu_run_ads200()
        {
            try
            {
                Application.Run(new ads200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        //******************************************************
        //******************************************************

        private void mt_cmr200_Click(object sender, EventArgs e)
        {
            tab_ads007 = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);//Program.gl_usr_usr);
            if (Convert.ToInt32(tab_ads007.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Fh_cmr200();
        }
        //procedimiento para que la aplicación arranque desde aquí(adm000)
        [STAThread()]
        public static void Fh_cmr200()
        {
            //Crea el hilo del menu administrador
            Thread h_cmr200 = new Thread(Fu_run_cmr200);
            h_cmr200.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_cmr200.Start();

        }
        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA (adm000)
        public static void Fu_run_cmr200()
        {
            try
            {
                Application.Run(new cmr200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        //******************************************************
        //******************************************************

        private void mt_res200_Click(object sender, EventArgs e)
        {
            tab_ads007 = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);//Program.gl_usr_usr);
            if (Convert.ToInt32(tab_ads007.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Fh_res200();
        }
        //procedimiento para que la aplicación arranque desde aquí(adm000)
        [STAThread()]
        public static void Fh_res200()
        {
            //Crea el hilo del menu administrador
            Thread h_res200 = new Thread(Fu_run_res200);
            h_res200.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_res200.Start();

        }
        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA (adm000)
        public static void Fu_run_res200()
        {
            try
            {
                Application.Run(new res200());// res001_02());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }



        //******************************************************
        //******************************************************

        private void mt_inv200_Click(object sender, EventArgs e)
        {
            tab_ads007 = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);//Program.gl_usr_usr);
            if (Convert.ToInt32(tab_ads007.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Fh_inv200();
        }
        //procedimiento para que la aplicación arranque desde aquí(adm000)
        [STAThread()]
        public static void Fh_inv200()
        {
            //Crea el hilo del menu administrador
            Thread h_inv200 = new Thread(Fu_run_inv200);
            h_inv200.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_inv200.Start();

        }
        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA (adm000)
        public static void Fu_run_inv200()
        {
            try
            {
                Application.Run(new inv200()); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        //******************************************************
        //******************************************************





        public ads000_02()
        {
            InitializeComponent();
        }
        
        private void ads000_02_Load(object sender, EventArgs e)
        {
            //** INICIALIZA FORMULARIO DE CARGA INICIAL PARA REPORTES
            mt_res000_R00_Click();

            //Obtiene nombre de la empresa
            tab_ads013 = o_ads013.Fe_obt_glo(1, 4);
            nom_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();
            this.Text = this.Text + nom_emp;

            // Obtiene version del sistema
            tab_ads013 = o_ads013.Fe_obt_glo(1, 100);
            lb_nro_ver.Text = "ver " + tab_ads013.Rows[0]["va_glo_car"].ToString();

            // Obtiene Usuario logueado
            lb_ide_usr.Text = o_ads013.va_ide_usr;

            // Obtiene permisos del usuario sobre las aplicaciones
            tab_ads008 = o_ads008.Fe_ads008_01(lb_ide_usr.Text);

            // Envia a funcion que verifica aplicaciones permitidas para mostrar
            Fi_apl_per();

        }

        private void Fi_apl_per()
        {
            // Si tiene permitido aplicacion ADMINISTRADOR
            for (int i = 0; i < tab_ads008.Rows.Count; i++)
            {
                if (tab_ads008.Rows[i]["va_ide_apl"].ToString() == "ads200")
                    mn_adm_sis.Visible = true;
                if (tab_ads008.Rows[i]["va_ide_apl"].ToString() == "inv200")
                    mn_com_pra.Visible = true;
                if (tab_ads008.Rows[i]["va_ide_apl"].ToString() == "cmr200")
                    mn_com_erc.Visible = true;
                if (tab_ads008.Rows[i]["va_ide_apl"].ToString() == "res200")
                    mn_res_tau.Visible = true;
            }
            
            

        }


        //********** INICIALIZA CARGA DE FORMULARIO CRISTAL REPORT **************
        //*********** PARA QUE LUEGO NO LE TARDE MUCHO AL CLIENTE ***************

        private void mt_res000_R00_Click()
        {
            tab_ads007 = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);//Program.gl_usr_usr);
            if (Convert.ToInt32(tab_ads007.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario ya tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Crearsis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            fh_res000_R00();
        }
        //procedimiento para que la aplicación arranque desde aquí(adm000)
        [STAThread()]
        public static void fh_res000_R00()
        {
            //Crea el hilo del menu administrador
            Thread h_res000_R00 = new Thread(fu_run_res000_R00);
            h_res000_R00.SetApartmentState(ApartmentState.STA);

            //Inicia el hilo
            h_res000_R00.Start();

        }
        //ESTA ES EL METODO AL QUE LLAMA EL HILO PARA ABRIR LA VENTANA (adm000)
        public static void fu_run_res000_R00()
        {
            try
            {
                ads000_R00w frm = new ads000_R00w();
                frm.Visible = false;

                Application.Run(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        //******************************************************
        //******************************************************

    }
}
