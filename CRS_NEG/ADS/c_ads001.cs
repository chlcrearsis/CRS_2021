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
    /// Clase: MODULOS
    /// </summary>
    public class c_ads001
    {
        //######################################################################
        //##       Tabla: ads001                                              ##
        //##      Nombre: Modulo                                              ##
        //## Descripcion: Modulos del sistema                                 ##         
        //##       Autor: CHL - (07-11-2019)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();



        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;


        DataTable Tabla = new DataTable();
        string cadena;
        public c_ads001()
        {

            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda  = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }



        public DataTable Fe_obt_mod()
        {
            cadena = "SELECT * FROM ads001 " +
                " WHERE va_est_ado = 'V' ";
            Tabla =  ob_con_ecA.fe_exe_sql(cadena);

            return Tabla;
        }

    }
}
