using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
namespace CRS_NEG.ADS
{
    /// <summary>
    /// Clase USUARIO
    /// </summary>
    public class c_ads017
    {
        //######################################################################
        //##       Tabla: ads017_01                                           ##
        //##      Nombre: Usuario                                             ##
        //## Descripcion: Inicio Sesion Usuario                               ##         
        //##       Autor: JEJR - (05-01-2019)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();      

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
       
       
        public c_ads017()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        #region "PERMISO SOBRE PLANTILLA DE VENTA"

        /// <summary>
        /// Obtiene Permiso sobre Plantilla de ventas
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads017_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads017 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre una  Plantilla especifico
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_cod_plv">Cod de plantilla </param>
        /// <returns></returns>
        public Boolean Fe_ads017_02(string ag_ide_usr, int ag_cod_plv)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads017 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_cod_plv =" + ag_cod_plv ;
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
        public DataTable Fe_ads017_03(string ag_ide_usr, int ag_cod_plv)
        {
            cadena = " INSERT INTO ads017 VALUES ";
            cadena += " ('" + ag_ide_usr + "', " + ag_cod_plv + ") ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre talonario
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads017_04(string ag_ide_usr, int ag_cod_plv)
        {
            cadena = " DELETE ads017 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_cod_plv = " + ag_cod_plv;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
