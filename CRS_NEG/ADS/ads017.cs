using CRS_DAT;
using System;
using System.Data;
namespace CRS_NEG
{
    /// <summary>
    /// Clase USUARIO
    /// </summary>
    public class ads017
    {
        //######################################################################
        //##       Tabla: ads017_01                                           ##
        //##      Nombre: PIN Usuario                                         ##
        //## Descripcion: PIN Usuario                                         ##         
        //##       Autor: CHL - (15-10-2010)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        DataTable Tabla = new DataTable();

        public ads017()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        //#region ""

        public void Fe_crea(string ar_ide_usr, int ar_pin_usr, DateTime ar_fec_reg, DateTime ar_fec_exp, string nom_eqp)
        {
            cadena = " INSERT INTO ads017 VALUES('" + ar_ide_usr + "'," + ar_pin_usr + " ," +
                " '" + ar_fec_reg.ToString("dd/MM/yyyy hh:mm") + "', '" + ar_fec_exp.ToString("dd/MM/yyyy hh:mm") + "','" + nom_eqp + "')";

            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_pin(string ar_ide_usr, int ar_pin_usr, DateTime ar_fec_reg, DateTime ar_fec_exp, string nom_eqp)
        {
            cadena = " UPDATE ads017 SET va_pin_usr = " + ar_pin_usr + " , va_fec_reg = '" + ar_fec_reg + "', va_fec_exp = '" + ar_fec_exp + "', va_nom_eqp = '" + nom_eqp + "' " +
                    " WHERE va_ide_usr = '" + ar_ide_usr + "'" ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_pin(string ar_ide_usr)
        {
            cadena = " DELETE ads017 WHERE va_ide_usr = '" + ar_ide_usr + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_pin(string ar_ide_usr)
        {
            cadena = " SELECT * FROM ads017 WHERE va_ide_usr =  '" + ar_ide_usr + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

    }
}