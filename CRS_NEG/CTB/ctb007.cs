using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase DOSIFICACION
    /// </summary>
    public class ctb007
    {
        //######################################################################
        //##       Tabla: cmr001                                              ##
        //##      Nombre: DOSIFICACION                                        ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (28-08-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        string DateFornat = "dd.MM.yyyy hh:mm:ss";
        string dateF = "dd.MM.yyyy";


        public ctb007()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="val_bus"></param>
        /// <param name="prm_bus"></param>
        /// <param name="va_fec_ini"></param>
        /// <param name="va_fec_fin"></param>
        /// <param name="est_bus"></param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string val_bus, DateTime va_fec_ini, DateTime va_fec_fin)
        {
            try
            {
                cadena = "";
                cadena = " execute ctb007_01a_p01 '" + val_bus + "', '" + va_fec_ini  + "', '"+ va_fec_fin + "'";

                //switch (prm_bus)
                //{
                //    case 0:
                //        cadena +=" WHERE va_nro_aut like '" + val_bus + "%' "; 
                //        break;
                //}

                //cadena +=" AND va_fec_ini BETWEEN '" + va_fec_ini.ToShortDateString() + "' AND '" + va_fec_fin.ToShortDateString() + "'";

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Registra dosificacion
        /// </summary>
        /// <param name="nro_dos">Nuemero de dosificacion</param>
        /// <param name="tip_fac">Tipo de factura 0=Computarizada ; 1=Manual</param>
        /// <param name="cod_suc">Codigo sucursal</param>
        /// <param name="cod_act">Codigo Actividad economica</param>
        /// <param name="nro_ini">Numero inicial factura</param>
        /// <param name="nro_fin">Numero final factura</param>
        /// <param name="fec_ini">Fecha inicial dosificacion</param>
        /// <param name="fec_fin">Fecha final dosificacion</param>
        /// <param name="cod_ley">Codigo de leyenda</param>
        /// <returns></returns>
        public void Fe_crea(long nro_dos, int tip_fac, int cod_suc, int cod_act, int nro_ini, int nro_fin, DateTime fec_ini, DateTime fec_fin, int cod_ley)
        {
            try
            {
                cadena = "INSERT INTO ctb007 VALUES(" + nro_dos + "," + tip_fac + ", '" + fec_ini.ToString(dateF) + "' , " +
                    "'" + fec_fin.ToString(dateF) + "' ," + nro_ini + "," + nro_fin + "," + cod_suc + "," + cod_act + "," + cod_ley + ",'', 0)";
                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Modifica dosificacion"
        /// </summary>
        /// <param name="nro_dos"></param>
        /// <param name="tip_fac"></param>
        /// <param name="cod_sucu"></param>
        /// <param name="cod_act"></param>
        /// <param name="nro_ini"></param>
        /// <param name="nro_fin"></param>
        /// <param name="fec_ini"></param>
        /// <param name="fec_fin"></param>
        /// <param name="cod_ley"></param>
        /// <returns></returns>
        public void Fe_edi_tar(long nro_dos, int tip_fac, int cod_suc, int cod_act, int nro_ini, int nro_fin, int con_tad, DateTime fec_ini, DateTime fec_fin, int cod_ley)
        {
            try
            {
                
                cadena = " UPDATE ctb007 SET va_tip_fac = " + tip_fac + ",";
                cadena += "va_fec_ini = '" + fec_ini.ToShortDateString() + "', va_fec_fin = '" + fec_fin.ToShortDateString() + "',";
                cadena += " va_nro_ini = "+ nro_ini + ", va_nro_fin = " + nro_fin + ",  va_con_tad = " + con_tad + " , " +
                         "va_cod_suc = " + cod_suc + "," + cod_act + ", va_cod_ley = " + cod_ley + " ";
                cadena += "WHERE va_nro_aut = '" + nro_dos + "'";
               

                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza llave de dosificacion
        /// </summary>
        /// <param name="nro_dos">Numero de dosificacion</param>
        /// <param name="lla_vee"></param>
        /// <returns></returns>
        public void Fe_edi_tar(long nro_dos, string lla_vee)
        {
            try
            {

                cadena = " UPDATE ctb007 SET va_lla_vee = '" + lla_vee + "' ";
                cadena += " WHERE va_nro_aut = " + nro_dos + " ";

                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_con_sul(long nro_dos)
        {
            try
            {
                cadena = " SELECT * FROM ctb007";
                cadena += " WHERE  va_nro_aut = " + nro_dos ;

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Elimina Dosificacion"
        /// </summary>
        /// <param name="nro_dos">codigo de Dosificacion</param>
        /// <returns></returns>
        public void Fe_eli_min(long nro_dos)
        {
            try
            {
                
                cadena = " DELETE ctb007 WHERE va_nro_aut ='" + nro_dos + "'";

                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
