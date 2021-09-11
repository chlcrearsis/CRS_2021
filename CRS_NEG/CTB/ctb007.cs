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
        public DataTable Fe_bus_car(string val_bus, int prm_bus, DateTime va_fec_ini, DateTime va_fec_fin, string est_bus)
        {
            try
            {
                cadena = "";
                cadena = " SELECT * FROM ctb007  ";

                switch (prm_bus)
                {
                    case 0:
                        cadena +=" WHERE va_nro_aut like '" + val_bus + "%' "; 
                        break;
                }

                cadena +=" AND va_fec_ini BETWEEN '" + va_fec_ini.ToShortDateString() + "' AND '" + va_fec_fin.ToShortDateString() + "'";

                cadena += " AND va_est_ado ='" + est_bus + "'";
               

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
                    "'" + fec_fin.ToString(dateF) + "' ," + nro_ini + "," + nro_fin + "," + cod_suc + "," + cod_act + "," + cod_ley + ",'' " + "," + "'H')";
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
        public void _03(long nro_dos, int tip_fac, int cod_sucu, int cod_act, int nro_ini, int nro_fin, DateTime fec_ini, DateTime fec_fin, int cod_ley, string lla_ve)
        {
            try
            {
                
                cadena = " EXECUTE ctb007_03p1 " + "'" + nro_dos + "'," + tip_fac + ",";
                cadena += "'" + fec_ini.ToShortDateString() + "','" + fec_fin.ToShortDateString() + "',";
                cadena += nro_ini + "," + nro_fin + "," + cod_sucu + "," + cod_act + "," + cod_ley + ",";

                switch (tip_fac)
                {
                    case 0: cadena += "'" + lla_ve + "'"; break;

                    case 1: cadena += "''"; break;
                }



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
        public void _03(long nro_dos, string lla_vee)
        {
            try
            {
                    
                cadena = " UPDATE ctb007 SET va_lla_vee = '" + lla_vee + "' ";
                cadena += " WHERE va_nro_aut = " + nro_dos + " ";
                //cadena = " EXECUTE ctb007_03ap1 " + "'" + nro_dos + "','" + lla_vee + "'");

                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Habilita/Deshabilita Dosificacion"
        /// </summary>
        /// <param name="nro_dos">Codigo de dosificaion</param>
        /// <param name="est_ado">Estado de dosificaion</param>
        /// <returns></returns>
        public void _04(long nro_dos, string est_ado)
        {
            try
            {
                
                //cadena = " UPDATE ctb007 SET ");
                //cadena = " va_est_ado='" + est_ado + "' ");
                //cadena = " WHERE  va_nro_aut = '" + nro_dos + "'");


                switch (est_ado)
                {
                    case "H": cadena = " EXECUTE ctb007_04p1 " + "'" + nro_dos + "'"; break;

                    case "N": cadena = " EXECUTE ctb007_04p2 " + "'" + nro_dos + "'"; break;
                }

                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta dosificacion"
        /// </summary>
        /// <param name="nro_dos">Codigo de la dosificacion</param>
        /// <returns></returns>
        public DataTable _055(string proc, long nro_dos)
        {
            try
            {
               
                cadena = " EXECUTE " + proc + " '" + nro_dos + "'";


                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable _05(long nro_dos)
        {
            try
            {
                
                cadena = " SELECT ctb007.va_nro_aut, ctb007.va_cod_suc, 'Nombre sucursal' as va_nom_suc, ctb007.va_fec_ini,  " +
                    "ctb007.va_fec_fin, ctb007.va_con_tad FROM ctb007 ";
                cadena += " WHERE  ctb007.va_nro_aut = " + nro_dos ;

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
        public void _06(long nro_dos)
        {
            try
            {
                
                cadena = " EXECUTE ctb007_06p1 " + "'" + nro_dos + "'";

                 ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
