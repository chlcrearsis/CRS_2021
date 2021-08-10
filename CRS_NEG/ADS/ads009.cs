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
    /// Clase PERMISO TIPO USUARIO SOBRE EL SISTEMA
    /// </summary>
    public class ads009
    {
        //######################################################################
        //##       Tabla: ads009_01                                           ##
        //##      Nombre: Aplicaciones                                        ##
        //## Descripcion:Permiso Tipo Usuario sobre el sistema                ##         
        //##       Autor: CHL - (26-07-2021)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_tus;//= ob_con_ecA.va_ide_tus;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";


        public ads009()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_tus = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        #region "PERMISO DE TIPO USUARIO SOBRE EL SISTEMA"

        /// <summary>
        /// Obtiene Permiso sobre una tabla
        /// </summary>
        /// <param name="ag_ide_tus">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_01(string ag_ide_tus, string ag_ide_tab)
        {
            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_tus = '" + ag_ide_tus + "' AND va_ide_tab = '" + ag_ide_tab + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre algo en especifico
        /// </summary>
        /// <param name="ag_ide_tus">ID. Usuario</param>
        /// <param name="ag_ide_tab">ID. tabla </param>
        /// <param name="ag_ide_uno">ID. uno </param>
        /// <returns></returns>
        public Boolean Fe_ads009_02(string ag_ide_tus, string ag_ide_tab, string ag_ide_uno)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_tus = '" + ag_ide_tus + "' AND va_ide_tab = '" + ag_ide_tab + "'" +
                " AND va_ide_uno = '" + ag_ide_uno + "'";

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
        /// <param name="ag_ide_tus">ID. Usuario</param>
        /// <param name="ag_ide_tab">ID. tabla </param>
        /// <param name="ag_ide_uno">ID. uno </param>
        /// <param name="ag_ide_dos">ID. dos </param>
        /// <returns></returns>
        public Boolean Fe_ads009_02(string ag_ide_tus, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_tus = '" + ag_ide_tus + "' AND va_ide_tab = '" + ag_ide_tab + "'" +
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
        public DataTable Fe_ads009_03(string ag_ide_tus, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos = "", string ag_ide_tre = "")
        {
            cadena = " INSERT INTO ads009 VALUES ";
            cadena += " ('" + ag_ide_tus + "', '" + ag_ide_tab + "', '" + ag_ide_uno + "','" + ag_ide_dos + "','" + ag_ide_tre + "',0) ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre tabla
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads009_04(string ag_ide_tus, string ag_ide_tab)
        {
            cadena = " DELETE ads009 ";
            cadena += " WHERE va_ide_tus ='" + ag_ide_tus + "' AND va_ide_tab = '" + ag_ide_tab + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre un atributo de la tabla
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads009_04(string ag_ide_tus, string ag_ide_tab, string ag_ide_uno, string ag_ide_dos = "")
        {
            cadena = " DELETE ads009 ";
            cadena += " WHERE va_ide_tus ='" + ag_ide_tus + "' AND va_ide_tab = '" + ag_ide_tab + "'" +
                " AND va_ide_uno ='" + ag_ide_uno + "' AND va_ide_dos = '" + ag_ide_dos + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
