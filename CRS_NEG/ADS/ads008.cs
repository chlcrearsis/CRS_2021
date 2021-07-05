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
    /// Clase APLICACIONES
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

        #region "PERMISO SOBRE APLICACIONES"

        /// <summary>
        /// Obtiene Permiso sobre Plantilla de ventas
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads008_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads008 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre una  Plantilla especifico
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_ide_apl">Cod de plantilla </param>
        /// <returns></returns>
        public Boolean Fe_ads008_02(string ag_ide_usr, string ag_ide_apl)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads008 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_ide_apl = '" + ag_ide_apl + "'";
            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul = false;
            if (tabla.Rows.Count > 0)
                resul = true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre Talonario
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads008_03(string ag_ide_usr, string ag_ide_apl)
        {
            cadena = " INSERT INTO ads008 VALUES ";
            cadena += " ('" + ag_ide_usr + "', '" + ag_ide_apl + "') ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre talonario
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads008_04(string ag_ide_usr, string ag_ide_apl)
        {
            cadena = " DELETE ads008 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_ide_apl = '" + ag_ide_apl + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
