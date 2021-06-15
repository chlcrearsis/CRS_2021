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
    /// Clase PERMISO S/LISTA DE PRECIO
    /// </summary>
    public class c_ads019
    {
        //######################################################################
        //##       Tabla: ads019_01                                           ##
        //##      Nombre: Permiso S/Lista de precio                           ##
        //## Descripcion:Permiso sobre Lista de precio                        ##         
        //##       Autor: CHL - (19-02-2021)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();      

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
       
       
        public c_ads019()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        #region "PERMISO SOBRE LISTA DE PRECIO"

        /// <summary>
        /// Obtiene Permiso sobre Plantilla de ventas
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads019_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads019 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre una  Lista de precio especifica
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_cod_lis">Cod de lista de precio </param>
        /// <returns></returns>
        public Boolean Fe_ads019_02(string ag_ide_usr, int ag_cod_lis)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads019 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_cod_lis =" + ag_cod_lis ;
            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul = false;
            if (tabla.Rows.Count > 0)
                resul = true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre Lista de precio
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads019_03(string ag_ide_usr, int ag_cod_lis)
        {
            cadena = " INSERT INTO ads019 VALUES ";
            cadena += " ('" + ag_ide_usr + "', " + ag_cod_lis + ") ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre lista de precio
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads019_04(string ag_ide_usr, int ag_cod_lis)
        {
            cadena = " DELETE ads019 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_cod_lis = " + ag_cod_lis;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
