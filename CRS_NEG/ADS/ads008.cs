using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
namespace CRS_NEG
{
    /// <summary>
    /// Clase PERMISO USUARIOS SOBRE EL SISTEMA
    /// </summary>
    public class ads008
    {
        //######################################################################
        //##       Tabla: ads008_01                                           ##
        //##      Nombre: Aplicaciones                                        ##
        //## Descripcion:Permiso sobre Aplicaciones                           ##         
        //##       Autor: JEJR - (05-01-2019)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();      

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
       
       
        public ads008()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        #region "PERMISO DE USUARIO SOBRE EL SISTEMA"

        /// <summary>
        /// Obtiene las aplicaciones autorizadas al usuario P/Menu Principal
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads008_00(string ag_ide_usr)
        {
            cadena = "EXECUTE ads008_01a_p01 '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Obtiene las aplicaciones autorizadas al usuario
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads008_01(string ag_ide_usr, string ag_ide_tab)
        {
            cadena = " SELECT * FROM ads008 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_ide_tab = '" + ag_ide_tab + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre algo en especifico
        /// </summary>
        /// <param name="ag_ide_usr">ID. Usuario</param>
        /// <param name="ag_ide_tab">ID. tabla </param>
        /// <param name="ag_ide_uno">ID. uno </param>
        /// <returns></returns>
        public Boolean Fe_ads008_02(string ag_ide_usr, string ag_ide_tab, string ag_ide_uno)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads008 ";
            cadena += " WHERE va_ide_usr = '" + ag_ide_usr + "'";
            cadena += "   AND va_ide_tab = '" + ag_ide_tab + "'";
            cadena += "   AND va_ide_uno = '" + ag_ide_uno + "'";

            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul = false;
            if (tabla.Rows.Count > 0)
                resul = true;

            return resul;
        }
        /// <summary>
        /// Consulta si el usuario tiene permiso sobre algo en especifico
        /// </summary>
        /// <param name="ag_ide_usr">ID. Usuario</param>
        /// <param name="ag_ide_tab">ID. tabla </param>
        /// <param name="ag_ide_uno">ID. uno </param>
        /// <param name="ag_ide_dos">ID. dos </param>
        /// <returns></returns>
        public Boolean Fe_ads008_02(string ag_ide_usr, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads008 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_ide_tab = '" + ag_ide_tab + "'" +
                " AND va_ide_uno = '" + ag_ide_uno + "' AND va_ide_dos = '" + ag_ide_dos + "' ";
            
            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul = false;
            if (tabla.Rows.Count > 0)
                resul = true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre tabla y atributos
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads008_03(string ag_ide_usr, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos = "", string ag_ide_tre = "" )
        {
            cadena = " INSERT INTO ads008 VALUES ";
            cadena += " ('" + ag_ide_usr + "', '" + ag_ide_tab + "', '" + ag_ide_uno + "','" + ag_ide_dos + "','" + ag_ide_tre + "',0) ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre tabla
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads008_04(string ag_ide_usr, string ag_ide_tab)
        {
            cadena = " DELETE ads008 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_ide_tab = '" + ag_ide_tab + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre un atributo de la tabla
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads008_04(string ag_ide_usr, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos = "")
        {
            cadena = " DELETE ads008 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_ide_tab = '" + ag_ide_tab + "'" +
                " AND va_ide_uno ='" + ag_ide_uno + "' AND va_ide_dos = '"+ ag_ide_dos + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
