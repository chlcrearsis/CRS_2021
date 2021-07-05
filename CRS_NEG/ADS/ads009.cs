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
    /// Clase USUARIO
    /// </summary>
    public class ads009
    {
        //######################################################################
        //##       Tabla: ads009_01                                           ##
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
       
       
        public ads009()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        #region "PERMISO SOBRE TALONARIO"
     
        /// <summary>
        /// Obtiene Permiso sobre Talonarios
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre un talonario especifico
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_nro_tal">Nro talonario</param>
        /// <returns></returns>
        public Boolean Fe_ads009_02(string ag_ide_usr,string ag_ide_doc, int ag_nro_tal)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'AND va_ide_doc ='" + ag_ide_doc + "' AND va_nro_tal =" + ag_nro_tal;
            DataTable tabla =  ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul =  false;
            if (tabla.Rows.Count >0)
                resul= true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre Talonario
        /// </summary>
        /// <param name="ag_ide_usr">usuario</param>
        /// <param name="ag_ide_doc">ide_documento</param>
        /// <param name="ag_nro_tal">nro talonario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_03(string ag_ide_usr, string ag_ide_doc, int ag_nro_tal)
        {
            cadena = " INSERT INTO ads009 VALUES ";
            cadena += " ('" + ag_ide_usr + "','" + ag_ide_doc + "', " + ag_nro_tal + ") ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre talonario
        /// </summary>
        /// <param name="ag_ide_usr">usuario</param>
        /// <param name="ag_ide_doc">ide_documento</param>
        /// <param name="ag_nro_tal">nro talonario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_04(string ag_ide_usr, string ag_ide_doc, int ag_nro_tal)
        {
            cadena = " DELETE ads009 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_ide_doc = '" + ag_ide_doc + "' AND va_nro_tal = " + ag_nro_tal ;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion


    }
}
