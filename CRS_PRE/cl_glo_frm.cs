using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    class cl_glo_frm
    {

        General ob_con_ecA = new General();
        
        public enum ventana
        {
            /// <summary>
            /// Abre formulario sin hacer nada
            /// </summary>
            nada = 0,
            /// <summary>
            /// Abre hija y bloquea la ventana anterior
            /// </summary>
            bloq = 1,
            /// <summary>
            ///  Abre hija y oculta la ventana anterior
            /// </summary>
            ocul = 2,
            /// <summary>
            /// Abre formulario y bloquea el MDI principal que lo llamo.
            /// </summary>
            modal = 3,
        }

        /// <summary>
        /// Establece si se muestra la caja de botones Aceptar/Cancelar en el formulario
        /// </summary>
        public enum ctr_btn
        {
            /// <summary>
            /// Habilita caja de botones Aceptar/Cancelar
            /// </summary>
            no = 0,
            /// <summary>
            /// Deshabilita caja de botones Aceptar/Cancelar
            /// </summary>
            si = 1
           
        }


        /// <summary>
        /// FUNCION GLOBAL: Obtiene la fecha actual del servidor///
        /// </summary>
        /// <returns></returns>
        public DateTime fg_fec_act()
        {
            return ob_con_ecA.Fe_fec_act();
        }

        public static void abrir(dynamic frm_pad, dynamic frm_hja, ventana frm_tip = 0, ctr_btn ctr_btn= 0, DataTable tab_dat = null)
        {
            //** TRATAMIENTO FORMULARIO **\\
            bool abi_ert = false;   //--> Formulario abierto
            dynamic frm_mdi;        //--> Formulario MDI principal
            DataTable frm_dat;
            
            //obtiene formulario MDI
            frm_mdi = frm_pad.TopLevelControl;
          
            // Si frm_tip = modal o frm_mdi <> formulario MDI
            // no deberia de verificar si ya se abrio la ventana anteriormente (por que se abre a peticion 
            //y no se hace otra accion hasta su cierre
            // (no hacer lo de arriba)

            //Verifica si ya está abierto.//
            foreach (Form f in frm_mdi.MdiChildren){
                //Si está abierto devuelvo False ( = no se puede abrir ).
                if (f.Name == frm_hja.Name)
                {                  
                    abi_ert = true; // Activa bandera indicando que ya esta abierta
                    frm_hja = f;    
                }
            }
            if (abi_ert == true) // Si ya esta habierto, solo lo muestra formulario hijo y pone en frente
            {
                frm_hja.BringToFront(); //Lleva al frenta
                return;
            }
            if (abi_ert == false) // De lo contrario habre nuevo formulario
            {
                
                //Pasa el formulario que origino la llamada como variable padre al nuevo formulario
                frm_hja.frm_pad = frm_pad;

                // Si frm_tip <> modal o frm_mdi = formulario MDI -> pasar a MDI padre de la ventana
                if(frm_tip != ventana.modal && frm_mdi.IsMdiContainer == true)
                    frm_hja.MdiParent = frm_mdi;

                //pasa de que forma abrira el formulario
                frm_hja.frm_tip = (int)frm_tip;

                //pasa tabla con datos en caso de tenerlo
                frm_dat = tab_dat;
                if (frm_dat != null)
                {
                    frm_hja.frm_dat = frm_dat;
                }

                //Pregunta de que forma abrira el formulario nuevo
                switch (frm_tip)
                {
                    case ventana.nada: // para formularios: Crea, Modifica, Consulta, Elimina
                        break;
                    case ventana.bloq:
                        // Elimina formularios dependientes de formulario padre primero
                        foreach (Form f in frm_mdi.MdiChildren)
                        {
                            // Cerrar ventanas hijas que frm_pad = frm_hja.frm_pad y Diferente a frm_hja
                            dynamic fx = f;
                            if (fx.frm_pad.Name == frm_pad.Name && fx.Name != frm_hja.Name)
                                f.Dispose();
                        }
                        frm_pad.Enabled = false;
                        break;
                    case ventana.ocul:
                        foreach (Form f in frm_mdi.MdiChildren)
                        {
                            // Cerrar ventanas hijas que frm_pad = frm_hja.frm_pad y Diferente a frm_hja
                            dynamic fx = f;
                            if(fx.frm_pad.Name == frm_pad.Name && fx.Name != frm_hja.Name)
                                f.Dispose();
                        }
                        frm_pad.Visible = false;
                        break;
                    case ventana.modal:
                        frm_hja.MdiParent = null;
                        //frm_hja.ShowDialog();
                        break;
                    default:
                        break;
                }

                //Establece si Habilita o no la caja de botones Aceptar/Cancelar
                switch (ctr_btn)
                {
                    case ctr_btn.si:
                        frm_hja.gb_ctr_btn.Enabled = true;
                        break;
                    case ctr_btn.no:
                        //frm_hja.gb_ctr_btn.Enabled = false;
                        break;
                  
                    default:
                        break;
                }
                if (frm_hja.MdiParent == null)
                {
                    frm_hja.BringToFront();
                    frm_hja.ShowDialog();
                }
                    
                else
                {
                    frm_hja.Show();
                    frm_hja.BringToFront();

                    frm_mdi.m_mod_ulo.Visible = false;
                    frm_mdi.m_frm_hja.Visible = true;
                }

            }

            ////Pregunta que tipo de form abrira
            //frm_mdi.m_mod_ulo.Visible = false;
            //frm_mdi.m_frm_hja.Visible = true;
            //switch (frm_tip)
            //{
            //    case ventana.nada:
            //        //foreach (MenuStrip menu in frm_mdi.Controls)
            //        //{
            //        //    if (menu.Name == "m_" + frm_pad.Name)
            //        //    {  
            //        //    }
            //        //}
            //        //break;
            //    case ventana.bloq: // Bloquea menu del padre
            //        //foreach (MenuStrip menu in frm_mdi.Controls)
            //        //{
            //        //    if (menu.Name == "m_" + frm_pad.Name)
            //        //        menu.Enabled = false;
            //        //}
            //        break;
            //    case ventana.ocul:
            //        break;
            //    case ventana.modal:
            //        break;
            //    default:
            //        break;
            //}
        }
        
        public static void Cerrar(dynamic frm_hja)
        {
            dynamic frm_mdi = frm_hja.TopLevelControl;
            dynamic frm_pad = frm_hja.frm_pad;
            dynamic frm_tip = frm_hja.frm_tip;

            if(frm_mdi.IsMdiContainer == false)
            {
                frm_hja.Close();
                return;
            }          

            //si el formulario padre es el mismo formulario MDI
            if (frm_mdi.Name == frm_pad.Name)
            {
                frm_mdi.m_mod_ulo.Visible = true;
                frm_mdi.m_frm_hja.Visible = false;

                foreach (dynamic frm_aux in frm_mdi.MdiChildren)
                {
                    frm_aux.Close();
                }
            }
            else
            {

                // Cierra todas las ventanas que tengan como padre a 
                foreach (dynamic frm_aux in frm_mdi.MdiChildren)
                {
                    if(frm_aux.frm_pad.Name == frm_hja.Name)
                        frm_aux.Close();
                }


                if (frm_tip == (int)ventana.bloq)
                    frm_pad.Enabled = true;
                if(frm_tip == (int)ventana.ocul)
                    frm_pad.Visible = true;

                frm_hja.Close();
            }

               

        }

        public static void Activar(dynamic frm_hja)
        {
            //Form aa;
            //Obtiene Formulario MDI contenedor
            dynamic frm_mdi = frm_hja.TopLevelControl;

            //Pregunta que tipo de form abrira
            switch (frm_hja.frm_tip)
            {
                case ventana.nada:
                  
                    break;
                case ventana.bloq: // Bloquea menu del padre
                    foreach (MenuStrip menu in frm_mdi.pn_con_mnu.Controls)
                    {
                        if (menu.Name == "m_" + frm_mdi.Name)
                            menu.Enabled = false;
                    }
                    break;
                case ventana.ocul:
                    break;
                case ventana.modal:
                    break;
                default:
                    break;
            }
            frm_hja.BringToFront();
        }




        //***************
        //CLAVE
        string clave;

        public string fg_obt_cla()
        {
            DateTime fec_srv;

            int vv_nro_dia; // numero de dia de la semana
            int vv_nro_mes; //nro del mes

            string vv_let_dia; //letra correspondiente al dia
            string vv_let_mes; //letra correspondiente al mes

            int vv_tmp_dia; //temporal del dia
            int vv_tmp_mes; //temporal del mes

            string[] vv_vec_dia = { "g", "a", "b", "c", "d", "e", "f" }; //dia ( 1=a ; 2=b ; 3=c ... ; 8=a ; 9=b ; 10=c ... 15=a ...; 28=a ...
            string[] vv_vec_mes = { "m", "h", "i", "j", "k", "l" }; //meses (enero=h ; febrero=i ; marzo=j ; abril=k ...)

            //'obtiene fecha del servidor

            fec_srv = fg_fec_act();
            //fec_srv = "14/08/2016"

            //'obtiene nro de dia de la fecha
            vv_nro_dia = fec_srv.Day;

            //obtiene nro de mes de la fecha
            vv_nro_mes = fec_srv.Month;

            //obtiene letra del dia segun fecha
            vv_tmp_dia = vv_nro_dia / 7;
            vv_tmp_dia = 7 * vv_tmp_dia;
            vv_tmp_dia = vv_nro_dia - vv_tmp_dia;

            vv_let_dia = vv_vec_dia[vv_tmp_dia];
            //obtiene letra del mes segun fecha
            vv_tmp_mes = vv_nro_mes / 6;
            vv_tmp_mes = 6 * vv_tmp_mes;
            vv_tmp_mes = vv_nro_mes - vv_tmp_mes;

            vv_let_mes = vv_vec_mes[vv_tmp_mes];

            int a; //primer digito del dia
            int b; //segundo digito del dia

            int c; //primer digito del mes
            int d; //segundo digito del mes

            if (vv_nro_dia < 10)
            {
                a = 0;
                b = vv_nro_dia;
            }
            else
            {
                string pate = Convert.ToString(vv_nro_dia);
                a = Convert.ToInt32(pate.Substring(0, 1));
                b = Convert.ToInt32(pate.Substring(1, 1));
            }

            if (vv_nro_mes < 10)
            {
                c = 0;
                d = vv_nro_mes;
            }
            else
            {
                string pate = Convert.ToString(vv_nro_mes);
                c = Convert.ToInt32(pate.Substring(0, 1));
                d = Convert.ToInt32(pate.Substring(1, 1));
            }

            int suma_dia;
            int suma_mes;
            string suma_total;

            suma_dia = a + b;

            suma_mes = c + d;

            suma_total = Convert.ToString(suma_dia + suma_mes);

            if (Convert.ToInt32(suma_total) < 10)
            {
                suma_total = "0" + suma_total;
            }


            clave = vv_let_dia + "" + b + "-" + vv_let_mes + "" + a + "-" + suma_total;

            return clave;
        }

    }
}
