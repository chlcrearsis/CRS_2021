using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*        CAPA: PRESENTACIÓN                                          */
    /*  Aplicación: Program - Clase Global                                */
    /* Descripción: Define Variables Globales para el Sistema             */
    /*       Autor: JEJR - Crearsis             Fecha: 21-04-2023         */
    /**********************************************************************/
    static class Program
    {
        // CONSTANTES GLOBAL DATOS DE USUARIO DE CONEXION
        public static string gl_usr_sql = "crssql";
        public static string gl_pas_sql = "crssql7*";

        // VARIABLE GLOBAL DATOS DEL USUARIO LOGUEADO
        public static string gl_ide_uni = "";       // Id unico de pantalla
        public static string gl_ide_gru = "";       // Id grupo de usuario
        public static string gl_ide_usr = "";       // Id usuario
        public static string gl_nom_usr = "";       // Nombre de usuario
        public static string gl_pas_usr = "";       // Contraseña de usuario
        public static string gl_cnx_str = "";       // Cadena de coneccion 

        public static string gl_ser_bdo = "";       // Servidor de base de datos  
        public static string gl_ins_bdo = "";       // Instancia de Base de datos  
        public static string gl_nom_bdo = "";       // Base de datos    

        // VARIABLE GLOBAL PARA CONTROLAR EL NUMERO DE VENTANAS ABIERTAS
        public static int gl_nro_win = 0;
        // VARIABLE GLOBAL PARA CONTROLAR LAS NOTIFICACIONES Y SUS POSICIONES
        public static int gl_nro_not = 0;
        public static int gl_win_cer = 0;
        public static string ClientSettingsProviderServiceUri = "";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] //STAThread
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ads000_00());
        }
    }
}
